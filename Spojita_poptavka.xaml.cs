using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Rizeni_Zasob_GUI
{
	public partial class Spojita_poptavka : Window
	{
		private double Q;

		private double c1;

		private double c2;

		private double Oq;

		private double d;

		private double r;

		private double w;

		private double r2;

		private double z;

		private double q2;

		private double Od;

		public Spojita_poptavka()
		{
			this.InitializeComponent();
		}

		public void Assign()
		{
			double parsedValue_Q;
			double parsedValue_c1;
			double parsedValue_c2;
			double parsedValue_Oq;
			double parsedValue_z;
			double parsedValue_d;
			if (!double.TryParse(this.Tb_Q.Text, out parsedValue_Q))
			{
				MessageBox.Show("Hodnota Q nesplňuje správny formát!");
				return;
			}
			this.Q = double.Parse(this.Tb_Q.Text);
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
			if (!double.TryParse(this.Tb_Oq.Text, out parsedValue_Oq))
			{
				MessageBox.Show("Hodnota Oq nesplňuje správny formát!");
				return;
			}
			this.Oq = double.Parse(this.Tb_Oq.Text);
			if (!double.TryParse(this.Tb_z.Text, out parsedValue_z))
			{
				MessageBox.Show("Hodnota z nesplňuje správny formát!");
				return;
			}
			this.z = double.Parse(this.Tb_z.Text);
			if (!double.TryParse(this.Tb_d.Text, out parsedValue_d))
			{
				MessageBox.Show("Hodnota d nesplňuje správny formát!");
				return;
			}
			this.d = double.Parse(this.Tb_d.Text);
		}

		private void c1_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void c2_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		public void Calculate()
		{
			this.q2 = Math.Round(Math.Sqrt(2 * this.Q * this.c2 / this.c1));
			this.d = 360 / this.d;
			this.r = Math.Round(this.Q / this.d);
			this.Od = Math.Round(this.Oq / this.d);
			this.w = Math.Round(this.z * this.Od);
			this.r2 = Math.Round(this.r + this.w);
		}

		private void Clean(object sender, RoutedEventArgs e)
		{
			(new MainWindow()).Show();
			base.Close();
		}

		private void d_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void N_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Oq_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Q_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void q2_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void r_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		public void Results()
		{
			this.Tb_q2.Text = this.q2.ToString();
			this.Tb_r.Text = this.r.ToString();
			this.Tb_N.Text = string.Concat(new string[] { "N(", this.r.ToString(), ", ", this.Od.ToString(), ")" });
			this.Tb_r2.Text = this.r2.ToString();
			this.Tb_w.Text = this.w.ToString();
		}

		private void Vypocitat(object sender, RoutedEventArgs e)
		{
			this.Assign();
			this.Calculate();
			this.Results();
		}

		private void vysledek_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void z_TextChanged(object sender, TextChangedEventArgs e)
		{
		}
	}
}