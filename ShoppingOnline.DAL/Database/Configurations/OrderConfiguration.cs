using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.DAL.Database.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.ToTable("Order");
		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();
		builder.Property(c => c.Total).HasColumnType("decimal(10,2)");
		builder.Property(c => c.Address).HasMaxLength(500);
		builder.Property(c => c.CustomerName).HasMaxLength(100);
		builder.Property(c => c.PhoneNumber).HasMaxLength(13);
		
		
		builder.HasOne(c => c.Promotion)
			.WithMany(c => c.Orders).HasForeignKey(c => c.PromotionId);
	}
}
