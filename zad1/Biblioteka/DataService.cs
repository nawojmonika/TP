using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    class DataService
    {
        DataRepository dataRepository;
        DataService(DataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        public IEnumerable<Katalog> WszystkeiPozycjeKatalogu()
        {
            var katalogs = new List<Katalog>();
            foreach(var katalog in this.dataRepository.GetAllKsiazki())
            {
                katalogs.Add(katalog.Value);
            }
            return katalogs;
        }

        public IEnumerable<Zdarzenie> ZdarzeniaDlaElementuWykazu(Wykaz szukanyWykaz)
        {
            var zdarzeniaDlaWykazu = new List<Zdarzenie>();
            foreach(Zdarzenie zdarzenie in this.dataRepository.GetAllZdarzenia())
            {
                if (zdarzenie.KtoWypozyczyl == szukanyWykaz)
                {
                    zdarzeniaDlaWykazu.Add(zdarzenie);
                }
            }
            return zdarzeniaDlaWykazu;
        }

        public IEnumerable<Zdarzenie> ZdarzeniaPomiedzyDatami(DateTime from, DateTime to)
        {
            var zdarzeniePomiedzyDatami = new List<Zdarzenie>();
            foreach(Zdarzenie zdarzenie in this.dataRepository.GetAllZdarzenia())
            {
                if (zdarzenie.DataWypozyczenia >= from && zdarzenie.DataWypozyczenia <= to) {
                    zdarzeniePomiedzyDatami.Add(zdarzenie);
                }
            }
            return zdarzeniePomiedzyDatami;
        }

        public Zdarzenie Wypozycz(Wykaz wypozyczajacy, OpisStanu stan)
        {
            Zdarzenie zdarzenie = new Wypozyczenie(wypozyczajacy, new DateTime(), DateTime.Today.AddMonths(1));
            this.dataRepository.AddOpisStanu(stan);
            this.dataRepository.AddZdarzenie(zdarzenie);
            return zdarzenie;
        }
        public Zdarzenie Oddaj(Wykaz wypozyczajacy, OpisStanu stan)
        {
            Zdarzenie zdarzenie = new Oddanie(wypozyczajacy, new DateTime(), DateTime.Today.AddMonths(1));
            this.dataRepository.AddOpisStanu(stan);
            this.dataRepository.AddZdarzenie(zdarzenie);
            return zdarzenie;
        }

        public string WyswietlKatalog(IEnumerable<Katalog> pozycje)
        {
            return pozycje.Intersect(this.dataRepository.GetAllKsiazki().Values).ToString();
        }

        public void WyswietlPowiazaneZdarzenia(IEnumerable<Zdarzenie> zdarzenia)
        {
            // No idea what should be put here
        }
    }
}
