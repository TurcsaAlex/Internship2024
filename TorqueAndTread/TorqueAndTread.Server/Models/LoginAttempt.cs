using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace TorqueAndTread.Server.Models
{
    public class LoginAttempt
    {
        [Key]
        public int LoginAttemptId { get; set; }
        public string Username { get; set; }
        public LoginAttemptResultEnum LoginAttemptResult { get; set; }

        public string LoginMessage{ get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public Nullable<int> UserId { get; set; }

        [Required]
        public bool Active { get; set; }
        [Required]
        [ForeignKey("CreatedById")]
        public User CreatedBy { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        [ForeignKey("LastUpdatedById")]
        public User LastUpdatedBy { get; set; }
        [Required]
        public DateTime LastUpdatedOn { get; set; }
    }
}
