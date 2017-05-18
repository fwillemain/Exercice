using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace RelevésMétéo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DALMeteo _dal;

        public MainWindow()
        {
            InitializeComponent();
            Language = System.Windows.Markup.XmlLanguage.GetLanguage(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
            _dal = new DALMeteo();

            btnFichier.Click += BtnFichier_Click;
            cbVue.SelectionChanged += CbVue_SelectionChanged;
            cbTri.SelectionChanged += CbVue_SelectionChanged;
            cbTriSens.SelectionChanged += CbVue_SelectionChanged;
        }

        private void CbVue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbMétéo.ItemTemplate = (DataTemplate)Resources[cbVue.SelectedValue];

            ICollectionView view = CollectionViewSource.GetDefaultView(_dal.Data);

            view.SortDescriptions.Clear();
            view.GroupDescriptions.Clear();

            string critèreTri = cbTri.SelectedValue.ToString();
            var sensTri = cbTriSens.SelectedIndex == 0 ? ListSortDirection.Ascending : ListSortDirection.Descending;
            if (critèreTri == "Mois")
                view.SortDescriptions.Add(new SortDescription("Date", sensTri));
            else
                view.SortDescriptions.Add(new SortDescription(critèreTri, sensTri));

            if (cbVue.SelectedValue.ToString() == "TemplateListGroup")
            {
                view.SortDescriptions.Add(new SortDescription("Date", sensTri));
                view.GroupDescriptions.Add(new PropertyGroupDescription("Année"));
            }

        }

        private void BtnFichier_Click(object sender, RoutedEventArgs e)
        {
            var dial = new OpenFileDialog();

            if (dial.ShowDialog().Value)
            {
                string file = dial.FileName;
                tbFichier.Text = file;

                try
                {
                    _dal.ChargerDonnées(file);
                    this.DataContext = _dal;
                }
                catch (Exception)
                {
                    MessageBox.Show("Impossible de charger les données", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
