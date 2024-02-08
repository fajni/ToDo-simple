using Shared.Interfaces;
using Shared.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RepositoryLayer
{
    public class ObligationRepository : IObligationRepository
    {
        public List<Obligation> GetAllObligations()
        {
            List<Obligation> obligations = new List<Obligation>();

            using(SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Obligations";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while(sqlDataReader.Read()) 
                {
                    Obligation obligation = new Obligation();

                    obligation.GetSetId = sqlDataReader.GetInt32(0);
                    obligation.GetSetTitle = sqlDataReader.GetString(1);
                    obligation.GetSetDate = sqlDataReader.GetDateTime(2);
                    obligation.GetSetNote = sqlDataReader.GetString(3);
                    obligation.GetSetUserId = sqlDataReader.GetInt32(4);

                    obligations.Add(obligation);
                }
            }

            return obligations;
        }

        public int InsertObligation(Obligation obligation)
        {
            using(SqlConnection sqlConnection = new SqlConnection( Constants.connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = string.Format("INSERT INTO Obligations(title, date, note, user_id) VALUES('{0}', '{1}', '{2}', {3})", 
                        obligation.GetSetTitle, obligation.GetSetDate.ToString("MM-dd-yyyy"), obligation.GetSetNote, obligation.GetSetUserId)
                };

                return sqlCommand.ExecuteNonQuery();
            }
        }
    
        public int DeleteObligation(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandText = string.Format("DELETE FROM Obligations WHERE id={0}", id)
                };

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateObligation(Obligation obligation)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE Obligations SET title = '{0}', date = '{1}', note = '{2}' WHERE id = {3}",
                    obligation.GetSetTitle, obligation.GetSetDate, obligation.GetSetNote, obligation.GetSetId);

                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
