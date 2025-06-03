using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace  LAB3_WEBAPP.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }
        
        [JsonIgnore]
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}