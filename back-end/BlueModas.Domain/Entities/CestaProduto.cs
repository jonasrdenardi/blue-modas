using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlueModas.Domain.Entities
{
    public class CestaProduto
    {
        [Key, Column(Order = 0)]
        public int IdCesta { get; set; }
        [Key, Column(Order = 1)]
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
