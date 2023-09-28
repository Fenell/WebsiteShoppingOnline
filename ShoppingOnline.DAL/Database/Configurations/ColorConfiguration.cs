using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.DAL.Database.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
	public void Configure(EntityTypeBuilder<Color> builder)
	{
		builder.ToTable("Color");
		builder.HasKey(x => x.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();

		builder.Property(c => c.Name).HasMaxLength(20);
		builder.HasData
				(
					new Color()
					{
						Id = new Guid("A0097F6C-3C63-4A8B-875A-80E0ADFB4891"),
						Name = "Đen",
						Status = EntityStatus.Active,
						CreatedAt = new DateTime(2023, 09, 21),
						CreatedBy = "Le Xuan Minh Chien"
					},
					new Color()
					{
						Id = new Guid("64718A33-4E12-4310-BFA6-459A3B03BAC5"),
						Name = "Trắng",
						Status = EntityStatus.Active,
						CreatedAt = new DateTime(2023, 09, 21),
						CreatedBy = "Le Xuan Minh Chien"
					}
				);
	}
}
