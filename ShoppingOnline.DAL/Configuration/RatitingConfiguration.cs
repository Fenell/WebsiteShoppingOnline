using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Configuration;
public class RatitingConfiguration : IEntityTypeConfiguration<Ratiting>
{
	public void Configure(EntityTypeBuilder<Ratiting> builder)
	{
		builder.HasKey(x => x.Id);
		builder.HasOne(x=>x.Product).WithMany(c=>c.Ratitings).HasForeignKey(x=>x.ProductId);
	}
}
