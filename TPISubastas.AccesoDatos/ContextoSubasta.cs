using System;
using Microsoft.EntityFrameworkCore;
using TPISubastas.Dominio;
namespace TPISubastas.AccesoDatos
{
    public class ContextoSubasta : DbContext
    {
        public ContextoSubasta(DbContextOptions<ContextoSubasta> options) : base(options)
        {
        }



        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Subasta> Subasta { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<EstadoSubasta> EstadoSubasta { get; set; }
        public DbSet<Oferta> Oferta { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>(entity =>
            {
                //entity.ToTable("NombreTabla");
                entity.HasKey(e => e.IdUsuario);
                //entity.Property(e => e.Nombre).HasMaxLength(256).IsRequired();
                //entity.HasMany<Subasta>(e=>e.Subastas).WithOne().HasForeignKey(x => x.IdUsuario).HasConstraintName("FK_Subasta_Usuario");
                //entity.HasMany<Oferta>(o=>o.Ofertas).WithOne().HasForeignKey(x => x.IdUsuario).HasConstraintName("FK_Oferta_Usuario");
                entity.HasMany<Subasta>().WithOne().HasForeignKey(x => x.IdUsuario).HasConstraintName("FK_Subasta_Usuario").OnDelete(DeleteBehavior.NoAction);
                entity.HasMany<Oferta>().WithOne().HasForeignKey(x => x.IdUsuario).HasConstraintName("FK_Oferta_Usuario").OnDelete(DeleteBehavior.NoAction);

            }
            );

            modelBuilder.Entity<Subasta>(entity =>
            {
                entity.HasKey(e => e.IdSubasta);
                entity.Property(x => x.MontoInicial).HasColumnType("Money");
                // entity.HasOne<Usuario>();
                //entity.HasOne<Producto>();
                entity.HasMany<Oferta>().WithOne().HasForeignKey(x => x.IdSubasta).HasConstraintName("FK_Oferta_Subasta").OnDelete(DeleteBehavior.NoAction); 
            }
            );

            modelBuilder.Entity<EstadoSubasta>(entity =>
            {

                entity.HasKey(e => e.IdEstadoSubasta);
                entity.HasMany<Subasta>().WithOne().HasForeignKey(x => x.IdEstadoSubasta).HasConstraintName("FK_Subasta_EstadoSubasta");

            }
           );
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);
                entity.HasMany<Subasta>().WithOne().HasForeignKey(x => x.IdProducto).HasConstraintName("FK_Subasta_Producto");
            }
            );

            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.HasKey(e => e.IdOferta);
                entity.Property(x => x.Monto).HasColumnType("Money");
                //entity.HasOne<Subasta>(s=>s.Subasta);
                //entity.HasOne<Usuario>(u=>u.Usuario);
                // entity.HasOne<Subasta>();
                //entity.HasOne<Usuario>();
            }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
