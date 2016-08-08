using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevWebApiClientLib
{
	public sealed class ProcessInfo
	{
		public ProcessInfo()
		{

		}
		public string FileName { get; set; }
		public bool StartAsAdministrator { get; set; }
	}
}
