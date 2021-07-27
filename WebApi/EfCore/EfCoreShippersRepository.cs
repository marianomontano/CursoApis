using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.EfCore
{
	public class EfCoreShippersRepository : EfCoreRepository<Shippers, NorthwindContext>
	{
		public EfCoreShippersRepository(NorthwindContext context) : base(context)
		{
		}
	}
}
