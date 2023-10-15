using ShoppingOnline.Client.DataTransferObjects.ColorDto;

namespace ShoppingOnline.Client.Services.ColorClient;

public interface IColorClientServices
{
	Task<IEnumerable<GetColor>> GetAllColors();
}
