using Solver;
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
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Markup;

namespace Rizeni_Zasob_GUI
{
	public partial class Dynamicke_programovani : Window
	{
		private double porizovaciCena;

		private double skladovaciCena;

		public double poptavka1;

		public double poptavka2;

		public double poptavka3;

		public double poptavka4;

		public double poptavka5;

		public double poptavka6;

		private int zacatekObdobi1;

		private int zacatekObdobi2;

		private int zacatekObdobi3;

		private int zacatekObdobi4;

		private int zacatekObdobi5;

		private int zacatekObdobi6;

		private double dobaPredchoziObjednavky1;

		private double dobaPredchoziObjednavky2;

		private double dobaPredchoziObjednavky3;

		private double dobaPredchoziObjednavky4;

		private double dobaPredchoziObjednavky5;

		private double dobaPredchoziObjednavky6;

		private double N11;

		private double N12;

		private double N13;

		private double N14;

		private double N15;

		private double N16;

		private double N22;

		private double N23;

		private double N24;

		private double N25;

		private double N26;

		private double N33;

		private double N34;

		private double N35;

		private double N36;

		private double N44;

		private double N45;

		private double N46;

		private double N55;

		private double N56;

		private double N66;

		private double f0;

		private double f1;

		private double f2;

		private double f3;

		private double f4;

		private double f5;

		private double f6;

		private double PocetJednotek1;

		private double PocetJednotek2;

		private double PocetJednotek3;

		private double PocetJednotek4;

		private double PocetJednotek5;

		private double PocetJednotek6;

		private double a;

		private double b;

		private double c;

		private double d;

		private double e;

		public Dynamicke_programovani()
		{
			this.InitializeComponent();
		}

		public void Assign()
		{
			double parsedValue_porizovaciCena;
			double parsedValue_skladovaciCena;
			double parsedValue_tbP1;
			double parsedValue_tbP2;
			double parsedValue_tbP3;
			double parsedValue_tbP4;
			double parsedValue_tbP5;
			double parsedValue_tbP6;
			if (!double.TryParse(this.tbPorizCena.Text, out parsedValue_porizovaciCena))
			{
				MessageBox.Show("Hodnota pořizovací ceny nesplňuje číselný formát!");
				return;
			}
			this.porizovaciCena = double.Parse(this.tbPorizCena.Text);
			if (!double.TryParse(this.tbSkladCena.Text, out parsedValue_skladovaciCena))
			{
				MessageBox.Show("Hodnota ceny skladování nesplňuje číselný formát!");
				return;
			}
			this.skladovaciCena = double.Parse(this.tbSkladCena.Text);
			if (!double.TryParse(this.tbP1.Text, out parsedValue_tbP1))
			{
				MessageBox.Show("Hodnota 1. poptávky nesplňuje číselný formát!");
				return;
			}
			this.poptavka1 = double.Parse(this.tbP1.Text);
			if (!double.TryParse(this.tbP2.Text, out parsedValue_tbP2))
			{
				MessageBox.Show("Hodnota 2. poptávky nesplňuje číselný formát!");
				return;
			}
			this.poptavka2 = double.Parse(this.tbP2.Text);
			if (!double.TryParse(this.tbP3.Text, out parsedValue_tbP3))
			{
				MessageBox.Show("Hodnota 3. poptávky nesplňuje číselný formát!");
				return;
			}
			this.poptavka3 = double.Parse(this.tbP3.Text);
			if (!double.TryParse(this.tbP4.Text, out parsedValue_tbP4))
			{
				MessageBox.Show("Hodnota 4. poptávky nesplňuje číselný formát!");
				return;
			}
			this.poptavka4 = double.Parse(this.tbP4.Text);
			if (!double.TryParse(this.tbP5.Text, out parsedValue_tbP5))
			{
				MessageBox.Show("Hodnota 5. poptávky nesplňuje číselný formát!");
				return;
			}
			this.poptavka5 = double.Parse(this.tbP5.Text);
			if (!double.TryParse(this.tbP6.Text, out parsedValue_tbP6))
			{
				MessageBox.Show("Hodnota 6. poptávky nesplňuje číselný formát!");
				return;
			}
			this.poptavka6 = double.Parse(this.tbP6.Text);
			this.zacatekObdobi1 = 0;
			try
			{
				this.zacatekObdobi2 = this.Calendar2.SelectedDate.Value.Day;
				this.zacatekObdobi3 = this.Calendar3.SelectedDate.Value.Day;
				this.zacatekObdobi4 = this.Calendar4.SelectedDate.Value.Day;
				this.zacatekObdobi5 = this.Calendar5.SelectedDate.Value.Day;
				this.zacatekObdobi6 = this.Calendar6.SelectedDate.Value.Day;
			}
			catch
			{
			}
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
				DataTable dataTable = new DataTable();
				PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20f, PdfFontStyle.Bold);
				PdfGraphics graphics = page.Graphics;
				PdfStringFormat format = new PdfStringFormat()
				{
					Alignment = PdfTextAlignment.Center
				};
				PdfGridCellStyle headerStyle = new PdfGridCellStyle();
				headerStyle.Borders.All = new PdfPen(new PdfColor(0, 89, 166));
				headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(0, 89, 166));
				headerStyle.TextBrush = PdfBrushes.White;
				headerStyle.Font = new PdfStandardFont(PdfFontFamily.Helvetica, 10f, PdfFontStyle.Regular);
				headerStyle.StringFormat = format;
				PdfGridCellStyle cellStyle = new PdfGridCellStyle()
				{
					StringFormat = format
				};
				PdfGridCellStyle cellStyle2 = new PdfGridCellStyle()
				{
					BackgroundBrush = PdfBrushes.LightSteelBlue,
					StringFormat = format
				};
				dataTable.Columns.Add("Cislo obdobi");
				dataTable.Columns.Add("Vyse poptavky");
				dataTable.Columns.Add("Zacatek obdobi");
				dataTable.Columns.Add("Doba predchozi objednavky");
				dataTable.Columns.Add("Pocet kusu");
				dataTable.Columns.Add("Minimalni naklady");
				dataTable.Rows.Add(new object[] { "1", this.poptavka1, this.zacatekObdobi1, this.dobaPredchoziObjednavky1, this.PocetJednotek1, this.f1 });
				dataTable.Rows.Add(new object[] { "2", this.poptavka2, this.zacatekObdobi2, this.dobaPredchoziObjednavky2, this.PocetJednotek2, this.f2 });
				dataTable.Rows.Add(new object[] { "3", this.poptavka3, this.zacatekObdobi3, this.dobaPredchoziObjednavky3, this.PocetJednotek3, this.f3 });
				dataTable.Rows.Add(new object[] { "4", this.poptavka4, this.zacatekObdobi4, this.dobaPredchoziObjednavky4, this.PocetJednotek4, this.f4 });
				dataTable.Rows.Add(new object[] { "5", this.poptavka5, this.zacatekObdobi5, this.dobaPredchoziObjednavky5, this.PocetJednotek5, this.f5 });
				dataTable.Rows.Add(new object[] { "6", this.poptavka6, this.zacatekObdobi6, this.dobaPredchoziObjednavky6, this.PocetJednotek6, this.f6 });
				pdfGrid.DataSource = dataTable;
				pdfGrid.Headers.ApplyStyle(headerStyle);
				pdfGrid.Rows.ApplyStyle(cellStyle);
				pdfGrid.Rows[0].ApplyStyle(cellStyle2);
				pdfGrid.Rows[2].ApplyStyle(cellStyle2);
				pdfGrid.Rows[4].ApplyStyle(cellStyle2);
				graphics.DrawString("Dynamické programování", font, PdfBrushes.Black, new PointF(150f, 20f));
				pdfGrid.Draw(page, new PointF(50f, 70f));
				doc.Save("Dynam_prog.pdf");
				doc.Close(true);
				if (MessageBox.Show("Přejete si zobrazit PDF?", "Hotovo!", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
				{
					try
					{
						Process.Start("Dynam_prog.pdf");
					}
					catch (Win32Exception win32Exception)
					{
						Console.WriteLine(win32Exception.ToString());
					}
				}
			}
		}

		public void Funkce()
		{
			this.f1 = (new double[] { this.f0 + this.N11 }).Min();
			this.f2 = (new double[] { this.f0 + this.N12, this.f1 + this.N22 }).Min();
			this.f3 = (new double[] { this.f0 + this.N13, this.f1 + this.N23, this.f2 + this.N33 }).Min();
			this.f4 = (new double[] { this.f0 + this.N14, this.f1 + this.N24, this.f2 + this.N34, this.f3 + this.N44 }).Min();
			this.f5 = (new double[] { this.f0 + this.N15, this.f1 + this.N25, this.f2 + this.N35, this.f3 + this.N45, this.f4 + this.N55 }).Min();
			this.f6 = (new double[] { this.f0 + this.N16, this.f1 + this.N26, this.f2 + this.N36, this.f3 + this.N46, this.f4 + this.N56, this.f5 + this.N66 }).Min();
		}

		public void Graf()
		{
			double Poptavkycelkem = this.poptavka1 + this.poptavka2 + this.poptavka3 + this.poptavka4 + this.poptavka5 + this.poptavka6;
			double Nakladycelkem = this.f1 + this.f2 + this.f3 + this.f4 + this.f5 + this.f6;
			((ColumnSeries)this.mcChart.Series[0]).ItemsSource = (IEnumerable)(new KeyValuePair<string, double>[] { new KeyValuePair<string, double>("Hodnota Poptávek", Poptavkycelkem), new KeyValuePair<string, double>("Celkové Náklady", Nakladycelkem) });
		}

		public void Matice()
		{
			Matrix matrix = new Matrix();
			this.N11 = matrix.N11(this.porizovaciCena, this.skladovaciCena, this.poptavka1, (double)this.zacatekObdobi1);
			this.N12 = matrix.N12(this.porizovaciCena, this.skladovaciCena, this.poptavka1, this.poptavka2, (double)this.zacatekObdobi1, (double)this.zacatekObdobi2);
			this.N13 = matrix.N13(this.porizovaciCena, this.skladovaciCena, this.poptavka1, this.poptavka2, this.poptavka3, (double)this.zacatekObdobi1, (double)this.zacatekObdobi2, (double)this.zacatekObdobi3);
			this.N14 = matrix.N14(this.porizovaciCena, this.skladovaciCena, this.poptavka1, this.poptavka2, this.poptavka3, this.poptavka4, (double)this.zacatekObdobi1, (double)this.zacatekObdobi2, (double)this.zacatekObdobi3, (double)this.zacatekObdobi4);
			this.N15 = matrix.N15(this.porizovaciCena, this.skladovaciCena, this.poptavka1, this.poptavka2, this.poptavka3, this.poptavka4, this.poptavka5, (double)this.zacatekObdobi1, (double)this.zacatekObdobi2, (double)this.zacatekObdobi3, (double)this.zacatekObdobi4, (double)this.zacatekObdobi5);
			this.N16 = matrix.N16(this.porizovaciCena, this.skladovaciCena, this.poptavka1, this.poptavka2, this.poptavka3, this.poptavka4, this.poptavka5, this.poptavka6, (double)this.zacatekObdobi1, (double)this.zacatekObdobi2, (double)this.zacatekObdobi3, (double)this.zacatekObdobi4, (double)this.zacatekObdobi5, (double)this.zacatekObdobi6);
			this.N22 = matrix.N22(this.porizovaciCena, this.skladovaciCena, this.poptavka2, (double)this.zacatekObdobi2);
			this.N23 = matrix.N23(this.porizovaciCena, this.skladovaciCena, this.poptavka2, this.poptavka3, (double)this.zacatekObdobi2, (double)this.zacatekObdobi3);
			this.N24 = matrix.N24(this.porizovaciCena, this.skladovaciCena, this.poptavka2, this.poptavka3, this.poptavka4, (double)this.zacatekObdobi2, (double)this.zacatekObdobi3, (double)this.zacatekObdobi4);
			this.N25 = matrix.N25(this.porizovaciCena, this.skladovaciCena, this.poptavka2, this.poptavka3, this.poptavka4, this.poptavka5, (double)this.zacatekObdobi2, (double)this.zacatekObdobi3, (double)this.zacatekObdobi4, (double)this.zacatekObdobi5);
			this.N26 = matrix.N26(this.porizovaciCena, this.skladovaciCena, this.poptavka2, this.poptavka3, this.poptavka4, this.poptavka5, this.poptavka6, (double)this.zacatekObdobi2, (double)this.zacatekObdobi3, (double)this.zacatekObdobi4, (double)this.zacatekObdobi5, (double)this.zacatekObdobi6);
			this.N33 = matrix.N33(this.porizovaciCena, this.skladovaciCena, this.poptavka3, (double)this.zacatekObdobi3);
			this.N34 = matrix.N34(this.porizovaciCena, this.skladovaciCena, this.poptavka3, this.poptavka4, (double)this.zacatekObdobi3, (double)this.zacatekObdobi4);
			this.N35 = matrix.N35(this.porizovaciCena, this.skladovaciCena, this.poptavka3, this.poptavka4, this.poptavka5, (double)this.zacatekObdobi3, (double)this.zacatekObdobi4, (double)this.zacatekObdobi5);
			this.N36 = matrix.N36(this.porizovaciCena, this.skladovaciCena, this.poptavka3, this.poptavka4, this.poptavka5, this.poptavka6, (double)this.zacatekObdobi3, (double)this.zacatekObdobi4, (double)this.zacatekObdobi5, (double)this.zacatekObdobi6);
			this.N44 = matrix.N44(this.porizovaciCena, this.skladovaciCena, this.poptavka4, (double)this.zacatekObdobi4);
			this.N45 = matrix.N45(this.porizovaciCena, this.skladovaciCena, this.poptavka4, this.poptavka5, (double)this.zacatekObdobi4, (double)this.zacatekObdobi5);
			this.N46 = matrix.N46(this.porizovaciCena, this.skladovaciCena, this.poptavka4, this.poptavka5, this.poptavka6, (double)this.zacatekObdobi4, (double)this.zacatekObdobi5, (double)this.zacatekObdobi6);
			this.N55 = matrix.N55(this.porizovaciCena, this.skladovaciCena, this.poptavka5, (double)this.zacatekObdobi5);
			this.N56 = matrix.N56(this.porizovaciCena, this.skladovaciCena, this.poptavka5, this.poptavka6, (double)this.zacatekObdobi5, (double)this.zacatekObdobi6);
			this.N66 = matrix.N66(this.porizovaciCena, this.skladovaciCena, this.poptavka6, (double)this.zacatekObdobi6);
		}

		public void PocetJednotek()
		{
			if (this.dobaPredchoziObjednavky6 != 6)
			{
				this.PocetJednotek6 = 0;
				this.a = this.poptavka6;
			}
			else
			{
				this.PocetJednotek6 = this.poptavka6;
			}
			if (this.dobaPredchoziObjednavky5 != 5)
			{
				this.PocetJednotek5 = 0;
				this.b = this.poptavka5;
			}
			else
			{
				this.PocetJednotek5 = this.poptavka5 + this.a;
				this.a = 0;
			}
			if (this.dobaPredchoziObjednavky4 != 4)
			{
				this.PocetJednotek4 = 0;
				this.c = this.poptavka4;
			}
			else
			{
				this.PocetJednotek4 = this.poptavka4 + this.a + this.b;
				this.a = 0;
				this.b = 0;
			}
			if (this.dobaPredchoziObjednavky3 != 3)
			{
				this.PocetJednotek3 = 0;
				this.d = this.poptavka3;
			}
			else
			{
				this.PocetJednotek3 = this.poptavka3 + this.a + this.b + this.c;
				this.a = 0;
				this.b = 0;
				this.c = 0;
			}
			if (this.dobaPredchoziObjednavky2 != 2)
			{
				this.PocetJednotek2 = 0;
				this.e = this.poptavka2;
			}
			else
			{
				this.PocetJednotek2 = this.poptavka2 + this.a + this.b + this.c + this.d;
				this.a = 0;
				this.b = 0;
				this.c = 0;
				this.d = 0;
			}
			if (this.dobaPredchoziObjednavky1 != 1)
			{
				this.PocetJednotek1 = 0;
				return;
			}
			this.PocetJednotek1 = this.poptavka1 + this.a + this.b + this.c + this.d + this.e;
			this.a = 0;
			this.b = 0;
			this.c = 0;
			this.d = 0;
			this.e = 0;
		}

		public void PosledniObj()
		{
			if (this.f1 == this.f0 + this.N11)
			{
				this.dobaPredchoziObjednavky1 = 1;
			}
			if (this.f2 == this.f0 + this.N12)
			{
				this.dobaPredchoziObjednavky2 = 1;
			}
			else if (this.f2 == this.f1 + this.N22)
			{
				this.dobaPredchoziObjednavky2 = 2;
			}
			if (this.f3 == this.f0 + this.N13)
			{
				this.dobaPredchoziObjednavky3 = 1;
			}
			else if (this.f3 == this.f1 + this.N23)
			{
				this.dobaPredchoziObjednavky3 = 2;
			}
			else if (this.f3 == this.f2 + this.N33)
			{
				this.dobaPredchoziObjednavky3 = 3;
			}
			if (this.f4 == this.f0 + this.N14)
			{
				this.dobaPredchoziObjednavky4 = 1;
			}
			else if (this.f4 == this.f1 + this.N24)
			{
				this.dobaPredchoziObjednavky4 = 2;
			}
			else if (this.f4 == this.f2 + this.N34)
			{
				this.dobaPredchoziObjednavky4 = 3;
			}
			else if (this.f4 == this.f3 + this.N44)
			{
				this.dobaPredchoziObjednavky4 = 4;
			}
			if (this.f5 == this.f0 + this.N15)
			{
				this.dobaPredchoziObjednavky5 = 1;
			}
			else if (this.f5 == this.f1 + this.N25)
			{
				this.dobaPredchoziObjednavky5 = 2;
			}
			else if (this.f5 == this.f2 + this.N35)
			{
				this.dobaPredchoziObjednavky5 = 3;
			}
			else if (this.f5 == this.f3 + this.N45)
			{
				this.dobaPredchoziObjednavky5 = 4;
			}
			else if (this.f5 == this.f4 + this.N55)
			{
				this.dobaPredchoziObjednavky5 = 5;
			}
			if (this.f6 == this.f0 + this.N16)
			{
				this.dobaPredchoziObjednavky6 = 1;
				return;
			}
			if (this.f6 == this.f1 + this.N26)
			{
				this.dobaPredchoziObjednavky6 = 2;
				return;
			}
			if (this.f6 == this.f2 + this.N36)
			{
				this.dobaPredchoziObjednavky6 = 3;
				return;
			}
			if (this.f6 == this.f3 + this.N46)
			{
				this.dobaPredchoziObjednavky6 = 4;
				return;
			}
			if (this.f6 == this.f4 + this.N56)
			{
				this.dobaPredchoziObjednavky6 = 5;
				return;
			}
			if (this.f6 == this.f5 + this.N66)
			{
				this.dobaPredchoziObjednavky6 = 6;
			}
		}

		public void Results()
		{
			List<Dynamicke_programovani.Vysledky> vysledky = new List<Dynamicke_programovani.Vysledky>()
			{
				new Dynamicke_programovani.Vysledky()
				{
					Cislo_obdobi = 1,
					Vyse_poptavky = this.poptavka1,
					Zacatek_obdobi = (double)this.zacatekObdobi1,
					Doba_pred_obj = this.dobaPredchoziObjednavky1,
					Pocet_kusu = this.PocetJednotek1,
					Min_naklady = this.f1
				},
				new Dynamicke_programovani.Vysledky()
				{
					Cislo_obdobi = 2,
					Vyse_poptavky = this.poptavka2,
					Zacatek_obdobi = (double)this.zacatekObdobi2,
					Doba_pred_obj = this.dobaPredchoziObjednavky2,
					Pocet_kusu = this.PocetJednotek2,
					Min_naklady = this.f2
				},
				new Dynamicke_programovani.Vysledky()
				{
					Cislo_obdobi = 3,
					Vyse_poptavky = this.poptavka3,
					Zacatek_obdobi = (double)this.zacatekObdobi3,
					Doba_pred_obj = this.dobaPredchoziObjednavky3,
					Pocet_kusu = this.PocetJednotek3,
					Min_naklady = this.f3
				},
				new Dynamicke_programovani.Vysledky()
				{
					Cislo_obdobi = 4,
					Vyse_poptavky = this.poptavka4,
					Zacatek_obdobi = (double)this.zacatekObdobi4,
					Doba_pred_obj = this.dobaPredchoziObjednavky4,
					Pocet_kusu = this.PocetJednotek4,
					Min_naklady = this.f4
				},
				new Dynamicke_programovani.Vysledky()
				{
					Cislo_obdobi = 5,
					Vyse_poptavky = this.poptavka5,
					Zacatek_obdobi = (double)this.zacatekObdobi5,
					Doba_pred_obj = this.dobaPredchoziObjednavky5,
					Pocet_kusu = this.PocetJednotek5,
					Min_naklady = this.f5
				},
				new Dynamicke_programovani.Vysledky()
				{
					Cislo_obdobi = 6,
					Vyse_poptavky = this.poptavka6,
					Zacatek_obdobi = (double)this.zacatekObdobi6,
					Doba_pred_obj = this.dobaPredchoziObjednavky6,
					Pocet_kusu = this.PocetJednotek6,
					Min_naklady = this.f6
				}
			};
			this.Result.ItemsSource = vysledky;
		}

		private void tbO1_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void tbO2_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void tbO3_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void tbO4_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void tbO5_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void tbO6_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void tbP1_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void tbP2_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void tbP3_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void tbP4_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void tbP5_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void tbP6_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void tbPorizCena_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void tbSkladCena_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void Vykreslit(object sender, RoutedEventArgs e)
		{
			this.Graf();
		}

		private void Vypocitat(object sender, RoutedEventArgs e)
		{
			this.Assign();
			this.Matice();
			this.Funkce();
			this.PosledniObj();
			this.PocetJednotek();
			this.Results();
		}

		public class Vysledky
		{
			public double Cislo_obdobi
			{
				get;
				set;
			}

			public double Doba_pred_obj
			{
				get;
				set;
			}

			public double Min_naklady
			{
				get;
				set;
			}

			public double Pocet_kusu
			{
				get;
				set;
			}

			public double Vyse_poptavky
			{
				get;
				set;
			}

			public double Zacatek_obdobi
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