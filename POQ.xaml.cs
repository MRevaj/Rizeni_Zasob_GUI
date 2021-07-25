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
	public partial class POQ : Window
	{
		private double Q;

		private double p;

		private double h;

		private double d;

		private double c1;

		private double c2;

		private double q;

		private double N;

		private double t;

		private double t1;

		private double r;

		private double m;

		public POQ()
		{
			this.InitializeComponent();
		}

		public void Assign()
		{
			double parsedValue_Q;
			double parsedValue_c1;
			double parsedValue_c2;
			double parsedValue_p;
			double parsedValue_h;
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
			if (!double.TryParse(this.Tb_p.Text, out parsedValue_p))
			{
				MessageBox.Show("Hodnota p nesplňuje správny formát!");
				return;
			}
			this.p = double.Parse(this.Tb_p.Text);
			if (!double.TryParse(this.Tb_h.Text, out parsedValue_h))
			{
				MessageBox.Show("Hodnota h nesplňuje správny formát!");
				return;
			}
			this.h = double.Parse(this.Tb_h.Text);
			if (!double.TryParse(this.Tb_d.Text, out parsedValue_d))
			{
				MessageBox.Show("Hodnota d nesplňuje správny formát!");
				return;
			}
			this.d = double.Parse(this.Tb_d.Text);
		}

		public void Calculate()
		{
			this.q = Math.Round(Math.Sqrt(2 * this.Q * this.c2 / this.c1) * Math.Sqrt(this.p / (this.p - this.h)));
			this.N = Math.Round(Math.Sqrt(2 * this.Q * this.c1 * this.c2) * Math.Sqrt((this.p - this.h) / this.p));
			this.t = Math.Round(this.Q / this.q);
			this.t1 = this.q / this.p;
			this.m = Math.Round((this.p - this.h) * this.t1);
			this.r = Math.Round(this.d / 365 * this.Q);
		}

		public void Clean(object sender, RoutedEventArgs e)
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
				DataTable dataTable = new DataTable();
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
				dataTable.Columns.Add("Celkove naklady");
				dataTable.Columns.Add("Polozky v cyklu");
				dataTable.Columns.Add("Pocet cyklu");
				dataTable.Columns.Add("Maximalni pocet polozek na sklade");
				dataTable.Columns.Add("Zacit vyrabet pri poctu");
				dataTable.Rows.Add(new object[] { this.N, this.q, this.t, this.m, this.r });
				pdfGrid.DataSource = dataTable;
				pdfGrid.Headers.ApplyStyle(headerStyle);
				pdfGrid.Rows.ApplyStyle(cellStyle);
				graphics.DrawString("POQ", font, PdfBrushes.Black, new PointF(250f, 20f));
				graphics.DrawString(string.Concat("Poptavka: ", this.Q.ToString()), font2, PdfBrushes.Black, new PointF(0f, 70f));
				graphics.DrawString(string.Concat("Vyrobni kapacita: ", this.p.ToString()), font2, PdfBrushes.Black, new PointF(0f, 90f));
				graphics.DrawString(string.Concat("Spotreba: ", this.h.ToString()), font2, PdfBrushes.Black, new PointF(0f, 110f));
				graphics.DrawString(string.Concat("Delka vyrobniho cyklu: ", this.d.ToString()), font2, PdfBrushes.Black, new PointF(0f, 130f));
				graphics.DrawString(string.Concat("Skladovaci naklady: ", this.c1.ToString()), font2, PdfBrushes.Black, new PointF(0f, 150f));
				graphics.DrawString(string.Concat("Fixni naklady: ", this.c2.ToString()), font2, PdfBrushes.Black, new PointF(0f, 170f));
				graphics.DrawString("OPTIMALNI STRATEGIE", font2, PdfBrushes.Black, new PointF(190f, 250f));
				pdfGrid.Draw(page, new PointF(50f, 280f));
				doc.Save("POQ.pdf");
				doc.Close(true);
				if (MessageBox.Show("Přejete si zobrazit PDF?", "Hotovo!", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
				{
					try
					{
						Process.Start("POQ.pdf");
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
			((PieSeries)this.mcChart.Series[0]).ItemsSource = (IEnumerable)(new KeyValuePair<string, double>[] { new KeyValuePair<string, double>("Celkové náklady", 12), new KeyValuePair<string, double>("Počet vyrobených položek v cyklu", 25), new KeyValuePair<string, double>("Počet cyklů", 5), new KeyValuePair<string, double>("Maximálně kusů na skladě", 6), new KeyValuePair<string, double>("Počet kusů, kdy započít výrobu", 10) });
		}

		public void Results()
		{
			List<POQ.Vysledky> vysledky = new List<POQ.Vysledky>()
			{
				new POQ.Vysledky()
				{
					Celkove_naklady = this.N,
					Polozky_v_cyklu = this.q,
					Pocet_cyklu = this.t,
					Max_polozky_sklad = this.m,
					Zacit_vyrabet_pri = this.r
				}
			};
			this.Result.ItemsSource = vysledky;
		}

		private void Tb_c1_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Tb_c2_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Tb_d_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Tb_h_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Tb_p_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Tb_Q_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Vykreslit(object sender, RoutedEventArgs e)
		{
			this.Graf();
		}

		private void Vypocitat(object sender, RoutedEventArgs e)
		{
			this.Assign();
			this.Calculate();
			this.Results();
		}

		public class Vysledky
		{
			public double Celkove_naklady
			{
				get;
				set;
			}

			public double Max_polozky_sklad
			{
				get;
				set;
			}

			public double Pocet_cyklu
			{
				get;
				set;
			}

			public double Polozky_v_cyklu
			{
				get;
				set;
			}

			public double Zacit_vyrabet_pri
			{
				get;
				set;
			}

			public Vysledky()
			{
			}
		}
	}
}