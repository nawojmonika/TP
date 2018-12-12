
using System;
using System.Collections.Generic;

namespace Repository
{
    public class DatabaseRepo : IDataRepository
    {
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
            DataClasses1DataContext context = new DataClasses1DataContext();
            var t = from u in context.User select u;
        }
    }
}
