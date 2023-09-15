using ShoppingOnline.API.Middleware;
using ShoppingOnline.BLL;
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