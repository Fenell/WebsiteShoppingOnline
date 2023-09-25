using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.DAL.Database.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.ToTable("Product");
		builder.HasKey(x => x.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();
		builder.Property(x => x.Price).HasColumnType("decimal(10,2)");
		

		builder.HasOne(x => x.Brand)
			.WithMany(c => c.Products).HasForeignKey(p => p.BrandId);
		
		builder.HasOne(x => x.Category)
			.WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
	}
}