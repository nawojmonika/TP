
using Repository;
using Repository.LINQ_to_SQL;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using WpdOstatni.MVVMLight;

namespace WpdOstatni.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region constructors
        public MainViewModel()
        {
            this.displayError = new ErrorMessageDialog();
            FetchDataCommend = new RelayCommand(() => DataLayer = new DataRepository());
            RemoveUser = new RelayCommand(RemoveCurrentUser);
            AddUser = new RelayCommand(AddNewUser);
            UpdateUser = new RelayCommand(UpdateDataUser);
            DataLayer = new DataRepository();
            refreshUsers();
            UserToAdd = new User { Name = "", Age = "0" };
        }
        #endregion

        DisplayError displayError;

        private void refreshUsers()
        {
            Users = new ObservableCollection<User>(DataLayer.GetUsers());
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
                m_DataLayer = value; Users = new ObservableCollection<User>(value.GetUsers());
            }
        }

        public DisplayError DisplayError { get => displayError; set => displayError = value; }
        #endregion

        #region Private stuff
        private IDataRepository m_DataLayer;
        private User m_CurrentUser;
        private User m_UserToAdd;
        private ObservableCollection<User> m_Users;

        public void RemoveCurrentUser()
        {
            try
            {
                DataLayer.RemoveUser(CurrentUser);
            }
            catch (Exception error)
            {
                this.displayError.PresentError(error.Message);
            }
            refreshUsers();
        }


        public void AddNewUser()
        {
            DataLayer.AddUser(new User { Name = UserToAdd.Name, Age = UserToAdd.Age });
            refreshUsers();
        }

        public void UpdateDataUser()
        {
            try
            {
                DataLayer.UpdateUser(CurrentUser);
            }
            catch (Exception error)
            {
                this.displayError.PresentError(error.Message);
            }
            refreshUsers();
        }

        #endregion


    }
}
