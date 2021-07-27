using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebApi.Data;

namespace WebApi.Models
{
	public class LoginUsuarios : IEntity
	{
		public int Id { get; set; }
		public string Usuario { get; set; }
		public string Clave { get; set; }
		public string Apellido { get; set; }
		public string Nombre { get; set; }

		[EmailAddress]
		public string Email { get; set; }

	}
}
