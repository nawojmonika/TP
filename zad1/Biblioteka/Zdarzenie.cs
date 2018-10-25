using System;

namespace Biblioteka
{
    public class Zdarzenie
    {
        public Zdarzenie(Wykaz ktoWypozyczyl, DateTime dataWypozyczenia, DateTime dataOddania)
        {
            this.KtoWypozyczyl = ktoWypozyczyl;
            this.DataWypozyczenia = dataWypozyczenia;
            this.DataOddania = DataOddania;
        }
        public Wykaz KtoWypozyczyl { get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public DateTime DataOddania { get; set; }
    }
}
