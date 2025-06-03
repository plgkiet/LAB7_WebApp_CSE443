using Microsoft.AspNetCore.Mvc;
using LAB3_WEBAPP.Models;
using LAB3_WEBAPP.Models.Book;
using LAB3_WEBAPP.Data;
using LAB3_WEBAPP.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LAB3_WEBAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryContext _context;

        public HomeController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var books = _context.Books.Include(b => b.Author).ToList();

            var carousels = _context.Carousels.ToList();

            var viewModel = new HomeIndexViewModel
            {
                Books = books,
                Carousels = carousels
            };

            return View(viewModel);
        }
    }
}
