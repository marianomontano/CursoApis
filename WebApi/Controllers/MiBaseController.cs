using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.EfCore;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public abstract class MiBaseController<TEntity, TRepository> : ControllerBase
		where TEntity : class, IEntity
		where TRepository : IRepository<TEntity>
	{
		private readonly TRepository repository;

		public MiBaseController(TRepository repository)
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

		[HttpPost]
		public async Task<IActionResult> Post(TEntity entity)
		{
			try
			{
				await repository.Add(entity);
				var newentity = await repository.GetById(entity.Id);
				return Ok(newentity);
			}
			catch (Exception ex)
			{
				return Content(ex.Message + "\n" + ex.StackTrace);
			}
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Put(int id, TEntity entity)
		{
			if (id != entity.Id)
				return BadRequest();
			try
			{
				await repository.Update(entity);
				return NoContent();
			}
			catch (Exception)
			{
				return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
			}
		}

		[HttpDelete("{id:int}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var entity = await repository.GetById(id);
				await repository.Delete(id);
				return Ok(entity);
			}
			catch (Exception)
			{
				return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
			}
		}
	}
}
