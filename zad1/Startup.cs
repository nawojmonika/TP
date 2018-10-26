namespace zad1
{
    class Startup
    {
        public void Configure() {
            IWypelnianieStalymi wypelniacz = new WypelnianieStalymi();
            DataRepository app = new DataRepository(wypelniacz);
        }
    }
}
