using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace HatTrick.DbEx.MsSql.Test.Database
{
    public class Seeder
    {
        private ConnectionStringSettings connectionStringSettings;

        public Seeder(string name, string connectionString)
        {
            connectionStringSettings = new ConnectionStringSettings(name, connectionString);
        }

        public Seeder(ConnectionStringSettings connectionStringSettings)
        {
            this.connectionStringSettings = connectionStringSettings;
        }

        public void RunScript(string scriptName)
        {
            RunScript(scriptName, AppDomain.CurrentDomain.BaseDirectory);
        }

        public void RunScript(string scriptName, string scriptPath)
        {
            using var resetScriptReader = File.OpenText(Path.Combine(scriptPath, scriptName));
            using var conn = new SqlConnection(connectionStringSettings.ConnectionString);
            var serverConn = new ServerConnection(conn);
            var server = new Server(serverConn);
            server.ConnectionContext.ExecuteNonQuery(resetScriptReader.ReadToEnd());
            serverConn.Disconnect();
        }
    }
}
