using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TorqueAndTread.Server.DTOs;

namespace TorqueAndTread.Server.Models
{
    [Index(nameof(UserName),nameof(Email),IsUnique = true)]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        
        
        public List<Role> Roles { get; set; }
        public List<UserRole> UserRoles { get; set; }


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

        public User(RegisterDTO registerDTO)
        {
            this.Name = registerDTO.Name;
            this.UserName = registerDTO.UserName;
            this.Password = registerDTO.Password;
            this.Email = registerDTO.Email;
        }
        public User() { }
    }
}
