using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SBS.ApplicationCore.Entities;

namespace SBS.Infrastructure.Persistence
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SbsUsuario> SbsUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "GMATOS");

            modelBuilder.Entity<SbsUsuario>(entity =>
            {
                entity.HasKey(e => e.Usuarioid)
                    .HasName("PK_USUARIOID");

                entity.ToTable("SBS_USUARIO");

                entity.Property(e => e.Usuarioid)
                    .HasColumnName("USUARIOID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Activo).HasColumnName("ACTIVO");

                entity.Property(e => e.Alias)
                    .HasColumnName("ALIAS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Apellidomaterno)
                    .IsRequired()
                    .HasColumnName("APELLIDOMATERNO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apellidopaterno)
                    .IsRequired()
                    .HasColumnName("APELLIDOPATERNO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Clavesecreta)
                    .IsRequired()
                    .HasColumnName("CLAVESECRETA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Codigousuario)
                    .IsRequired()
                    .HasColumnName("CODIGOUSUARIO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Primeravezlogin).HasColumnName("PRIMERAVEZLOGIN");

                entity.Property(e => e.Primernombre)
                    .IsRequired()
                    .HasColumnName("PRIMERNOMBRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rolid)
                    .HasColumnName("ROLID")
                    .HasColumnType("NUMBER(2)");

                entity.Property(e => e.Segundonombre)
                    .HasColumnName("SEGUNDONOMBRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
