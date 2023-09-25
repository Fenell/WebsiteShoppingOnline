using ShoppingOnline.DAL.Entities.Example;

namespace ShoppingOnline.DAL.Repositories.Interface;

public interface IExampleRepos
{
	Task<IEnumerable<ExampleEntity>> GetAllAsync();

	Task<ExampleEntity?> GetByIdAsync(Guid id);

	Task<Guid> CreateAsync(ExampleEntity exampleEntity);
	
	Task<bool?> UpdateAsync(ExampleEntity exampleEntity);
	
	Task<bool?> DeleteAsync(Guid id);
	
}