using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divers.ViewModel
{
	public class VMRegions : ViewModelBase
	{
		public string NomRegion { get; }

		public VMRegions()
		{
			NomRegion = "Hauts-de-France";
		}
	}
}
