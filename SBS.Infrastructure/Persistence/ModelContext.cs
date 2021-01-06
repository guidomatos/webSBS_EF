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
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XE)));User Id = gmatos; Password = gmatosc88; Persist Security Info=True");
            }
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
