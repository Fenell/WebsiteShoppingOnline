using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities.Identity;
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
		

		services.AddScoped<ICategoryRepository, CategoryRepository>();
		services.AddScoped<IColorRepository, ColorRepository>();
		services.AddScoped<ISizeRepository, SizeRepository>();

		services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequiredLength = 6;
			})
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddDefaultTokenProviders();

		services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

		services.AddScoped<IProductRepository, ProductRepository>();
		services.AddScoped<IProductItemRepository, ProductItemRepository>();
		services.AddScoped<IOrderRepository, OrderRepository>();
		services.AddScoped<IOrderItemRepository, OrderItemRepository>();

		return services;
	}
}