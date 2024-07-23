using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bluesoftbank.Models;

public partial class BluesoftBankContext : DbContext
{
    public BluesoftBankContext()
    {
    }

    public BluesoftBankContext(DbContextOptions<BluesoftBankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    public virtual DbSet<Tipodemovimiento> Tipodemovimientos { get; set; }

    public virtual DbSet<Tipodepersona> Tipodepersonas { get; set; }

    public virtual DbSet<Tiposdecuenta> Tiposdecuenta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-56QVMV6\\SQLEXPRESS;Database=BluesoftBank;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("CLIENTES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Saldo).HasColumnName("SALDO");
            entity.Property(e => e.Tipodecuenta).HasColumnName("TIPODECUENTA");
            entity.Property(e => e.Tipodepersona).HasColumnName("TIPODEPERSONA");

            entity.HasOne(d => d.TipodepersonaNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Tipodepersona)
                .HasConstraintName("FK_CLIENTES_TIPODEPERSONA");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.ToTable("MOVIMIENTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.Idcliente).HasColumnName("IDCLIENTE");
            entity.Property(e => e.Tipodemovimiento).HasColumnName("TIPODEMOVIMIENTO");
            entity.Property(e => e.Valor).HasColumnName("VALOR");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.Idcliente)
                .HasConstraintName("FK_MOVIMIENTO_CLIENTES");
        });

        modelBuilder.Entity<Tipodemovimiento>(entity =>
        {
            entity.ToTable("TIPODEMOVIMIENTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DebitoCredito)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DEBITO_CREDITO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Tipodepersona>(entity =>
        {
            entity.ToTable("TIPODEPERSONA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Tipodepersona1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TIPODEPERSONA");
        });

        modelBuilder.Entity<Tiposdecuenta>(entity =>
        {
            entity.ToTable("TIPOSDECUENTA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
