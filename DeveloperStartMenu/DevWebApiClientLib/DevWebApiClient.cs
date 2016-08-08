using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DevWebApiClientLib
{
	public sealed class DevWebApiClient
	{
		private string _baseUri = "http://localhost:9000";

		public DevWebApiClient()
		{
		}

		public async Task InvokeProcessAsync(ProcessInfo processInfo)
		{
			string processApiUrl = $"{_baseUri}/Api/Process";
			var contentJson = JsonConvert.SerializeObject(processInfo);
			HttpContent contentPost = new StringContent(contentJson, Encoding.UTF8, "application/json");

			HttpClientHandler handler = new HttpClientHandler()
			{
				UseDefaultCredentials = true
			};

			using (HttpClient client = new HttpClient(handler))
			{
				await client.PostAsync(processApiUrl, contentPost);
			}
		}
	}
}
