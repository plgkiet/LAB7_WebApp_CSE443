using Microsoft.AspNetCore.Mvc;
using LAB3_WEBAPP.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using LAB3_WEBAPP.Models;
using Microsoft.AspNetCore.Authorization;


namespace LAB3_WEBAPP.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly LibraryContext _context;

        public AdminController(LibraryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var carouselsCount = _context.Carousels.Count();
            var categoriesCount = _context.Categories.Count();
            var authorsCount = _context.Authors.Count();
            var booksCount = _context.Books.Count();
            var usersCount = _context.Users.Count();
            var loansCount = _context.Loans.Count();

            var dashboardData = new DashboardViewModel
            {
                CarouselsCount = carouselsCount,
                CategoriesCount = categoriesCount,
                AuthorsCount = authorsCount,
                BooksCount = booksCount,
                UsersCount = usersCount,
                LoansCount = loansCount
            };

            return View(dashboardData);
        }

        
    }
}