using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Constants;
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
		builder.HasData
				(
					new Product()
					{
						Id = new Guid("38E3F05F-F89A-4FB3-8CB7-9262110D7D16"),
						CategoryId = new Guid("5BD691E4-BD41-47C3-BB5B-E23319511841"),
						BrandId = new Guid("313E7A81-9B89-4981-8389-477CB23CFABB"),
						Name = "Regular.XL.2.3131",
						Price = 259000,
						Discount = 275000,
						Description = "- Được kiểm tra hàng trước khi nhận hàng" +
									  "- Đổi hàng trong vòng 30 ngày kể từ khi nhận hàng",
						Status = EntityStatus.Active,
						CreatedAt = new DateTime(2023, 09, 21),
						CreatedBy = "Le Xuan Minh Chien"
					},
					new Product()
					{
						Id = new Guid("4DCCADDC-9DBC-4F6D-A6C8-244BE05D735F"),
						CategoryId = new Guid("30F958F6-F5B0-4651-8918-5D02F8CB6CEE"),
						BrandId = new Guid("D80CD77C-A89B-4FF2-8F60-20BFE056C2ED"),
						Name = "Regular L.3.2987",
						Price = 339000,
						Discount = 275000,
						Description = "- Được kiểm tra hàng trước khi nhận hàng" +
									  "- Đổi hàng trong vòng 30 ngày kể từ khi nhận hàng",
						Status = EntityStatus.Active,
						CreatedAt = new DateTime(2023, 09, 21),
						CreatedBy = "Le Xuan Minh Chien"
					}
				);
	}
}