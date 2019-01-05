using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using Repository.LINQ_to_SQL;
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
            mvm.DisplayError = new DebugDisplayError();
            mvm.CurrentUser = mvm.DataLayer.GetUsers()[0];
            int dataLayerSize = mvm.DataLayer.GetUsers().Count;
            mvm.RemoveCurrentUser();
            Assert.IsTrue(--dataLayerSize == mvm.DataLayer.GetUsers().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Cannot remove.")]
        public void RemoveUserFailTest()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.DisplayError = new DebugDisplayError();
            int dataLayerSize = mvm.DataLayer.GetUsers().Count;
            mvm.RemoveCurrentUser();
        }

        [TestMethod]
        public void AddUserTest()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.UserToAdd = new User{ Age = "23", Name = "Mariuszk" };
            int dataLayerSize = mvm.DataLayer.GetUsers().Count;
            mvm.AddNewUser();
            Assert.IsTrue(++dataLayerSize == mvm.DataLayer.GetUsers().Count);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.DisplayError = new DebugDisplayError();
            var userToUpdate = mvm.DataLayer.GetUsers()[0];
            const string newName = "newName";
            userToUpdate.Name = newName;
            mvm.CurrentUser = userToUpdate;
            mvm.UpdateDataUser();
            userToUpdate = mvm.DataLayer.GetUsers()[0];
            Assert.AreEqual(userToUpdate.Name, newName);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Cannot update.")]
        public void UpdateUserFailTest()
        {
            MainViewModel mvm = new MainViewModel();
            mvm.DisplayError = new DebugDisplayError();
            var userToUpdate = mvm.DataLayer.GetUsers()[0];
            const string newName = "newName";
            userToUpdate.Name = newName;
            mvm.UpdateDataUser();
            userToUpdate = mvm.DataLayer.GetUsers()[0];
            Assert.AreEqual(userToUpdate.Name, newName);
        }
    }
}
