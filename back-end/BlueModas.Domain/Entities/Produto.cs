using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Domain.Entities
{
    public class Produto : BaseEntity<int>
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public byte[] Imagem { get; set; }
    }
}
