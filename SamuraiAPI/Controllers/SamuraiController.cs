using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace SamuraiAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SamuraiController : ControllerBase
    {
        private readonly SamuraiContext _context;
        private readonly ILogger<SamuraiController> _logger;

        public SamuraiController(ILogger<SamuraiController> logger,SamuraiContext context)
        {
            _context = context;
        }
        //GET: api/Samurais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Samurai>>> GetSamurais()
        { 
            return await _context.Samurais.ToListAsync();
        }

        //GET: api/Samurais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Samurai>> GetSamurai(int id)
        {
            var samurai = await _context.Samurais.FindAsync(id);

            if (samurai == null)
            {
                return NotFound();

            }
            return samurai;
        }

        //PUT: api/Samurais/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSamurai(int id, Samurai samurai)
        {
            if (id != samurai.Id)
            {
                return BadRequest();
            }
            _context.Entry(samurai).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SamuraiExists(id))
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
        [HttpPost]
        public async Task<ActionResult<Samurai>> PostSamurai(Samurai samurai)
        {
            _context.Samurais.Add(samurai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSamurai", new { id = samurai.Id }, samurai);
        }

        //delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSamurai(int id)
        {
            var samurai = await _context.Samurais.FindAsync(id);

            if (samurai == null)
            {
                return NotFound();

            }
            _context.Samurais.Remove(samurai);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool SamuraiExists(int id)
        {
            return _context.Samurais.Any(e => e.Id == id);
        }
    }
}
