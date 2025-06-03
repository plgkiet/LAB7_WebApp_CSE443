using LAB3_WEBAPP.Data;
using LAB3_WEBAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB3_WEBAPP.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly LibraryContext _context;
        public CategoriesController(LibraryContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories() => await _context.Categories.ToListAsync();
    }
}
