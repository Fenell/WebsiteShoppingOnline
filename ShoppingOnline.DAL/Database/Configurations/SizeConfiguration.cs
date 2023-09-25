using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
	}
}