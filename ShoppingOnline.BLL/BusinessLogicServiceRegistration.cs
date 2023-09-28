using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;
using ShoppingOnline.BLL.Features.ColorFeature;
using ShoppingOnline.BLL.Features.SizeFeature;
using System.Reflection;

namespace ShoppingOnline.BLL;

public static class BusinessLogicServiceRegistration
{
	public static IServiceCollection AddBusinessLogicLayerService(this IServiceCollection services)
	{
		services.AddAutoMapper(config =>  config.AddExpressionMapping(),
			Assembly.GetExecutingAssembly(), Assembly.GetEntryAssembly());
		

		services.AddScoped<IColorService, ColorService>();
		services.AddScoped<ISizeService, SizeService>();
		return services;
	}
}