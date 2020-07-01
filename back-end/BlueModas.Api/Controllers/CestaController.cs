using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueModas.Domain.Entities;
using BlueModas.Infra.Data.Context;

namespace BlueModas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CestaController : ControllerBase
    {
        private readonly BlueModasContext _context;

        public CestaController(BlueModasContext context)
        {
            _context = context;
        }

        // GET: api/Cesta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cesta>>> GetCesta()
        {
            return await _context.Cesta.ToListAsync();
        }

        // GET: api/Cesta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cesta>> GetCesta(int id)
        {
            var cesta = await _context.Cesta.FindAsync(id);

            if (cesta == null)
            {
                return NotFound();
            }

            return cesta;
        }

        // PUT: api/Cesta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCesta(int id, Cesta cesta)
        {
            if (id != cesta.Id)
            {
                return BadRequest();
            }

            _context.Entry(cesta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CestaExists(id))
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

        // POST: api/Cesta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cesta>> PostCesta(Cesta cesta)
        {
            _context.Cesta.Add(cesta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCesta", new { id = cesta.Id }, cesta);
        }

        // DELETE: api/Cesta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cesta>> DeleteCesta(int id)
        {
            var cesta = await _context.Cesta.FindAsync(id);
            if (cesta == null)
            {
                return NotFound();
            }

            _context.Cesta.Remove(cesta);
            await _context.SaveChangesAsync();

            return cesta;
        }

        private bool CestaExists(int id)
        {
            return _context.Cesta.Any(e => e.Id == id);
        }
    }
}
