
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
        

        public void addUser(User user) 
        {
            user.Id = Guid.NewGuid();
            Users.Add(user);
        }

        public void removeUser(User user)
        {
            if (user == null) {
                throw new Exception("Cannot remove.");
            }
            Users.RemoveAll(u => (u.Id == user.Id));
        }

        public void updateUser(User updateUser)
        {
            if (updateUser == null) {
                throw new Exception("Cannot update.");
            }

            User u = Users.Find(user => (user.Id == updateUser.Id));
            u.Name = updateUser.Name;
            u.Age = updateUser.Age;
            u.Active = updateUser.Active;
        }

        public List<User> getUsers()
        {
            return Users;
        }
    }
}
