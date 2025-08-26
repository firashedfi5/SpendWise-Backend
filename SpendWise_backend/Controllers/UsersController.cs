using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpendWise_backend.Models;

namespace SpendWise_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(ApiDbContext context) : ControllerBase
    {
        private readonly ApiDbContext _context = context;

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<Users>> GetUsersByUserId(string userId)
        {
            var users = await _context.Users.FindAsync(userId);
            if (users == null)
            {
                return NotFound();
            }
            return users;
        }

        // PUT: api/Users/5
        [HttpPut("{userId}")]
        public async Task<IActionResult> PutUsers(string userId, Users users)
        {
            if (userId != users.userId)
            {
                return BadRequest();
            }
            _context.Entry(users).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(userId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUsersByUserId", new { userId = users.userId }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var users = await _context.Users.FindAsync(userId);
            if (users == null)
            {
                return NotFound();
            }
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool UsersExists(string userId)
        {
            return _context.Users.Any(e => e.userId == userId);
        }
    }
}