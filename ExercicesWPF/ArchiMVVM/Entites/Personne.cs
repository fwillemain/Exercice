using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divers
{
	public class Personne //: ValidationBase
	{
		private string _prenom;

		[Required]
		[StringLength(10)]
		public string Prenom
		{
			get { return _prenom; }
			set
			{
				_prenom = value;
				//ValidateProperty(value);
				//base.OnPropertyChanged("FirstName");
			}
		}
		public string Nom { get; set; }
		public DateTime DateNaissance { get; set; }
		public bool Visible { get; set; }
	}
}