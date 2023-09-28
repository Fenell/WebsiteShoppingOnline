using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ShoppingOnline.BLL.Features.ColorFeature;
using ShoppingOnline.BLL.Features.SizeFeature;

using Microsoft.IdentityModel.Tokens;
using ShoppingOnline.BLL.Features.CategoryFeature;
using ShoppingOnline.BLL.Features.Identity;
using ShoppingOnline.BLL.Features.OrderApplication;
using ShoppingOnline.BLL.Features.OrderItemApplication;
using ShoppingOnline.BLL.Features.ProductApplication;
using ShoppingOnline.BLL.Features.ProductItemApplication;
using ShoppingOnline.BLL.OptionModels;
using ShoppingOnline.DAL.Repositories.Implement;
using ShoppingOnline.DAL.Repositories.Interface;

using System.Reflection;
using System.Text;

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

		services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(cfg =>
		{
			cfg.TokenValidationParameters = new TokenValidationParameters()
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateIssuerSigningKey = true,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero,
				ValidIssuer = configuration["JWTSettings:Issuer"],
				ValidAudience = configuration["JWTSettings:Audience"],
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
			};
		});

		services.AddTransient<IAuthService, AuthService>();

		services.AddScoped<IProductServices, ProductServices>();
		services.AddScoped<IProductItemServices, ProductItemsServices>();
		services.AddScoped<IOrderServices, OrderServices>();
		services.AddScoped<IOrderItemServices, OrderItemServices>();


		return services;
	}
}