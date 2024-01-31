using Shared.Models;
using System.Collections.Generic;

namespace Shared.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        int InsertUser(User user);
        int DeleteUser(int user_id);
        int UpdateUser(User user);
    }
}
