using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.DAL.Database.Configurations;

public class SlideShowConfiguration:IEntityTypeConfiguration<SlideShow>
{
	public void Configure(EntityTypeBuilder<SlideShow> builder)
	{
		builder.ToTable("SlideShow");
		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();

		builder.Property(c => c.LinkDetail).HasMaxLength(500);
		builder.Property(c => c.ImageUrl).HasMaxLength(500);
	}
}