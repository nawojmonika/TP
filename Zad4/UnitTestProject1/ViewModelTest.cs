using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using WpdOstatni.ViewModel;

namespace UnitTestProject1
{
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void ViewModelConstructorTest()
        {
            MainViewModel mvm = new MainViewModel();
        }

        [TestMethod]
        public void RemoveUserTest()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.CurrentUser = mvm.DataLayer.getUsers()[0];
            int dataLayerSize = mvm.DataLayer.getUsers().Count;
            mvm.RemoveCurrentUser();
            Assert.IsTrue(--dataLayerSize == mvm.DataLayer.getUsers().Count);
        }

        [TestMethod]
        public void AddUserTest()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.UserToAdd = new User{ Age = 23, Name = "Mariuszk", Active = false };
            int dataLayerSize = mvm.DataLayer.getUsers().Count;
            mvm.AddNewUser();
            Assert.IsTrue(++dataLayerSize == mvm.DataLayer.getUsers().Count);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            MainViewModel mvm = new MainViewModel();
            var userToUpdate = mvm.DataLayer.getUsers()[0];
            const string newName = "newName";
            userToUpdate.Name = newName;
            mvm.CurrentUser = userToUpdate;
            mvm.UpdateDataUser();
            userToUpdate = mvm.DataLayer.getUsers()[0];
            Assert.AreEqual(userToUpdate.Name, newName);
        }
    }
}
