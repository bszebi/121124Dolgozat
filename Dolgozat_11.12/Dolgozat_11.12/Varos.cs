using System.Globalization;

namespace Dolgozat_11._12
{
    internal class Varos
    {
        public string Nev { get; set; }
        public string Orszag { get; set; }
        public double Nepesseg { get; set; }

        public Varos(string sor)
        {
            var elemek = sor.Split(';');
            Nev = elemek[0];
            Orszag = elemek[1];
            Nepesseg = double.Parse(elemek[2]);
        }

        public override string ToString() =>
            $"{Nev}; {Orszag}; {Nepesseg:F2} millió fő";
    }
}
