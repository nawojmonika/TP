using System;
using System.Collections.Generic;

namespace Biblioteka
{
    public class Wykaz
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string IdKarty { get; set; }
        public DateTime DataZalozenia { get; set; }
        public Boolean CzyKontoAktywne { get; set; }
    }

    public class Katalog
    {
        public string IdKsiazki { get; set; }
        public string Autor { get; set; }
        public DateTime DataWydania { get; set; }
        public string Wydawnictwo { get; set; }
        public ICollection<Kategoria> Kategorie { get; set; }
        public OpisStanu AktualnyStan { get; set; }
    }

    public class OpisStanu
    {
        public Boolean CzyWypozyczona { get; set; }
    }

    public class Zdarzenie
    {
        public Wykaz KtoWypozyczyl { get; set; }
        public Katalog WypozyczonaKsiazka{ get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public DateTime DataOddania { get; set; }
    }

    public enum Kategoria
    {
        Biografia = 0,
        Fantastyka = 1,
        Historyczna = 2,
        Poezja = 3,
        Sensacja = 4,
        Popularnonaukowe = 5
    }
}

