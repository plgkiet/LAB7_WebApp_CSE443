using Microsoft.AspNetCore.Mvc;
using LAB3_WEBAPP.Models;
using System.Collections.Generic;
using System.Linq;
using LAB3_WEBAPP.Models.Book;
using LAB3_WEBAPP.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace LAB3_WEBAPP.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryContext _context;
        private readonly IWebHostEnvironment _env;


        public BookController(LibraryContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Details(int id)
        {
            var book = _context.Books.Include(b => b.Author)
                .FirstOrDefault(b => b.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public async Task<IActionResult> SelfHelpBooks()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.Category.Name == "Self-help")
                .ToListAsync();

            return View(books);
        }

        public async Task<IActionResult> TravelBooks()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.Category.Name == "Travel")
                .ToListAsync();

            return View(books);
        }

        public async Task<IActionResult> LiteratureBooks()
        {
            var books = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.Category.Name == "Literature")
                .ToListAsync();

            return View(books);
        }
        
        [Authorize]
        public IActionResult ReadPdf(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == id);

            if (book == null || string.IsNullOrEmpty(book.Pdf))
            {
                return NotFound("Không tìm thấy sách hoặc file PDF.");
            }

            var relativePath = $"/pdf/{book.Pdf}";
            var physicalPath = Path.Combine(_env.WebRootPath, "pdf", book.Pdf);

            if (!System.IO.File.Exists(physicalPath))
            {
                return NotFound("File PDF không tồn tại.");
            }

            ViewBag.PdfPath = relativePath;
            ViewBag.Title = book.Title;

            return View();
        }

        // GET: BookController
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.Include(b => b.Author)
                    .Include(b => b.Category).ToListAsync()
                ;
            return View(books);
        }


        // GET: /Book/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("BookId,Title,CoverImage,CategoryId,AuthorId,Pdf")]
            Book book)
        {
            if (ModelState.IsValid)
            {
                book.CreatedDate = DateTime.Now;
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name", book.CategoryId);
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "FullName", book.AuthorId);
            
            return View(book);

        }



        // GET: /Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name");
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "FullName");

            return View(book);
        }

        // POST: /Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.BookId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "Name", book.CategoryId);
            ViewBag.Authors = new SelectList(_context.Authors, "AuthorId", "FullName", book.AuthorId);
            return View(book);
        }

        // GET: /Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            return View(book);
        }

        // POST: /Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}