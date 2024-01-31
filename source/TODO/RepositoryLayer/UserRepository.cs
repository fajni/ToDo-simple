using Shared.Interfaces;
using Shared.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Sockets;

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

        public int InsertUser(User user)
        {
            using(SqlConnection sqlConnection = new SqlConnection( Constants.connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = string.Format("INSERT INTO Users(name, lastname, password) VALUES('{0}', '{1}', '{2}')",
                        user.GetSetName, user.GetSetLastname, user.GetSetPassword)
                };

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeleteUser(int user_id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = string.Format("DELETE FROM Users WHERE user_id={0}", user_id)
                };

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateUser(User user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE Users SET name = '{0}', lastname = '{1}', password = '{2}' WHERE user_id = {3}",
                    user.GetSetName, user.GetSetLastname, user.GetSetPassword, user.GetSetUserId);
                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
