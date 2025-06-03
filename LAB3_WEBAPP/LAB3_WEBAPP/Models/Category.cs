using System.ComponentModel.DataAnnotations;
using LAB3_WEBAPP.Models;
using LAB3_WEBAPP.Models.Book;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;


namespace LAB3_WEBAPP.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool IsActive { get; set; }

        public string? Avatar { get; set; }
        
        // Navigation
        [ValidateNever]
        [JsonIgnore]
        public ICollection<Book.Book>? Books { get; set;}
    }
}