using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Constants;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.DAL.Database.Configurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
	public void Configure(EntityTypeBuilder<Size> builder)
	{
		builder.ToTable("Size");
		builder.HasKey(x => x.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();
		builder.Property(c => c.Name).HasMaxLength(10);
		builder.HasData
				(
					new Size()
					{
						Id = new Guid("3F12E4D9-0E48-4C32-B788-7769D2BE7B2C"),
						Name = "XL",
						Status = EntityStatus.Active,
						CreatedAt = new DateTime(2023, 09, 21),
						CreatedBy = "Le Xuan Minh Chien"
					},
					new Size()
					{
						Id = new Guid("468A7E91-42A7-4E09-9834-D3BC0CE2C2F5"),
						Name = "M",
						Status = EntityStatus.Active,
						CreatedAt = new DateTime(2023, 09, 21),
						CreatedBy = "Le Xuan Minh Chien"
					}
				);
	}
}