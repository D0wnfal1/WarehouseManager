﻿using Microsoft.EntityFrameworkCore;
using WarehouseManager.DataAccess.Repositories.IRepositories;

namespace WarehouseManager.DataAccess.EfRepository
{
    public class EfRepository<T> : IRepository<T> where T : class
	{
		private readonly WarehouseDbContext _context;

		public EfRepository(WarehouseDbContext context)
		{
			_context = context;
		}

		public async Task<T> GetByIdAsync(Guid id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			_context.Set<T>().Remove(entity);
			await _context.SaveChangesAsync();
		}
	}
}
