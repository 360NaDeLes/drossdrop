using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DrossDrop
{
    public class AppConfiguration
    {
        public AppConfiguration() //Haalt de connnection string uit de 'appsettings.json' file en slaat deze op in een public property
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSettings = root.GetSection("ConnectionStrings:ConnectionString");
            sqlConnectionString = appSettings.Value;
        }

        public string sqlConnectionString { get; set; }

    }
}