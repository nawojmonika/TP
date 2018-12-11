using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Biblioteka
 {
    public interface IWypelnianieStalymi
    {
        List<Wykaz> WypelnijCzytelnikow();
        Dictionary<Guid, Katalog> WypelnijKsiazki();
        ObservableCollection<Zdarzenie> WypelnijZdarzenia();
        ObservableCollection<OpisStanu> WypelnijOpisyStanu();
    }
}
