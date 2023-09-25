using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.DAL.Database.Configurations;

public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
{
	public void Configure(EntityTypeBuilder<ProductItem> builder)
	{
		builder.ToTable("ProductItem");
		builder.HasKey(x => x.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();

		builder.HasOne(x => x.Product)
			.WithMany(c => c.ProductItems).HasForeignKey(x => x.ProductId);

		builder.HasOne(x => x.Size)
			.WithMany(c => c.ProductItems).HasForeignKey(x => x.SizeId);

		builder.HasOne(x => x.Color)
			.WithMany(c => c.ProductItems).HasForeignKey(x => x.ColorId);
	}
}