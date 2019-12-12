using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MotoPartsAPI.Models
{
    public partial class MotoPartsContext : DbContext
    {
        public MotoPartsContext()
        {
        }

        public MotoPartsContext(DbContextOptions<MotoPartsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<DirtBikes> DirtBikes { get; set; }
        public virtual DbSet<PartCategories> PartCategories { get; set; }
        public virtual DbSet<Parts> Parts { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:cloud22.database.windows.net,1433;Initial Catalog=MotoParts;Persist Security Info=False;User ID=cloud22;Password=Lighthouse44;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.BrandId);

                entity.Property(e => e.BrandId).HasColumnName("BrandID");

                entity.Property(e => e.BrandDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BrandName)
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId).ValueGeneratedNever();

                entity.Property(e => e.PartFk).HasColumnName("PartFK");

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.Property(e => e.UserFk).HasColumnName("UserFK");

                entity.HasOne(d => d.PartFkNavigation)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.PartFk)
                    .HasConstraintName("FK__Cart__PartFK__6D0D32F4");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.UserFk)
                    .HasConstraintName("FK__Cart__UserFK__6C190EBB");
            });

            modelBuilder.Entity<DirtBikes>(entity =>
            {
                entity.HasKey(e => e.DirtBikeId)
                    .HasName("PK__DirtBike__28ACABC67A2C72CC");

                entity.Property(e => e.Make)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PartCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.PartCategory)
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parts>(entity =>
            {
                entity.HasKey(e => e.PartId)
                    .HasName("PK__Parts__7C3F0D504BC7445A");

                entity.Property(e => e.BrandFk).HasColumnName("BrandFK");

                entity.Property(e => e.CategoryFk).HasColumnName("CategoryFK");

                entity.Property(e => e.DirtBikeFk).HasColumnName("DirtBikeFK");

                entity.Property(e => e.PartDescription)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.PartName)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.BrandFkNavigation)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.BrandFk)
                    .HasConstraintName("FK_Parts_Brands");

                entity.HasOne(d => d.CategoryFkNavigation)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.CategoryFk)
                    .HasConstraintName("FK_Parts_PartCategories");

                entity.HasOne(d => d.DirtBikeFkNavigation)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.DirtBikeFk)
                    .HasConstraintName("FK_Parts_DirtBikes");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C724B12AD");

                entity.Property(e => e.Email)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleFk).HasColumnName("RoleFK");

                entity.Property(e => e.Salt)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(d => d.RoleFkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleFk)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
