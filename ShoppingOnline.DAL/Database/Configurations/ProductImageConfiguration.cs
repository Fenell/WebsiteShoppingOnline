using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.DAL.Database.Configurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
	public void Configure(EntityTypeBuilder<ProductImage> builder)
	{
		builder.ToTable("ProductImage");
		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();

		builder.HasOne(c => c.ProductItem)
			.WithMany(c => c.ProductImages).HasForeignKey(c => c.ProducItemtId);
	}
}