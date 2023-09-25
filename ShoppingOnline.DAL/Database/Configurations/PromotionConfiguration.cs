using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.DAL.Database.Configurations;

public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
{
	public void Configure(EntityTypeBuilder<Promotion> builder)
	{
		builder.ToTable("Promotion");
		builder.HasKey(x => x.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();
	}
}