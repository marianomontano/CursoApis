using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
	public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class
	{
	}
}