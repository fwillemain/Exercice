using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UCEmployés _ucEmpCourant;
        private UCTrombi _ucTrombiCourant;
        private UCTreeView _ucTreeViewCourant;

        public MainWindow()
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

            InitializeComponent();

            miTrombi.Click += MiTrombi_Click;
            miEmployés.Click += MiEmployés_Click;
            miTreeView.Click += MiTreeView_Click;
        }

        private void MiTreeView_Click(object sender, RoutedEventArgs e)
        {
            if (_ucTreeViewCourant == null)
                _ucTreeViewCourant = new UCTreeView();

            contentCtrl.Content = _ucTreeViewCourant;
        }

        private void MiTrombi_Click(object sender, RoutedEventArgs e)
        {
            if (_ucTrombiCourant == null)
                _ucTrombiCourant = new UCTrombi();

            contentCtrl.Content = _ucTrombiCourant;
        }

        private void MiEmployés_Click(object sender, RoutedEventArgs e)
        {
            if(_ucEmpCourant == null)
                _ucEmpCourant = new UCEmployés();

            contentCtrl.Content = _ucEmpCourant;
        }
    }
}
