using System.Text;

namespace Dolgozat_11._12;

    class Program
    {
        static void Main()
        {
            List<Varos> varosok = new();

            using StreamReader sr = new(@"..\..\..\src\varosok.csv", Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                varosok.Add(new Varos(sr.ReadLine()));
            }
            Console.WriteLine($"A kollekció hossza: {varosok.Count} elem\n");

            // 1) Hány millió fő él összesen kínai nagyvárosokban?
            var osszNepessegKina = varosok
                .Where(v => v.Orszag == "Kína")
                .Sum(v => v.Nepesseg);
            Console.WriteLine($"1) Kínai nagyvárosok össznépessége: {osszNepessegKina:F2} millió fő\n");

            // 2) Mekkora az indiai nagyvárosok átlaglélekszáma?
            var atlagNepessegIndia = varosok
                .Where(v => v.Orszag == "India")
                .Average(v => v.Nepesseg);
            Console.WriteLine($"2) Indiai nagyvárosok átlaglélekszáma: {atlagNepessegIndia:F2} millió fő\n");

            // 3) Melyik nagyváros a legnépesebb?
            var legnepesebbVaros = varosok.MaxBy(v => v.Nepesseg);
            Console.WriteLine($"3) Legnépesebb nagyváros: {legnepesebbVaros}\n");

            // 4) 20M lakos feletti nagyvárosok, népesség szerint csökkenő sorrendben
            var nagyVarosok20M = varosok
                .Where(v => v.Nepesseg > 20)
                .OrderByDescending(v => v.Nepesseg)
                .ToList();
            Console.WriteLine("4) 20 millió fő feletti nagyvárosok népesség szerint csökkenő sorrendben:");
            nagyVarosok20M.ForEach(v => Console.WriteLine($"{v}"));

            // 5) Hány olyan ország van, ami több nagyvárossal is szerepel a listában?
            var orszagokTobbVarossal = varosok
                .GroupBy(v => v.Orszag)
                .Count(g => g.Count() > 1);
            Console.WriteLine($"\n5) Országok, melyek több nagyvárossal is szerepelnek: {orszagokTobbVarossal} db\n");

            // 6) Milyen betűvel kezdődik a legtöbb nagyváros neve?
            var leggyakoribbKezdobetu = varosok
                .GroupBy(v => v.Nev[0])
                .OrderByDescending(g => g.Count())
                .First().Key;
            Console.WriteLine($"6) Leggyakoribb kezdőbetű a nagyvárosok neveiben: {leggyakoribbKezdobetu}\n");
        }
    }

