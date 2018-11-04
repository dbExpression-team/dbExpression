using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace HatTrick.DbEx.MsSql.Test.Database
{
    public class Seeder
    {
        private ConnectionStringSettings connectionStringSettings;
        private string SourceDirectory => AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", string.Empty);

        public Seeder(string name, string connectionString)
        {
            connectionString = connectionString.Replace("{Path}", SourceDirectory);
            connectionStringSettings = new ConnectionStringSettings(name, connectionString);
        }

        public Seeder(ConnectionStringSettings connectionStringSettings)
        {
            this.connectionStringSettings = connectionStringSettings;
            connectionStringSettings.ConnectionString = connectionStringSettings.ConnectionString.Replace("{Path}", SourceDirectory);
        }

        public void RunScript(string scriptName)
        {
            RunScript(SourceDirectory, scriptName);
        }

        public void RunScript(string scriptPath, string scriptName)
        {
            using (var resetScriptReader = File.OpenText(Path.Combine(scriptPath, "Reset.sql")))
            using (var conn = new SqlConnection(connectionStringSettings.ConnectionString))
            {
                var server = new Server(new ServerConnection(conn));
                server.ConnectionContext.ExecuteNonQuery(resetScriptReader.ReadToEnd());
            }
        }
    }
}
