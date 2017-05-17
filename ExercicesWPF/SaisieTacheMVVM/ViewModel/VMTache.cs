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
        public ObservableCollection<Tache> ListeTache { get; set; }

        public VMTache()
        {
            ListeTache = new ObservableCollection<Tache>(DAL.RécupérerListeTache());
        }

        ICommand _ajouterTache;
        ICommand _supprimerTache;
        ICommand _enregistrerTache;
        ICommand _annulerTache;
        Tache _tacheCourante;
        ModesEdition _modeEditionCourant;

        // TODO : revoir RelayCommand et la création des commandes dans le Context pour être à l'aise
        public ICommand CommandeAjouterTache
        {
            get
            {
                if (_ajouterTache == null)
                    _ajouterTache = new RelayCommand(AjouterTache);

                return _ajouterTache;
            }
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
        public ICommand CommandeEnregistrerTache
        {
            get
            {
                if (_enregistrerTache == null)
                    _enregistrerTache = new RelayCommand(EnregistrerTache, ActiverBouton);

                return _enregistrerTache;
            }
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

        private bool ActiverBouton(object obj)
        {
            return _modeEditionCourant == ModesEdition.Edition;
        }

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

        private void SupprimerTache(object obj)
        {
            ListeTache.Remove(TacheCourante);
        }

        private void EnregistrerTache(object obj)
        {
            ModeEditionCourant = ModesEdition.Consultation;
            DAL.EnregistrerListeTache(ListeTache.ToList());
        }

        private void AnnulerCommande(object obj)
        {
            ListeTache.Remove(TacheCourante);
            ModeEditionCourant = ModesEdition.Consultation;
        }
    }
}
