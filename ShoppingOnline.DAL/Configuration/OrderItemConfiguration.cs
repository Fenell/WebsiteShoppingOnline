using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Configuration;
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
	public void Configure(EntityTypeBuilder<OrderItem> builder)
	{
		builder.HasKey(c => c.Id);
		builder.HasOne(c => c.Order).WithMany(c => c.OrderItems).HasForeignKey(c => c.OrderId);
		builder.HasOne(c => c.ProductItem).WithMany(c => c.OrderItems).HasForeignKey(c => c.ProductItemId);
		builder.Property(c => c.Price).HasColumnType("decimal(10,2)");
	}
}
