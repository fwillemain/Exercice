using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Trombinoscope
{
    public class VMMain : ViewModelBase
    {
        private ViewModelBase _vmCourante;
        public ViewModelBase VMCourante
        {
            get { return _vmCourante; }
            set
            {
                SetProperty(ref _vmCourante, value);
            }
        }

        private ICommand _cmdEmployés;
        public ICommand CmdEmployés
        {
            get
            {
                if (_cmdEmployés == null)
                    _cmdEmployés = new RelayCommand((object o) => VMCourante = new VMEmployés());

                return _cmdEmployés;
            }
        }

        private ICommand _cmdTrombi;
        public ICommand CmdTrombi
        {
            get
            {
                if (_cmdTrombi == null)
                    _cmdTrombi = new RelayCommand((object o) => VMCourante = new VMTrombi());

                return _cmdTrombi;
            }
        }

    }
}
