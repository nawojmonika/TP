
namespace Biblioteka
{
    public class OpisStanu
    {
        public enum Stan { Wypozyczona, NieWypozyczona }
        public OpisStanu(Katalog ksiazka, Stan stan, string opis)
        {
            this.ObecnyStan = stan;
            this.Ksiazka = ksiazka;
            this.Opis = opis;
        }
        private Stan ObecnyStan;
        private Katalog Ksiazka;
        private string Opis;

        public Stan StanWypozyczenia { get; set; } 
    }
}
