﻿
using Repository;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using WpdOstatni.MVVMLight;

namespace WpdOstatni.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        #region constructors
        public MainViewModel()
        {
            FetchDataCommend = new RelayCommand(() => DataLayer = new DataRepository());
            RemoveUser = new RelayCommand(RemoveCurrentUser);
            AddUser = new RelayCommand(AddNewUser);
            UpdateUser = new RelayCommand(UpdateDataUser);
            DataLayer = new DataRepository();
            refreshUsers();
            UserToAdd = new User { Name = "", Age = 0, Active = false };
        }
        #endregion

        private void refreshUsers()
        {
            Users = new ObservableCollection<User>(DataLayer.getUsers());
        }
        #region ViewModel API
        public ObservableCollection<User> Users
        {
            get { return m_Users; }
            set
            {
                m_Users = value;
                RaisePropertyChanged();
            }
        }
        public User CurrentUser
        {
            get
            {
                return m_CurrentUser;
            }
            set
            {
                m_CurrentUser = value;
                DataLayer.updateUser(value);
                RaisePropertyChanged();
            }
        }


        public User UserToAdd
        {
            get
            {
                return m_UserToAdd;
            }
            set
            {
                m_UserToAdd = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand RemoveUser
        {
            get;
            set;
        }
        public RelayCommand AddUser
        {
            get;
            set;
        }

        public RelayCommand UpdateUser
        {
            get;
            set;
        }

        public RelayCommand FetchDataCommend
        {
            get; private set;
        }

        #endregion

        #region Unit test instrumentation
        public IDataRepository DataLayer
        {
            get { return m_DataLayer; }
            set
            {
                m_DataLayer = value; Users = new ObservableCollection<User>(value.getUsers());
            }
        }
        #endregion

        #region Private stuff
        private IDataRepository m_DataLayer;
        private User m_CurrentUser;
        private User m_UserToAdd;
        private ObservableCollection<User> m_Users;

        public void RemoveCurrentUser()
        {
            DataLayer.removeUser(CurrentUser);
            refreshUsers();
        }

        public void AddNewUser()
        {
            DataLayer.addUser(new User { Name = UserToAdd.Name, Age = UserToAdd.Age, Active = UserToAdd.Active });
            refreshUsers();
        }

        public void UpdateDataUser()
        {
            DataLayer.updateUser(CurrentUser);
            refreshUsers();
        }

        #endregion


    }
}
