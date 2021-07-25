using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Rizeni_Zasob_GUI
{
	public partial class Jednorazova_zasoba : Window
	{
		private double u;

		private double q;

		private double c1;

		private double c2;

		private double T;

		private double Y;

		private double vysledek;

		public Jednorazova_zasoba()
		{
			this.InitializeComponent();
		}

		public void Assign()
		{
			double parsedValue_u;
			double parsedValue_q;
			double parsedValue_c1;
			double parsedValue_c2;
			if (!double.TryParse(this.Tb_u.Text, out parsedValue_u))
			{
				MessageBox.Show("Hodnota u nesplňuje správny formát!");
				return;
			}
			this.u = double.Parse(this.Tb_u.Text);
			if (!double.TryParse(this.Tb_q.Text, out parsedValue_q))
			{
				MessageBox.Show("Hodnota q nesplňuje správny formát!");
				return;
			}
			this.q = double.Parse(this.Tb_q.Text);
			if (!double.TryParse(this.Tb_c1.Text, out parsedValue_c1))
			{
				MessageBox.Show("Hodnota c1 nesplňuje správny formát!");
				return;
			}
			this.c1 = double.Parse(this.Tb_c1.Text);
			if (!double.TryParse(this.Tb_c2.Text, out parsedValue_c2))
			{
				MessageBox.Show("Hodnota c2 nesplňuje správny formát!");
				return;
			}
			this.c2 = double.Parse(this.Tb_c2.Text);
		}

		public void Assign_2()
		{
			double parsedValue_T;
			if (!double.TryParse(this.Tb_T.Text, out parsedValue_T))
			{
				MessageBox.Show("Hodnota T nesplňuje správny formát!");
				return;
			}
			this.T = double.Parse(this.Tb_T.Text);
		}

		public void Calculate()
		{
			this.Y = Math.Round(this.c2 / (this.c1 + this.c2), 4);
		}

		public void Calculate_2()
		{
			this.vysledek = Math.Round(this.u + this.T * this.q);
		}

		private void Clean(object sender, RoutedEventArgs e)
		{
			(new MainWindow()).Show();
			base.Close();
		}

		private void TextBox_TextChanged_c1(object sender, TextChangedEventArgs e)
		{
		}

		private void TextBox_TextChanged_c2(object sender, TextChangedEventArgs e)
		{
		}

		private void TextBox_TextChanged_q(object sender, TextChangedEventArgs e)
		{
		}

		private void TextBox_TextChanged_T(object sender, TextChangedEventArgs e)
		{
		}

		private void TextBox_TextChanged_u(object sender, TextChangedEventArgs e)
		{
		}

		private void Vypocitat(object sender, RoutedEventArgs e)
		{
			this.Assign();
			this.Calculate();
			this.Vysledek_1();
		}

		private void Vypocitat_2(object sender, RoutedEventArgs e)
		{
			this.Assign_2();
			this.Calculate_2();
			this.Vysledek_2();
		}

		public void Vysledek_1()
		{
			this.y.Text = this.Y.ToString();
		}

		public void Vysledek_2()
		{
			this.result.Text = this.vysledek.ToString();
		}
	}
}