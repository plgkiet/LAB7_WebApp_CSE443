using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using LAB3_WEBAPP.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace LAB3_WEBAPP.Controllers
{
    public class AccountController : Controller
    {
        private readonly LibraryContext _context;
        
        public AccountController(LibraryContext context)
        {
            _context = context;
        }
        // GET: AccountController
        public IActionResult Login()
        {
            return View();  
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefault(u => u.Username == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            };

            claims.AddRange(user.UserRoles.Select(ur => new Claim(ClaimTypes.Role, ur.Role.Name)));

            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            
            await HttpContext.SignInAsync("CookieAuth", claimsPrincipal);

            return RedirectToAction("Index", "Home");
        }
        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult AccessDenied(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        public IActionResult Register()
        {
            return View(); 
        }
    
        
    }
}
