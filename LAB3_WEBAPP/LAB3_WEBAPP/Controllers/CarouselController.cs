using Microsoft.AspNetCore.Mvc;
using LAB3_WEBAPP.Data;


namespace LAB3_WEBAPP.Controllers
{
    public class CarouselController : Controller
    {
        private readonly LibraryContext _context;

        public CarouselController(LibraryContext context)
        {
            _context = context;
        }
        // GET: CarouselController
        public IActionResult Index()
        {
            var carousels = _context.Carousels.ToList();
            return View(carousels);
        }

    }
}
