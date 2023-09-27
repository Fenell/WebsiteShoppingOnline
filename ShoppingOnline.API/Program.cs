using ShoppingOnline.API.Middleware;
using ShoppingOnline.BLL;
using ShoppingOnline.BLL.Features.ProductApplication;
using ShoppingOnline.BLL.Features.ProductItemApplication;
using ShoppingOnline.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddBusinessLogicLayerService();
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

//DI
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductItemServices, ProductItemsServices>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();