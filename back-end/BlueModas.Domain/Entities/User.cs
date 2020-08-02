using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
