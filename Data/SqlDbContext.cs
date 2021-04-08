using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebShopApi2.Models;

#nullable disable

namespace WebShopApi2.Data
{
    public partial class SqlDbContext : DbContext
    {
        public SqlDbContext()
        {
        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CartNumber> CartNumbers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductShoppingCart> ProductShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCartList> ShoppingCartLists { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagList> TagLists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CartNumber>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.ColorHex)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ColorName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.AddedDate).HasColumnType("datetime");

                entity.Property(e => e.Image).HasMaxLength(100);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Products__BrandI__2E1BDC42");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__2F10007B");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK__Products__ColorI__2D27B809");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK__Products__SizeId__300424B4");
            });

            modelBuilder.Entity<ProductShoppingCart>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductShoppingCarts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductSh__Produ__3D5E1FD2");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasOne(d => d.ShoppingCartNavigation)
                    .WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.ShoppingCartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingC__Shopp__5AEE82B9");
            });

            modelBuilder.Entity<ShoppingCartList>(entity =>
            {
                entity.HasOne(d => d.CartNumber)
                    .WithMany(p => p.ShoppingCartLists)
                    .HasForeignKey(d => d.CartNumberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingC__CartN__4BAC3F29");

                entity.HasOne(d => d.ProductShoppingCart)
                    .WithMany(p => p.ShoppingCartLists)
                    .HasForeignKey(d => d.ProductShoppingCartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ShoppingC__Produ__5BE2A6F2");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.SizeName)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TagList>(entity =>
            {
                entity.HasOne(d => d.Produt)
                    .WithMany(p => p.TagLists)
                    .HasForeignKey(d => d.ProdutId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TagLists__Produt__33D4B598");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.TagLists)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TagLists__TagId__32E0915F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
