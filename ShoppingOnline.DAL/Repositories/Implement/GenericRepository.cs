﻿using Microsoft.EntityFrameworkCore;
using ShoppingOnline.DAL.Database.AppDbContext;
using ShoppingOnline.DAL.Entities.Common;
using ShoppingOnline.DAL.Repositories.Interface;

namespace ShoppingOnline.DAL.Repositories.Implement;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
	private readonly ApplicationDbContext _context;

	public GenericRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<IQueryable<T>> GetAllAsync()
	{
		return _context.Set<T>().AsNoTracking();
	}

	public async Task<T?> GetByIdAsync(Guid id)
	{
		var entity = await _context.Set<T>().AsNoTracking()
			.FirstOrDefaultAsync(c => c.Id == id);

		return entity;
	}

	public async Task<Guid> CreateAsync(T entity)
	{
		try
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity.Id;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

	public async Task<int> CreateRangeAsync(List<T> entities)
	{
		try
		{
			await _context.Set<T>().AddRangeAsync(entities);

			return await _context.SaveChangesAsync();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

	public async Task<bool> UpdateAsync(T entity)
	{
		try
		{
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return true;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}

	public async Task<bool> DeleteAsync(T entity)
	{
		try
		{
			_context.Remove(entity);
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