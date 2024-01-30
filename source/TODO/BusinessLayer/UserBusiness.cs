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

        public bool InsertUser(User user)
        {
            if(this.userRepository.InsertUser(user) > 0) 
            {
                return true;
            }
            else { return false; };
        }

        public bool DeleteUser(int user_id)
        {
            if(this.userRepository.DeleteUser(user_id) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
