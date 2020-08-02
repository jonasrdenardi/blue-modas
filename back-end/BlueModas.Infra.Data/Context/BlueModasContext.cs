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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CestaProduto>()
                .HasKey(x => new { x.IdCesta, x.IdProduto });

            modelBuilder.Entity<PedidoProduto>()
                .HasKey(x => new { x.IdPedido, x.IdProduto });
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cesta> Cesta { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<CestaProduto> CestaProduto { get; set; }
        public DbSet<PedidoProduto> PedidoProduto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
