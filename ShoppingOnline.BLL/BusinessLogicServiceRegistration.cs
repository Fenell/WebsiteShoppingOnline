using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;
using ShoppingOnline.DAL.Repositories.Implement;
using ShoppingOnline.DAL.Repositories.Interface;
using System.Reflection;

namespace ShoppingOnline.BLL;

public static class BusinessLogicServiceRegistration
{
	public static IServiceCollection AddBusinessLogicLayerService(this IServiceCollection services)
	{
		services.AddAutoMapper(config => config.AddExpressionMapping(),
			Assembly.GetExecutingAssembly(), Assembly.GetEntryAssembly());

		services.AddScoped<IProductRepository, ProductRepository>();
		services.AddScoped<IProductItemRepository, ProductItemRepository>();
		services.AddScoped<IOrderRepository, OrderRepository>();
		services.AddScoped<IOrderItemRepository, OrderItemRepository>();

		return services;
	}
}