using System.ComponentModel.DataAnnotations;
using LAB3_WEBAPP.Models.Book;

namespace LAB3_WEBAPP.Models
{
    public class Loan
    {
        public int LoanId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int BookId { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Range(0, 2)]
        public int Status { get; set; } = 0;

        // Navigation
        public User? User { get; set; }
        public Book.Book? Book { get; set; }
    }
 
}

