using Microsoft.Owin.Hosting;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevWebApiApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			if (FormWindowState.Minimized == this.WindowState)
			{
				notifyIcon1.Visible = true;
				notifyIcon1.ShowBalloonTip(100);
				this.Hide();
			}
			else if (FormWindowState.Normal == this.WindowState)
			{
				notifyIcon1.Visible = false;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Task.Run(() => HostWebApi());
		}

		private static void HostWebApi()
		{
			do
			{
				try
				{
					// Allow only callers from localhost
					string baseAddress = "http://localhost:9000/";
					Trace.TraceInformation($"{DateTime.Now} - Starting up web api: {baseAddress}");

					StartOptions options = new StartOptions();
					options.Urls.Add(baseAddress);

					using (WebApp.Start<Startup>(options))
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
				catch (Exception ex)
				{
					Trace.TraceError($"{DateTime.Now} - {ex.ToString()}");
					Thread.Sleep(TimeSpan.FromMinutes(1));
				}
			}
			while (true);
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Show();
			this.BringToFront();
		}
	}
}
