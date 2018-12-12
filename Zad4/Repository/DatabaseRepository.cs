
using System;
using System.Collections.Generic;

namespace Repository
{
    public class DatabaseRepository : IDataRepository
    {
        public void addUser(User user) 
        {
        }

        public void removeUser(User user)
        {
        }

        public void updateUser(User updateUser)
        {
        }

        public List<User> getUsers()
        {
            var d = new Database1Entities();
            var k = from u in d.User select u;
            return k;
        }
    }
}
