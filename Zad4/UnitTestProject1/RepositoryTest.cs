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

        [TestMethod]
        public void removeUserTest()
        {
            IDataRepository dataRepository = new DataRepository();
            var users = dataRepository.getUsers();
            int previousReposSize = dataRepository.getUsers().Count;
            dataRepository.removeUser(users[0]);
            Assert.IsTrue(dataRepository.getUsers().Count == --previousReposSize);
        }

        [TestMethod]
        public void updateUserTest()
        {
            IDataRepository dataRepository = new DataRepository();
            var newUser = new User() { Id = Guid.NewGuid(), Age = 66, Name = "Karol M", Active = false };
            dataRepository.addUser(newUser);
            const string newUserName = "NewName";
            newUser.Name = newUserName;
            dataRepository.updateUser(newUser);
            var users = dataRepository.getUsers();
            Assert.AreEqual(users[users.Count - 1].Name, newUserName);
        }

        [TestMethod]
        public void getUTest()
        {
            IDataRepository dataRepository = new DataRepository();
            var u = dataRepository.getU`
        }
    }
}
