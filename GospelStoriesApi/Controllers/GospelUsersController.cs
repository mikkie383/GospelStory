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
    public class GospelUsersController : ControllerBase
    {
        private readonly GospelStoryDBContext _context;

        public GospelUsersController(GospelStoryDBContext context)
        {
            _context = context;
        }

        // GET: api/GospelUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GospelUser>>> GetGospelUser()
        {
            return await _context.GospelUser.ToListAsync();
        }

        [HttpGet("GetGospelUserAll")]
        public async Task<ActionResult<IEnumerable<GospelUser>>> GetGospelUserAll()
        {
            return _context.GospelUser
                                .Include(user => user.GospelSharing)
                                .ToList();
        }

        // GET: api/GospelUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GospelUser>> GetGospelUser(int id)
        {
            var gospelUser = await _context.GospelUser.FindAsync(id);

            if (gospelUser == null)
            {
                return NotFound();
            }

            return gospelUser;
        }

        // GET: api/GospelUsers/5
        [HttpGet("GetGospelUserDetail/{id}")]
        public async Task<ActionResult<GospelUser>> GetGospelUserDetail(int id)
        {
            var gospelUser = _context.GospelUser
                                                .Include(user => user.GospelSharing)
                                                .Where(user => user.GospelUserId == id)
                                                .FirstOrDefault();

            if (gospelUser == null)
            {
                return NotFound();
            }

            return gospelUser;
        }

        // PUT: api/GospelUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGospelUser(int id, GospelUser gospelUser)
        {
            if (id != gospelUser.GospelUserId)
            {
                return BadRequest();
            }

            _context.Entry(gospelUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GospelUserExists(id))
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

        // POST: api/GospelUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GospelUser>> PostGospelUser(GospelUser gospelUser)
        {
            _context.GospelUser.Add(gospelUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGospelUser", new { id = gospelUser.GospelUserId }, gospelUser);
        }

        // DELETE: api/GospelUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GospelUser>> DeleteGospelUser(int id)
        {
            var gospelUser = await _context.GospelUser.FindAsync(id);
            if (gospelUser == null)
            {
                return NotFound();
            }

            _context.GospelUser.Remove(gospelUser);
            await _context.SaveChangesAsync();

            return gospelUser;
        }

        private bool GospelUserExists(int id)
        {
            return _context.GospelUser.Any(e => e.GospelUserId == id);
        }
    }
}
