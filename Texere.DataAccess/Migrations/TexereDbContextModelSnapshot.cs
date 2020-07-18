﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Texere.DataAccess;

namespace Texere.DataAccess.Migrations
{
    [DbContext(typeof(TexereDbContext))]
    partial class TexereDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Texere.Model.Accesorios", b =>
                {
                    b.Property<int>("AccesorioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool>("TieneTalle")
                        .HasColumnType("bit");

                    b.HasKey("AccesorioId");

                    b.ToTable("Accesorios");
                });

            modelBuilder.Entity("Texere.Model.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DniCuit")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<int>("Domicilio")
                        .HasColumnType("int")
                        .HasMaxLength(30);

                    b.Property<int>("Email")
                        .HasColumnType("int")
                        .HasMaxLength(30);

                    b.Property<int>("NombreApellido")
                        .HasColumnType("int")
                        .HasMaxLength(50);

                    b.Property<int>("Telefono")
                        .HasColumnType("int")
                        .HasMaxLength(20);

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Texere.Model.Pedidos", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("PedidoId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Texere.Model.PrecioAccesorio", b =>
                {
                    b.Property<int>("PrecioAccesorioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccesorioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaVigencia")
                        .HasColumnType("datetime2");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("PrecioAccesorioId");

                    b.HasIndex("AccesorioId");

                    b.ToTable("PrecioAccesorio");
                });

            modelBuilder.Entity("Texere.Model.Pedidos", b =>
                {
                    b.HasOne("Texere.Model.Clientes", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Texere.Model.PrecioAccesorio", b =>
                {
                    b.HasOne("Texere.Model.Accesorios", "Accesorio")
                        .WithMany("HistoricoPrecio")
                        .HasForeignKey("AccesorioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
