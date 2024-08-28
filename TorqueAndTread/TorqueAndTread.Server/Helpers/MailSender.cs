using System.Net;
using System.Net.Mail;

namespace TorqueAndTread.Server.Helpers
{
    public class MailSender
    {
        private static string smtpUser = "neluaccenturelu@gmail.com";
        private SmtpClient _smtpClient;
        public MailSender()
        {
            _smtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("neluaccenturelu@gmail.com", "qkxz kcfa cgzz jfxu"),
                EnableSsl = true,
            };
        }
        private string getHtmlContent()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "HTMLTemplates\\emailTemplate.html");
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Html file not found", filePath);
            }

            return  File.ReadAllText(filePath);
        }
        public void SendActivationMail(string recieverMail)
        {
            
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(smtpUser);
            mail.To.Add(recieverMail);
            mail.Subject = "Account Activation Pending";
            mail.Body = getHtmlContent();
            mail.IsBodyHtml = true;

            _smtpClient.Send(mail);
        }
        public void SendTest()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(smtpUser);
            mail.To.Add("aturcsa@gmail.com");
            mail.Subject = "Account Activation Pending";
            mail.Body = getHtmlContent();
            mail.IsBodyHtml = true;

            this._smtpClient.Send(mail);
        }
    }
}
