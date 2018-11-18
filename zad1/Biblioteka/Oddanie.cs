using System;

namespace Biblioteka
{
    public class Oddanie : Zdarzenie
 {
        public Oddanie(Wykaz ktoWypozyczyl, DateTime dataWypozyczenia, DateTime dataOddania) :base(ktoWypozyczyl, dataWypozyczenia, dataOddania)
        {
        }
    }
}
