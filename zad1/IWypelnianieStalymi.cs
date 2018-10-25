using Biblioteka;
using System.Collections.Generic;

namespace zad1
{
    interface IWypelnianieStalymi
    {
        ICollection<Wykaz> WypelnijWykazy();
        ICollection<Katalog> WypelnijKsiazki();
        ICollection<Zdarzenie> WypelnijZdarzenia();
        ICollection<OpisStanu> WypelnijOpisyStanu();
    }
}
