using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueModas.Domain.Entities;
using BlueModas.Infra.Data.Context;
using BlueModas.Domain.Interfaces;

namespace BlueModas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CestaController : ControllerBase
    {
        private readonly IServiceCesta _serviceCesta;

        public CestaController(IServiceCesta service) => _serviceCesta = service;

        // GET: api/Cesta
        [HttpGet]
        public IActionResult GetCesta()
        {
            return Ok(_serviceCesta.GetAll());
        }

        // GET: api/Cesta/5
        [HttpGet("{id}")]
        public IActionResult GetCesta(int id)
        {
            var cesta = _serviceCesta.GetById(id);

            if (cesta == null)
                return NotFound();

            return Ok(cesta);
        }

        // PUT: api/Cesta/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutCesta(Cesta cesta)
        {
            if (cesta == null)
                return BadRequest();

            cesta = _serviceCesta.Update(cesta);

            return NoContent();
        }

        // POST: api/Cesta
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult PostCesta(Cesta cesta)
        {
            if (cesta == null)
                return BadRequest();

            cesta = _serviceCesta.Insert(cesta);

            return Ok(cesta);
        }

        // DELETE: api/Cesta/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCesta(int id)
        {
            _serviceCesta.Delete(id);

            return NoContent();
        }
    }
}
