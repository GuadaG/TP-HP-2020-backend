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
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<PrecioAccesorio> PrecioAccesorio { get; set; }
    }
}
