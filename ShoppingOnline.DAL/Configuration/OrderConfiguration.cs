using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Configuration;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.HasKey(c => c.Id);
		builder.HasOne(c => c.Promotion).WithMany(c => c.Orders).HasForeignKey(c => c.PromotionId);
		builder.Property(c => c.Total).HasColumnType("decimal(10,2)");
	}
}
