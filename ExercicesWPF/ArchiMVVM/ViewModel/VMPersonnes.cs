using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divers.ViewModel
{
	public class VMPersonnes : ViewModelBase
	{
		public Personne Pers { get; set; }

		public VMPersonnes()
		{
			Pers = new Personne() { Nom = "Lefranc", Prenom = "Arnaud" };
		}
	}
}
