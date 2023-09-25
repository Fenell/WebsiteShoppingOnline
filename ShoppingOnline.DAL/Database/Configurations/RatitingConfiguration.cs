using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;

namespace ShoppingOnline.DAL.Database.Configurations;

public class RatitingConfiguration : IEntityTypeConfiguration<Ratiting>
{
	public void Configure(EntityTypeBuilder<Ratiting> builder)
	{
		builder.ToTable("Ratiting");
		builder.HasKey(x => x.Id);

		builder.HasOne(x => x.Product)
			.WithMany(c => c.Ratitings).HasForeignKey(x => x.ProductId);
	}
}