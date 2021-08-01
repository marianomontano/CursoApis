using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.EfCore
{
	public class SuppliersRepository : BaseRepository<Suppliers, NorthwindContext>
	{
		public SuppliersRepository(NorthwindContext context) : base(context)
		{
		}
	}
}
