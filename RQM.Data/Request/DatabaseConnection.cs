using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RQM.Data.Request
{
    public class DatabaseConnection
    {
        public string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", false)
                        .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("No connection string in appsettings.json");
            }

            return connectionString;
        }
    }
}
