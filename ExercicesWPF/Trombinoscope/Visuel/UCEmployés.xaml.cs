using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Trombinoscope
{
    /// <summary>
    /// Interaction logic for UCEmployés.xaml
    /// </summary>
    public partial class UCEmployés : UserControl
    {
        private List<Employé> _lstEmployé;
        public UCEmployés()
        {
            InitializeComponent();

            this.Loaded += UCEmployés_Loaded;
            // Sélection d'un nouvel employé dans la liste
            lbEmployés.SelectionChanged += LbEmployés_SelectionChanged;
        }

        private void UCEmployés_Loaded(object sender, RoutedEventArgs e)
        {
            _lstEmployé = DAL.GetEmployés();
            lbEmployés.ItemsSource = _lstEmployé.Select(em => new { NomComplet = em.Nom + " " + em.Prénom, em.Id });
            #region Paramétrage lbEmployés
            lbEmployés.DisplayMemberPath = "NomComplet";
            lbEmployés.SelectedValuePath = "Id"; 
            #endregion
        }

        private void LbEmployés_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Récupérer l'employé sélectuoi
            Employé emp = _lstEmployé.Where(em => em.Id == (int)lbEmployés.SelectedValue).First();
            tbId.Text = emp.Id.ToString();
            tbNom.Text = emp.Nom;
            tbPrénom.Text = emp.Prénom;
        }
    }
}
