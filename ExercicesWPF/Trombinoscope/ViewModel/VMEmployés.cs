using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Trombinoscope
{
    public class VMEmployés : ViewModelBase
    {
        public ObservableCollection<Employé> Employés { get; }

        private Employé _nouvelEmployé;
        public Employé NouvelEmployé
        {
            get { return _nouvelEmployé; }
            private set
            {
                SetProperty(ref _nouvelEmployé, value);
            }
        }

        public VMEmployés()
        {
            Employés = new ObservableCollection<Employé>(DAL.GetEmployés());
            NouvelEmployé = new Employé();
        }

        private ICommand _cmdAjouter;
        private ICommand _cmdSupprimer;

        public ICommand CmdAjouter
        {
            get
            {
                if (_cmdAjouter == null)
                    _cmdAjouter = new RelayCommand(AjouterEmployé);
                return _cmdAjouter;
            }
            set { _cmdAjouter = value; }
        }

        private void AjouterEmployé(object obj)
        {
            AjoutEmployeWindow wdw = new AjoutEmployeWindow(NouvelEmployé);

            if (wdw.ShowDialog().Value)
            {
                try
                {
                    DAL.AjouterEmployé(NouvelEmployé);
                    NouvelEmployé.Id = DAL.RécupérérIdDernierEmployé();
                    Employés.Add(NouvelEmployé);
                }
                catch (Exception)
                {
                    MessageBox.Show("Impossible d'ajouter l'employé!", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public ICommand CmdSupprimer
        {
            get
            {
                if (_cmdSupprimer == null)
                    _cmdSupprimer = new RelayCommand(SupprimerEmployé);
                return _cmdSupprimer;
            }
            set { _cmdSupprimer = value; }
        }

        private void SupprimerEmployé(object obj)
        {
            Employé employéASuppr = (Employé)CollectionViewSource.GetDefaultView(Employés).CurrentItem;

            try
            {
                DAL.SupprimerEmployé(employéASuppr.Id);
                Employés.Remove(employéASuppr);
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de supprimer l'employé!", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
