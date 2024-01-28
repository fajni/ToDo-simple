using RepositoryLayer;
using Shared.Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class UserBusiness
    {
        private UserRepository userRepository;

        public UserBusiness() 
        {
            this.userRepository = new UserRepository();
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }
    }
}
