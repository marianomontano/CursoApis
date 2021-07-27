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
	public class RegionesController : MiBaseController<Region, EfCoreRegionRepository>
	{
		public RegionesController(EfCoreRegionRepository repository) : base(repository)
		{
		}
	}
}
