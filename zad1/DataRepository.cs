
using Biblioteka;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        public Katalog GetKsiazka(Guid idKsiazki)
        {
            return this.Contex.Ksiazki[idKsiazki];
        }

        public Zdarzenie GetZdarzenie(Guid idZdarzenia)
        {
            return this.Contex.Zdarzenia.Single(z => z.IdZdarzenia == idZdarzenia);
        }

        public OpisStanu GetOpisStanu(Guid idStanu)
        {
            return this.Contex.OpisyStanu.Single(s => s.IdStanu == idStanu);
        }

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

        public void UpdateCzytelnik(Wykaz czytelnik)
        {
            int index = this.Contex.Czytelnicy.IndexOf(this.GetCzytelnik(czytelnik.IdKarty));
            this.Contex.Czytelnicy[index] = czytelnik;
        }

        public void UpdateKsiazka(Katalog ksiazka)
        {
            this.Contex.Ksiazki[ksiazka.IdKsiazki] = ksiazka;
        }

        public void UpdateZdarzenie(Zdarzenie zdarzenie)
        {
            int index = this.Contex.Zdarzenia.IndexOf(this.GetZdarzenie(zdarzenie.IdZdarzenia));
            this.Contex.Zdarzenia[index] = zdarzenie;
        }

        public void UpdateOpisStanu(OpisStanu opisStanu)
        {
            int index = this.Contex.OpisyStanu.IndexOf(this.GetOpisStanu(opisStanu.IdStanu));
            this.Contex.OpisyStanu[index] = opisStanu;
        }

        public void RemoveCzytelnik(Guid idKarty)
        {
            this.Contex.Czytelnicy.RemoveAll(c => c.IdKarty == idKarty);
        }

        public void RemoveKsiazka(Guid idKsiazki)
        {
            this.Contex.Ksiazki.Remove(idKsiazki);
        }

        public void RemoveZdarzenie(Guid idZdarzenia)
        {
            Zdarzenie item  = this.GetZdarzenie(idZdarzenia);
            this.Contex.Zdarzenia.Remove(item);
        }

        public void RemoveOpisStanu(Guid idStanu)
        {
            OpisStanu item = this.GetOpisStanu(idStanu);
            this.Contex.OpisyStanu.Remove(item);
        }
    }
}