using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.EfCore;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PreciosController : ControllerBase
	{
		private readonly PricesViewModelRepository repository;

		public PreciosController(PricesViewModelRepository repository)
		{
			this.repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var lista = await repository.GetAll();
			var listaJson = JsonConvert.SerializeObject(lista);
			return Ok(listaJson);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById(int id)
		{
			if (id < 0)
				return BadRequest();

			var entity = await repository.GetById(id);

			if (entity == null)
				return NotFound();

			return Ok(entity);
		}
	}
}
