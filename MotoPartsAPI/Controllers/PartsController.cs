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
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly IDbContext _context;

        public PartsController(IDbContext context)
        {
            _context = context;
        }

        // GET: api/Parts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parts>>> GetParts()
        {
            return await _context.MotoPartsContext().Parts.ToListAsync();
        }

        // GET: api/Parts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parts>> GetParts(int id)
        {
            var parts = await _context.MotoPartsContext().Parts.FindAsync(id);

            if (parts == null)
            {
                return NotFound();
            }

            return parts;
        }

        // PUT: api/Parts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParts(int id, Parts parts)
        {
            if (id != parts.PartId)
            {
                return BadRequest();
            }

            _context.MotoPartsContext().Entry(parts).State = EntityState.Modified;

            try
            {
                await _context.MotoPartsContext().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartsExists(id))
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

        // POST: api/Parts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Parts>> PostParts(Parts parts)
        {
            _context.MotoPartsContext().Parts.Add(parts);
            await _context.MotoPartsContext().SaveChangesAsync();

            return CreatedAtAction("GetParts", new { id = parts.PartId }, parts);
        }

        // DELETE: api/Parts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Parts>> DeleteParts(int id)
        {
            var parts = await _context.MotoPartsContext().Parts.FindAsync(id);
            if (parts == null)
            {
                return NotFound();
            }

            _context.MotoPartsContext().Parts.Remove(parts);
            await _context.MotoPartsContext().SaveChangesAsync();

            return parts;
        }

        private bool PartsExists(int id)
        {
            return _context.MotoPartsContext().Parts.Any(e => e.PartId == id);
        }
    }
}
