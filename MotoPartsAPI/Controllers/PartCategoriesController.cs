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
    public class PartCategoriesController : ControllerBase
    {
        private readonly MotoPartsContext _context;

        public PartCategoriesController(MotoPartsContext context)
        {
            _context = context;
        }

        // GET: api/PartCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartCategories>>> GetPartCategories()
        {
            return await _context.PartCategories.ToListAsync();
        }

        // GET: api/PartCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartCategories>> GetPartCategories(int id)
        {
            var partCategories = await _context.PartCategories.FindAsync(id);

            if (partCategories == null)
            {
                return NotFound();
            }

            return partCategories;
        }

        // PUT: api/PartCategories/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartCategories(int id, PartCategories partCategories)
        {
            if (id != partCategories.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(partCategories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartCategoriesExists(id))
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

        // POST: api/PartCategories
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PartCategories>> PostPartCategories(PartCategories partCategories)
        {
            _context.PartCategories.Add(partCategories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartCategories", new { id = partCategories.CategoryId }, partCategories);
        }

        // DELETE: api/PartCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PartCategories>> DeletePartCategories(int id)
        {
            var partCategories = await _context.PartCategories.FindAsync(id);
            if (partCategories == null)
            {
                return NotFound();
            }

            _context.PartCategories.Remove(partCategories);
            await _context.SaveChangesAsync();

            return partCategories;
        }

        private bool PartCategoriesExists(int id)
        {
            return _context.PartCategories.Any(e => e.CategoryId == id);
        }
    }
}
