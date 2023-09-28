using ShoppingOnline.DAL.Entities.Common;

namespace ShoppingOnline.DAL.Repositories.Interface;

public interface IGenericRepository<T> where T : BaseEntity
{
	Task<IEnumerable<T>> GetAllAsync();
	Task<T?> GetByIdAsync(Guid id);

	Task<Guid> CreateAsync(T entity);

	Task<int> CreateRangeAsync(List<T> entities);

	Task<bool> UpdateAsync(T entity);

	Task<bool> DeleteAsync(T entity);
}