using ShoppingOnline.Admin.ViewModels.ViewModelClient;


namespace ShoppingOnline.Admin.Services.Interface;

public interface IBrandClientService
{
	Task<List<BrandVM>> GetAllBrandClient();
	Task<BrandVM> GetAllBrandClientById(Guid id);
	Task<bool> CreateBrandClient(BrandVM brand);
	Task<bool> DeleteBrandClient(Guid id);
	Task<bool> UpdateBrandClient(BrandVM brandVM);
}
