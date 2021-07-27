using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClientMvc.Utilities;
using System.Net.Http;
using ApiClientMvc.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace ApiClientMvc.Controllers
{

	public class TransportesController : Controller
	{
		private readonly HttpClient client;
		private readonly IConfiguration configuration;

		public TransportesController(IConfiguration configuration)
		{
			HttpClientHelper.Inicializar();
			this.client = HttpClientHelper.Client;
			this.configuration = configuration;
		}

		public async Task<IActionResult> Index()
		{
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration["Tokens:Jwt"]);
			var response = await client.GetStringAsync("shippers");
			var shippers = JsonConvert.DeserializeObject<List<ShipperModel>>(response);

			return View(shippers);
		}

		public async Task<IActionResult> Details(int id)
		{
			var shipper = new ShipperModel();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration["Tokens:Jwt"]);
			var response = await client.GetAsync($"shippers/{id}");

			if (response.IsSuccessStatusCode)
			{
				shipper = JsonConvert.DeserializeObject<ShipperModel>(await response.Content.ReadAsStringAsync());
			}

			return View(shipper);
		}

		public async Task<IActionResult> Edit(int id)
		{
			var shipper = new ShipperModel();

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration["Tokens:Jwt"]);
			var response = await client.GetAsync($"shippers/{id}");

			if (response.IsSuccessStatusCode)
			{
				shipper = JsonConvert.DeserializeObject<ShipperModel>(await response.Content.ReadAsStringAsync());
			}

			return View(shipper);
		}

		[HttpPost("{id:int}")]
		public async Task<IActionResult> Edit(int id, ShipperModel shipper)
		{
			if (!ModelState.IsValid || id != shipper.Id)
				return BadRequest();

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration["Tokens:Jwt"]);
			var response = await client.PutAsJsonAsync<ShipperModel>($"shippers/{id}", shipper);

			if (!response.IsSuccessStatusCode)
				return View(shipper);

			return RedirectToAction("Index");
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(ShipperModel shipper)
		{
			if (!ModelState.IsValid)
			{
				return View(shipper);
			}

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration["Tokens:Jwt"]);
			var response = await client.PostAsJsonAsync<ShipperModel>("shippers", shipper);

			if (!response.IsSuccessStatusCode)
			{
				return View(shipper);
			}

			return RedirectToAction("Index");
		}
	}
}
