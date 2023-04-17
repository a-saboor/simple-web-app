using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Proj9.DAL.Entities
{
    public partial class DB9Context : DbContext
    {
        public DB9Context()
        {
        }

        public DB9Context(DbContextOptions<DB9Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ItemCategory> ItemCategorys { get; set; }
        public virtual DbSet<ItemMaster> ItemMasters { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual DbSet<PurchaseMaster> PurchaseMasters { get; set; }
        public virtual DbSet<ReturnDetail> ReturnDetails { get; set; }
        public virtual DbSet<ReturnMaster> ReturnMasters { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }
        public virtual DbSet<SaleMaster> SaleMasters { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=DB9;User ID=sa;Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Contact)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<ItemMaster>(entity =>
            {
                entity.HasIndex(e => e.ItemCat, "IX_ItemMasters_ItemCat");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PurRate).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SaleRate).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.ItemCatNavigation)
                    .WithMany(p => p.ItemMasters)
                    .HasForeignKey(d => d.ItemCat);
            });

            modelBuilder.Entity<PurchaseDetail>(entity =>
            {
                entity.HasIndex(e => e.ItemMasterId, "IX_PurchaseDetails_ItemMasterID");

                entity.HasIndex(e => e.PurchaseMasterId, "IX_PurchaseDetails_PurchaseMasterID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItemMasterId).HasColumnName("ItemMasterID");

                entity.Property(e => e.PurchaseMasterId).HasColumnName("PurchaseMasterID");

                entity.HasOne(d => d.ItemMaster)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.ItemMasterId);

                entity.HasOne(d => d.PurchaseMaster)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.PurchaseMasterId);
            });

            modelBuilder.Entity<PurchaseMaster>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TotalAmt).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<ReturnDetail>(entity =>
            {
                entity.HasIndex(e => e.ItemMasterId, "IX_ReturnDetails_ItemMasterID");

                entity.HasIndex(e => e.ReturnMasterId, "IX_ReturnDetails_ReturnMasterID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItemMasterId).HasColumnName("ItemMasterID");

                entity.Property(e => e.ReturnMasterId).HasColumnName("ReturnMasterID");

                entity.HasOne(d => d.ItemMaster)
                    .WithMany(p => p.ReturnDetails)
                    .HasForeignKey(d => d.ItemMasterId);

                entity.HasOne(d => d.ReturnMaster)
                    .WithMany(p => p.ReturnDetails)
                    .HasForeignKey(d => d.ReturnMasterId);
            });

            modelBuilder.Entity<ReturnMaster>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TotalAmt).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.HasIndex(e => e.ItemMasterId, "IX_SaleDetails_ItemMasterID");

                entity.HasIndex(e => e.SaleMasterId, "IX_SaleDetails_SaleMasterID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ItemMasterId).HasColumnName("ItemMasterID");

                entity.Property(e => e.SaleMasterId).HasColumnName("SaleMasterID");

                entity.HasOne(d => d.ItemMaster)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.ItemMasterId);

                entity.HasOne(d => d.SaleMaster)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.SaleMasterId);
            });

            modelBuilder.Entity<SaleMaster>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TotalAmt).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.About)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
