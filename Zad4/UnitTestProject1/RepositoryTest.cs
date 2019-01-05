using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using Repository.LINQ_to_SQL;

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
            int previousReposSize = dataRepository.GetUsers().Count;
            dataRepository.AddUser(new User() { Id = Guid.NewGuid(), Age = "32", Name = "Mariuszk" });
            Assert.IsTrue(dataRepository.GetUsers().Count == ++previousReposSize);
        }

        [TestMethod]
        public void removeUserTest()
        {
            IDataRepository dataRepository = new DataRepository();
            var users = dataRepository.GetUsers();
            int previousReposSize = dataRepository.GetUsers().Count;
            dataRepository.RemoveUser(users[0]);
            Assert.IsTrue(dataRepository.GetUsers().Count == --previousReposSize);
        }

    }
}
