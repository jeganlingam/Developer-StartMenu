using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;

namespace DevWebApi
{
	public sealed class ProcessController : ApiController
	{
		// GET api/Process
		public string Get(ProcessInfo processInfo)
		{
			PerformBasicAuthorization();

			return "all good";
		}

		// POST api/Process
		public void Post([FromBody]ProcessInfo processInfo)
		{
			PerformBasicAuthorization();

			var processStartInfo = new ProcessStartInfo(processInfo.FileName);
			if (processInfo.StartAsAdministrator)
			{
				processStartInfo.Verb = "runas";
			}

			Process.Start(processStartInfo);
		}

		private static void PerformBasicAuthorization()
		{
			if(!Thread.CurrentPrincipal.Identity.IsAuthenticated || WindowsIdentity.GetCurrent().Name != Thread.CurrentPrincipal.Identity.Name)
			{
				new Exception($"{Thread.CurrentPrincipal.Identity.Name} caller not authorized!");
			}
		}
	}
}
