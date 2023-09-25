using Microsoft.EntityFrameworkCore;
using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities.Example;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.DAL.Repositories.Implement;

public class ExampleRepos : IExampleRepos
{
	private readonly ApplicationDbContext _context;

	public ExampleRepos(ApplicationDbContext context)
	{
		_context = context;
	}


	public Task<IEnumerable<ExampleEntity>> GetAllAsync()
	{
		return Task.FromResult<IEnumerable<ExampleEntity>>(_context.ExampleEntities.AsNoTracking().Where(c => !c.IsDeleted));
	}

	public async Task<ExampleEntity?> GetByIdAsync(Guid id)
	{
		try
		{
			var obj = await _context.ExampleEntities.AsNoTracking()
				.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

			return obj;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			throw;
		}
	}

	public async Task<Guid> CreateAsync(ExampleEntity exampleEntity)
	{
		try
		{
			exampleEntity.CreatedAt = DateTime.Now;

			await _context.ExampleEntities.AddAsync(exampleEntity);
			await _context.SaveChangesAsync();

			return exampleEntity.Id;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			throw;
		}
	}

	public async Task<bool?> UpdateAsync(ExampleEntity exampleEntity)
	{
		try
		{
			var entity = await _context.ExampleEntities
				.FirstOrDefaultAsync(c => c.Id == exampleEntity.Id && !c.IsDeleted);

			if (entity is null)
				return null;

			entity.Name = exampleEntity.Name;
			entity.UpdateAt = DateTime.Now;

			_context.ExampleEntities.Update(entity);
			await _context.SaveChangesAsync();

			return true;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			return false;
		}
	}

	public Task<bool?> DeleteAsync(ExampleEntity exampleEntity)
	{
		throw new NotImplementedException();
	}

	public async Task<bool?> DeleteAsync(Guid id)
	{
		try
		{
			var entity = await _context.ExampleEntities
				.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);

			if (entity is null)
				return null;

			entity.IsDeleted = true;
			entity.UpdateAt = DateTime.Now;
			_context.ExampleEntities.Remove(entity);
			
			await _context.SaveChangesAsync();
			return true;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}
}