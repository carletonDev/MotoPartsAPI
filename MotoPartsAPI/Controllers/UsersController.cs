using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoPartsAPI.Interfaces;
using MotoPartsAPI.Models;

namespace MotoPartsAPI.Controllers
{
    //this is the route template
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDbContext _context;

        public UsersController(IDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.MotoPartsContext().Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await _context.MotoPartsContext().Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.UserId)
            {
                return BadRequest();
            }

            _context.MotoPartsContext().Entry(users).State = EntityState.Modified;

            try
            {
                await _context.MotoPartsContext().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            _context.MotoPartsContext().Users.Add(users);
            await _context.MotoPartsContext().SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            var users = await _context.MotoPartsContext().Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.MotoPartsContext().Users.Remove(users);
            await _context.MotoPartsContext().SaveChangesAsync();

            return users;
        }

        private bool UsersExists(int id)
        {
            return _context.MotoPartsContext().Users.Any(e => e.UserId == id);
        }
    }
}
