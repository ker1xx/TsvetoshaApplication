using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TsvetoshaAPI.Models;

namespace TsvetoshaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeDatumsController : ControllerBase
    {
        private readonly TsvetoshaContext _context;

        public AuthorizeDatumsController(TsvetoshaContext context)
        {
            _context = context;
        }

        // GET: api/AuthorizeDatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorizeDatum>>> GetAuthorizeData()
        {
          if (_context.AuthorizeData == null)
          {
              return NotFound();
          }
            return await _context.AuthorizeData.ToListAsync();
        }

        // GET: api/AuthorizeDatums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorizeDatum>> GetAuthorizeDatum(int? id)
        {
          if (_context.AuthorizeData == null)
          {
              return NotFound();
          }
            var authorizeDatum = await _context.AuthorizeData.FindAsync(id);

            if (authorizeDatum == null)
            {
                return NotFound();
            }

            return authorizeDatum;
        }

        // PUT: api/AuthorizeDatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorizeDatum(int? id, AuthorizeDatum authorizeDatum)
        {
            if (id != authorizeDatum.Id)
            {
                return BadRequest();
            }

            _context.Entry(authorizeDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorizeDatumExists(id))
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

        // POST: api/AuthorizeDatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorizeDatum>> PostAuthorizeDatum(AuthorizeDatum authorizeDatum)
        {
          if (_context.AuthorizeData == null)
          {
              return Problem("Entity set 'TsvetoshaContext.AuthorizeData'  is null.");
          }
            _context.AuthorizeData.Add(authorizeDatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthorizeDatum", new { id = authorizeDatum.Id }, authorizeDatum);
        }

        // DELETE: api/AuthorizeDatums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorizeDatum(int? id)
        {
            if (_context.AuthorizeData == null)
            {
                return NotFound();
            }
            var authorizeDatum = await _context.AuthorizeData.FindAsync(id);
            if (authorizeDatum == null)
            {
                return NotFound();
            }

            _context.AuthorizeData.Remove(authorizeDatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorizeDatumExists(int? id)
        {
            return (_context.AuthorizeData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
