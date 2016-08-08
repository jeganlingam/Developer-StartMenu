using Microsoft.Owin.Hosting;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace DevWebApi
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			bool result;
			var mutex = new System.Threading.Mutex(true, "DevWebApi", out result);
			if (!result)
			{
				return;
			}

			HostWebApi();
		}

		private static void HostWebApi()
		{
			do
			{
				try
				{
					string baseAddress = "http://localhost:9000/";
					Trace.TraceInformation($"{DateTime.Now} - Starting up web api: {baseAddress}");

					using (WebApp.Start<Startup>(url: baseAddress))
					{
						Trace.TraceInformation($"{DateTime.Now} - Started successfully");

						do
						{
							Trace.TraceInformation($"{DateTime.Now} - Running");
							Thread.Sleep(TimeSpan.FromMinutes(10));
						}
						while (true);
					}
				}
				catch(Exception ex)
				{
					Trace.TraceError($"{DateTime.Now} - {ex.ToString()}");
					Thread.Sleep(TimeSpan.FromMinutes(1));
				}
			}
			while (true);
		}
	}
}
