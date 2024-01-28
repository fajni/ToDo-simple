using Shared.Interfaces;
using Shared.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RepositoryLayer
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using(SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Users";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while(sqlDataReader.Read())
                {
                    User user = new User();
                    user.GetSetUserId = sqlDataReader.GetInt32(0);
                    user.GetSetName = sqlDataReader.GetString(1);
                    user.GetSetLastname = sqlDataReader.GetString(2);
                    user.GetSetPassword = sqlDataReader.GetString(3);

                    users.Add(user);
                }
            }
            return users;
        }
    }
}
