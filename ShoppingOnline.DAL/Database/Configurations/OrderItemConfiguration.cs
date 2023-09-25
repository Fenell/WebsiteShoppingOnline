using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.DAL.Database.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
	public void Configure(EntityTypeBuilder<OrderItem> builder)
	{
		builder.ToTable("OrderItem");
		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();

		builder.HasOne(c => c.Order)
			.WithMany(c => c.OrderItems).HasForeignKey(c => c.OrderId);
		
		builder.HasOne(c => c.ProductItem)
			.WithMany(c => c.OrderItems).HasForeignKey(c => c.ProductItemId);
		
		builder.Property(c => c.Price).HasColumnType("decimal(10,2)");
	}
}