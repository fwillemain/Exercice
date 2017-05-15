using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace Trombinoscope
{
    public class Employé
    {
        public int Id { get; set; }
        public string Nom { get; set; }
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