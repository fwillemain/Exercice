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

namespace Paramétrage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UCGénéral _ucGénéral;
        private UCAffichage _ucAffichage;

        public MainWindow()
        {
            InitializeComponent();

            tcMenu.SelectionChanged += TcMenu_SelectionChanged;
        }

        private void TcMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tab = (TabItem)tcMenu.SelectedItem;
            switch (tab.Name)
            {
                case "tiGénéral":
                    if (_ucGénéral == null)
                        _ucGénéral = new UCGénéral();

                    tab.Content = _ucGénéral;
                    break;

                case "tiAffichage":
                    if (_ucAffichage == null)
                        _ucAffichage = new UCAffichage();

                    tab.Content = _ucAffichage;
                    break;

                default:
                    break;
            }
        }
    }
}
