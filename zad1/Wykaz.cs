using System;

namespace Biblioteka
{
    public class Wykaz
    {
        public Wykaz(string imie, string nazwisko)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.IdKarty = Guid.NewGuid();
            this.DataZalozenia = new DateTime();
            this.CzyKontoAktywne = true;
        }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public Guid IdKarty { get; set; }
        public DateTime DataZalozenia { get; set; }
        public Boolean CzyKontoAktywne { get; set; }

    }
}