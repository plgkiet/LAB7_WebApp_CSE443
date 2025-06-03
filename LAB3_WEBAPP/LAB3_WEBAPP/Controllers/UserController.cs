using LAB3_WEBAPP.Data;
using LAB3_WEBAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB3_WEBAPP.Controllers
{
    public class UserController : Controller
    {
        private readonly LibraryContext _context;

        public UserController(LibraryContext context)
        {
            _context = context;
        }
        
          // GET
          public async Task<IActionResult> Index()
          {
              var users = await _context.Users
                  .Include(u => u.UserRoles)
                  .ThenInclude(ur => ur.Role)
                  .ToListAsync();
              return View(users);
          }



        // GET: /Users/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("UserId,Fullname,Username,Password,Email,Phone, Address,IsActive,Avatar")] User user)
        {
            if (ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", error.ErrorMessage); // Gắn lỗi vào View
                }
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.UserCode = "USR" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
                user.CreatedDate = DateTime.Now;
                user.Status = 0;
                user.IsLocked = false;
                user.IsDeleted = false;
                user.UserRoles.Add(new UserRole
                {
                    RoleId = 2 // Role mặc định là User
                });                
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }


        // GET: /User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        // POST: /User/Edit/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, User user)
        // {
        //     if (id != user.UserId) return NotFound();
        //     ModelState.Remove("Password");
        //
        //     if (ModelState.IsValid)
        //     {
        //         foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
        //         {
        //             ModelState.AddModelError("", error.ErrorMessage); // Gắn lỗi vào View
        //         }
        //         _context.Update(user);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //
        //     return View(user);
        // }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.UserId)
                return NotFound();

            ModelState.Remove("Password");
            ModelState.Remove("Username");


            if (ModelState.IsValid)
            {
                var userInDb = await _context.Users.FindAsync(id);
                if (userInDb == null) return NotFound();

                userInDb.Fullname = user.Fullname;
                userInDb.Email = user.Email;
                userInDb.Phone = user.Phone;
                userInDb.Address = user.Address;
                userInDb.Avatar = user.Avatar;
                userInDb.IsActive = user.IsActive;
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }


        // GET: /Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        // POST: /Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
