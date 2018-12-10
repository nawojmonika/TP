using System.Collections.Generic;

namespace Repository
{
    public interface IDataRepository
    {
        void addUser(User addUser);
        void removeUser(User addUser);
        void updateUser(User updateUser);
        List<User> getUsers();
    }
}
