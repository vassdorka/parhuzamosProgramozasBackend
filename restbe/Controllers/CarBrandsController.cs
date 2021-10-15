using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restbe.Models;

namespace restbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public CarBrandsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/CarBrands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarBrands>>> GetCarBrands()
        {
            return await _context.CarBrands.ToListAsync();
        }

        // GET: api/CarBrands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarBrands>> GetCarBrands(int id)
        {
            var carBrands = await _context.CarBrands.FindAsync(id);

            if (carBrands == null)
            {
                return NotFound();
            }

            return carBrands;
        }

        // PUT: api/CarBrands/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarBrands(int id, CarBrands carBrands)
        {
            if (id != carBrands.Id)
            {
                return BadRequest();
            }

            _context.Entry(carBrands).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarBrandsExists(id))
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

        // POST: api/CarBrands
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CarBrands>> PostCarBrands(CarBrands carBrands)
        {
            _context.CarBrands.Add(carBrands);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarBrands", new { id = carBrands.Id }, carBrands);
        }

        // DELETE: api/CarBrands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarBrands>> DeleteCarBrands(int id)
        {
            var carBrands = await _context.CarBrands.FindAsync(id);
            if (carBrands == null)
            {
                return NotFound();
            }

            _context.CarBrands.Remove(carBrands);
            await _context.SaveChangesAsync();

            return carBrands;
        }

        private bool CarBrandsExists(int id)
        {
            return _context.CarBrands.Any(e => e.Id == id);
        }
    }
}
