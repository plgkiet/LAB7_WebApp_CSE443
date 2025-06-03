using System.ComponentModel.DataAnnotations;
using LAB3_WEBAPP.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace LAB3_WEBAPP.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required, StringLength(200)]
        public string Fullname { get; set; }

        public string? Description { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string? Password { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string Address { get; set; }

        public int? Status { get; set; } = 0;

        public DateTime CreatedDate { get; set; }

        public string? UserCode { get; set; }

        public bool? IsLocked { get; set; } = false;

        public bool? IsDeleted { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public string? ActiveCode { get; set; }

        public string? Avatar { get; set; }
        
        public ICollection<UserRole> UserRoles { get; set; }
        public User()
        {
            UserRoles = new List<UserRole>();
        }

        // Navigation
        [ValidateNever]
        [JsonIgnore]
        public ICollection<Loan> Loans { get; set; }
    }
  
}
