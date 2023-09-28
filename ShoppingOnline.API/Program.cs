using Microsoft.OpenApi.Models;
using ShoppingOnline.API.Middleware;
using ShoppingOnline.BLL;
using ShoppingOnline.BLL.Features.OrderApplication;
using ShoppingOnline.BLL.Features.OrderItemApplication;
using ShoppingOnline.BLL.Features.ProductApplication;
using ShoppingOnline.BLL.Features.ProductItemApplication;
using ShoppingOnline.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBusinessLogicLayerService(builder.Configuration);
builder.Services.AddDataAccessLayerService(builder.Configuration);

//Add CORS 
builder.Services.AddCors(options =>
{
	options.AddPolicy("policy", cfg =>
	{
		cfg.AllowAnyHeader();
		cfg.AllowAnyMethod();
		cfg.AllowAnyOrigin();
	});
});


//Add Swagger Bearer
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "TangWeb_Api", Version = "v1" });
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Description = "Please Bearer and then token in the field",
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey
	});
	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			new string[] { }
		}
	});
});


var app = builder.Build();

//Add Custom Middleware
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("policy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();