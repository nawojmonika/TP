
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
        public DataContex Contex { get; set; }
    }
}