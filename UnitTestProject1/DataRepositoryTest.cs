using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteka;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UnitTestProject1
{
    [TestClass]
    public class DataRepositoryTest
    {
        private static IWypelnianieStalymi Wypelniacz = new WypelnianieStalymi();

        private const string Imie1 = "Artur";
        private const string Nazwisko1 = "Dziedziczak";
        private const string Imie2 = "Monika";
        private const string Nazwisko2 = "Nawój";
        private static Wykaz Wykaz1 = new Wykaz(Imie1, Nazwisko1);
        private static Wykaz Wykaz2 = new Wykaz(Imie2, Nazwisko2);
        private static List<Wykaz> Wykazy1 = Wypelniacz.WypelnijCzytelnikow();

        private const string ImieAutora1 = "Karol Puchałke";
        private static System.DateTime DataWydania1 = new System.DateTime(1999,05, 30);
        private const string Wydawnictwo1 = "Księgozbiór polski";
        private static ICollection<Kategoria> Kategoria1 = new List<Kategoria>{Kategoria.Biografia, Kategoria.Fantastyka};
        private static Katalog Katalog1 = new Katalog(ImieAutora1, DataWydania1, Wydawnictwo1, Kategoria1);
        private static Dictionary<System.Guid, Katalog> Katalogi1 = Wypelniacz.WypelnijKsiazki();

        private static System.DateTime DataWypozyczenia = new System.DateTime(2018,05, 30);
        private static System.DateTime DataOddania = new System.DateTime(2019,05, 30);
        private static Zdarzenie Zdarzenie1 = new Zdarzenie(Wykaz1, DataWypozyczenia, DataOddania);
        private static ObservableCollection<Zdarzenie> Zdarzenia1 = Wypelniacz.WypelnijZdarzenia();

        private const string opis = "Książka nie oddana, bo nie wypożyczona";
        private static OpisStanu OpisStanu1 = new OpisStanu(Katalog1, OpisStanu.Stan.NieWypozyczona, opis);
        private static ObservableCollection<OpisStanu> OpisyStanow1 = Wypelniacz.WypelnijOpisyStanu();


        [TestMethod]
        public void BasicConstructorTest()
        {
            IWypelnianieStalymi wypelniacz = new WypelnianieStalymi();
            Assert.IsNotNull(new DataRepository(wypelniacz));
        }
        [TestMethod]
        public void addCzytelnikTest()
        {
            DataRepository dataRepository = buildDataRepository();
            dataRepository.AddCzytelnik(Wykaz1);
            Assert.AreSame(Wykaz1, dataRepository.GetCzytelnik(Wykaz1.IdKarty));
        }
        [TestMethod]
        public void addKsiazkaTest()
        {
            DataRepository dataRepository = buildDataRepository();
            dataRepository.AddKsiazka(Katalog1);
            Assert.AreSame(Katalog1, dataRepository.GetKsiazka(Katalog1.IdKsiazki));
        }
        [TestMethod]
        public void addZdarzenieTest()
        {
            DataRepository dataRepository = buildDataRepository();
            dataRepository.AddZdarzenie(Zdarzenie1);
            Assert.AreSame(Zdarzenie1, dataRepository.GetZdarzenie(Zdarzenie1.IdZdarzenia));
        }
        [TestMethod]
        public void addOpisStanuTest()
        {
            DataRepository dataRepository = buildDataRepository();
            dataRepository.AddOpisStanu(OpisStanu1);
            Assert.AreSame(OpisStanu1, dataRepository.GetOpisStanu(OpisStanu1.IdStanu));
        }
        [TestMethod]
        public void getAllCzytelniecyTest()
        {
            DataRepository dataRepository = buildDataRepository();
            CollectionAssert.AreEqual(Wykazy1, dataRepository.GetAllCzytelnicy());
            List<Wykaz> WykazyWithNewValues = Wypelniacz.WypelnijCzytelnikow();
            WykazyWithNewValues.Add(Wykaz1);
            WykazyWithNewValues.Add(Wykaz2);
            dataRepository.AddCzytelnik(Wykaz1);
            dataRepository.AddCzytelnik(Wykaz2);
            CollectionAssert.AreEqual(WykazyWithNewValues, dataRepository.GetAllCzytelnicy());
        }
        [TestMethod]
        public void getAllKsiazkiTest()
        {
            DataRepository dataRepository = buildDataRepository();
            CollectionAssert.AreEqual(Katalogi1, dataRepository.GetAllKsiazki());
            Dictionary<System.Guid, Katalog> KatalogiWithNewValues = Wypelniacz.WypelnijKsiazki();
            KatalogiWithNewValues.Add(Katalog1.IdKsiazki, Katalog1);
            dataRepository.AddKsiazka(Katalog1);
            CollectionAssert.AreEqual(KatalogiWithNewValues, dataRepository.GetAllKsiazki());
        }
        [TestMethod]
        public void getAllZdarzeniaTest()
        {
            DataRepository dataRepository = buildDataRepository();
            CollectionAssert.AreEqual(Zdarzenia1, dataRepository.GetAllZdarzenia());
            var ZdarzeniaWithNewValues = Wypelniacz.WypelnijZdarzenia();
            ZdarzeniaWithNewValues.Add(Zdarzenie1);
            dataRepository.AddZdarzenie(Zdarzenie1);
            CollectionAssert.AreEqual(ZdarzeniaWithNewValues, dataRepository.GetAllZdarzenia());
        }
        [TestMethod]
        public void getAllOpisyStanuTest()
        {
            DataRepository dataRepository = buildDataRepository();
            CollectionAssert.AreEqual(OpisyStanow1, dataRepository.GetAllOpisyStanu());
            var OpisyStanowWithNewValues = Wypelniacz.WypelnijOpisyStanu();
            OpisyStanowWithNewValues.Add(OpisStanu1);
            dataRepository.AddOpisStanu(OpisStanu1);
            CollectionAssert.AreEqual(OpisyStanowWithNewValues, dataRepository.GetAllOpisyStanu());
        }
        private DataRepository buildDataRepository()
        {
            return new DataRepository(Wypelniacz);
        }
    }
}
