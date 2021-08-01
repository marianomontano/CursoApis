using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApi.Models
{
	public partial class NorthwindContext : DbContext
	{
		public NorthwindContext()
		{
		}

		public NorthwindContext(DbContextOptions<NorthwindContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Categories> Categories { get; set; }
		public virtual DbSet<Suppliers> Suppliers { get; set; }
		public virtual DbSet<Products> Products { get; set; }
		public virtual DbSet<Shippers> Shippers { get; set; }
		public virtual DbSet<Region> Region { get; set; }
		public virtual DbSet<LoginUsuarios> LoginUsuarios { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Shippers>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.Id).HasColumnName("ShipperID");

				entity.Property(e => e.CompanyName)
					.IsRequired()
					.HasMaxLength(40);

				entity.Property(e => e.Phone).HasMaxLength(24);
			});

			modelBuilder.Entity<Region>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.Id).HasColumnName("RegionID");

				entity.Property(e => e.RegionDescription)
					.IsRequired()
					.HasMaxLength(50);
			});

			modelBuilder.Entity<LoginUsuarios>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.Property(e => e.Id).HasColumnName("Id");

				entity.Property(e => e.Usuario)
				.IsRequired();

				entity.Property(e => e.Clave)
				.IsRequired();

				entity.Property(e => e.Apellido);

				entity.Property(e => e.Nombre);

				entity.Property(e => e.Email);

			});

			modelBuilder.Entity<Categories>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.HasIndex(e => e.CategoryName)
					.HasName("CategoryName");

				entity.Property(e => e.Id).HasColumnName("CategoryID");

				entity.Property(e => e.CategoryName)
					.IsRequired()
					.HasMaxLength(15);

				entity.Property(e => e.Description).HasColumnType("ntext");

				entity.Property(e => e.Picture).HasColumnType("image");
			});

			modelBuilder.Entity<Products>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.HasIndex(e => e.CategoryId)
					.HasName("CategoryID");

				entity.HasIndex(e => e.ProductName)
					.HasName("ProductName");

				entity.HasIndex(e => e.SupplierId)
					.HasName("SuppliersProducts");

				entity.Property(e => e.Id).HasColumnName("ProductID");

				entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

				entity.Property(e => e.ProductName)
					.IsRequired()
					.HasMaxLength(40);

				entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);

				entity.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");

				entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

				entity.Property(e => e.UnitPrice)
					.HasColumnType("money")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.UnitsInStock).HasDefaultValueSql("((0))");

				entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("((0))");

				entity.HasOne(d => d.Category)
					.WithMany(p => p.Products)
					.HasForeignKey(d => d.CategoryId)
					.HasConstraintName("FK_Products_Categories");

				entity.HasOne(d => d.Supplier)
					.WithMany(p => p.Products)
					.HasForeignKey(d => d.SupplierId)
					.HasConstraintName("FK_Products_Suppliers");
			});

			modelBuilder.Entity<Suppliers>(entity =>
			{
				entity.HasKey(e => e.Id);

				entity.HasIndex(e => e.CompanyName)
					.HasName("CompanyName");

				entity.HasIndex(e => e.PostalCode)
					.HasName("PostalCode");

				entity.Property(e => e.Id).HasColumnName("SupplierID");

				entity.Property(e => e.Address).HasMaxLength(60);

				entity.Property(e => e.City).HasMaxLength(15);

				entity.Property(e => e.CompanyName)
					.IsRequired()
					.HasMaxLength(40);

				entity.Property(e => e.ContactName).HasMaxLength(30);

				entity.Property(e => e.ContactTitle).HasMaxLength(30);

				entity.Property(e => e.Country).HasMaxLength(15);

				entity.Property(e => e.Fax).HasMaxLength(24);

				entity.Property(e => e.HomePage).HasColumnType("ntext");

				entity.Property(e => e.Phone).HasMaxLength(24);

				entity.Property(e => e.PostalCode).HasMaxLength(10);

				entity.Property(e => e.Region).HasMaxLength(15);
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
