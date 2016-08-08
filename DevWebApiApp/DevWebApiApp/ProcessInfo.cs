namespace DevWebApi
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public sealed class ProcessInfo
	{
		public string FileName { get; set; }
		public bool StartAsAdministrator { get; set; }
	}
}
