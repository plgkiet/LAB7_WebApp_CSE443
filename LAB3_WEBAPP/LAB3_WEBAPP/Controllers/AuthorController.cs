using LAB3_WEBAPP.Data;
using LAB3_WEBAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LAB3_WEBAPP.Controllers
{
    public class AuthorController : Controller
    {
        private readonly LibraryContext _context;
        public AuthorController(LibraryContext context)
        {
            _context = context;
        }
        
        // GET: AuthorController
        public async Task<IActionResult> Index()
        {
            var authors = await _context.Authors.ToListAsync();
            return View(authors);
        }
        
           // GET: /Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("AuthorId, FirstName, LastName,CreatedDate,IsActive, Avatar")] Author author)
        {
            if (ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", error.ErrorMessage); // Gắn lỗi vào View
                }

                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(author);
        }


        // GET: /Author/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var author = await _context.Authors.FindAsync(id);
            if (author == null) return NotFound();

            return View(author);
        }

        // POST: /Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Author author)
        {
            if (id != author.AuthorId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(author);
        }

        // GET: /Author/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var author = await _context.Authors.FindAsync(id);
            if (author == null) return NotFound();

            return View(author);
        }

        // POST: /Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return NotFound();

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
