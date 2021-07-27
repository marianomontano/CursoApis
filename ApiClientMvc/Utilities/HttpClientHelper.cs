using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiClientMvc.Utilities
{
	public static class HttpClientHelper
	{
		public static HttpClient Client { get; set; }

		public static void Inicializar()
		{
			Client = new HttpClient();
			Client.BaseAddress = new Uri("https://localhost:44367/api/");
			Client.DefaultRequestHeaders.Add("accept", "application/json");
		}
	}
}
