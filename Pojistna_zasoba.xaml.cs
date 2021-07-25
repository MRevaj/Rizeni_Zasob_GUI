using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Rizeni_Zasob_GUI
{
	public partial class Pojistna_zasoba : Window
	{
		private double Q;

		private double d;

		private double Z;

		public Pojistna_zasoba()
		{
			this.InitializeComponent();
		}

		public void Assign()
		{
			double parsedValue_Q;
			double parsedValue_d;
			if (!double.TryParse(this.Tb_Q.Text, out parsedValue_Q))
			{
				MessageBox.Show("Hodnota Q nesplňuje správny formát!");
				return;
			}
			this.Q = double.Parse(this.Tb_Q.Text);
			if (!double.TryParse(this.Tb_d.Text, out parsedValue_d))
			{
				MessageBox.Show("Hodnota d nesplňuje správny formát!");
				return;
			}
			this.d = double.Parse(this.Tb_d.Text);
		}

		public void Calculate()
		{
			this.Z = Math.Round(this.Q / 53 * this.d);
			this.Tb_vysledek.Text = this.Z.ToString();
		}

		private void Clean(object sender, RoutedEventArgs e)
		{
			(new MainWindow()).Show();
			base.Close();
		}

		private void d_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Q_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Vysledek(object sender, RoutedEventArgs e)
		{
			this.Assign();
			this.Calculate();
			this.label.Visibility = System.Windows.Visibility.Visible;
			this.Tb_vysledek.Visibility = System.Windows.Visibility.Visible;
			this.label2.Visibility = System.Windows.Visibility.Visible;
		}

		private void vysledek_TextChanged(object sender, TextChangedEventArgs e)
		{
		}
	}
}