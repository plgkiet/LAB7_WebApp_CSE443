using LAB3_WEBAPP.Data;
using LAB3_WEBAPP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;


namespace LAB3_WEBAPP.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly LibraryContext _context;

        public UsersController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .ToListAsync();

            return Ok(users);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            user.UserCode = "USR" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            user.CreatedDate = DateTime.Now;
            user.Status = 0;
            user.IsLocked = false;
            user.IsDeleted = false;

            user.UserRoles = new List<UserRole> { new UserRole { RoleId = 2 } };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.UserId) return BadRequest();

            var userInDb = await _context.Users.FindAsync(id);
            if (userInDb == null) return NotFound();

            userInDb.Fullname = user.Fullname;
            userInDb.Email = user.Email;
            userInDb.Phone = user.Phone;
            userInDb.Address = user.Address;
            userInDb.Avatar = user.Avatar;
            userInDb.IsActive = user.IsActive; 
            userInDb.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(u => u.UserId == id);
        }
    }
}
