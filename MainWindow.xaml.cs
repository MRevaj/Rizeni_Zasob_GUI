using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Rizeni_Zasob_GUI
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();
		}

		private void Dynamicke_programovani(object sender, RoutedEventArgs e)
		{
			(new Dynamicke_programovani()).Show();
			base.Close();
		}

		private void EOQ(object sender, RoutedEventArgs e)
		{
			(new EOQ()).Show();
			base.Close();
		}

		private void Jednorazova_zasoba(object sender, RoutedEventArgs e)
		{
			(new Jednorazova_zasoba()).Show();
			base.Close();
		}

		private void Pojistna_zasoba(object sender, RoutedEventArgs e)
		{
			(new Pojistna_zasoba()).Show();
			base.Close();
		}

		private void POQ(object sender, RoutedEventArgs e)
		{
			(new POQ()).Show();
			base.Close();
		}

		private void Spojita_poptavka(object sender, RoutedEventArgs e)
		{
			(new Spojita_poptavka()).Show();
			base.Close();
		}
	}
}