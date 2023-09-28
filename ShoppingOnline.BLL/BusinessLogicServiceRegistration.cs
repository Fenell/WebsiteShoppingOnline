﻿using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ShoppingOnline.BLL.Features.Identity;
using ShoppingOnline.BLL.OptionModels;
using System.Reflection;
using System.Text;

namespace ShoppingOnline.BLL;

public static class BusinessLogicServiceRegistration
{
	public static IServiceCollection AddBusinessLogicLayerService(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddAutoMapper(config =>  config.AddExpressionMapping(),
			Assembly.GetExecutingAssembly(), Assembly.GetEntryAssembly());

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
		
		
		return services;
	}
}