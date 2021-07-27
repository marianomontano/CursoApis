using ApiClientMvc.Models;
using ApiClientMvc.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiClientMvc.Controllers
{
	public class PreciosController : Controller
	{
		private readonly HttpClient client;
		string url = "https://localhost:44342/api/";

		public PreciosController()
		{
			HttpClientHelper.Inicializar();
			client = HttpClientHelper.Client;
		}
		public async Task<IActionResult> Index()
		
		{
			client.BaseAddress = new Uri(url);
			var response = await client.GetStringAsync("precios");
			var precios = JsonConvert.DeserializeObject<List<PreciosViewModel>>(response).Where(x => x.UnitsInStock > 0).ToList();
			return View(precios);
		}
	}
}
