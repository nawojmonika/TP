using System;

namespace Biblioteka
{
    public abstract class Zdarzenie
    {
        public Zdarzenie(Wykaz ktoWypozyczyl, DateTime dataWypozyczenia, DateTime dataOddania)
        {
            this.IdZdarzenia = Guid.NewGuid();
            this.KtoWypozyczyl = ktoWypozyczyl;
            this.DataWypozyczenia = dataWypozyczenia;
            this.DataOddania = DataOddania;
        }
        public Guid IdZdarzenia { get; set; }
        public Wykaz KtoWypozyczyl { get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public DateTime DataOddania { get; set; }
    }
}
