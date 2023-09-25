using ShoppingOnline.BLL.DataTransferObjects.Example;
using ShoppingOnline.BLL.DataTransferObjects.Example.Request;

namespace ShoppingOnline.BLL.Features.Example;

public interface IExampleService
{
	Task<List<ExampleDto>> GetAsync();
	Task<ExampleDto> GetById(Guid id);
	Task<Guid> Create(ExampleCreateRequest request);
	Task Update(ExampleUpdateRequest request);
	Task Delete(ExampleDeleteRequest request);
}