using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.EfCore
{
	public class EfCoreLoginRepository : EfCoreRepository<LoginUsuarios, NorthwindContext>
	{
		public EfCoreLoginRepository(NorthwindContext context) : base(context)
		{
		}
	}
}
