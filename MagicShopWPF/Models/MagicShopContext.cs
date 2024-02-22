using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MagicShopWPF.Models;

public partial class MagicShopContext : DbContext
{
    public MagicShopContext()
    {
    }

    public MagicShopContext(DbContextOptions<MagicShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Mage> Mages { get; set; }

    public virtual DbSet<MageRole> MageRoles { get; set; }

    public virtual DbSet<MagicProduct> MagicProducts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-D0U93NL\\SQLEXPRESS; Database=MagicShop; Integrated Security = true; TrustServerCertificate = true ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NumberPhone).HasMaxLength(20);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
        });

        modelBuilder.Entity<Mage>(entity =>
        {
            entity.HasKey(e => e.MageId).HasName("PK_User");

            entity.ToTable("Mage");

            entity.Property(e => e.MageId).HasColumnName("MageID");
            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Mages)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_User_UserRole");
        });

        modelBuilder.Entity<MageRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_UserRole");

            entity.ToTable("MageRole");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
        });

        modelBuilder.Entity<MagicProduct>(entity =>
        {
            entity.ToTable("MagicProduct");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.HasOne(d => d.Category).WithMany(p => p.MagicProducts)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_MagicProduct_Categories");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.MageId).HasColumnName("MageID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_Order_Clients");

            entity.HasOne(d => d.Mage).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MageId)
                .HasConstraintName("FK_Order_Mage");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Order_MagicProduct");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
