using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TorqueAndTread.Server.Models;

namespace TorqueAndTread.Server.DTOs
{
    public class UserAbvrDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string ProfilePicturePath { get; set; }

        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public UserAbvrDTO()
        {

        }
        public UserAbvrDTO(User user)
        {
            UserId = user.UserId;
            Name = user.Name;
            UserName = user.UserName;
            Email = user.Email;
            CreatedOn = user.CreatedOn;
            LastUpdatedOn = user.LastUpdatedOn;
            Active = user.Active;
            ProfilePicturePath = user.ProfilePicturePath;
        }
    }
}

