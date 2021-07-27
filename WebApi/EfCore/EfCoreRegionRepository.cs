using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.EfCore
{
	public class EfCoreRegionRepository : EfCoreRepository<Region, NorthwindContext>
	{
		public EfCoreRegionRepository(NorthwindContext context) : base(context)
		{
		}
	}
}
