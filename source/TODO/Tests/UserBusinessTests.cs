using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class UserBusinessTests
    {
        private Mock<UserBusiness> mockUserBusiness = new Mock<UserBusiness>(); //unused
        private UserBusiness userBusiness;
        private User user = new User
        {
            GetSetName = "Test User Name",
            GetSetLastname = "Test User Lastname",
            GetSetPassword = "test"
        };
        private List<User> users = new List<User>();

        public UserBusinessTests()
        {
            users.Add(user);
            userBusiness = new UserBusiness();
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            userBusiness.InsertUser(user);
            users = userBusiness.GetAllUsers();
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void GetUserTest() 
        {
            userBusiness.InsertUser(user);
            User newUser = new User("Test User Name", "Test User Lastname", "test");
            User testUser = new User();

            foreach(var user in userBusiness.GetAllUsers())
            {
                if(user.GetSetName == "Test User Name")
                {
                    testUser = user;
                    break;
                }
            }

            Assert.AreEqual(newUser.GetSetName, testUser.GetSetName);
        }

        [TestMethod]
        public void InsertUserTest()
        {
            Assert.IsTrue(userBusiness.InsertUser(user));
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            userBusiness.InsertUser(user);
            User newUser = userBusiness.GetAllUsers().Where(u => u.GetSetName == user.GetSetName).ToList()[0];
            Assert.IsTrue(userBusiness.DeleteUser(newUser.GetSetUserId));
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            userBusiness.InsertUser(user);
            User newUser = userBusiness.GetAllUsers().Where(u => u.GetSetName == user.GetSetName).ToList()[0];
            bool result = userBusiness.UpdateUser(newUser);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            userBusiness.InsertUser(user);
            User newUser = userBusiness.GetAllUsers().Where(u => u.GetSetName == user.GetSetName).ToList()[0];
            Console.Write(newUser.ToString());
            Assert.IsNotNull(userBusiness.GetUserById(newUser.GetSetUserId));
        }

        [TestMethod]
        public void ConstructorTest()
        {
            userBusiness = new UserBusiness();
            Assert.AreEqual(userBusiness.ToString(), new UserBusiness().ToString());
        }

        [TestCleanup]
        public void clean()
        {

            foreach(var u in userBusiness.GetAllUsers())
            {
                if(u.GetSetName == user.GetSetName)
                {
                    userBusiness.DeleteUser(u.GetSetUserId);
                }
            }

            //User newUser = userBusiness.GetAllUsers().Where(u => u.GetSetName == user.GetSetName).ToList()[0];
            //userBusiness.DeleteUser(newUser.GetSetUserId);
        }
    }
}
