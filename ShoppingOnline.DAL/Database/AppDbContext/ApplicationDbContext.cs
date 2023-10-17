using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Entities.Common;
using ShoppingOnline.DAL.Entities.Identity;
using ShoppingOnline.DAL.Repositories.Identity;
using System.Reflection;

namespace ShoppingOnline.DAL.Database.AppDbContext;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public DbSet<Product> Products { get; set; }
	public DbSet<ProductItem> ProductItems { get; set; }
	public DbSet<ProductImage> ProductImages { get; set; }
	public DbSet<Brand> Brands { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Color> Colors { get; set; }
	public DbSet<Size> Sizes { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderItem> OrderItems { get; set; }
	public DbSet<Ratiting> Ratitings { get; set; }
	public DbSet<Promotion> Promotions { get; set; }
	public DbSet<SlideShow> SlideShows { get; set; }

	public string? CurrentUserId;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		base.OnModelCreating(modelBuilder);
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
	{
		foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
					 .Where(c => c.State is EntityState.Added or EntityState.Modified))
		{
			if (entry.State == EntityState.Added)
			{
				entry.Entity.CreatedAt = DateTime.Now;
				entry.Entity.CreatedBy = CurrentUserId;
			}

			if (entry.State == EntityState.Modified)
			{
				entry.Entity.UpdateAt = DateTime.Now;
				entry.Entity.UpdateBy = CurrentUserId;
			}
		}

		return base.SaveChangesAsync(cancellationToken);
	}
}
