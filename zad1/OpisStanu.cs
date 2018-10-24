using System;

namespace Biblioteka
{
    public class OpisStanu
    {
        public enum Stan { Wypozyczona, NieWypozyczona }
        public OpisStanu(Stan stan)
        {
            this.ObecnyStan = stan;
        }
        public Stan ObecnyStan;
        public Stan StanWypozyczenia { get; set; }
    }
}
