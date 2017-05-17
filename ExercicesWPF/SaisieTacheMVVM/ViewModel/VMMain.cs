using SaisieTacheMVVM.Entités;
using SaisieTacheMVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaisieTacheMVVM.ViewModel
{
    public class VMMain : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                if (_currentViewModel == null)
                    _currentViewModel = new VMTache();

                return _currentViewModel;
            }
        }
    }
}
