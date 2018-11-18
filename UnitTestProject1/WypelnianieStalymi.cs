using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Biblioteka;

namespace UnitTestProject1
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


            this.ksiazki = new List<Katalog>();
            this.ksiazki.Add(new Katalog("Monika Nawoj", new System.DateTime(), "KPF", new List<Kategoria> { Kategoria.Biografia, Kategoria.Historyczna }));
            this.ksiazki.Add(new Katalog("Artur Dziedziczak", new System.DateTime(), "ZDF", new List<Kategoria> { Kategoria.Poezja, Kategoria.Historyczna }));
            this.ksiazki.Add(new Katalog("Karol Puchalke", new System.DateTime(), "Polskie Ksiazki", new List<Kategoria> { Kategoria.Sensacja }));

            this.zdarzenia = new ObservableCollection<Zdarzenie>();
            this.zdarzenia.Add(new Wypozyczenie(this.czytelnicy[0], new System.DateTime(), new System.DateTime()));
            this.zdarzenia.Add(new Wypozyczenie(this.czytelnicy[1], new System.DateTime(), new System.DateTime()));
            this.zdarzenia.Add(new Wypozyczenie(this.czytelnicy[2], new System.DateTime(), new System.DateTime()));
            this.zdarzenia.Add(new Oddanie(this.czytelnicy[3], new System.DateTime(), new System.DateTime()));
            this.zdarzenia.Add(new Oddanie(this.czytelnicy[3], new System.DateTime(), new System.DateTime()));

            this.opisyStanu = new ObservableCollection<OpisStanu>();
            this.opisyStanu.Add(new OpisStanu(this.ksiazki[0], OpisStanu.Stan.Wypozyczona, "Tutaj jest opis wypozyczenia"));
            this.opisyStanu.Add(new OpisStanu(this.ksiazki[1], OpisStanu.Stan.Wypozyczona, "Tutaj jest opis wypozyczenia"));
            this.opisyStanu.Add(new OpisStanu(this.ksiazki[2], OpisStanu.Stan.NieWypozyczona, "Ksiazka zniszczona"));
        }

        public List<Wykaz> WypelnijCzytelnikow()
        {
            return this.czytelnicy;
        }

        public Dictionary<Guid, Katalog> WypelnijKsiazki()
        {
            Dictionary<Guid, Katalog> katalog = new Dictionary<Guid, Katalog>();
            foreach(Katalog ksiazka in this.ksiazki)
            {
                katalog.Add(ksiazka.IdKsiazki, ksiazka);
            }
            return katalog;
        }

        public ObservableCollection<OpisStanu> WypelnijOpisyStanu()
        {
            return this.opisyStanu;
        }

        public ObservableCollection<Zdarzenie> WypelnijZdarzenia()
        {
            return this.zdarzenia;
        }
    }
}
