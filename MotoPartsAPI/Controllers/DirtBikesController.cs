using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoPartsAPI.Models;

namespace MotoPartsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirtBikesController : ControllerBase
    {
        private readonly MotoPartsContext _context;

        public DirtBikesController(MotoPartsContext context)
        {
            _context = context;
        }

        // GET: api/DirtBikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirtBikes>>> GetDirtBikes()
        {
            return await _context.DirtBikes.ToListAsync();
        }

        // GET: api/DirtBikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DirtBikes>> GetDirtBikes(int id)
        {
            var dirtBikes = await _context.DirtBikes.FindAsync(id);

            if (dirtBikes == null)
            {
                return NotFound();
            }

            return dirtBikes;
        }

        // PUT: api/DirtBikes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirtBikes(int id, DirtBikes dirtBikes)
        {
            if (id != dirtBikes.DirtBikeId)
            {
                return BadRequest();
            }

            _context.Entry(dirtBikes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirtBikesExists(id))
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

        // POST: api/DirtBikes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DirtBikes>> PostDirtBikes(DirtBikes dirtBikes)
        {
            _context.DirtBikes.Add(dirtBikes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirtBikes", new { id = dirtBikes.DirtBikeId }, dirtBikes);
        }

        // DELETE: api/DirtBikes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DirtBikes>> DeleteDirtBikes(int id)
        {
            var dirtBikes = await _context.DirtBikes.FindAsync(id);
            if (dirtBikes == null)
            {
                return NotFound();
            }

            _context.DirtBikes.Remove(dirtBikes);
            await _context.SaveChangesAsync();

            return dirtBikes;
        }

        private bool DirtBikesExists(int id)
        {
            return _context.DirtBikes.Any(e => e.DirtBikeId == id);
        }
    }
}
