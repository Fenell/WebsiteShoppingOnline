using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Constants;
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
		builder.HasData
			   (
				   new Order()
				   {
					   Id = new Guid("46B23FC3-BF12-4104-8785-D650360181ED"),
					   PromotionId = new Guid("6DFB12E5-04BC-4680-B953-4B53E8E56CB5"),
					   CustomerName = "Mai Tuan Dat",
					   Address = "Thai Binh",
					   PhoneNumber = "1234567890",
					   Note = "Khach vip",
					   Total = 259000,
					   OrderStatus = EntityStatus.Success,
					   CreatedAt = new DateTime(2023, 09, 21),
					   CreatedBy = "Le Xuan Minh Chien"
				   }
			   );
	}
}
