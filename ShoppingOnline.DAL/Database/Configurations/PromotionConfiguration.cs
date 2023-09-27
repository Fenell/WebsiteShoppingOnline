using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.DAL.Database.Configurations;

public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
	public void Configure(EntityTypeBuilder<Promotion> builder)
	{
		builder.ToTable("Promotion");
		builder.HasKey(x => x.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();
		builder.HasData
				(
					new Promotion()
					{
						Id = new Guid("6DFB12E5-04BC-4680-B953-4B53E8E56CB5"),
						Code = "xxxx-noi-em-anh-chien-de-giam-10%",
						DiscountPercent = 10,
						PromotionStatus = EntityStatus.Active,
						CreatedAt = new DateTime(2023, 09, 21),
						CreatedBy = "Le Xuan Minh Chien"
					}
				);
	}
}