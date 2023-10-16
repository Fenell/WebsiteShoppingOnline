using ShoppingOnline.Admin.ViewModels.Color;

namespace ShoppingOnline.Admin.Services.Interface;

public interface IColorServices
{
	Task<List<ColorDtos>> GetAllColor();
	Task<ColorDtos> GetColorById(Guid id);
}
