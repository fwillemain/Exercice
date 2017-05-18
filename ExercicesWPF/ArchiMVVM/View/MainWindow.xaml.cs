using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace Divers.View
{
	/// <summary>
	/// Logique d'interaction pour MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			DataContext = new ViewModel.VMMain();
		}
	}
}
