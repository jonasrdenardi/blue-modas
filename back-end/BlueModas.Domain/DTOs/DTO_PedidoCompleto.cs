using BlueModas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Domain.DTOs
{
    public class DTO_PedidoCompleto
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoProduto> PedidoProduto { get; set; }
    }
}
