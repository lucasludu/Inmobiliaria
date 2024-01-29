using Inmobiliaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Inmobiliaria.Data
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Propiedad> Propiedads { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<TipoPropiedad> TipoPropiedads { get; set; } = null!;
        public virtual DbSet<TipoTransaccion> TipoTransaccions { get; set; } = null!;
        public virtual DbSet<Transaccion> Transaccions { get; set; } = null!;
        public virtual DbSet<Ubicacion> Ubicacions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("pk_Estado");

                entity.ToTable("Estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Propiedad>(entity =>
            {
                entity.HasKey(e => e.IdPropiedad)
                    .HasName("Pk_Propiedad");

                entity.ToTable("Propiedad");

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Propiedads)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Propiedad_Estado");

                entity.HasOne(d => d.IdTipoPropiedadNavigation)
                    .WithMany(p => p.Propiedads)
                    .HasForeignKey(d => d.IdTipoPropiedad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Propiedad_TipoPropiedad");

                entity.HasOne(d => d.IdUbicacionNavigation)
                    .WithMany(p => p.Propiedads)
                    .HasForeignKey(d => d.IdUbicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Propiedad_Ubicacion");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("pk_Rol");

                entity.ToTable("Rol");

                entity.Property(e => e.RolName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPropiedad>(entity =>
            {
                entity.HasKey(e => e.IdTipoPropiedad)
                    .HasName("pk_tipoPropiedad");

                entity.ToTable("TipoPropiedad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoTransaccion>(entity =>
            {
                entity.HasKey(e => e.IdTipoTransaccion)
                    .HasName("Pk_TipoTransaccion");

                entity.ToTable("TipoTransaccion");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaccion>(entity =>
            {
                entity.HasKey(e => e.IdTransaccion)
                    .HasName("Pk_Transaccion");

                entity.ToTable("Transaccion");

                entity.Property(e => e.FechaTransaccion).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdPropiedadNavigation)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.IdPropiedad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Transaccion_Propiedad");

                entity.HasOne(d => d.IdTipoTransaccionNavigation)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.IdTipoTransaccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fK_Transaccion_TipoTransaccion");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Transaccion_Usuario");
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasKey(e => e.IdUbicacion)
                    .HasName("pk_Ubicacion");

                entity.ToTable("Ubicacion");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("pk_Usuario");

                entity.ToTable("Usuario");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
