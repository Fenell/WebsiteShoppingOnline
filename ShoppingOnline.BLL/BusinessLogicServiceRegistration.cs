using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingOnline.BLL.Features.ColorFeature;
using ShoppingOnline.BLL.Features.SizeFeature;
using Microsoft.IdentityModel.Tokens;
using ShoppingOnline.BLL.Features.BrandApplication;
using ShoppingOnline.BLL.Features.CategoryFeature;
using ShoppingOnline.BLL.Features.Identity;
using ShoppingOnline.BLL.Features.OrderApplication;
using ShoppingOnline.BLL.Features.OrderItemApplication;
using ShoppingOnline.BLL.Features.ProductApplication;
using ShoppingOnline.BLL.Features.ProductItemApplication;
using ShoppingOnline.BLL.OptionModels;

using System.Reflection;
using System.Text;
using ShoppingOnline.BLL.Features.BrandFeature;

namespace ShoppingOnline.BLL;

public static class BusinessLogicServiceRegistration
{
	public static IServiceCollection AddBusinessLogicLayerService(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddAutoMapper(config => config.AddExpressionMapping(),
			Assembly.GetExecutingAssembly(), Assembly.GetEntryAssembly());
		
		services.AddScoped<ICategoryService, CategoryService>();
		services.AddScoped<IColorService, ColorService>();
		services.AddScoped<ISizeService, SizeService>();

		services.Configure<JwtSettings>(configuration.GetSection("JWTSettings"));
		
		services.AddTransient<IAuthService, AuthService>();

		services.AddScoped<IProductServices, ProductServices>();
		services.AddScoped<IProductItemServices, ProductItemsServices>();
		services.AddScoped<IOrderServices, OrderServices>();
		services.AddScoped<IOrderItemServices, OrderItemServices>();
		services.AddScoped<IBrandServices, BrandServices>();



		return services;
	}
}