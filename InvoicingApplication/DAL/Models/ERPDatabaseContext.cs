using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Models
{
    public partial class ERPDatabaseContext : DbContext
    {
        public ERPDatabaseContext()
        {
        }

        public ERPDatabaseContext(DbContextOptions<ERPDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<InvoiceHeader> InvoiceHeader { get; set; }
        public virtual DbSet<InvoicePosition> InvoicePosition { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Vat> Vat { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<WarehouseDocumentHeader> WarehouseDocumentHeader { get; set; }
        public virtual DbSet<WarehouseDocumentPosition> WarehouseDocumentPosition { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=ERPDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<InvoiceHeader>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("UQ__InvoiceH__3214EC06084508AF")
                    .IsUnique();

                entity.HasIndex(e => e.IdBuyer)
                    .HasName("InvoiceHeader_idx_IdBuyer");

                entity.HasIndex(e => e.IdSeller)
                    .HasName("InvoiceHeader_idx_IdSeller");

                entity.HasIndex(e => e.PaymentDate)
                    .HasName("InvoiceHeader_idx_PaymentDate");

                entity.HasOne(d => d.IdBuyerNavigation)
                    .WithMany(p => p.InvoiceHeaderIdBuyerNavigation)
                    .HasForeignKey(d => d.IdBuyer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InvoiceHeader_fk");

                entity.HasOne(d => d.IdSellerNavigation)
                    .WithMany(p => p.InvoiceHeaderIdSellerNavigation)
                    .HasForeignKey(d => d.IdSeller)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InvoiceHeader_fk2");
            });

            modelBuilder.Entity<InvoicePosition>(entity =>
            {
                entity.HasIndex(e => e.IdProduct)
                    .HasName("InvoicePosition_idx_IdProduct");

                entity.HasIndex(e => e.IdVat)
                    .HasName("InvoicePosition_idx_IdVat");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("numeric(12, 4)");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Value).HasColumnType("money");

                entity.HasOne(d => d.IdHeaderNavigation)
                    .WithMany(p => p.InvoicePosition)
                    .HasForeignKey(d => d.IdHeader)
                    .HasConstraintName("Position_fk2");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.InvoicePosition)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Position_fk");

                entity.HasOne(d => d.IdVatNavigation)
                    .WithMany(p => p.InvoicePosition)
                    .HasForeignKey(d => d.IdVat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Position_fk3");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Vat>(entity =>
            {
                entity.ToTable("VAT");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PayRate).HasColumnType("numeric(3, 1)");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.Warehouse)
                    .HasForeignKey(d => d.IdOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Warehouse_fk");
            });

            modelBuilder.Entity<WarehouseDocumentHeader>(entity =>
            {
                entity.HasIndex(e => e.DocumentDate)
                    .HasName("whdHdrIndxDocDate");

                entity.HasIndex(e => e.IdContractor)
                    .HasName("WarehouseDocumentHeader_idx_IdContractor");

                entity.HasIndex(e => e.IdIssuer)
                    .HasName("WarehouseDocumentHeader_idx_IdIssuer");

                entity.HasIndex(e => e.IdWarehouse)
                    .HasName("WarehouseDocumentHeader_idx_IdWarehouse");

                entity.HasIndex(e => e.IssueDate)
                    .HasName("WarehouseDocumentHeader_idx_IssueDate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdContractorNavigation)
                    .WithMany(p => p.WarehouseDocumentHeaderIdContractorNavigation)
                    .HasForeignKey(d => d.IdContractor)
                    .HasConstraintName("WarehouseDocumentHeader_fk2");

                entity.HasOne(d => d.IdIssuerNavigation)
                    .WithMany(p => p.WarehouseDocumentHeaderIdIssuerNavigation)
                    .HasForeignKey(d => d.IdIssuer)
                    .HasConstraintName("WarehouseDocumentHeader_fk");

                entity.HasOne(d => d.IdWarehouseNavigation)
                    .WithMany(p => p.WarehouseDocumentHeader)
                    .HasForeignKey(d => d.IdWarehouse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("WarehouseDocumentHeader_fk3");
            });

            modelBuilder.Entity<WarehouseDocumentPosition>(entity =>
            {
                entity.HasIndex(e => e.IdInvoicePosition)
                    .HasName("WarehouseDocumentPosition_idx_IdInvoicePosition");

                entity.HasIndex(e => e.IdProduct)
                    .HasName("WarehouseDocumentPosition_idx_IdProduct");

                entity.HasIndex(e => e.IdWarehouseDocumentHeader)
                    .HasName("WarehouseDocumentPosition_idx_IdWarehouseDocumentHeader");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("numeric(12, 4)");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.IdInvoicePositionNavigation)
                    .WithMany(p => p.WarehouseDocumentPosition)
                    .HasForeignKey(d => d.IdInvoicePosition)
                    .HasConstraintName("WarehouseDocumentPosition_fk2");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.WarehouseDocumentPosition)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("WarehouseDocumentPosition_fk");

                entity.HasOne(d => d.IdWarehouseDocumentHeaderNavigation)
                    .WithMany(p => p.WarehouseDocumentPosition)
                    .HasForeignKey(d => d.IdWarehouseDocumentHeader)
                    .HasConstraintName("IdWarehouseDocumentHeader");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
