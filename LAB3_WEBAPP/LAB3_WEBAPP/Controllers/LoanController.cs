using LAB3_WEBAPP.Data;
using LAB3_WEBAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LAB3_WEBAPP.Controllers
{
    public class LoanController : Controller
    {
        private readonly LibraryContext _context;

        public LoanController(LibraryContext context)
        {
            _context = context;
        }
        
        // GET:
        public async Task<IActionResult> Index()
        {
            var loans = await _context.Loans.Include(b => b.User)
                .Include(b => b.Book).ToListAsync();
            return View(loans);
        }
        
          // GET: /Loans/Create
        public IActionResult Create()
        {
            ViewBag.Users = new SelectList(_context.Users, "UserId", "Fullname");
            ViewBag.Books = new SelectList(_context.Books, "BookId", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("LoanId,UserId,BookId,Status")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", error.ErrorMessage); // Gắn lỗi vào View
                }
                loan.LoanDate = DateTime.Now;            
                loan.DueDate = DateTime.Now.AddDays(7);
                _context.Add(loan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = new SelectList(_context.Users, "UserId", "Fullname", loan.UserId);
            ViewBag.Books = new SelectList(_context.Books, "BookId", "Title", loan.BookId);
            return View(loan);
        }


        // GET: /Loans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var loan = await _context.Loans.FindAsync(id);
            if (loan == null) return NotFound();
            ViewBag.Users = new SelectList(_context.Users, "UserId", "Fullname");
            ViewBag.Books = new SelectList(_context.Books, "BookId", "Title");
            return View(loan);
        }

        // POST: /Loans/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Loan loan)
        {
            if (id != loan.LoanId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(loan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = new SelectList(_context.Users, "UserId", "Fullname", loan.UserId);
            ViewBag.Books = new SelectList(_context.Books, "BookId", "Title", loan.BookId);
            return View(loan);
        }

        // GET: /Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var loan = await _context.Loans.FindAsync(id);
            if (loan == null) return NotFound();

            return View(loan);
        }

        // POST: /Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null) return NotFound();

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}
