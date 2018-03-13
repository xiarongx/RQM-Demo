using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RQM.Data.Request
{
    public class WriteProject
    {
        // Use pascal
        public void InsertProjectSelection(int projectListID, string createdBy, string updatedBy, DateTime createdTime)
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            string connectionString = databaseConnection.GetConnectionString();

            using (var conn = new SqlConnection(connectionString))
            {
                // test insert
                // use stored procuduer

                var storedProcedure = "AddProjectSelection";
                var cmd = new SqlCommand(storedProcedure, conn);
                // set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                // pass parameter
                cmd.Parameters.Add("@projectListID", SqlDbType.Int).Value = projectListID;
                cmd.Parameters.Add("@createdBy", SqlDbType.NVarChar, 50).Value = createdBy;
                cmd.Parameters.Add("@updatedBy", SqlDbType.NVarChar, 50).Value = updatedBy;
                cmd.Parameters.Add("@createdTime", SqlDbType.DateTime).Value = createdTime;

                using (cmd)
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
