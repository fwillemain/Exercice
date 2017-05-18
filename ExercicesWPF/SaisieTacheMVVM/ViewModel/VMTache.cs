using SaisieTacheMVVM.Entités;
using SaisieTacheMVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SaisieTacheMVVM.ViewModel
{
    public enum ModesEdition { Consultation, Edition };

    public class VMTache : ViewModelBase
    {
        #region Champs privés
        private ICommand _ajouterTache;
        private ICommand _supprimerTache;
        private ICommand _enregistrerTache;
        private ICommand _annulerTache;
        private Tache _tacheCourante;
        private ModesEdition _modeEditionCourant;
        #endregion

        #region Propriétés
        public ObservableCollection<Tache> ListeTache { get; set; }
        public Tache TacheCourante
        {
            get { return _tacheCourante ?? ListeTache.FirstOrDefault(); }
            set
            {
                SetProperty(ref _tacheCourante, value);
            }
        }
        public ModesEdition ModeEditionCourant
        {
            get { return _modeEditionCourant; }
            set
            {
                SetProperty(ref _modeEditionCourant, value);
            }
        }
        #endregion

        #region Constructeurs
        public VMTache()
        {
            ListeTache = new ObservableCollection<Tache>(DAL.RécupérerListeTache());
        }
        #endregion

        #region Commandes
        public ICommand CommandeAjouterTache
        {
            get
            {
                if (_ajouterTache == null)
                    _ajouterTache = new RelayCommand(AjouterTache);

                return _ajouterTache;
            }
        }
        private void AjouterTache(object obj)
        {
            var tache = new Tache()
            {
                Id = ListeTache.Any() ? ListeTache.Max(t => t.Id) + 1 : 1,
                DateCréation = DateTime.Today,
                DateEchéance = DateTime.Today,
                Priorité = 1
            };

            ListeTache.Add(tache);
            TacheCourante = tache;
            ModeEditionCourant = ModesEdition.Edition;
        }

        public ICommand CommandeSupprimerTache
        {
            get
            {
                if (_supprimerTache == null)
                    _supprimerTache = new RelayCommand(SupprimerTache);

                return _supprimerTache;
            }
        }
        private void SupprimerTache(object obj)
        {
            ListeTache.Remove(TacheCourante);
        }

        public ICommand CommandeEnregistrerTache
        {
            get
            {
                if (_enregistrerTache == null)
                    _enregistrerTache = new RelayCommand(EnregistrerTache, ActiverBouton);

                return _enregistrerTache;
            }
        }
        private void EnregistrerTache(object obj)
        {
            ModeEditionCourant = ModesEdition.Consultation;
            DAL.EnregistrerListeTache(ListeTache.ToList());
        }

        public ICommand CommandeAnnulerTache
        {
            get
            {
                if (_annulerTache == null)
                    _annulerTache = new RelayCommand(AnnulerCommande, ActiverBouton);

                return _annulerTache;
            }
        }
        private void AnnulerCommande(object obj)
        {
            ListeTache.Remove(TacheCourante);
            ModeEditionCourant = ModesEdition.Consultation;
        }

        // CanExecute pour les commandes EnregistrerTache et AnnulerTache
        private bool ActiverBouton(object obj)
        {
            return _modeEditionCourant == ModesEdition.Edition;
        }
        #endregion
    }
}
