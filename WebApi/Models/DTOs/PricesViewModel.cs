using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
	public class PricesViewModel
	{
		public int IdProducto { get; set; }
		public string Categoria { get; set; }
		public string Proveedor { get; set; }
		public string NombreProducto { get; set; }
		public decimal? Precio { get; set; }
		public short? UnidadesEnStock { get; set; }
	}
}
