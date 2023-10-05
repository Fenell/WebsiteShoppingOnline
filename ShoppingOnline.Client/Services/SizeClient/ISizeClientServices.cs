using ShoppingOnline.Client.DataTransferObjects.SizeDto;

namespace ShoppingOnline.Client.Services.SizeClient;

public interface ISizeClientServices
{
	Task<IEnumerable<GetSize>> GetAllSizes();
}
