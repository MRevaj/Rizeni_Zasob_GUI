using System;

namespace Solver
{
    // Vypočítá hodnoty pro Matici N
    public class Matrix
    {

        #region Matice N11 - N16
        public double N11(double porizovaciCena, double skladovaciCena, double poptavka1, double zacatekObdobi1)
        {
            return porizovaciCena + skladovaciCena * (poptavka1 * (zacatekObdobi1 - zacatekObdobi1));
        }

        public double N12(double porizovaciCena, double skladovaciCena, double poptavka1, double poptavka2, double zacatekObdobi1, double zacatekObdobi2)
        {
            return porizovaciCena + skladovaciCena * (poptavka1 * (zacatekObdobi1 - zacatekObdobi1) + poptavka2 * (zacatekObdobi2 - zacatekObdobi1));
        }

        public double N13(double porizovaciCena, double skladovaciCena, double poptavka1, double poptavka2, double poptavka3, double zacatekObdobi1, double zacatekObdobi2, double zacatekObdobi3)
        {
            return porizovaciCena + skladovaciCena * (poptavka1 * (zacatekObdobi1 - zacatekObdobi1) + poptavka2 * (zacatekObdobi2 - zacatekObdobi1) + poptavka3 * (zacatekObdobi3 - zacatekObdobi1));
        }

        public double N14(double porizovaciCena, double skladovaciCena, double poptavka1, double poptavka2, double poptavka3, double poptavka4, double zacatekObdobi1, double zacatekObdobi2, double zacatekObdobi3, double zacatekObdobi4)
        {
            return porizovaciCena + skladovaciCena * (poptavka1 * (zacatekObdobi1 - zacatekObdobi1) + poptavka2 * (zacatekObdobi2 - zacatekObdobi1) + poptavka3 * (zacatekObdobi3 - zacatekObdobi1) + poptavka4 * (zacatekObdobi4 - zacatekObdobi1));
        }

        public double N15(double porizovaciCena, double skladovaciCena, double poptavka1, double poptavka2, double poptavka3, double poptavka4, double poptavka5, double zacatekObdobi1, double zacatekObdobi2, double zacatekObdobi3, double zacatekObdobi4, double zacatekObdobi5)
        {
            return porizovaciCena + skladovaciCena * (poptavka1 * (zacatekObdobi1 - zacatekObdobi1) + poptavka2 * (zacatekObdobi2 - zacatekObdobi1) + poptavka3 * (zacatekObdobi3 - zacatekObdobi1) + poptavka4 * (zacatekObdobi4 - zacatekObdobi1) + poptavka5 * (zacatekObdobi5 - zacatekObdobi1));
        }

        public double N16(double porizovaciCena, double skladovaciCena, double poptavka1, double poptavka2, double poptavka3, double poptavka4, double poptavka5, double poptavka6, double zacatekObdobi1, double zacatekObdobi2, double zacatekObdobi3, double zacatekObdobi4, double zacatekObdobi5, double zacatekObdobi6)
        {
            return porizovaciCena + skladovaciCena * (poptavka1 * (zacatekObdobi1 - zacatekObdobi1) + poptavka2 * (zacatekObdobi2 - zacatekObdobi1) + poptavka3 * (zacatekObdobi3 - zacatekObdobi1) + poptavka4 * (zacatekObdobi4 - zacatekObdobi1) + poptavka5 * (zacatekObdobi5 - zacatekObdobi1) + poptavka6 * (zacatekObdobi6 - zacatekObdobi1));
        }

        #endregion

        #region Matice N22 - N26
        public double N22(double porizovaciCena, double skladovaciCena, double poptavka2, double zacatekObdobi2)
        {
            return porizovaciCena + skladovaciCena * (poptavka2 * (zacatekObdobi2 - zacatekObdobi2));
        }

        public double N23(double porizovaciCena, double skladovaciCena, double poptavka2, double poptavka3, double zacatekObdobi2, double zacatekObdobi3)
        {
            return porizovaciCena + skladovaciCena * (poptavka2 * (zacatekObdobi2 - zacatekObdobi2) + poptavka3 * (zacatekObdobi3 - zacatekObdobi2));
        }

        public double N24(double porizovaciCena, double skladovaciCena, double poptavka2, double poptavka3, double poptavka4, double zacatekObdobi2, double zacatekObdobi3, double zacatekObdobi4)
        {
            return porizovaciCena + skladovaciCena * (poptavka2 * (zacatekObdobi2 - zacatekObdobi2) + poptavka3 * (zacatekObdobi3 - zacatekObdobi2) + poptavka4 * (zacatekObdobi4 - zacatekObdobi2));
        }

        public double N25(double porizovaciCena, double skladovaciCena, double poptavka2, double poptavka3, double poptavka4, double poptavka5, double zacatekObdobi2, double zacatekObdobi3, double zacatekObdobi4, double zacatekObdobi5)
        {
            return porizovaciCena + skladovaciCena * (poptavka2 * (zacatekObdobi2 - zacatekObdobi2) + poptavka3 * (zacatekObdobi3 - zacatekObdobi2) + poptavka4 * (zacatekObdobi4 - zacatekObdobi2) + poptavka5 * (zacatekObdobi5 - zacatekObdobi2));
        }

        public double N26(double porizovaciCena, double skladovaciCena, double poptavka2, double poptavka3, double poptavka4, double poptavka5, double poptavka6, double zacatekObdobi2, double zacatekObdobi3, double zacatekObdobi4, double zacatekObdobi5, double zacatekObdobi6)
        {
            return porizovaciCena + skladovaciCena * (poptavka2 * (zacatekObdobi2 - zacatekObdobi2) + poptavka3 * (zacatekObdobi3 - zacatekObdobi2) + poptavka4 * (zacatekObdobi4 - zacatekObdobi2) + poptavka5 * (zacatekObdobi5 - zacatekObdobi2) + poptavka6 * (zacatekObdobi6 - zacatekObdobi2));
        }

        #endregion

        #region Matice N33 - N36
        public double N33(double porizovaciCena, double skladovaciCena, double poptavka3, double zacatekObdobi3)
        {
            return porizovaciCena + skladovaciCena * (poptavka3 * (zacatekObdobi3 - zacatekObdobi3));
        }

        public double N34(double porizovaciCena, double skladovaciCena, double poptavka3, double poptavka4, double zacatekObdobi3, double zacatekObdobi4)
        {
            return porizovaciCena + skladovaciCena * (poptavka3 * (zacatekObdobi3 - zacatekObdobi3) + poptavka4 * (zacatekObdobi4 - zacatekObdobi3));
        }

        public double N35(double porizovaciCena, double skladovaciCena, double poptavka3, double poptavka4, double poptavka5, double zacatekObdobi3, double zacatekObdobi4, double zacatekObdobi5)
        {
            return porizovaciCena + skladovaciCena * (poptavka3 * (zacatekObdobi3 - zacatekObdobi3) + poptavka4 * (zacatekObdobi4 - zacatekObdobi3) + poptavka5 * (zacatekObdobi5 - zacatekObdobi3));
        }

        public double N36(double porizovaciCena, double skladovaciCena, double poptavka3, double poptavka4, double poptavka5, double poptavka6, double zacatekObdobi3, double zacatekObdobi4, double zacatekObdobi5, double zacatekObdobi6)
        {
            return porizovaciCena + skladovaciCena * (poptavka3 * (zacatekObdobi3 - zacatekObdobi3) + poptavka4 * (zacatekObdobi4 - zacatekObdobi3) + poptavka5 * (zacatekObdobi5 - zacatekObdobi3) + poptavka6 * (zacatekObdobi6 - zacatekObdobi3));
        }

        #endregion

        #region Matice N44 - N46
        public double N44(double porizovaciCena, double skladovaciCena, double poptavka4, double zacatekObdobi4)
        {
            return porizovaciCena + skladovaciCena * (poptavka4 * (zacatekObdobi4 - zacatekObdobi4));
        }

        public double N45(double porizovaciCena, double skladovaciCena, double poptavka4, double poptavka5, double zacatekObdobi4, double zacatekObdobi5)
        {
            return porizovaciCena + skladovaciCena * (poptavka4 * (zacatekObdobi4 - zacatekObdobi4) + poptavka5 * (zacatekObdobi5 - zacatekObdobi4));
        }

        public double N46(double porizovaciCena, double skladovaciCena, double poptavka4, double poptavka5, double poptavka6, double zacatekObdobi4, double zacatekObdobi5, double zacatekObdobi6)
        {
            return porizovaciCena + skladovaciCena * (poptavka4 * (zacatekObdobi4 - zacatekObdobi4) + poptavka5 * (zacatekObdobi5 - zacatekObdobi4) + poptavka6 * (zacatekObdobi6 - zacatekObdobi4));
        }

        #endregion

        #region Matice N55 - N56
        public double N55(double porizovaciCena, double skladovaciCena, double poptavka5, double zacatekObdobi5)
        {
            return porizovaciCena + skladovaciCena * (poptavka5 * (zacatekObdobi5 - zacatekObdobi5));
        }

        public double N56(double porizovaciCena, double skladovaciCena, double poptavka5, double poptavka6, double zacatekObdobi5, double zacatekObdobi6)
        {
            return porizovaciCena + skladovaciCena * (poptavka6 * (zacatekObdobi6 - zacatekObdobi5));
        }

        #endregion

        #region Matice N66

        public double N66(double porizovaciCena, double skladovaciCena, double poptavka6, double zacatekObdobi6)
        {
            return porizovaciCena + skladovaciCena * (poptavka6 * (zacatekObdobi6 - zacatekObdobi6));
        }

        #endregion
    }
}
