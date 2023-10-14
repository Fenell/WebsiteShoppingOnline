using ShoppingOnline.Admin.ViewModels.Size;

namespace ShoppingOnline.Admin.Services.Interface;

public interface ISizeServices
{
	Task<SizeDtos> GetSizeById(Guid id);
	Task<List<SizeDtos>> GetAllSize();
}
