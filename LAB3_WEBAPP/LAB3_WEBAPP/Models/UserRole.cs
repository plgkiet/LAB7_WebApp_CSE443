using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace  LAB3_WEBAPP.Models
{
    [PrimaryKey("UserId", "RoleId")]
    public class UserRole
    {
        public int UserId { get; set; }
        
        [JsonIgnore] 
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }

}