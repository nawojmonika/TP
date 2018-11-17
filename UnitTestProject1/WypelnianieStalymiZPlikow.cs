using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Biblioteka;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace UnitTestProject1
{
    class WypelnianieStalymiZPlikow : IWypelnianieStalymi
    {
        private List<Wykaz> czytelnicy;
        private List<Katalog> ksiazki;
        private ObservableCollection<Zdarzenie> zdarzenia;
        private ObservableCollection<OpisStanu> opisyStanu;

        public WypelnianieStalymiZPlikow()
        {
            this.czytelnicy = new List<Wykaz>();
            this.ksiazki = new List<Katalog>();
            using (var rd = new StreamReader(@"C:\Users\ArturDziedziczak\Desktop\TP\czytelnicy.txt"))
            {
                while (!rd.EndOfStream)
                {
                    string[] splits = rd.ReadLine().Split(',');
                    string imie = splits[0];
                    string nazwisko = splits[1];
                    this.czytelnicy.Add(new Wykaz(imie, nazwisko));

                }
            }

            this.ksiazki = new List<Katalog>();
            using (var rd = new StreamReader(@"C:\Users\ArturDziedziczak\Desktop\TP\katalogi.txt"))
            {
                while (!rd.EndOfStream)
                {
                    string[] splits = rd.ReadLine().Split(',');
                    string autor = splits[0];
                    string[] date = splits[1].Split('-');
                    int day = Convert.ToInt32(date[0]);
                    int month = Convert.ToInt32(date[1]);
                    int year = Convert.ToInt32(date[2]);
                    System.DateTime data = new System.DateTime(year, month, day);
                    string wyd = splits[2];
                    string[] kategorie = splits[3].Split(';');
                    List<Kategoria> kategorieTypy = new List<Kategoria>();
                    foreach (var k in kategorie)
                    {
                        kategorieTypy.Add((Kategoria)Convert.ToInt32(k));
                    }
                    this.ksiazki.Add(new Katalog(autor, data, wyd, kategorieTypy));

                }
            }

            this.zdarzenia = new ObservableCollection<Zdarzenie>();
            using (var rd = new StreamReader(@"C:\Users\ArturDziedziczak\Desktop\TP\zdarzenia.txt"))
            {
                while (!rd.EndOfStream)
                {
                    string[] splits = rd.ReadLine().Split(',');
                    int czytelnikIndex = Convert.ToInt32(splits[0]);

                    string[] dataWypozyczenia = splits[1].Split('-');
                    int day = Convert.ToInt32(dataWypozyczenia[0]);
                    int month = Convert.ToInt32(dataWypozyczenia[1]);
                    int year = Convert.ToInt32(dataWypozyczenia[2]);
                    System.DateTime dataWyp = new System.DateTime(year, month, day);

                    string[] dataOddania = splits[1].Split('-');
                    day = Convert.ToInt32(dataOddania[0]);
                    month = Convert.ToInt32(dataOddania[1]);
                    year = Convert.ToInt32(dataOddania[2]);
                    System.DateTime dataOd = new System.DateTime(year, month, day);

                    this.zdarzenia.Add(new Zdarzenie(this.czytelnicy[czytelnikIndex], dataWyp, dataOd));
                }
            }

            this.opisyStanu = new ObservableCollection<OpisStanu>();
            using (var rd = new StreamReader(@"C:\Users\ArturDziedziczak\Desktop\TP\opisyStanow.txt"))
            {
                while (!rd.EndOfStream)
                {
                    string[] splits = rd.ReadLine().Split(',');
                    int ksiazkaIndex = Convert.ToInt32(splits[0]);
                    int stan = Convert.ToInt32(splits[1]);
                    string opis = splits[2];
                    this.opisyStanu.Add(new OpisStanu(this.ksiazki[ksiazkaIndex], (OpisStanu.Stan)stan, opis));
                }
            }
        }

        public List<Wykaz> WypelnijCzytelnikow()
        {
            return this.czytelnicy;
        }

        public Dictionary<Guid, Katalog> WypelnijKsiazki()
        {
            Dictionary<Guid, Katalog> katalog = new Dictionary<Guid, Katalog>();
            foreach (Katalog ksiazka in this.ksiazki)
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
