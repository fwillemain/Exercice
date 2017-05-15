using System;
using System.Windows.Controls;


namespace Trombinoscope
{
    /// <summary>
    /// Interaction logic for UCTrombi.xaml
    /// </summary>
    public partial class UCTrombi : UserControl
    {
        public UCTrombi()
        {
            InitializeComponent();

            this.DataContext = DAL.GetEmployésWithPhoto();
        }
    }
}
