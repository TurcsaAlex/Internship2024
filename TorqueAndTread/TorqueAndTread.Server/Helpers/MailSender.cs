using System.Net;
using System.Net.Mail;

namespace TorqueAndTread.Server.Helpers
{
    public class MailSender
    {
        private static string smtpUser = "neluaccenturelu@gmail.com";
        private static string htmlContent = @"
            <!DOCTYPE html>
            <html>
            <head>
              <meta charset='UTF-8'>
              <title>Account Activation</title>
              <style>
                body {
                  font-family: Arial, sans-serif;
                  background-color: #f4f4f4;
                  color: #333;
                  padding: 20px;
                  text-align: center;
                }
                .container {
                  background-color: #fff;
                  padding: 20px;
                  border-radius: 8px;
                  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                  max-width: 600px;
                  margin: 0 auto;
                }
                h1 {
                  color: purple;
                }
                p {
                  font-size: 16px;
                }
              </style>
            </head>
            <body>
              <div class='container'>
                <h1>Account Activation Pending</h1>
                <p>Thank you for signing up! Your account is currently pending activation by the administrator.</p>
                <p>We appreciate your patience!</p>
                <br>
                <p>Best regards,</p>
                <p>The Support Team</p>
              </div>
            </body>
            </html>";
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

        public void SendActivationMail(string recieverMail)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(smtpUser);
            mail.To.Add(recieverMail);
            mail.Subject = "Account Activation Pending";
            mail.Body = htmlContent;
            mail.IsBodyHtml = true;

            _smtpClient.Send(mail);
        }
        public void SendTest()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(smtpUser);
            mail.To.Add("aturcsa@gmail.com");
            mail.Subject = "Account Activation Pending";
            mail.Body = htmlContent;
            mail.IsBodyHtml = true;

            this._smtpClient.Send(mail);
        }
    }
}
