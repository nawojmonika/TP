using System.Collections.Generic;

namespace Repository
{
    public interface IDataRepository
    {
        void AddUser(User addUser);
        void RemoveUser(User addUser);
        void UpdateUser(User updateUser);
        List<User> GetUsers();
    }
}
