using System;
using System.Collections.Generic;

namespace Biblioteka
{
    public class Katalog
    {
        public Katalog(string autor, DateTime dataWydania, string wydawnictwo, ICollection<Kategoria> kategorie)
        {
            this.IdKsiazki = Guid.NewGuid();
            this.Autor = autor;
            this.DataWydania = dataWydania;
            this.Wydawnictwo = wydawnictwo;
            this.Kategorie = kategorie;
            this.AktualnyStan = new OpisStanu(OpisStanu.Stan.NieWypozyczona);
        }
        public Guid IdKsiazki { get; set; }
        public string Autor { get; set; }
        public DateTime DataWydania { get; set; }
        public string Wydawnictwo { get; set; }
        public ICollection<Kategoria> Kategorie { get; set; }
        public OpisStanu AktualnyStan { get; set; }

    }
}
