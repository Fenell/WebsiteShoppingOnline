using Microsoft.EntityFrameworkCore;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.EF;
public class ShoppingOnlineDbContext : DbContext
{
	public ShoppingOnlineDbContext(DbContextOptions options) : base(options)
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
	public DbSet<Payment> Payments { get; set; }
	public DbSet<Promotion> Promotions { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		base.OnModelCreating(modelBuilder);
	}
}
