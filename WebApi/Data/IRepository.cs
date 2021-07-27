using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
	public interface IRepository<T> where T : class
	{
		Task<List<T>> GetAll();
		Task<T> GetById(int id);
		Task Add(T entity);
		Task Update(T entity);
		Task Delete(int id);
	}
}