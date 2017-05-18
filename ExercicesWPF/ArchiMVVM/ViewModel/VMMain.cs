using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Divers.ViewModel
{
	public class VMMain : ViewModelBase
	{
		// Vue-modèle courante, à laquelle est liée le ContentControl de la zone principale
		private ViewModelBase _VMCourante;
		public ViewModelBase VMCourante
		{
			get { return _VMCourante; }
			private set
			{
				SetProperty(ref _VMCourante, value);
			}
		}

		#region Commandes associées aux menus
		private ICommand _cmdPersonnes;
		public ICommand CmdPersonnes
		{
			get
			{
				// On définit une instance de VMPersonnes comme vue-modèle courante
				if (_cmdPersonnes == null)
					_cmdPersonnes = new RelayCommand((object o) => VMCourante = new VMPersonnes());
				return _cmdPersonnes;
			}
		}

		private ICommand _cmdRegions;
		public ICommand CmdRegions
		{
			get
			{
				// On définit une instance de VMPersonnes comme vue-modèle courante
				if (_cmdRegions == null)
					_cmdRegions = new RelayCommand((object o) => { VMCourante = new VMRegions(); });
				return _cmdRegions;
			}
		}

		#endregion
	}
}
