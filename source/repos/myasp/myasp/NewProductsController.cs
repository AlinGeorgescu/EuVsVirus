using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myasp.Model;

namespace myasp
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewProductsController : ControllerBase
    {
        private readonly NEWFarmerContext _context;

        public NewProductsController(NEWFarmerContext context)
        {
            _context = context;
        }

        // GET: api/NewProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewProducts>>> GetNewProducts()
        {
            return await _context.NewProducts.ToListAsync();
        }

        // GET: api/NewProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewProducts>> GetNewProducts(int id)
        {
            var newProducts = await _context.NewProducts.FindAsync(id);

            if (newProducts == null)
            {
                return NotFound();
            }

            return newProducts;
        }

        // PUT: api/NewProducts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNewProducts(int id, NewProducts newProducts)
        {
            if (id != newProducts.Id)
            {
                return BadRequest();
            }

            _context.Entry(newProducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewProductsExists(id))
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

        // POST: api/NewProducts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NewProducts>> PostNewProducts(NewProducts newProducts)
        {
            _context.NewProducts.Add(newProducts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNewProducts", new { id = newProducts.Id }, newProducts);
        }

        // DELETE: api/NewProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewProducts>> DeleteNewProducts(int id)
        {
            var newProducts = await _context.NewProducts.FindAsync(id);
            if (newProducts == null)
            {
                return NotFound();
            }

            _context.NewProducts.Remove(newProducts);
            await _context.SaveChangesAsync();

            return newProducts;
        }

        private bool NewProductsExists(int id)
        {
            return _context.NewProducts.Any(e => e.Id == id);
        }
    }
}
