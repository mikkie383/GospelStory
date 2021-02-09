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
    public class GospelSharingsController : ControllerBase
    {
        private readonly GospelStoryDBContext _context;

        public GospelSharingsController(GospelStoryDBContext context)
        {
            _context = context;
        }

        // GET: api/GospelSharings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GospelSharing>>> GetGospelSharing()
        {
            return await _context.GospelSharing.ToListAsync();
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<GospelSharing>>> GetGospelSharingAll()
        {
            return _context.GospelSharing
                                        .Include(share => share.GospelUser)
                                        .ToList();
        }

        // GET: api/GospelSharings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GospelSharing>> GetGospelSharing(int id)
        {
            var gospelSharing = await _context.GospelSharing.FindAsync(id);

            if (gospelSharing == null)
            {
                return NotFound();
            }

            return gospelSharing;
        }

        // GET: api/GospelSharings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GospelSharing>> GetGospelSharingDetail(int id)
        {
            var gospelSharing = await _context.GospelSharing.FindAsync(id);

            if (gospelSharing == null)
            {
                return NotFound();
            }

            return gospelSharing;
        }

        // PUT: api/GospelSharings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGospelSharing(int id, GospelSharing gospelSharing)
        {
            if (id != gospelSharing.ShareId)
            {
                return BadRequest();
            }

            _context.Entry(gospelSharing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GospelSharingExists(id))
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

        // POST: api/GospelSharings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GospelSharing>> PostGospelSharing(GospelSharing gospelSharing)
        {
            _context.GospelSharing.Add(gospelSharing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGospelSharing", new { id = gospelSharing.ShareId }, gospelSharing);
        }

        // DELETE: api/GospelSharings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GospelSharing>> DeleteGospelSharing(int id)
        {
            var gospelSharing = await _context.GospelSharing.FindAsync(id);
            if (gospelSharing == null)
            {
                return NotFound();
            }

            _context.GospelSharing.Remove(gospelSharing);
            await _context.SaveChangesAsync();

            return gospelSharing;
        }

        private bool GospelSharingExists(int id)
        {
            return _context.GospelSharing.Any(e => e.ShareId == id);
        }
    }
}
