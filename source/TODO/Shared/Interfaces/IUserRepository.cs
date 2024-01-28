using Shared.Models;
using System.Collections.Generic;

namespace Shared.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
    }
}
