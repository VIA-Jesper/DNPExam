using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestService.Data;

namespace TestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndpointController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EndpointController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Endpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VolumeResult>>> GetVolumeResult()
        {
            return await _context.VolumeResult.ToListAsync();
        }

        // GET: api/Endpoint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VolumeResult>> GetVolumeResult(int id)
        {
            var volumeResult = await _context.VolumeResult.FindAsync(id);

            if (volumeResult == null)
            {
                return NotFound();
            }

            return volumeResult;
        }

        // PUT: api/Endpoint/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVolumeResult(int id, VolumeResult volumeResult)
        {
            if (id != volumeResult.Id)
            {
                return BadRequest();
            }

            _context.Entry(volumeResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolumeResultExists(id))
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

        // POST: api/Endpoint
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VolumeResult>> PostVolumeResult(VolumeResult volumeResult)
        {
            _context.VolumeResult.Add(volumeResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVolumeResult", new { id = volumeResult.Id }, volumeResult);
        }

        // DELETE: api/Endpoint/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VolumeResult>> DeleteVolumeResult(int id)
        {
            var volumeResult = await _context.VolumeResult.FindAsync(id);
            if (volumeResult == null)
            {
                return NotFound();
            }

            _context.VolumeResult.Remove(volumeResult);
            await _context.SaveChangesAsync();

            return volumeResult;
        }

        private bool VolumeResultExists(int id)
        {
            return _context.VolumeResult.Any(e => e.Id == id);
        }
    }
}
