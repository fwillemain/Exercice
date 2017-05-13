using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SaisieTache
{

    public enum ModesEdition { Consultation, Edition };

    public class Contexte : INotifyPropertyChanged
    {
        #region Champs privés
        private ICommand _cmdAjouter;
        private ICommand _cmdSupprimer;
        private ICommand _cmdEnregistrer;
        private ICommand _cmdAnnuler;
        private ModesEdition _modeEdit;
        private Tache _tacheSelectionnée;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        #region Propriétés
        public ICommand CmdAjouter
        {
            get
            {
                if (_cmdAjouter == null)
                    _cmdAjouter = new RelayCommand(AjouterTache);

                return _cmdAjouter;
            }

        }
        public ICommand CmdSupprimer
        {
            get
            {
                if (_cmdSupprimer == null)
                    _cmdSupprimer = new RelayCommand(SupprimerTache);

                return _cmdSupprimer;
            }

        }
        public ICommand CmdEnregistrer
        {
            get
            {
                if (_cmdEnregistrer == null)
                    _cmdEnregistrer = new RelayCommand(EnregistrerTache);

                return _cmdEnregistrer;
            }

        }
        public ICommand CmdAnnuler
        {
            get
            {
                if (_cmdAnnuler == null)
                    _cmdAnnuler = new RelayCommand(AnnulerTache);

                return _cmdAnnuler;
            }

        }

        public ObservableCollection<Tache> Taches { get; private set; }
        public ModesEdition ModeEdit
        {
            get { return _modeEdit; }
            set
            {
                _modeEdit = value;
                RaisePropertyChanged("ModeEdit");
            }
        }
        public Tache TacheSelectionnée
        {
            get { return _tacheSelectionnée ?? Taches.FirstOrDefault(); }
            set
            {
                _tacheSelectionnée = value;
                RaisePropertyChanged("TacheSelectionnée");
            }
        }

        private void RaisePropertyChanged(string caller = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
        #endregion

        #region Constructeurs
        public Contexte()
        {
            Taches = AccèsDonnées.ChargerDonnées();
        }
        #endregion

        #region Méthodes privées
        private void AjouterTache(object sender)
        {
            Tache task = new Tache()
            {
                Id = Taches.Any() ? Taches.Max(t => t.Id) + 1 : 1,
                Creation = DateTime.Today,
                Term = DateTime.Today,
                Prio = 1
            };

            Taches.Add(task);

            TacheSelectionnée = task;
            ModeEdit = ModesEdition.Edition;
        }

        private void EnregistrerTache(object sender)
        {
            if (Taches.Last().Description != null)
            {
                AccèsDonnées.EnregistrerTaches(Taches);
                ModeEdit = ModesEdition.Consultation;
            }
        }

        private void SupprimerTache(object sender)
        {
            if (TacheSelectionnée != null)
            {
                Taches.Remove(TacheSelectionnée);
                TacheSelectionnée = Taches.LastOrDefault();
                AccèsDonnées.EnregistrerTaches(Taches);
            }
        }

        private void AnnulerTache(object sender)
        {
            Taches.Remove(TacheSelectionnée);
            TacheSelectionnée = Taches.LastOrDefault();

            ModeEdit = ModesEdition.Consultation;
        }
        #endregion
    }
}
