using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.DTOs
{
    public class LoginAttemptDTO
    {
        public int LoginAttemptId { get; set; }
        public string Username { get; set; }
        public string LoginAttemptResult { get; set; }
        public string LoginMessage { get; set; }
        public DateTime LoginDate { get; set; }
    }
}
