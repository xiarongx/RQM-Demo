using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RQM.Data.Request
{
    public class ReadProject
    {
        public string getProjects()
        {
            List<string> projectList = new List<string>();

            DatabaseConnection databaseConnection = new DatabaseConnection();
            string connectionString = databaseConnection.GetConnectionString();

            using (var conn = new SqlConnection(connectionString))
            {
                // SP name
                var storedProcedure = "GetProjectList";
                var cmd = new SqlCommand(storedProcedure, conn);
                // set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                using (cmd)
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        foreach (DataRow dataRow in resultTable.Rows)
                        {
                            foreach (var item in dataRow.ItemArray)
                            {
                                projectList.Add(item.ToString());
                            }
                        }
                    }
                }
            }
            return JsonConvert.SerializeObject(projectList);
        }

        public string getProjectsByAccessGroupTypeName(string groupTypeName)
        {
            List<string> projectList = new List<string>();

            DatabaseConnection databaseConnection = new DatabaseConnection();
            string connectionString = databaseConnection.GetConnectionString();

            using (var conn = new SqlConnection(connectionString))
            {
                // pass procedure name
                var storedProcedure = "GetProjectListByAccessGroupType";
                var cmd = new SqlCommand(storedProcedure, conn);
                // set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                // pass parameter
                cmd.Parameters.Add(new SqlParameter("@groupTypeName", groupTypeName));

                using (cmd)
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var resultTable = new DataTable();
                        adapter.Fill(resultTable);

                        foreach (DataRow dataRow in resultTable.Rows)
                        {
                            foreach (var item in dataRow.ItemArray)
                            {
                                projectList.Add(item.ToString());
                            }
                        }
                    }
                }
            }
            return JsonConvert.SerializeObject(projectList);
        }
    }
}
