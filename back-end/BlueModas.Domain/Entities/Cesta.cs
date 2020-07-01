using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Domain.Entities
{
    public class Cesta : BaseEntity<int>
    {
        public int IdCliente { get; set; }
    }
}
