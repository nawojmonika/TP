using System.Collections.Generic;
using System.Collections.ObjectModel;
using Biblioteka;

namespace zad1
{
    class WypelnianieStalymi : IWypelnianieStalymi
    {
        private List<Wykaz> czytelnicy;
        private List<Katalog> ksiazki;
        private ObservableCollection<Zdarzenie> zdarzenia;
        private ObservableCollection<OpisStanu> opisyStanu;

        public WypelnianieStalymi()
        {
            this.czytelnicy = new List<Wykaz>();
            this.czytelnicy.Add(new Wykaz("Monika", "Nawoj"));
            this.czytelnicy.Add(new Wykaz("Artur", "Dziedziczak"));
            this.czytelnicy.Add(new Wykaz("Karol", "Mariuszewski"));
            this.czytelnicy.Add(new Wykaz("Sebastian", "Seba"));

            this.ksiazki.Add(new Katalog("Monika Nawoj", new System.DateTime(), "KPF", new List<Kategoria> { Kategoria.Biografia, Kategoria.Historyczna }));
            this.ksiazki.Add(new Katalog("Artur Dziedziczak", new System.DateTime(), "ZDF", new List<Kategoria> { Kategoria.Poezja, Kategoria.Historyczna }));
            this.ksiazki.Add(new Katalog("Karol Puchalke", new System.DateTime(), "Polskie Ksiazki", new List<Kategoria> { Kategoria.Sensacja }));

            this.zdarzenia.Add(new Zdarzenie(this.czytelnicy[0], new System.DateTime(), new System.DateTime()));
            this.zdarzenia.Add(new Zdarzenie(this.czytelnicy[1], new System.DateTime(), new System.DateTime()));
            this.zdarzenia.Add(new Zdarzenie(this.czytelnicy[2], new System.DateTime(), new System.DateTime()));
            this.zdarzenia.Add(new Zdarzenie(this.czytelnicy[3], new System.DateTime(), new System.DateTime()));
            this.zdarzenia.Add(new Zdarzenie(this.czytelnicy[3], new System.DateTime(), new System.DateTime()));

            this.opisyStanu.Add(new OpisStanu(this.ksiazki[0], OpisStanu.Stan.Wypozyczona, "Tutaj jest opis wypozyczenia"));
            this.opisyStanu.Add(new OpisStanu(this.ksiazki[1], OpisStanu.Stan.Wypozyczona, "Tutaj jest opis wypozyczenia"));
            this.opisyStanu.Add(new OpisStanu(this.ksiazki[2], OpisStanu.Stan.NieWypozyczona, "Ksiazka zniszczona"));
        }

        public ICollection<Wykaz> WypelnijCzytelnikow()
        {
            return this.czytelnicy;
        }

        public ICollection<Katalog> WypelnijKsiazki()
        {
            return this.ksiazki;
        }

        public ICollection<OpisStanu> WypelnijOpisyStanu()
        {
            return this.opisyStanu;
        }

        public ICollection<Zdarzenie> WypelnijZdarzenia()
        {
            return this.zdarzenia;
        }
    }
}
