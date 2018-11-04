using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Biblioteka
 {
    class DataContex
    {
        public List<Wykaz> Czytelnicy { get; set; }
        public Dictionary<Guid, Katalog> Ksiazki { get; set; }
        public ObservableCollection<Zdarzenie> Zdarzenia { get; set; }
        public ObservableCollection<OpisStanu> OpisyStanu { get; set; }
    }
}
