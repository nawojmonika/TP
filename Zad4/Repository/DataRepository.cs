
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DataRepository : IDataRepository
    {
        List<User> Users = new List<User>()
        {
          new User{  Age = 21, Name = "Jan", Active = true },
          new User{  Age = 22, Name = "Monika", Active = false },
          new User{  Age = 23, Name = "Mariuszk", Active = false },
          new User{  Age = 24, Name = "Stefan", Active = false },
          new User{  Age = 25, Name = "Marcin", Active = false },
          new User{  Age = 27, Name = "Kamil", Active = false }
        };

        public void AddUser(User user) 
        {
            ProjektEntities2 db = new ProjektEntities2();
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            if (user == null) {
                throw new Exception("Cannot remove.");
            }
            ProjektEntities2 db = new ProjektEntities2();
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void UpdateUser(User updateUser)
        {
            if (updateUser == null) {
                throw new Exception("Cannot update.");
            }
            ProjektEntities2 db = new ProjektEntities2();
            User user =  db.Users.Find(updateUser.Id);
            user.Name = updateUser.Name;
            user.Age = updateUser.Age;
            user.Active = updateUser.Active;
            db.SaveChanges();
        }

        public List<User> GetUsers()
        {
            ProjektEntities2 db = new ProjektEntities2();
            return db.Users.ToList();
        }
    }
}
