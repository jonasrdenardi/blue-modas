using BlueModas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueModas.Infra.Data.Context
{
    public class BlueModasContext : DbContext
    {
        public BlueModasContext(DbContextOptions<BlueModasContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }

    }
}
