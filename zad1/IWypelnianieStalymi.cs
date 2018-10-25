using Biblioteka;
using System.Collections.Generic;

namespace zad1
{
    interface IWypelnianieStalymi
    {
        ICollection<Wykaz> WypelnijCzytelnikow();
        ICollection<Katalog> WypelnijKsiazki();
        ICollection<Zdarzenie> WypelnijZdarzenia();
        ICollection<OpisStanu> WypelnijOpisyStanu();
    }
}
