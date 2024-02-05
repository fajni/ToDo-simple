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
    }
}
