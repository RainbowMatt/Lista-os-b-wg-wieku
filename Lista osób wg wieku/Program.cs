using System;
using System.Linq;

namespace Lista_osób_wg_wieku
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Krzysztof Molenda, 1965-11-20; Jan Kowalski, 1987-01-01; Anna Abacka, 1972-05-20; Józef Kabacki, 2000-01-02; Kazimierz Moksa, 2001-01-02";
            var query = s.Split(';')
              .Select(dane => dane.Trim())
              .Select(dane => dane.Split(','))
              .Select(x => (imienazwisko: x[0], data: x[1]))
              .Select(d => d.imienazwisko + d.data)
              .Select(osoba => osoba.Split(' '))
              .Select(x => (imie: x[0], nazwisko: x[1], data: x[2]))
              .OrderBy(o => o.data)
              .ThenBy(o => o.nazwisko)
              .ThenBy(o => o.imie)
              .Select(o => o.imie + " " + o.nazwisko + ' ' +o.data);
            string wynik = String.Join(", ", query);
            Console.WriteLine(wynik);
        }
    }
}
