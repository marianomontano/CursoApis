using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi
{
	public static class FuncionesToken<TContext> 
		where TContext : DbContext
	{
		public static  async Task<LoginUsuarios> AutenticarUsuario(LoginUsuarios usuario, TContext contexto)
		{
			var user = new LoginUsuarios();

			user = await contexto.Set<LoginUsuarios>()
				.FirstOrDefaultAsync(u => u.Usuario == usuario.Usuario && u.Clave == usuario.Clave);

			return user;
		}

		public static string GenerarToken(LoginUsuarios usuario, IConfiguration config)
		{
			//header
			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:ClaveSecreta"]));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
			var header = new JwtHeader(signingCredentials);

			//claims
			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.NameId, usuario.Id.ToString()),
				new Claim("nombre", usuario.Nombre),
				new Claim("apellido", usuario.Apellido),
				new Claim(JwtRegisteredClaimNames.Email, usuario.Email)
			};

			//payload
			var payload = new JwtPayload(	
				issuer: config["JWT:Issuer"],
				audience: config["JWT:Audience"],
				claims: claims,
				notBefore: DateTime.Today,
				expires: DateTime.Now.AddHours(5));

			//generar token
			var token = new JwtSecurityToken(header, payload);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
