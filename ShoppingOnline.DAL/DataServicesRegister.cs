using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingOnline.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingOnline.DAL;
public static class DataServicesRegister
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ShoppingOnlineDbContext>(otp =>
			otp.UseSqlServer(configuration.GetConnectionString("ShoppingOnline")));

		return services;
	}
}
