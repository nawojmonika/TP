
using System;

namespace Biblioteka
{
    public class OpisStanu
    {
        public enum Stan { Wypozyczona, NieWypozyczona }
        public OpisStanu(Katalog ksiazka, Stan stan, string opis, Zdarzenie zdarzenie)
        {
            this.IdStanu = Guid.NewGuid();
            this.ObecnyStan = stan;
            this.Ksiazka = ksiazka;
            this.Opis = opis;
            this.Zdarzenie = zdarzenie;
        }

        public Guid IdStanu { get; set; }
        public Stan ObecnyStan { get; set; }
        public Katalog Ksiazka { get; set; }
        public string Opis { get; set; }
        public Stan StanWypozyczenia { get; set; } 
        public Zdarzenie Zdarzenie { get; set; } 
    }
}
