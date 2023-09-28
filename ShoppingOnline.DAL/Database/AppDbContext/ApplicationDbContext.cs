using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.DAL.Entities;
using ShoppingOnline.DAL.Entities.Identity;
using System.Reflection;

namespace ShoppingOnline.DAL.Database.AppDbContext;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	
	public ApplicationDbContext(DbContextOptions options) : base(options)
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
	


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		base.OnModelCreating(modelBuilder);
	}
}
