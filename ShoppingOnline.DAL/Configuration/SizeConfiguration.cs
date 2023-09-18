﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingOnline.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL.Configuration;
public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
	public void Configure(EntityTypeBuilder<Size> builder)
	{
		builder.HasKey(x => x.Id);
	}
}
