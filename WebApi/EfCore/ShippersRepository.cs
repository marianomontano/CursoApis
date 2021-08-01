using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.EfCore
{
	public class ShippersRepository : BaseRepository<Shippers, NorthwindContext>
	{
		public ShippersRepository(NorthwindContext context) : base(context)
		{
		}
	}
}
