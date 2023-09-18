using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Configuration;
public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
	public void Configure(EntityTypeBuilder<ProductImage> builder)
	{
		builder.HasKey(c => c.Id);
		builder.HasOne(c => c.ProductItem).WithMany(c => c.ProductImages).HasForeignKey(c => c.ProducItemtId);
	}
}
