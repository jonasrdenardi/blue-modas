using BlueModas.Domain.Entities;
using BlueModas.Domain.Interfaces;
using BlueModas.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Infra.Data.Repository
{
    public class PedidoProdutoRepository
    {
        BlueModasContext _context;
        public PedidoProdutoRepository(BlueModasContext context)
        {
            _context = context;
        }

        public void Save(IEnumerable<PedidoProduto> obj)
        {
            _context.PedidoProduto.AddRange(obj);
        }

    }
}
