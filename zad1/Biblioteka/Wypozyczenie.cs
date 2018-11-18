using System;

namespace Biblioteka
{
    public class Wypozyczenie : Zdarzenie
 {
        public Wypozyczenie(Wykaz ktoWypozyczyl, DateTime dataWypozyczenia, DateTime dataOddania) :base(ktoWypozyczyl, dataWypozyczenia, dataOddania)
        {
        }
    }
}
