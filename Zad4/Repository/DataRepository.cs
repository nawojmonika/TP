
using Repository.LINQ_to_SQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DataRepository : IDataRepository
    {
        UsersDataContext _context = new UsersDataContext("Data Source=LAP01\\PROJEKT;Initial Catalog=Projekt;Integrated Security=True");
        
        public void AddUser(User user) 
        {
            LINQ_to_SQL.User u = new LINQ_to_SQL.User { Age = user.Age, Name = user.Name };
            _context.User.InsertOnSubmit(u);
            _context.SubmitChanges();
        }

        public void RemoveUser(User user)
        {
            if (user == null) {
                throw new Exception("Cannot remove.");
            }
            var userFetch = (from u in _context.User where u.Id == user.Id select u).First();
            _context.User.DeleteOnSubmit(userFetch);
        }

        public void UpdateUser(User updateUser)
        {
            if (updateUser == null) {
                throw new Exception("Cannot update.");
            }
            var userFetch = (from u in _context.User where u.Id == updateUser.Id select u).First();
            userFetch.Name = updateUser.Name;
            userFetch.Age = updateUser.Age;
            _context.SubmitChanges();
        }

        public List<User> GetUsers()
        {
            return (from u in _context.User select u).ToList();
        }
    }
}
