using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ShoppingOnline.BLL;

public static class BusinessLogicServiceRegistration
{
	public static IServiceCollection AddBusinessLogicLayerService(this IServiceCollection services)
	{
		services.AddAutoMapper(config =>  config.AddExpressionMapping(),
			Assembly.GetExecutingAssembly(), Assembly.GetEntryAssembly());
		
		return services;
	}
}