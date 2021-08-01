using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
	public interface IWriteRepository<T> where T : class
	{
		Task Add(T entity);
		Task Update(T entity);
		Task Delete(int id);
	}
}
