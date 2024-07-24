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

            entity.Property(e => e.id).HasColumnName("ID");
            entity.Property(e => e.nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.saldo).HasColumnName("SALDO");
            entity.Property(e => e.tipodecuenta).HasColumnName("TIPODECUENTA");
            entity.Property(e => e.tipodepersona).HasColumnName("TIPODEPERSONA");

           
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.ToTable("MOVIMIENTO");

            entity.Property(e => e.id).HasColumnName("ID");
            entity.Property(e => e.fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.idcliente).HasColumnName("IDCLIENTE");
            entity.Property(e => e.tipodemovimiento).HasColumnName("TIPODEMOVIMIENTO");
            entity.Property(e => e.valor).HasColumnName("VALOR");
            entity.Property(e => e.movimientolocal).HasColumnName("movimientolocal");
            entity.Property(e => e.mensajedeerror).HasColumnName("mensajedeerror");
            entity.Property(e => e.nombrecliente).HasColumnName("nombrecliente");
            entity.Property(e => e.movimientodebitoocredito).HasColumnName("movimientodebitoocredito");
            entity.Property(e => e.nombremovimiento).HasColumnName("nombremovimiento");




        });

        modelBuilder.Entity<Tipodemovimiento>(entity =>
        {
            entity.ToTable("TIPODEMOVIMIENTO");

            entity.Property(e => e.id).HasColumnName("ID");
            entity.Property(e => e.debitocredito)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DEBITO_CREDITO");
            entity.Property(e => e.nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Tipodepersona>(entity =>
        {
            entity.ToTable("TIPODEPERSONA");

            entity.Property(e => e.id).HasColumnName("ID");
            entity.Property(e => e.tipodepersona)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TIPODEPERSONA");
        });

        modelBuilder.Entity<Tiposdecuenta>(entity =>
        {
            entity.ToTable("TIPOSDECUENTA");

            entity.Property(e => e.id).HasColumnName("ID");
            entity.Property(e => e.nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
