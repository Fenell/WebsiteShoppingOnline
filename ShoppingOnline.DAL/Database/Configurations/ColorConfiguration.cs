using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
	}
}
