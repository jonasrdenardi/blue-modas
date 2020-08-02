using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueModas.Domain.Entities;
using BlueModas.Infra.Data.Context;
using Newtonsoft.Json;
using BlueModas.Domain.Interfaces;

namespace BlueModas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IServiceCliente _serviceCliente;

        public ClienteController(IServiceCliente service) => _serviceCliente = service;

        // GET: api/Cliente
        [HttpGet]
        public IActionResult GetCliente()
        {
            return Ok(_serviceCliente.GetAll());
        }

        // GET: api/Cliente/5
        [HttpGet("{id}")]
        public IActionResult GetCliente(int id)
        {
            var cliente = _serviceCliente.GetById(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        // PUT: api/Cliente/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutCliente(Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            cliente =_serviceCliente.Update(cliente);

            return Ok(cliente);
        }

        // POST: api/Cliente
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostCliente(Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            cliente = _serviceCliente.Insert(cliente);

            return Ok(cliente);
        }

        // DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            _serviceCliente.Delete(id);

            return NoContent();
        }

    }
}
