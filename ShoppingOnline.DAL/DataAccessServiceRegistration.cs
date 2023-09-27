using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Repositories.Implement;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.DAL;

public static class DataAccessServiceRegistration
{
	public static IServiceCollection AddDataAccessLayerService(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(otp =>
			otp.UseSqlServer(configuration.GetConnectionString("ShoppingOnline")));

		services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
		services.AddScoped<IProductRepository, ProductRepository>();


		return services;
	}
}