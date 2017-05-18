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
using System.Windows.Shapes;

namespace Trombinoscope
{
    /// <summary>
    /// Interaction logic for AjoutEmployeWindow.xaml
    /// </summary>
    public partial class AjoutEmployeWindow : Window
    {
        public AjoutEmployeWindow(Employé e)
        {
            InitializeComponent();

            btnOk.Click += BtnOk_Click;
            DataContext = e;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNom.Text) || string.IsNullOrWhiteSpace(tbPrénom.Text))
                DialogResult = true;
        }

    }
}
