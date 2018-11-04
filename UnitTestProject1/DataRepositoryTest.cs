using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteka;

namespace UnitTestProject1
{
    [TestClass]
    public class DataRepositoryTest
    {
        [TestMethod]
        public void BasicConstructorTest()
        {
            IWypelnianieStalymi wypelniacz = new WypelnianieStalymi();
            DataRepository app = new DataRepository(wypelniacz);
        }
    }
}
