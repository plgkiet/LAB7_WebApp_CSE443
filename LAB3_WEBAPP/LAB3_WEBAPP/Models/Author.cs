using System.ComponentModel.DataAnnotations;
using LAB3_WEBAPP.Models;
using LAB3_WEBAPP.Models.Book;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;


namespace LAB3_WEBAPP.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";


        public DateTime? DateOfBirth { get; set; }

        public string? Biography { get; set; }

        [StringLength(100)]
        public string? Nationality { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Url]
        public string? Website { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActive { get; set; }

        public string? Avatar { get; set; }
       
        
        // Navigation
        [ValidateNever]
        [JsonIgnore]
        public ICollection<Book.Book>? Books { get; set;}
    }
}

