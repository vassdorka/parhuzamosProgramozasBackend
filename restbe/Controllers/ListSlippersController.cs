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
    public class ListSlippersController : ControllerBase
    {
        private readonly MainDbContext _context;

        public ListSlippersController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/ListSlippers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListSlippers>>> GetListSlippers()
        {
            return await _context.ListSlippers.ToListAsync();
        }

        // GET: api/ListSlippers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListSlippers>> GetListSlippers(int id)
        {
            var listSlippers = await _context.ListSlippers.FindAsync(id);

            if (listSlippers == null)
            {
                return NotFound();
            }

            return listSlippers;
        }

        // PUT: api/ListSlippers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListSlippers(int id, ListSlippers listSlippers)
        {
            if (id != listSlippers.Id)
            {
                return BadRequest();
            }

            _context.Entry(listSlippers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListSlippersExists(id))
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

        // POST: api/ListSlippers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ListSlippers>> PostListSlippers(ListSlippers listSlippers)
        {
            _context.ListSlippers.Add(listSlippers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListSlippers", new { id = listSlippers.Id }, listSlippers);
        }

        // DELETE: api/ListSlippers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ListSlippers>> DeleteListSlippers(int id)
        {
            var listSlippers = await _context.ListSlippers.FindAsync(id);
            if (listSlippers == null)
            {
                return NotFound();
            }

            _context.ListSlippers.Remove(listSlippers);
            await _context.SaveChangesAsync();

            return listSlippers;
        }

        private bool ListSlippersExists(int id)
        {
            return _context.ListSlippers.Any(e => e.Id == id);
        }
    }
}
