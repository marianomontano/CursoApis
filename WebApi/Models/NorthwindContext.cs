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

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
