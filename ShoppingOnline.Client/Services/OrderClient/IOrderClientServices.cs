using ShoppingOnline.Client.DataTransferObjects.OrderDto;

namespace ShoppingOnline.Client.Services.OrderClient;

public interface IOrderClientServices
{
	Task<bool> CreatedOrder(OrderCreatedDto createdDto);
}
