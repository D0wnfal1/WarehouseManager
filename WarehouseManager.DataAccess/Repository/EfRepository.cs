﻿using Microsoft.EntityFrameworkCore;

namespace WarehouseManager.DataAccess.Repository
{
    public class EfRepository<T> : IRepository<T> where T : class
	{
		private readonly WarehouseDbContext _context;

		public EfRepository(WarehouseDbContext context)
		{
			_context = context;
		}

		public async Task<T> GetByIdAsync(Guid id) => await _context.Set<T>().FindAsync(id);

		public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

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