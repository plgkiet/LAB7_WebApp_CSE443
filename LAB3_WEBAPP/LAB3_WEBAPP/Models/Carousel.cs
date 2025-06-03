using System.ComponentModel.DataAnnotations;

namespace LAB3_WEBAPP.Models
{
    public class Carousel
    {
        public int CarouselId { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? LinkURL { get; set; }

        [Required]
        public int Order { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}