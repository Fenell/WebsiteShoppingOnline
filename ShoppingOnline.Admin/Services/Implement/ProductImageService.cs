using Microsoft.AspNetCore.Components.Forms;
using ShoppingOnline.Admin.Constants;
using ShoppingOnline.Admin.Models.ProductImage;
using ShoppingOnline.Admin.Services.Interface;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ShoppingOnline.Admin.Services.Implement;

public class ProductImageService : IProductImageService
{
	private readonly IHttpClientFactory _httpClientFactory;
	private string _apiUrl;

	public ProductImageService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
	{
		_httpClientFactory = httpClientFactory;
		_apiUrl = configuration.GetSection("BaseApiUrl").Value;
	}

	public async Task<bool> CreateProductItem(Guid productItemId, IReadOnlyList<IBrowserFile> files)
	{
		var httpClient = _httpClientFactory.CreateClient(ApplicationConstant.ClientName);

		var content = new MultipartFormDataContent();
		foreach (var item in files)
		{
			var fileContent = new StreamContent(item.OpenReadStream(int.MaxValue));
			fileContent.Headers.ContentType = new MediaTypeHeaderValue(item.ContentType);

			content.Add(
				content: fileContent,
				name: "\"files\"",
				fileName: item.Name);
		}

		var result = await httpClient.PostAsync($"api/ProductImgs/add-list/{productItemId}", content);
		var responseConent = await result.Content.ReadAsStringAsync();
		return result.IsSuccessStatusCode;
	}

	public async Task<List<ProductImageVM>> GetAllProducts(Guid productItemId)
	{
		var httpClient = _httpClientFactory.CreateClient(ApplicationConstant.ClientName);

		var listProductImages = await httpClient.GetFromJsonAsync<List<ProductImageVM>>($"api/ProductImgs/get-by-productItem/{productItemId}");

		//add "app.usestaticfile to the Api's Program file
		foreach (var item in listProductImages)
		{
			item.ImageUrl = _apiUrl + item.ImageUrl;
		}

		return listProductImages;
	}
}