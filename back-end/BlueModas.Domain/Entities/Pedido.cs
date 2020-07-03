using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Domain.Entities
{
    public class Pedido : BaseEntity<int>
    {
        public int IdCliente { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
