using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GospelStoriesApi.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace GospelStoriesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimoniesController : ControllerBase
    {
        private readonly GospelStoryDBContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public TestimoniesController(GospelStoryDBContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
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
        public async Task<ActionResult<Testimony>> PostTestimony([FromForm]Testimony testimony)
        {
            testimony.ContentImg = await SaveImage(testimony.ImageFile);
            _context.Testimony.Add(testimony);
            await _context.SaveChangesAsync();

            return StatusCode(201);
        }

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

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imageName);
            using(var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
        
    }
}
