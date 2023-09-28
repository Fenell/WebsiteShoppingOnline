using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.DAL.Database.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.ToTable("Category");
		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();
		builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
		builder.HasData
				(
					new Category()
					{
						Id = new Guid("5BD691E4-BD41-47C3-BB5B-E23319511841"),
						Name = "Polo",
						Status = EntityStatus.Active,
						CreatedAt = new DateTime(2023, 09, 21),
						CreatedBy = "Le Xuan Minh Chien"
					},
					new Category()
					{
						Id = new Guid("30F958F6-F5B0-4651-8918-5D02F8CB6CEE"),
						Name = "T-Shirt",
						Status = EntityStatus.Active,
						CreatedAt = new DateTime(2023, 09, 21),
						CreatedBy = "Le Xuan Minh Chien"
					}
				);
	}
}