using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.DAL.Database.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
	public void Configure(EntityTypeBuilder<Brand> builder)
	{
		builder.ToTable("Brand");
		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();
		builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
	}
}