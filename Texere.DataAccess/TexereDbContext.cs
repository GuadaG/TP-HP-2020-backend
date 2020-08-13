using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Texere.Model;

namespace Texere.DataAccess
{
    public class TexereDbContext : DbContext
    {
        public TexereDbContext(DbContextOptions<TexereDbContext> options) : base(options)
        {

        }
        public DbSet<Accesorios> Accesorios { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Instituciones> Instituciones { get; set; }
        public DbSet<Colores> Colores { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<PrecioAccesorio> PrecioAccesorio { get; set; }
        public DbSet<Talles> Talles { get; set; }
        public DbSet<Modelos> Modelos { get; set; }
        public DbSet<Materiales> Materiales { get; set; }
        public DbSet<LineasPedido> LineasPedido { get; set; }
        public DbSet<ColoresModelos> ColoresModelos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ColoresModelos>()
            .HasKey(cm => new { cm.ColorId, cm.ModeloId });
            modelBuilder.Entity<ColoresModelos>()
                .HasOne(cm => cm.Modelos)
                .WithMany(m => m.ColoresModelos)
                .HasForeignKey(cm => cm.ModeloId);
            modelBuilder.Entity<ColoresModelos>()
                .HasOne(cm => cm.Colores)
                .WithMany(c => c.ColoresModelos)
                .HasForeignKey(cm => cm.ColorId);
        }
    }
}
