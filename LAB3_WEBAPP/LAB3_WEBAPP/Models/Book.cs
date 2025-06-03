using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LAB3_WEBAPP.Models.Book
{
    public class Book
    {
        public int BookId { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; }
        
        public string? CoverImage { get; set; }

        public string? Description { get; set; }

        public string? BookCode { get; set; }

        public string? Publisher { get; set; }

        public DateTime? PublishedYear { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int? CategoryId { get; set; }
        
        [Required(ErrorMessage = "Author is required")]
        public int? AuthorId { get; set; }

        public int? TotalCopies { get; set; } = 0;

        public int? AvailableCopies { get; set; } = 0;

        public DateTime CreatedDate { get; set; }

        public string? Avatar { get; set; }

        public string? Pdf { get; set; }

        // Navigation
        public Category? Category { get; set; }

        public Author? Author { get; set; }
        
        [ValidateNever]
        [JsonIgnore]
        public ICollection<Loan> Loans { get; set; }
    

    }

}
    
