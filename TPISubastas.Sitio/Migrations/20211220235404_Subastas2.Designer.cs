﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TPISubastas.AccesoDatos;

namespace TPISubastas.Sitio.Migrations
{
    [DbContext(typeof(ContextoSubasta))]
    [Migration("20211220235404_Subastas2")]
    partial class Subastas2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TPISubastas.Dominio.EstadoSubasta", b =>
                {
                    b.Property<int>("IdEstadoSubasta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("IdEstadoSubasta");

                    b.ToTable("EstadoSubasta");
                });

            modelBuilder.Entity("TPISubastas.Dominio.Oferta", b =>
                {
                    b.Property<int>("IdOferta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdSubasta")
                        .HasColumnType("int");

                    b.Property<int>("IdSubastaProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("Money");

                    b.HasKey("IdOferta");

                    b.HasIndex("IdSubasta");

                    b.HasIndex("IdSubastaProducto");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Oferta");
                });

            modelBuilder.Entity("TPISubastas.Dominio.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(4096);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("IdProducto");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("TPISubastas.Dominio.Subasta", b =>
                {
                    b.Property<int>("IdSubasta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCierre")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Habilitada")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSubasta");

                    b.ToTable("Subasta");
                });

            modelBuilder.Entity("TPISubastas.Dominio.SubastaProducto", b =>
                {
                    b.Property<int>("IdSubastaProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(4096);

                    b.Property<string>("FormaPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<int>("IdEstadoSubasta")
                        .HasColumnType("int");

                    b.Property<int?>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdSubasta")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioComprador")
                        .HasColumnType("int");

                    b.Property<string>("ImagenProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("MarcaProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<decimal>("MontoInicial")
                        .HasColumnType("Money");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("Notificado")
                        .HasColumnType("bit");

                    b.HasKey("IdSubastaProducto");

                    b.HasIndex("IdEstadoSubasta");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdSubasta");

                    b.ToTable("SubastaProducto");
                });

            modelBuilder.Entity("TPISubastas.Dominio.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Calle")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<string>("CodigoPostal")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("TPISubastas.Dominio.Oferta", b =>
                {
                    b.HasOne("TPISubastas.Dominio.Subasta", null)
                        .WithMany()
                        .HasForeignKey("IdSubasta")
                        .HasConstraintName("FK_Oferta_Subasta")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TPISubastas.Dominio.SubastaProducto", null)
                        .WithMany()
                        .HasForeignKey("IdSubastaProducto")
                        .HasConstraintName("FK_Oferta_SubastaProducto")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TPISubastas.Dominio.Usuario", null)
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_Oferta_Usuario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("TPISubastas.Dominio.SubastaProducto", b =>
                {
                    b.HasOne("TPISubastas.Dominio.EstadoSubasta", null)
                        .WithMany()
                        .HasForeignKey("IdEstadoSubasta")
                        .HasConstraintName("FK_SubastaProducto_EstadoSubasta")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TPISubastas.Dominio.Producto", null)
                        .WithMany()
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("FK_Subasta_Producto")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TPISubastas.Dominio.Subasta", null)
                        .WithMany()
                        .HasForeignKey("IdSubasta")
                        .HasConstraintName("FK_SubastaProducto_Subasta")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
