using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Domain.Entities
{
    public class Usuario : BaseEntity<int>
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Regra { get; set; }
    }
}
