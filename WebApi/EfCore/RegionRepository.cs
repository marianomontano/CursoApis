using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.EfCore
{
	public class RegionRepository : BaseRepository<Region, NorthwindContext>
	{
		public RegionRepository(NorthwindContext context) : base(context)
		{
		}
	}
}
