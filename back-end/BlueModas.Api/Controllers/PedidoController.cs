using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueModas.Domain.Entities;
using BlueModas.Infra.Data.Context;
using BlueModas.Domain.DTOs;
using Newtonsoft.Json;
using BlueModas.Domain.Interfaces;

namespace BlueModas.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IServicePedido _servicePedido;

        public PedidoController(IServicePedido service)
        {
            _servicePedido = service;
        }

        // GET: api/Pedido
        [HttpGet]
        public ActionResult GetPedido()
        {
            return Ok(_servicePedido.GetAll());
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public IActionResult GetPedido(int id)
        {
            var pedido = _servicePedido.GetById(id);

            if (pedido == null)
                return NotFound();

            return Ok(pedido);
        }

        // PUT: api/Pedido/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutPedido(Pedido pedido)
        {
            if (pedido == null)
                return BadRequest();

            pedido = _servicePedido.Update(pedido);

            return Ok(pedido);
        }

        // POST: api/Pedido
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostPedido(Pedido pedido)
        {
            if (pedido == null)
                return BadRequest();

            pedido =_servicePedido.Insert(pedido);

            return Ok(pedido);
        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public IActionResult DeletePedido(int id)
        {
            _servicePedido.Delete(id);

            return NoContent();
        }

        // POST: api/Pedido/PedidoCompleto
        [HttpPost]
        public IActionResult PedidoCompleto(DTO_PedidoCompleto pc)
        {
            if (pc == null)
                return BadRequest();

            pc =_servicePedido.InsertPedidoCompleto(pc);

            return Ok(pc);
        }

    }
}
