using System;
using System.Collections.Generic;

namespace Biblioteka
{



    public class Zdarzenie
    {
        public Wykaz KtoWypozyczyl { get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public DateTime DataOddania { get; set; }
    }


    public enum Kategoria
    {
        Biografia = 0,
        Fantastyka = 1,
        Historyczna = 2,
        Poezja = 3,
        Sensacja = 4,
        Popularnonaukowe = 5
    }
}

