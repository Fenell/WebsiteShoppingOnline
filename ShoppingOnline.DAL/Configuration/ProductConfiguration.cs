using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Configuration;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasOne(x => x.Brand).WithMany(c => c.Products).HasForeignKey(p => p.BrandId);
		builder.HasOne(x => x.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
		builder.Property(x => x.Price).HasColumnType("decimal(10,2)");
	}
}
