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

        public User GetUserById(int id)
        {
            foreach(var user in userRepository.GetAllUsers())
            {
                if (user.GetSetUserId == id)
                {
                    return user;
                }
            }
            return null;
        }

        public int InsertUser(User user)
        {
            return userRepository.InsertUser(user);
        }
    }
}
