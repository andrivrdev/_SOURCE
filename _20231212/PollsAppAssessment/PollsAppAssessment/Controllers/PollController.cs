using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollsAppAssessment.Data;
using PollsAppAssessment.Models;

namespace PollsAppAssessment.Controllers
{
    [Route("api/poll")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PollController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.Poll.ToListAsync();
            return Ok(devs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dev = await _context.Poll.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(dev);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Poll poll)
        {
            _context.Add(poll);
            await _context.SaveChangesAsync();
            return Ok(poll.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Poll poll)
        {
            _context.Entry(poll).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var poll = new Poll { Id = id };
            _context.Remove(poll);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
