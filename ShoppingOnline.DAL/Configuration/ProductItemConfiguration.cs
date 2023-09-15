using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Configuration;
public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
{
	public void Configure(EntityTypeBuilder<ProductItem> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasOne(x => x.Product).WithMany(c => c.ProductItems).HasForeignKey(x => x.ProductId);
		builder.HasOne(x => x.Size).WithMany(c => c.ProductItems).HasForeignKey(x => x.SizeId);
		builder.HasOne(x => x.Color).WithMany(c => c.ProductItems).HasForeignKey(x => x.ColorId);
	}
}
