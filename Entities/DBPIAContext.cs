using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoExcel.Entities
{
    public partial class DBPIAContext : DbContext
    {
        public DBPIAContext()
        {
        }

        public DBPIAContext(DbContextOptions<DBPIAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Presupuestoegreso> Presupuestoegresos { get; set; } = null!;
        public virtual DbSet<Relacionanexo> Relacionanexos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS01; DataBase=DBPIA;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Presupuestoegreso>(entity =>
            {
                entity.HasKey(e => e.IdPresupuestoEgreso)
                    .HasName("PK__PRESUPUE__E25176C79052E482");

                entity.ToTable("PRESUPUESTOEGRESOS");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.E1aAmpPres)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("E_1A_AmpPres");

                entity.Property(e => e.E2aAmpPres)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("E_2A_AmpPres");

                entity.Property(e => e.E3aAmpPres)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("E_3A_AmpPres");

                entity.Property(e => e.EPreComp)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("E_PreComp");

                entity.Property(e => e.EPreCons)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("E_PreCons");

                entity.Property(e => e.EPreDev)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("E_PreDev");

                entity.Property(e => e.EPreEjer)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("E_PreEjer");

                entity.Property(e => e.EPreErog)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("E_PreErog");

                entity.Property(e => e.EPreModif)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("E_PreModif");

                entity.Property(e => e.EPreOrigApro)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("E_PreOrigApro");

                entity.Property(e => e.EPrePorEjer)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("E_PrePorEjer");

                entity.Property(e => e.ETotAmp)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("E_Tot_Amp");

                entity.Property(e => e.FechaCorte)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IPreDev)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("I_PreDev");

                entity.Property(e => e.IPreEstim)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("I_PreEstim");

                entity.Property(e => e.IPreMod)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("I_PreMod");

                entity.Property(e => e.IPreReca)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("I_PreReca");

                entity.Property(e => e.Secretaria)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Relacionanexo>(entity =>
            {
                entity.ToTable("RELACIONANEXOS");

                entity.Property(e => e.Aplica)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Articulo)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NombreAnexo)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Seccion)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
