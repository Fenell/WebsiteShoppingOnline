using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Constants;
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
		builder.HasData
				(
					new ProductItem()
					{
						Id = new Guid("18EC90BF-8932-4A59-BBB2-34DE95CE9602"),
						ProductId = new Guid("38E3F05F-F89A-4FB3-8CB7-9262110D7D16"),
						SizeId = new Guid("3F12E4D9-0E48-4C32-B788-7769D2BE7B2C"),
						ColorId = new Guid("A0097F6C-3C63-4A8B-875A-80E0ADFB4891"),
						Quantity = 1,
						Status = EntityStatus.Active,
						CreatedAt = new DateTime(2023, 09, 21),
						CreatedBy = "Le Xuan Minh Chien"
					},
					new ProductItem()
					{
						Id = new Guid("3C0915DB-2BCF-47F9-BE6E-F39BC127ABCA"),
						ProductId = new Guid("4DCCADDC-9DBC-4F6D-A6C8-244BE05D735F"),
						SizeId = new Guid("3F12E4D9-0E48-4C32-B788-7769D2BE7B2C"),
						ColorId = new Guid("A0097F6C-3C63-4A8B-875A-80E0ADFB4891"),
						Quantity = 1,
						Status = EntityStatus.Active,
						CreatedAt = new DateTime(2023, 09, 21),
						CreatedBy = "Le Xuan Minh Chien"
					}
				);
	}
}