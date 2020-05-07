using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeCards.Models;

namespace CodeCards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeCardsController : ControllerBase
    {
        private readonly CodeCardContext _context;

        public CodeCardsController(CodeCardContext context)
        {
            _context = context;
        }

        // GET: api/CodeCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodeCard>>> GetCodeCards()
        {
            return await _context.Code_Card.ToListAsync();
        }

        // GET: api/CodeCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CodeCard>> GetCodeCard(int id)
        {
            var codeCard = await _context.Code_Card.FindAsync(id);

            if (codeCard == null)
            {
                return NotFound();
            }

            return codeCard;
        }

        // PUT: api/CodeCards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodeCard(int id, CodeCard codeCard)
        {
            if (id != codeCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(codeCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodeCardExists(id))
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

        // POST: api/CodeCards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CodeCard>> PostCodeCard(CodeCard codeCard)
        {
            _context.Code_Card.Add(codeCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodeCard", new { id = codeCard.Id }, codeCard);
        }

        // DELETE: api/CodeCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CodeCard>> DeleteCodeCard(int id)
        {
            var codeCard = await _context.Code_Card.FindAsync(id);
            if (codeCard == null)
            {
                return NotFound();
            }

            _context.Code_Card.Remove(codeCard);
            await _context.SaveChangesAsync();

            return codeCard;
        }

        private bool CodeCardExists(int id)
        {
            return _context.Code_Card.Any(e => e.Id == id);
        }
    }
}
