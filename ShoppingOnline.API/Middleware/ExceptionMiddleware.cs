using ShoppingOnline.API.Model;
using ShoppingOnline.BLL.Exceptions;
using System.Net;

namespace ShoppingOnline.API.Middleware;
/// <summary>
/// Handle Exception dc bắn ra trong service hoặc controller
/// </summary>
/// 
public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;

	public ExceptionMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			await HandlerExceptionAsync(context, ex);
		}
	}
	
	private async Task HandlerExceptionAsync(HttpContext httpContext, Exception ex)
	{
		HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
		CustomProblemDetails problem;

		switch (ex)
		{
			case BadRequestExpection badRequestExpection :
				statusCode = HttpStatusCode.BadRequest;
				problem = new()
				{
					Title = badRequestExpection.Message,
					Status = (int)statusCode,
					Detail = badRequestExpection.InnerException?.Message,
					Type = nameof(BadRequestExpection),
					Errors = badRequestExpection.ValidationErrors
				};
				break;
			
			case NotFoundException notFoundException:
				statusCode = HttpStatusCode.NotFound;
				problem = new()
				{
					Title = notFoundException.Message, 
					Status = (int)statusCode, 
					Detail = notFoundException.InnerException?.Message, 
					Type = nameof(NotFoundException),
				};
				break;
			
			default:
				problem = new()
				{
					Title = ex.Message, 
					Detail = ex.StackTrace, 
					Status = (int)statusCode, Type = nameof(HttpStatusCode.InternalServerError),
				};
				break;
		}

		httpContext.Response.StatusCode = (int)statusCode;
		await httpContext.Response.WriteAsJsonAsync(problem);
	}
}