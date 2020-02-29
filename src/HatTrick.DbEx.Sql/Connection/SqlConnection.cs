using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Configuration;
using System.Dynamic;
using HatTrick.DbEx.Configuration;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql
{
    public abstract class SqlConnection : IDisposable
    {
        #region internals
        private bool disposed;
        protected DbConnection _dbConnection;
        protected ConnectionStringSettings ConnectionSettings { get; private set; }
        public DbTransaction DbTransaction { get; private set; }
        #endregion

        #region interface properties
        public string ConnectionString => ConnectionSettings.ConnectionString;

        public string ConnectionName => ConnectionSettings.Name;

        public string ProviderName => ConnectionSettings.ProviderName;

        public DbConnection DbConnection
        {
            get
            {
                this.EnsureConnection();
                return _dbConnection;
            }
            protected set
            {
                _dbConnection = value;
            }
        }

        public bool IsTransactional => DbTransaction != null;
        #endregion

        #region constructors
        protected SqlConnection() : this(ConfigurationService.Database.DefaultDatabase)
        {
        }

        protected SqlConnection(string connectionStringName)
        {
            if (string.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentNullException(nameof(connectionStringName));
            }

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[connectionStringName];
            ConnectionSettings = settings ?? throw new ArgumentException("no connection string found for provided name: " + connectionStringName, nameof(connectionStringName));
        }

        protected SqlConnection(ConnectionStringSettings settings)
        {
            ConnectionSettings = settings ?? throw new ArgumentNullException($"{nameof(settings)} is required.");
        }
        #endregion

        #region connection management methods
        public void EnsureOpenConnection()
        {
            this.EnsureConnection();
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }
        }

        public async Task EnsureOpenConnectionAsync()
        {
            this.EnsureConnection();
            if (_dbConnection.State != ConnectionState.Open)
            {
                await _dbConnection.OpenAsync().ConfigureAwait(false);
            }
        }

        public void Disconnect()
        {
            if (DbConnection != null)
            {
                if (DbConnection.State != ConnectionState.Closed)
                {
                    DbConnection.Close();
                }
                DbConnection.Dispose();
                DbConnection = null;
            }

            if (DbTransaction != null)
            {
                DbTransaction.Dispose();
                DbTransaction = null;
            }
        }
        #endregion

        #region transaction methods
        public SqlConnection BeginTransaction()
        {
            this.EnsureOpenConnection();
            DbTransaction = DbConnection.BeginTransaction();
            return this;
        }

        public SqlConnection BeginTransaction(IsolationLevel iso)
        {
            this.EnsureOpenConnection();
            DbTransaction = DbConnection.BeginTransaction(iso);
            return this;
        }

        public void CommitTransaction()
        {
            if (DbTransaction == null)
            {
                throw new InvalidOperationException("'CommitTransaction' failed.  A transaction was not started.");
            }
            DbTransaction.Commit();
            this.Disconnect();
        }

        public void RollbackTransaction()
        {
            if (this.IsTransactional)
            {
                DbTransaction.Rollback();
            }
            this.Disconnect();
        }
        #endregion

        #region abstract methods
        protected abstract void EnsureConnection();
        public abstract DbCommand GetDbCommand();
        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (DbTransaction != null)
                    {
                        DbTransaction.Dispose();
                    }
                    if (_dbConnection != null)
                    {
                        if (_dbConnection.State == ConnectionState.Open)
                            _dbConnection.Close();
                        _dbConnection.Dispose();
                    }
                }
                DbTransaction = null;
                DbConnection = null;
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
