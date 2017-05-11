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

            var lstPhoto = DAL.GetPhotos();
            foreach(var p in lstPhoto)
            {
                Image i = new Image() 
                {
                    Source = p,
                    Width = 200
                };

                lbPhotos.Items.Add(i);
            }
        }
    }
}
