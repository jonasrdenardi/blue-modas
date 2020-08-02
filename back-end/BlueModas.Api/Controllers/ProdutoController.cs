using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlueModas.Domain.Entities;
using BlueModas.Infra.Data.Context;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using BlueModas.Domain.DTOs;
using BlueModas.Domain.Interfaces;

namespace BlueModas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IServiceProduto _serviceProduto;

        public ProdutoController(IServiceProduto service) => _serviceProduto = service;

        // GET: api/Produto
        [HttpGet]
        public IActionResult GetProduto()
        {
            return Ok(_serviceProduto.GetAll());
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public ActionResult GetProduto(int id)
        {
            var produto = _serviceProduto.GetById(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        // PUT: api/Produto/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutProduto(Produto produto)
        {
            if (produto == null)
                return BadRequest();

            produto = _serviceProduto.Update(produto);

            return Ok(produto);
        }

        // POST: api/Produto
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostProduto(Produto produto)
        {
            if (produto == null)
                return BadRequest();

            produto = _serviceProduto.Insert(produto);

            return Ok(produto);
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduto(int id)
        {
            _serviceProduto.Delete(id);

            return NoContent();
        }

    }
}
