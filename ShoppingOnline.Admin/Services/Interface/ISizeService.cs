using ShoppingOnline.Admin.ViewModels.Models;

namespace ShoppingOnline.Admin.Services.Interface;

public interface ISizeService
{
	Task<List<SizesVM>> GetAllSizes();
	Task<bool> CreateSize(SizesVM si);
	Task<bool> UpdateSize(SizesVM si);
	Task<bool> DeleteSize(Guid id);
	Task<SizesVM> GetSize(Guid id);
}
