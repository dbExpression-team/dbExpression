using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Configuration;
using System.IO;

namespace HatTrick.DbEx.MsSql.Test.Database
{
    public class Seeder
    {
        private string connectionString;

        public Seeder(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void RunScript(string scriptName)
        {
            RunScript(scriptName, AppDomain.CurrentDomain.BaseDirectory);
        }

        public void RunScript(string scriptName, string scriptPath)
        {
            using var resetScriptReader = File.OpenText(Path.Combine(scriptPath, scriptName));
            using var conn = new SqlConnection(connectionString);
            var serverConn = new ServerConnection(conn);
            var server = new Server(serverConn);
            server.ConnectionContext.ExecuteNonQuery(resetScriptReader.ReadToEnd());
            serverConn.Disconnect();
        }
    }
}
