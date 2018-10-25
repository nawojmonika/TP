using Biblioteka;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace zad1
{
    interface IWypelnianieStalymi
    {
        List<Wykaz> WypelnijCzytelnikow();
        Dictionary<string, Katalog> WypelnijKsiazki();
        ObservableCollection<Zdarzenie> WypelnijZdarzenia();
        ObservableCollection<OpisStanu> WypelnijOpisyStanu();
    }
}
