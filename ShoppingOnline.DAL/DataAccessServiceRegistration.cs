using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ShoppingOnline.DAL;

public static class DataAccessServiceRegistration
{
	public static IServiceCollection AddDataAccessLayerService(this IServiceCollection services, IConfiguration configuration)
	{
		return services;
	}
}