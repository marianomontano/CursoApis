using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
	public class LoginController : ControllerBase
	{
		private readonly NorthwindContext context;
		private readonly IConfiguration config;
		public LoginController(NorthwindContext context, IConfiguration config)
		{
			this.context = context;
			this.config = config;
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginUsuarios usuario)
		{
			var user = await FuncionesToken<NorthwindContext>.AutenticarUsuario(usuario, context);

			if (user == null)
			{
				return Unauthorized();
			}

			var token = FuncionesToken<NorthwindContext>.GenerarToken(user, config);

			if (token == null && token == "")
			{
				return BadRequest(new { error = "Token no generado" });
			}

			return Ok(token);
		}
	}
}
