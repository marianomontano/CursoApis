using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.EfCore
{
	public class ProductsRepository : BaseRepository<Products, NorthwindContext>
	{
		public ProductsRepository(NorthwindContext context) : base(context)
		{
		}
	}
}
