
using System;
using System.Collections.Generic;

namespace Repository
{
    public class DataRepository : IDataRepository
    {
        List<User> Users = new List<User>()
        {
          new User{ Id = Guid.NewGuid(), Age = 21, Name = "Jan", Active = true },
          new User{ Id = Guid.NewGuid(), Age = 22, Name = "Monika", Active = false },
          new User{ Id = Guid.NewGuid(), Age = 23, Name = "Mariuszk", Active = false },
          new User{ Id = Guid.NewGuid(), Age = 24, Name = "Stefan", Active = false },
          new User{ Id = Guid.NewGuid(), Age = 25, Name = "Marcin", Active = false },
          new User{ Id = Guid.NewGuid(), Age = 27, Name = "Kamil", Active = false }
        };
        

        public bool addUser(User user) 
        {
            user.Id = Guid.NewGuid();
            Users.Add(user);
            return true;
        }

        public bool removeUser(User user)
        {
            if (user != null)
            {
                Users.RemoveAll(u => (u.Id == user.Id));
                return true;
            }
            return false;
        }

        public bool updateUser(User updateUser)
        {
            if (updateUser != null)
            {
                User u = Users.Find( user => (user.Id == updateUser.Id));
                u.Name = updateUser.Name;
                u.Age = updateUser.Age;
                u.Active = updateUser.Active;
                return true;
            }
            return false;
        }

        public List<User> getUsers()
        {
            return Users;
        }
    }
}
