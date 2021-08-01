using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
	public interface IReadRepository<T> where T : class
	{
		Task<List<T>> GetAll();
		Task<T> GetById(int id);
	}
}
