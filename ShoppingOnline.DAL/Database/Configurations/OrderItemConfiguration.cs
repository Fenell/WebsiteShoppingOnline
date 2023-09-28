using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Constants;
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
		builder.HasData
				(
					new OrderItem()
					{
						Id = new Guid("D2DDA39F-B2A0-467F-970D-1F9DED874AA0"),
						OrderId = new Guid("46B23FC3-BF12-4104-8785-D650360181ED"),
						ProductItemId = new Guid("18EC90BF-8932-4A59-BBB2-34DE95CE9602"),
						Price = 259000,
						OrderStatus = EntityStatus.Success,
						Quantity = 1,
						CreatedAt = new DateTime(2023, 09, 21),
						CreatedBy = "Le Xuan Minh Chien"
					}
				);
	}
}