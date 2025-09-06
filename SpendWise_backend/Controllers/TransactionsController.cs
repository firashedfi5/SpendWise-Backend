using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpendWise_backend.Models;

namespace SpendWise_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController(ApiDbContext context) : ControllerBase
    {
        private readonly ApiDbContext _context = context;

        // GET: api/Transactions/{userId}
        [HttpGet("{userId}")]
        public async Task<ActionResult<Dictionary<string, object>>> GetTransactions(string userId)
        {
            try
            {
                // Filter transactions by userId
                var transactions = await _context.Transactions
                    .Where(t => t.userId == userId)
                    .OrderByDescending(t => t.createdAt) //* Sorting
                    .ToListAsync();

                return Ok(new Dictionary<string, object>
                {
                    ["data"] = transactions
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Dictionary<string, object>
                {
                    ["error"] = ex.Message
                });
            }
        }

        // GET: api/Transactions/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Transactions>> GetTransactionsById(int id)
        {
            var transactions = await _context.Transactions.FindAsync(id);

            if (transactions == null)
            {
                return NotFound();
            }

            return transactions;
        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactions(int id, Transactions transactions)
        {
            if (id != transactions.id)
            {
                return BadRequest();
            }

            _context.Entry(transactions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionsExists(id))
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

        // POST: api/Transactions
        [HttpPost]
        public async Task<ActionResult<Transactions>> PostTransactions(Transactions transactions)
        {
            _context.Transactions.Add(transactions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionsById", new { id = transactions.id }, transactions);
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactions(int id)
        {
            var transactions = await _context.Transactions.FindAsync(id);
            if (transactions == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transactions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionsExists(int id)
        {
            return _context.Transactions.Any(e => e.id == id);
        }
    }
}