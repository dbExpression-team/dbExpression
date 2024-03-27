using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Configuration;
using System.Data.Common;
using System.IO;

namespace DbExpression.MsSql.Test.Database
{
    public class Seeder : IDisposable
    {
        private bool _requireReset = true;
        private static string? _databaseName;
        private static int _testsExecutedCount = 0;
        private bool disposedValue;

        private void RequireReset(bool require)
        {
            _requireReset = require;
        }

        public void ResetDatabase()
        {
            if (!_requireReset)
                return;

            RunScript("data.sql");
            if (_testsExecutedCount % 250 == 0)
                BackupDatabase();
            _testsExecutedCount++;
        }

        public void BackupDatabase()
        {
            Run($"BACKUP DATABASE [{GetDatabaseName()}] TO DISK = N'NUL';");
        }

        public void AppendImagesToProductsInDatabase()
        {
            RunScript("images.sql");
        }

        public void RunScript(string scriptName)
        {
            RunScript(scriptName, AppDomain.CurrentDomain.BaseDirectory);
        }

        public void RunScript(string scriptName, string scriptPath)
        {
            using var resetScriptReader = File.OpenText(Path.Combine(scriptPath, scriptName));
            using var conn = new SqlConnection(ConfigurationProvider.ConnectionString);
            var serverConn = new ServerConnection(conn);
            var server = new Server(serverConn);
            server.ConnectionContext.ExecuteNonQuery(resetScriptReader.ReadToEnd());
            serverConn.Disconnect();
        }

        public void Run(string command)
        {
            using var conn = new SqlConnection(ConfigurationProvider.ConnectionString);
            var serverConn = new ServerConnection(conn);
            var server = new Server(serverConn);
            server.ConnectionContext.ExecuteNonQuery(command);
            serverConn.Disconnect();
        }

        private static string GetDatabaseName()
        {
            if (_databaseName == null)
            {
                var builder = new DbConnectionStringBuilder();
                builder.ConnectionString = ConfigurationProvider.ConnectionString;
                if (builder.ContainsKey("database"))
                    _databaseName = builder["database"] as string;
                else if (builder.ContainsKey("initial catalog"))
                    _databaseName = builder["initial catalog"] as string;
                else throw new InvalidOperationException("Could not resolve the database name from the connection string from the configuration provider.");
            }

            return _databaseName!;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ResetDatabase();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
