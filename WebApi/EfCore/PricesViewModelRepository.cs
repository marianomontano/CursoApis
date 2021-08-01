using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.EfCore
{
	public class PricesViewModelRepository : IReadRepository<PricesViewModel>
	{
		private readonly NorthwindContext context;

		public PricesViewModelRepository(NorthwindContext context)
		{
			this.context = context;
		}

		public async Task<List<PricesViewModel>> GetAll()
		{
			var prices = new List<PricesViewModel>();
			var products = await context.Products
				.Include("Category")
				.Include("Supplier")
				.ToListAsync();
			
			products.ForEach(x =>	prices.Add(new PricesViewModel
				{
					IdProducto = x.Id,
					Categoria = x.Category.Description,
					Proveedor = x.Supplier.CompanyName,
					NombreProducto = x.ProductName,
					Precio = x.UnitPrice,
					UnidadesEnStock = x.UnitsInStock
				}));

			return prices;
		}

		public async Task<PricesViewModel> GetById(int id)
		{
			var product = await context.Products
				.Include("Category")
				.Include("Supplier")
				.FirstOrDefaultAsync(x => x.Id == id);

			var price = new PricesViewModel
			{
				IdProducto = product.Id,
				Categoria = product.Category.Description,
				Proveedor = product.Supplier.CompanyName,
				NombreProducto = product.ProductName,
				Precio = product.UnitPrice,
				UnidadesEnStock = product.UnitsInStock
			};

			return price;
		}
	}
}
