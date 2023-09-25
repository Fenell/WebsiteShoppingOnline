using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingOnline.DAL.Database.AppDbContext;

namespace ShoppingOnline.DAL;

public static class DataAccessServiceRegistration
{
	public static IServiceCollection AddDataAccessLayerService(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(otp =>
			otp.UseSqlServer(configuration.GetConnectionString("ShoppingOnline")));
		
		return services;
	}
}