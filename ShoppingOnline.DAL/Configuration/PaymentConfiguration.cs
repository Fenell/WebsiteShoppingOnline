using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Configuration;
public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
	public void Configure(EntityTypeBuilder<Payment> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasOne(c => c.Order).WithOne(c => c.Payment).HasForeignKey<Payment>(c => c.OrderId);
		builder.Property(c => c.Amount).HasColumnType("decimal(10,2)");
	}
}
