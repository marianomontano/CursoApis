using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.EfCore
{
	public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity> 
		where TEntity : class, IEntity
		where TContext : DbContext
	{
		private readonly TContext context;

		public BaseRepository(TContext context)
		{
			this.context = context;
		}
		public async Task<List<TEntity>> GetAll()
		{
			var entities = await context.Set<TEntity>().ToListAsync();

			return entities;
		}

		public async Task<TEntity> GetById(int id)
		{
			var entity = await context.Set<TEntity>().FindAsync(id);

			return entity;
		}

		public async Task Update(TEntity entity)
		{
			context.Set<TEntity>().Update(entity);
			await context.SaveChangesAsync();
		}

		public async Task Add(TEntity entity)
		{
			context.Set<TEntity>().Add(entity);
			await  context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var entity = await context.Set<TEntity>().FindAsync(id);

			if(entity != null)
			{
				context.Set<TEntity>().Remove(entity);
				await context.SaveChangesAsync();
			}
		}
	}
}
