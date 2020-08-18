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

            #region Seed
            modelBuilder.Entity<Accesorios>().HasData(
                new Accesorios
                {
                    AccesorioId = 1,
                    DescAccesorio = "Cuello",
                    TieneTalle = true
                },
                new Accesorios
                {
                    AccesorioId = 2,
                    DescAccesorio = "Puño",
                    TieneTalle = false
                },
                new Accesorios
                {
                    AccesorioId = 3,
                    DescAccesorio = "Cintura",
                    TieneTalle = false
                }
            );

            modelBuilder.Entity<Talles>().HasData(
                new Talles
                {
                    TalleId = 1,
                    DescTalle = "Talle 8",
                    Medida = 28
                },
                new Talles
                {
                    TalleId = 2,
                    DescTalle = "Talle 10",
                    Medida = 30
                },
                new Talles
                {
                    TalleId = 3,
                    DescTalle = "Talle 12",
                    Medida = 32
                },
                new Talles
                {
                    TalleId = 4,
                    DescTalle = "Talle 14",
                    Medida = 34
                },
                new Talles
                {
                    TalleId = 5,
                    DescTalle = "Talle 16 (XS)",
                    Medida = 36
                },
                new Talles
                {
                    TalleId = 6,
                    DescTalle = "Talle S",
                    Medida = 38
                },
                new Talles
                {
                    TalleId = 7,
                    DescTalle = "Talle M",
                    Medida = 40
                },
                new Talles
                {
                    TalleId = 8,
                    DescTalle = "Talle L",
                    Medida = 42
                },
                new Talles
                {
                    TalleId = 9,
                    DescTalle = "Talle XL",
                    Medida = 44
                },
                new Talles
                {
                    TalleId = 10,
                    DescTalle = "Talle XXL",
                    Medida = 46
                }
            );

            modelBuilder.Entity<Colores>().HasData(
                new Colores
                {
                    ColorId = 1,
                    Descripcion = "Blanco"
                },
                new Colores
                {
                    ColorId = 2,
                    Descripcion = "Verde Benetton"
                },
                new Colores
                {
                    ColorId = 3,
                    Descripcion = "Rojo Sangre"
                },
                new Colores
                {
                    ColorId = 4,
                    Descripcion = "Azul Marino"
                },
                new Colores
                {
                    ColorId = 5,
                    Descripcion = "Azul Marino Claro"
                },
                new Colores
                {
                    ColorId = 6,
                    Descripcion = "Blanco Óptico"
                },
                new Colores
                {
                    ColorId = 7,
                    Descripcion = "Verde Inglés"
                },
                new Colores
                {
                    ColorId = 8,
                    Descripcion = "Verde Oliva"
                },
                new Colores
                {
                    ColorId = 9,
                    Descripcion = "Negro"
                },
                new Colores
                {
                    ColorId = 10,
                    Descripcion = "Amarillo"
                },
                new Colores
                {
                    ColorId = 11,
                    Descripcion = "Naranja"
                },
                new Colores
                {
                    ColorId = 12,
                    Descripcion = "Gris Melange"
                },
                new Colores
                {
                    ColorId = 13,
                    Descripcion = "Gris Claro"
                }
            );

            modelBuilder.Entity<Materiales>().HasData(
                new Materiales
                {
                    MaterialId = 1,
                    DescMaterial = "Algodón"
                },
                new Materiales
                {
                    MaterialId = 2,
                    DescMaterial = "Poliéster"
                },
                new Materiales
                {
                    MaterialId = 3,
                    DescMaterial = "Acrílico"
                }
            );

            modelBuilder.Entity<Instituciones>().HasData(
                new Instituciones
                {
                    InstitucionId = 1,
                    Descripcion = "Colegio Adoratrices"
                },
                new Instituciones
                {
                    InstitucionId = 2,
                    Descripcion = "Colegio Adventista"
                },
                new Instituciones
                {
                    InstitucionId = 3,
                    Descripcion = "Colegio Alvear"
                },
                new Instituciones
                {
                    InstitucionId = 4,
                    Descripcion = "Colegio Arrayanes"
                },
                new Instituciones
                {
                    InstitucionId = 5,
                    Descripcion = "Colegio Asunción"
                },
                new Instituciones
                {
                    InstitucionId = 6,
                    Descripcion = "Colegio Boneo"
                },
                new Instituciones
                {
                    InstitucionId = 7,
                    Descripcion = "Colegio Brigadier López"
                },
                new Instituciones
                {
                    InstitucionId = 8,
                    Descripcion = "Colegio Buen Samaritano"
                },
                new Instituciones
                {
                    InstitucionId = 9,
                    Descripcion = "Colegio Cayetano Errico"
                },
                new Instituciones
                {
                    InstitucionId = 10,
                    Descripcion = "Colegio Comercio"
                },
                new Instituciones
                {
                    InstitucionId = 11,
                    Descripcion = "Colegio Complejo Alberdi"
                },
                new Instituciones
                {
                    InstitucionId = 12,
                    Descripcion = "Colegio Cooperación"
                },
                new Instituciones
                {
                    InstitucionId = 13,
                    Descripcion = "Colegio Cristo Rey"
                },
                new Instituciones
                {
                    InstitucionId = 14,
                    Descripcion = "Colegio Dante Alighieri"
                },
                new Instituciones
                {
                    InstitucionId = 15,
                    Descripcion = "Colegio Del Sur"
                },
                new Instituciones
                {
                    InstitucionId = 16,
                    Descripcion = "Colegio Divino Maestro"
                },
                new Instituciones
                {
                    InstitucionId = 17,
                    Descripcion = "Colegio Edmondo"
                },
                new Instituciones
                {
                    InstitucionId = 18,
                    Descripcion = "Colegio El Huerto"
                },
                new Instituciones
                {
                    InstitucionId = 19,
                    Descripcion = "Colegio Español"
                },
                new Instituciones
                {
                    InstitucionId = 20,
                    Descripcion = "Colegio Fuente De Vida"
                },
                new Instituciones
                {
                    InstitucionId = 21,
                    Descripcion = "Colegio Gianelli"
                },
                new Instituciones
                {
                    InstitucionId = 22,
                    Descripcion = "Colegio Gomara"
                },
                new Instituciones
                {
                    InstitucionId = 23,
                    Descripcion = "Colegio Grognet"
                },
                new Instituciones
                {
                    InstitucionId = 24,
                    Descripcion = "Colegio Guadalupe"
                },
                new Instituciones
                {
                    InstitucionId = 25,
                    Descripcion = "Colegio Instituto Sur"
                },
                new Instituciones
                {
                    InstitucionId = 26,
                    Descripcion = "Colegio Latino"
                },
                new Instituciones
                {
                    InstitucionId = 27,
                    Descripcion = "Colegio La Guardia"
                },
                new Instituciones
                {
                    InstitucionId = 28,
                    Descripcion = "Colegio La Merced"
                },
                new Instituciones
                {
                    InstitucionId = 29,
                    Descripcion = "Colegio La Salle"
                },
                new Instituciones
                {
                    InstitucionId = 30,
                    Descripcion = "Colegio Leloir"
                },
                new Instituciones
                {
                    InstitucionId = 31,
                    Descripcion = "Colegio López"
                },
                new Instituciones
                {
                    InstitucionId = 32,
                    Descripcion = "Colegio Los Ángeles"
                },
                new Instituciones
                {
                    InstitucionId = 33,
                    Descripcion = "Colegio Los Arroyos"
                },
                new Instituciones
                {
                    InstitucionId = 34,
                    Descripcion = "Colegio Luján"
                },
                new Instituciones
                {
                    InstitucionId = 35,
                    Descripcion = "Colegio Madre Cabrini"
                },
                new Instituciones
                {
                    InstitucionId = 36,
                    Descripcion = "Colegio Manantiales"
                },
                new Instituciones
                {
                    InstitucionId = 37,
                    Descripcion = "Colegio María Madre"
                },
                new Instituciones
                {
                    InstitucionId = 38,
                    Descripcion = "Colegio Maristas"
                },
                new Instituciones
                {
                    InstitucionId = 39,
                    Descripcion = "Colegio Mater Dei"
                },
                new Instituciones
                {
                    InstitucionId = 40,
                    Descripcion = "Colegio Mirasoles"
                },
                new Instituciones
                {
                    InstitucionId = 41,
                    Descripcion = "Colegio Msericordia"
                },
                new Instituciones
                {
                    InstitucionId = 42,
                    Descripcion = "Colegio Natividad"
                },
                new Instituciones
                {
                    InstitucionId = 43,
                    Descripcion = "Colegio Niño Jesús"
                },
                new Instituciones
                {
                    InstitucionId = 44,
                    Descripcion = "Colegio Normal"
                },
                new Instituciones
                {
                    InstitucionId = 45,
                    Descripcion = "Colegio Nuestra Sra. De La Paz"
                },
                new Instituciones
                {
                    InstitucionId = 46,
                    Descripcion = "Colegio Padre Claret"
                },
                new Instituciones
                {
                    InstitucionId = 47,
                    Descripcion = "Colegio Pompeya"
                },
                new Instituciones
                {
                    InstitucionId = 48,
                    Descripcion = "Colegio Prefectura"
                },
                new Instituciones
                {
                    InstitucionId = 49,
                    Descripcion = "Colegio Sabin"
                },
                new Instituciones
                {
                    InstitucionId = 50,
                    Descripcion = "Colegio Sagrada Familia"
                },
                new Instituciones
                {
                    InstitucionId = 51,
                    Descripcion = "Colegio Sagrado Corazón"
                },
                new Instituciones
                {
                    InstitucionId = 52,
                    Descripcion = "Colegio San Francisco De Asís"
                },
                new Instituciones
                {
                    InstitucionId = 53,
                    Descripcion = "Colegio San Jorge"
                },
                new Instituciones
                {
                    InstitucionId = 54,
                    Descripcion = "Colegio San Martín"
                },
                new Instituciones
                {
                    InstitucionId = 55,
                    Descripcion = "Colegio San Pablo"
                },
                new Instituciones
                {
                    InstitucionId = 56,
                    Descripcion = "Colegio San Patricio"
                },
                new Instituciones
                {
                    InstitucionId = 57,
                    Descripcion = "Colegio San Ramón"
                },
                new Instituciones
                {
                    InstitucionId = 58,
                    Descripcion = "Colegio Santa Teresita"
                },
                new Instituciones
                {
                    InstitucionId = 59,
                    Descripcion = "Colegio Santísimo Rosario"
                },
                new Instituciones
                {
                    InstitucionId = 60,
                    Descripcion = "Colegio Teodelina"
                },
                new Instituciones
                {
                    InstitucionId = 61,
                    Descripcion = "Colegio Urquiza"
                },
                new Instituciones
                {
                    InstitucionId = 62,
                    Descripcion = "Colegio Verbo Encarnado"
                }
            );
            #endregion Seed
        }
    }
}
