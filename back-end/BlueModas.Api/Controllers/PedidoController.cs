﻿using System;
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

namespace BlueModas.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly BlueModasContext _context;

        public PedidoController(BlueModasContext context)
        {
            _context = context;
        }

        // GET: api/Pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedido()
        {
            return await _context.Pedido.ToListAsync();
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Pedido/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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

        // POST: api/Pedido
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> DeletePedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        // POST: api/Pedido/PedidoCompleto
        [HttpPost]
        public async Task<ActionResult<string>> PedidoCompleto(DTO_PedidoCompleto pc)
        {

            _context.Pedido.Add(pc.Pedido);
            await _context.SaveChangesAsync();

            foreach (var pp in pc.PedidoProduto)
            {
                pp.IdPedido = pc.Pedido.Id;
            }
            _context.PedidoProduto.AddRange(pc.PedidoProduto);
            await _context.SaveChangesAsync();

            return JsonConvert.SerializeObject(pc);

        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.Id == id);
        }
    }
}
