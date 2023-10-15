using ShoppingOnline.Admin.ViewModels.Models;

namespace ShoppingOnline.Admin.Services.Interface;

public interface IColorService
{
	Task<List<ColorsVM>> GetAllColors();
	Task<bool> CreateColor(ColorsVM Co);
	Task<bool> UpdateColor(ColorsVM Co);
	Task<bool> DeleteColor(Guid id);
    Task<ColorsVM> GetColor(Guid id);
}
