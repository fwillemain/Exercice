using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Media;

namespace Trombinoscope
{
    public class Employé : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;


        public int Id { get; set; }
        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set {
                if (value != _nom)
                {
                    _nom = value;
                    RaisePropertyChanged();
                }
            }
        }

        private void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Prénom { get; set; }
        public ImageSource Photo { get; set; }
        public string NomManager { get; set; }
        public string PrénomManager { get; set; }
        public List<Territoire> LstTerritoire { get; set; }

    }

    public class Territoire
    {
        public string Id { get; set; }
        public string Description { get; set; }
    }
}