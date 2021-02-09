using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GospelStoriesApi.Models;

namespace GospelStoriesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimoniesController : ControllerBase
    {
        private readonly GospelStoryDBContext _context;

        public TestimoniesController(GospelStoryDBContext context)
        {
            _context = context;
        }

        // GET: api/Testimonies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testimony>>> GetTestimony()
        {
            return await _context.Testimony.ToListAsync();
        }

        // GET: api/Testimonies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Testimony>> GetTestimony(int id)
        {
            var testimony = await _context.Testimony.FindAsync(id);

            if (testimony == null)
            {
                return NotFound();
            }

            return testimony;
        }

        // PUT: api/Testimonies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestimony(int id, Testimony testimony)
        {
            if (id != testimony.TestimonyId)
            {
                return BadRequest();
            }

            _context.Entry(testimony).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestimonyExists(id))
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

        // POST: api/Testimonies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Testimony>> PostTestimony(Testimony testimony)
        {
            _context.Testimony.Add(testimony);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestimony", new { id = testimony.TestimonyId }, testimony);
        }

        #region Entity Framework
        // private void SaveFileBinarySQLServer
        #endregion

        // DELETE: api/Testimonies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Testimony>> DeleteTestimony(int id)
        {
            var testimony = await _context.Testimony.FindAsync(id);
            if (testimony == null)
            {
                return NotFound();
            }

            _context.Testimony.Remove(testimony);
            await _context.SaveChangesAsync();

            return testimony;
        }

        private bool TestimonyExists(int id)
        {
            return _context.Testimony.Any(e => e.TestimonyId == id);
        }
    }
}
