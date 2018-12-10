using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;

namespace UnitTestProject1
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void RepositoryConstructor()
        {
            IDataRepository dataRepository = new DataRepository();
        }

        [TestMethod]
        public void addUserTest()
        {
            IDataRepository dataRepository = new DataRepository();
            int previousReposSize = dataRepository.getUsers().Count;
            dataRepository.addUser(new User() { Id = Guid.NewGuid(), Age = 23, Name = "Mariuszk", Active = false });
            Assert.IsTrue(dataRepository.getUsers().Count == ++previousReposSize);
        }
    }
}
