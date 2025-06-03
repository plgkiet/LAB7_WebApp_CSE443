using Microsoft.AspNetCore.Mvc;

namespace LAB3_WEBAPP.Controllers
{
    public class BooksViewController : Controller
    {
        // GET: BooksViewController
        public ActionResult Index()
        {
            return View();
        }

    }
}
