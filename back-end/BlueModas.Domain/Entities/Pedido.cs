using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Domain.Entities
{
    public class Pedido : BaseEntity<int>
    {
        public string Descricao { get; set; }
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }
    }
}
