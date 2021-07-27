using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.EfCore;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EnviosController : MiBaseController<Shippers, EfCoreShippersRepository>
	{
		public EnviosController(EfCoreShippersRepository repository) : base(repository)
		{
		}
	}
}
