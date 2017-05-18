using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColBD.Entités;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows;

namespace ColBD.ViewModel
{
    public class VMMain
    {
        public List<CollectionBD> ListeCollectionBD { get; set; }

        public VMMain()
        {
            ListeCollectionBD = BD_DAL.ChargerCollectionsBD();
        }

        private ICommand _cmdNavigation;

        public ICommand CmdNavigation
        {
            get
            {
                if (_cmdNavigation == null)
                    _cmdNavigation = new RelayCommand(Navigation);
                return _cmdNavigation;
            }
        }

        private void Navigation(object obj)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(ListeCollectionBD);

            string dir = (string) obj;

            switch (dir)
            {
                case "F":
                    view.MoveCurrentToFirst();
                    break;
                case "P":
                    if (view.CurrentPosition > 0)
                        view.MoveCurrentToPrevious();
                    break;
                case "N":
                    if (view.CurrentPosition < view.GetLastIndex())
                        view.MoveCurrentToNext();
                    break;
                case "L":
                    view.MoveCurrentToLast();
                    break;
            }
        }
    }

}
