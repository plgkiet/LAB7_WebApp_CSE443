using LAB3_WEBAPP.Models;
using LAB3_WEBAPP.Models.Book;
using System.Collections.Generic;

namespace LAB3_WEBAPP.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Book.Book> Books { get; set; }
        public List<Carousel> Carousels { get; set; }
    }
}

