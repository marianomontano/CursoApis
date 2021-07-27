namespace ApiClientMvc.Models
{
	public class PreciosViewModel
	{
		public int IdProducto { get; set; }
		public string Categoria { get; set; }
		public string Proveedor { get; set; }
		public string NombreProducto { get; set; }
		public decimal Precio { get; set; }
		public short UnitsInStock { get; set; }
	}
}
