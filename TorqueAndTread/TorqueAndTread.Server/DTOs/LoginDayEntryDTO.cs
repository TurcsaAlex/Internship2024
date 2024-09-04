namespace TorqueAndTread.Server.DTOs
{
    public class LoginDayEntryDTO
    {
        public DateTime LoginTime { get; set; }
        //public LoginAttemptResultEnum LoginAttemptResult { get; set; }
        public int LoginAttemptNr { get; set; }
    }
}
