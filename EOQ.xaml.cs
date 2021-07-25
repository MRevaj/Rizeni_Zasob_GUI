using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Markup;

namespace Rizeni_Zasob_GUI
{
	public partial class EOQ : Window
	{
		private double Q;

		private double sq;

		private double c2;

		private double c1;

		private double c3;

		private double d;

		private double d2;

		private double alfa;

		private double beta;

		private double s;

		private double r2;

		private double q;

		private double N2;

		private double q_s;

		private double Q_q;

		private double q_2;

		private double c2_Q_q;

		private double c1_q_2;

		private double q_;

		private double N;

		private double N_;

		private double t;

		private double r;

		public EOQ()
		{
			this.InitializeComponent();
		}

		public void Assign()
		{
			double parsedValue_Q;
			double parsedValue_sq;
			double parsedValue_c2;
			double parsedValue_c1;
			double parsedValue_d;
			if (!double.TryParse(this.Tb_Q.Text, out parsedValue_Q))
			{
				MessageBox.Show("Hodnota Q nesplňuje správny formát!");
				return;
			}
			this.Q = double.Parse(this.Tb_Q.Text);
			if (!double.TryParse(this.Tb_sq.Text, out parsedValue_sq))
			{
				MessageBox.Show("Hodnota q nesplňuje správny formát!");
				return;
			}
			this.sq = double.Parse(this.Tb_sq.Text);
			if (!double.TryParse(this.Tb_c2.Text, out parsedValue_c2))
			{
				MessageBox.Show("Hodnota c2 nesplňuje správny formát!");
				return;
			}
			this.c2 = double.Parse(this.Tb_c2.Text);
			if (!double.TryParse(this.Tb_c1.Text, out parsedValue_c1))
			{
				MessageBox.Show("Hodnota c1 nesplňuje správny formát!");
				return;
			}
			this.c1 = double.Parse(this.Tb_c1.Text);
			if (!double.TryParse(this.Tb_d.Text, out parsedValue_d))
			{
				MessageBox.Show("Hodnota d nesplňuje správny formát!");
				return;
			}
			this.d = double.Parse(this.Tb_d.Text);
		}

		public void Calculate()
		{
			this.Q_q = this.Q / this.sq;
			this.c2_Q_q = this.Q_q * this.c2;
			this.q_2 = this.sq / 2;
			this.c1_q_2 = this.q_2 * this.c1;
			this.N = Math.Round(this.c2_Q_q + this.c1_q_2);
			this.q_ = Math.Round(Math.Sqrt(2 * this.Q * this.c2 / this.c1));
			this.N_ = Math.Round(Math.Sqrt(2 * this.Q * this.c1 * this.c2));
			this.t = Math.Round(12 / (this.q_ / this.Q * 10));
			this.d2 = 360 / this.d;
			this.r = Math.Round(this.Q / this.d2);
		}

		public void Calculate_Prechod_neuspokojeni()
		{
			double parsedValue_c3;
			if (!double.TryParse(this.Tb_c3.Text, out parsedValue_c3))
			{
				MessageBox.Show("Hodnota c3 nesplňuje správny formát!");
				return;
			}
			this.c3 = double.Parse(this.Tb_c3.Text);
			this.alfa = this.c3 / (this.c1 + this.c3);
			this.beta = 1 - this.alfa;
			this.q = Math.Round(Math.Sqrt(2 * this.Q * this.c2 / this.c1) * Math.Sqrt((this.c1 + this.c3) / this.c3));
			this.s = Math.Round(this.q * this.beta);
			this.q_s = Math.Round(this.q - this.s);
			this.r2 = Math.Round(this.r - this.s) * -1;
			this.N2 = Math.Round(Math.Sqrt(2 * this.Q * this.c1 * this.c2) * Math.Sqrt(this.alfa));
		}

		private void Clean(object sender, RoutedEventArgs e)
		{
			(new MainWindow()).Show();
			base.Close();
		}

		public void Export_Click(object sender, RoutedEventArgs e)
		{
			using (PdfDocument document = new PdfDocument())
			{
				PdfDocument doc = new PdfDocument();
				PdfPage page = doc.Pages.Add();
				PdfGrid pdfGrid = new PdfGrid();
				PdfGrid pdfGrid2 = new PdfGrid();
				PdfGrid pdfGrid3 = new PdfGrid();
				DataTable dataTable = new DataTable();
				DataTable dataTable2 = new DataTable();
				DataTable dataTable3 = new DataTable();
				PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20f, PdfFontStyle.Bold);
				PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 15f, PdfFontStyle.Bold);
				PdfGraphics graphics = page.Graphics;
				PdfStringFormat format = new PdfStringFormat()
				{
					Alignment = PdfTextAlignment.Center
				};
				PdfGridCellStyle headerStyle = new PdfGridCellStyle();
				headerStyle.Borders.All = new PdfPen(new PdfColor(0, 89, 166));
				headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(0, 89, 166));
				headerStyle.TextBrush = PdfBrushes.White;
				headerStyle.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 12f, PdfFontStyle.Regular);
				headerStyle.StringFormat = format;
				PdfGridCellStyle cellStyle = new PdfGridCellStyle()
				{
					StringFormat = format
				};
				PdfGridCellStyle pdfGridCellStyle = new PdfGridCellStyle()
				{
					BackgroundBrush = PdfBrushes.LightSteelBlue,
					StringFormat = format
				};
				dataTable.Columns.Add("Velikost objednavky");
				dataTable.Columns.Add("Celkove naklady");
				dataTable.Columns.Add("Pocet objednavek");
				dataTable.Columns.Add("Bod znovuobjednani");
				dataTable.Rows.Add(new object[] { this.sq, this.N, this.t, this.r });
				dataTable2.Columns.Add("Velikost objednavky");
				dataTable2.Columns.Add("Celkove naklady");
				dataTable2.Columns.Add("Pocet objednavek");
				dataTable2.Columns.Add("Bod znovuobjednani");
				dataTable2.Rows.Add(new object[] { this.q_, this.N_, this.t, this.r });
				dataTable3.Columns.Add("Celkove naklady");
				dataTable3.Columns.Add("Nova dodavka nejpozdeji");
				dataTable3.Columns.Add("Objednat pri poctu");
				dataTable3.Columns.Add("Usetreno");
				dataTable3.Rows.Add(new object[] { this.N2, this.s, this.r2, this.N_ - this.N2 });
				pdfGrid.DataSource = dataTable;
				pdfGrid2.DataSource = dataTable2;
				pdfGrid3.DataSource = dataTable3;
				pdfGrid.Headers.ApplyStyle(headerStyle);
				pdfGrid.Rows.ApplyStyle(cellStyle);
				pdfGrid2.Headers.ApplyStyle(headerStyle);
				pdfGrid2.Rows.ApplyStyle(cellStyle);
				pdfGrid3.Headers.ApplyStyle(headerStyle);
				pdfGrid3.Rows.ApplyStyle(cellStyle);
				graphics.DrawString("EOQ", font, PdfBrushes.Black, new PointF(250f, 20f));
				graphics.DrawString(string.Concat("Velikost poptavky: ", this.Q.ToString()), font2, PdfBrushes.Black, new PointF(0f, 70f));
				graphics.DrawString(string.Concat("Velikost objednavky: ", this.sq.ToString()), font2, PdfBrushes.Black, new PointF(0f, 90f));
				graphics.DrawString(string.Concat("Fixni náklady: ", this.c2.ToString()), font2, PdfBrushes.Black, new PointF(0f, 110f));
				graphics.DrawString(string.Concat("Skladovaci naklady: ", this.c1.ToString()), font2, PdfBrushes.Black, new PointF(0f, 130f));
				graphics.DrawString(string.Concat("Delka doruceni: ", this.d.ToString()), font2, PdfBrushes.Black, new PointF(0f, 150f));
				graphics.DrawString(string.Concat("Naklady z nedostatku zasoby: ", this.c3.ToString()), font2, PdfBrushes.Black, new PointF(0f, 170f));
				graphics.DrawString("ZVOLENA STRATEGIE", font2, PdfBrushes.Black, new PointF(190f, 250f));
				pdfGrid.Draw(page, new PointF(50f, 280f));
				graphics.DrawString("OPTIMALNI STRATEGIE", font2, PdfBrushes.Black, new PointF(190f, 350f));
				pdfGrid2.Draw(page, new PointF(50f, 380f));
				graphics.DrawString("PRECHODNE NEUSPOKOJENI POPTAVKY", font2, PdfBrushes.Black, new PointF(110f, 450f));
				pdfGrid3.Draw(page, new PointF(50f, 480f));
				doc.Save("EOQ.pdf");
				doc.Close(true);
				if (MessageBox.Show("Přejete si zobrazit PDF?", "Hotovo!", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
				{
					try
					{
						Process.Start("EOQ.pdf");
					}
					catch (Win32Exception win32Exception)
					{
						Console.WriteLine(win32Exception.ToString());
					}
				}
			}
		}

		public void Graf()
		{
			((ColumnSeries)this.mcChart.Series[0]).ItemsSource = (IEnumerable)(new KeyValuePair<string, double>[] { new KeyValuePair<string, double>("Vaše strategie", this.N), new KeyValuePair<string, double>("Optimální strategie", this.N_) });
		}

		private void Prechod_neuspokojeni(object sender, RoutedEventArgs e)
		{
			this.Calculate_Prechod_neuspokojeni();
			this.Results2();
		}

		public void Results()
		{
			List<EOQ.Vysledky> vysledky = new List<EOQ.Vysledky>()
			{
				new EOQ.Vysledky()
				{
					Velikost_objednavky = this.q_,
					Naklady = this.N_,
					Pocet_objednani = this.t,
					Bod_znovuobjednani = this.r
				}
			};
			this.ResultOptimal.ItemsSource = vysledky;
		}

		public void Results2()
		{
			List<EOQ.Vysledky2> vysledky2 = new List<EOQ.Vysledky2>()
			{
				new EOQ.Vysledky2()
				{
					Celkove_naklady = this.N2,
					Nova_dodavka_nejpozdeji = this.s,
					Objednat_pri = this.r2,
					Usetreno = this.N_ - this.N2
				}
			};
			this.Result_2.ItemsSource = vysledky2;
		}

		public void Results3()
		{
			List<EOQ.Vysledky3> vysledky3 = new List<EOQ.Vysledky3>()
			{
				new EOQ.Vysledky3()
				{
					Velikost_objednavky = this.sq,
					Naklady = this.N,
					Pocet_objednani = this.t,
					Bod_znovuobjednani = this.r
				}
			};
			this.ResultUser.ItemsSource = vysledky3;
		}

		private void Tb_c1_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Tb_c2_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Tb_c3_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Tb_d_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Tb_Q_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Tb_sq_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Vypocitat(object sender, RoutedEventArgs e)
		{
			this.Assign();
			this.Calculate();
			this.Results();
			this.Results3();
			this.Graf();
			this.Tb_c3.Visibility = System.Windows.Visibility.Visible;
			this.Vypocitat2.Visibility = System.Windows.Visibility.Visible;
			this.Label_nadpis_poptavka.Visibility = System.Windows.Visibility.Visible;
			this.Result_2.Visibility = System.Windows.Visibility.Visible;
			this.Label_prechod_neuspokojeni.Visibility = System.Windows.Visibility.Visible;
		}

		public class Vysledky
		{
			public double Bod_znovuobjednani
			{
				get;
				set;
			}

			public double Naklady
			{
				get;
				set;
			}

			public double Pocet_objednani
			{
				get;
				set;
			}

			public double Velikost_objednavky
			{
				get;
				set;
			}

			public Vysledky()
			{
			}
		}

		public class Vysledky2
		{
			public double Celkove_naklady
			{
				get;
				set;
			}

			public double Nova_dodavka_nejpozdeji
			{
				get;
				set;
			}

			public double Objednat_pri
			{
				get;
				set;
			}

			public double Usetreno
			{
				get;
				set;
			}

			public Vysledky2()
			{
			}
		}

		public class Vysledky3
		{
			public double Bod_znovuobjednani
			{
				get;
				set;
			}

			public double Naklady
			{
				get;
				set;
			}

			public double Pocet_objednani
			{
				get;
				set;
			}

			public double Velikost_objednavky
			{
				get;
				set;
			}

			public Vysledky3()
			{
			}
		}
	}
}