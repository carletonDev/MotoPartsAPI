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
    public class BrandsController : ControllerBase
    {
        private readonly IDbContext _context;

        public BrandsController(IDbContext context)
        {
            _context = context;
        }

        // GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brands>>> GetBrands()
        {
            return await _context.MotoPartsContext().Brands.ToListAsync();
        }

        // GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brands>> GetBrands(int id)
        {
            var brands = await _context.MotoPartsContext().Brands.FindAsync(id);

            if (brands == null)
            {
                return NotFound();
            }

            return brands;
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrands(int id, Brands brands)
        {
            if (id != brands.BrandId)
            {
                return BadRequest();
            }

            _context.MotoPartsContext().Entry(brands).State = EntityState.Modified;

            try
            {
                await _context.MotoPartsContext().SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandsExists(id))
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

        // POST: api/Brands
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Brands>> PostBrands(Brands brands)
        {
            _context.MotoPartsContext().Brands.Add(brands);
            await _context.MotoPartsContext().SaveChangesAsync();

            return CreatedAtAction("GetBrands", new { id = brands.BrandId }, brands);
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Brands>> DeleteBrands(int id)
        {
            var brands = await _context.MotoPartsContext().Brands.FindAsync(id);
            if (brands == null)
            {
                return NotFound();
            }

            _context.MotoPartsContext().Brands.Remove(brands);
            await _context.MotoPartsContext().SaveChangesAsync();

            return brands;
        }

        private bool BrandsExists(int id)
        {
            return _context.MotoPartsContext().Brands.Any(e => e.BrandId == id);
        }
    }
}
