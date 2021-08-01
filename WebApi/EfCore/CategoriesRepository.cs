using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.EfCore
{
	public class CategoriesRepository : BaseRepository<Categories, NorthwindContext>
	{
		public CategoriesRepository(NorthwindContext context) : base(context)
		{
		}
	}
}
