using Microsoft.Owin.Hosting;
using System;
using System.Threading;

namespace DevWebApi
{
	class Program
	{
		static void Main(string[] args)
		{
			HostWebApi();
		}

		private static void HostWebApi()
		{
			do
			{
				try
				{
					string baseAddress = "http://localhost:9000/";
					using (WebApp.Start<Startup>(url: baseAddress))
					{
						Console.ReadLine();
					}
				}
				catch(Exception)
				{
					// Todo: Log exception
					Thread.Sleep(TimeSpan.FromMinutes(1));
				}
			}
			while (true);
		}
	}
}
