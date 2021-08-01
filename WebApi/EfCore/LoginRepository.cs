using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.EfCore
{
	public class LoginRepository : BaseRepository<LoginUsuarios, NorthwindContext>
	{
		public LoginRepository(NorthwindContext context) : base(context)
		{
		}
	}
}
