using HatTrick.DbEx.Configuration;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Connection
{
    public abstract class SqlConnection : ISqlConnection, IDisposable
    {
        #region internals
        private bool disposed;
        protected DbConnection _dbConnection;
        protected Func<string> ConnectionStringFactory { get; private set; }
        public DbTransaction DbTransaction { get; private set; }
        #endregion

        #region interface properties
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

        public abstract DbCommand CreateDbCommand();

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

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[connectionStringName] ?? throw new ArgumentException("no connection string found for provided name: " + connectionStringName, nameof(connectionStringName)); ;
            ConnectionStringFactory = () => settings.ConnectionString;
        }

        protected SqlConnection(Func<string> connectionStringFactory)
        {
            ConnectionStringFactory = connectionStringFactory ?? throw new ArgumentNullException($"{nameof(connectionStringFactory)} is required.");
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
        public ISqlConnection BeginTransaction()
        {
            this.EnsureOpenConnection();
            DbTransaction = DbConnection.BeginTransaction();
            return this;
        }

        public ISqlConnection BeginTransaction(IsolationLevel iso)
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
