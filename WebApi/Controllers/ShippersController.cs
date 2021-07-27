using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShippersController : ControllerBase
	{
		private readonly NorthwindContext _context;

		public ShippersController(NorthwindContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var shippers = await _context.Shippers.ToListAsync();
			return Ok(shippers);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById(int id)
		{
			if (id < 0)
				return BadRequest();

			var shipper = await _context.Shippers.FindAsync(id);
			if (shipper == null)
				return NotFound();

			return Ok(shipper);
		}

		[HttpPost]
		public async Task<IActionResult> Post(Shippers shipper)
		{
			try
			{
				_context.Shippers.Add(shipper);
				await _context.SaveChangesAsync();
				return Ok(shipper);
			}
			catch (Exception ex)
			{
				return Content(ex.Message);
			}
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> Put(int id, Shippers _shipper)
		{
			if (_shipper.Id != id || id < 0)
				return BadRequest();

			try
			{
				_context.Shippers.Update(_shipper);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				return Content(ex.Message);
			}
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			if (id < 0)
				return BadRequest();

			var shipper = await _context.Shippers.FindAsync(id);

			if (shipper == null)
				return NotFound();

			try
			{
				_context.Shippers.Remove(shipper);
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (Exception ex)
			{
				return Content(ex.Message);
			}
		}
	}
}
