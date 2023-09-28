using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Constants;
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
		builder.HasData
			   (
				   new Brand()
				   {
					   Id = new Guid("313E7A81-9B89-4981-8389-477CB23CFABB"),
					   Name = "Adias",
					   Status = EntityStatus.Active,
					   CreatedAt = new DateTime(2023, 09, 21),
					   CreatedBy = "Le Xuan Minh Chien"
				   },
				   new Brand()
				   {
					   Id = new Guid("D80CD77C-A89B-4FF2-8F60-20BFE056C2ED"),
					   Name = "Nike",
					   Status = EntityStatus.Active,
					   CreatedAt = new DateTime(2023, 09, 21),
					   CreatedBy = "Le Xuan Minh Chien"
				   }
			   );
	}
}