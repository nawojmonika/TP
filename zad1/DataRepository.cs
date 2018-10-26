
using Biblioteka;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace zad1
{
    class DataRepository
    {
        public DataRepository(IWypelnianieStalymi wypelniacz)
        {
            this.Contex = new DataContex();
            this.Contex.Czytelnicy = wypelniacz.WypelnijCzytelnikow();
            this.Contex.Ksiazki = wypelniacz.WypelnijKsiazki();
            this.Contex.Zdarzenia = wypelniacz.WypelnijZdarzenia();
            this.Contex.OpisyStanu = wypelniacz.WypelnijOpisyStanu();
        }

        private DataContex Contex { get; set; }

        public void AddCzytelnik(Wykaz czytelnik)
        {
            this.Contex.Czytelnicy.Add(czytelnik);
        }

        public void AddKsiazka(Katalog ksiazka)
        {
            this.Contex.Ksiazki.Add(ksiazka.IdKsiazki,ksiazka);
        }

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            this.Contex.Zdarzenia.Add(zdarzenie);
        }

        public void AddOpisStanu(OpisStanu opisStanu)
        {
            this.Contex.OpisyStanu.Add(opisStanu);
        }

        public Wykaz GetCzytelnik(Guid idKarty)
        {
            return this.Contex.Czytelnicy.Find(c => c.IdKarty == idKarty);
        }

        //public Katalog GetKsiazka(Guid idKsiazki)
        //{
        //    return this.Contex.Ksiazki.
        //}TO DO

        //public Zdarzenie GetZdarzenie(Guid idZdarzenia)
        //{
        //    this.Contex.Zdarzenia.
        //} TO DO

        //public OpisStanu GetOpisStanu(Guid idStanu)
        //{
        //    return this.Contex.OpisyStanu.
        //} TO do

        public List<Wykaz> GetAllCzytelnicy()
        {
            return this.Contex.Czytelnicy;
        }

        public Dictionary<Guid, Katalog> GetAllKsiazki()
        {
            return this.Contex.Ksiazki;
        }

        public ObservableCollection<Zdarzenie> GetAllZdarzenia()
        {
            return this.Contex.Zdarzenia;
        }

        public ObservableCollection<OpisStanu> GetllOpisyStanu()
        {
            return this.Contex.OpisyStanu;
        }
    }
}