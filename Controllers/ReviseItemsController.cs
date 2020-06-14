using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revise.Models;

namespace Revise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviseItemsController : ControllerBase
    {
        private readonly ReviseContext _context;

        public ReviseItemsController(ReviseContext context)
        {
            _context = context;
        }

        // GET: api/ReviseItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviseItem>>> GetReviseItems()
        {
            return await _context.ReviseItems.ToListAsync();
        }

        // GET: api/ReviseItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviseItem>> GetReviseItem(int id)
        {
            var reviseItem = await _context.ReviseItems.FindAsync(id);

            if (reviseItem == null)
            {
                return NotFound();
            }

            return reviseItem;
        }

        // PUT: api/ReviseItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviseItem(int id, ReviseItem reviseItem)
        {
            if (id != reviseItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(reviseItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviseItemExists(id))
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

        // POST: api/ReviseItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReviseItem>> PostReviseItem(ReviseItem reviseItem)
        {
            _context.ReviseItems.Add(reviseItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReviseItem", new { id = reviseItem.Id }, reviseItem);
        }

        // DELETE: api/ReviseItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReviseItem>> DeleteReviseItem(int id)
        {
            var reviseItem = await _context.ReviseItems.FindAsync(id);
            if (reviseItem == null)
            {
                return NotFound();
            }

            _context.ReviseItems.Remove(reviseItem);
            await _context.SaveChangesAsync();

            return reviseItem;
        }

        private bool ReviseItemExists(int id)
        {
            return _context.ReviseItems.Any(e => e.Id == id);
        }
    }
}
