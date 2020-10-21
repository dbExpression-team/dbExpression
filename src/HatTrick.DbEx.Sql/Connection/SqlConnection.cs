using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Connection
{
    public class SqlConnector : ISqlConnection
    {
        #region i sql connection
        private bool disposed;
        protected IDbConnection _dbConnection;
        protected ISqlConnectionFactory _connectionFactory;

        public IDbTransaction DbTransaction { get; private set; }

        public IDbConnection DbConnection
        {
            get
            {
                EnsureConnection();
                return _dbConnection;
            }
            protected set
            {
                _dbConnection = value;
            }
        }

        public bool IsTransactional => DbTransaction is object;

        public SqlConnector(ISqlConnectionFactory connectionFactory)
        {
            if (connectionFactory is null)
            {
                throw new ArgumentNullException(nameof(connectionFactory));
            }

            _connectionFactory = connectionFactory;
        }

        protected void EnsureConnection()
        {
            if (_dbConnection is null)
                _dbConnection = _connectionFactory.CreateSqlConnection();
        }

        public void EnsureOpen()
        {
            EnsureConnection();
            if (_dbConnection.State != ConnectionState.Open)
                _dbConnection.Open();
        }

        public async Task EnsureOpenAsync(CancellationToken cancellation)
        {
            EnsureConnection();
            if (_dbConnection.State != ConnectionState.Open)
                await (_dbConnection as DbConnection).OpenAsync(cancellation);
        }

        public void CommitTransaction()
        {
            if (DbTransaction is null)
            {
                throw new InvalidOperationException("'CommitTransaction' failed.  No pending transaction exists.");
            }

            try
            {
                DbTransaction.Commit();
            }
            finally //Transactions are NOT reusable in any way.  No reason to risk consumer not disposing.
            {
                DbTransaction.Dispose();
                DbTransaction = null;
            }
        }

        public void RollbackTransaction()
        {
            if (!(DbConnection is null))
            {
                try
                {
                    DbTransaction.Rollback();
                }
                finally //Transactions are NOT reusable in any way.  No reason to risk consumer not disposing.
                {
                    DbTransaction.Dispose();
                    DbTransaction = null;
                }
            }
        }
        #endregion

        #region i db connection
        public string ConnectionString
        {
            get
            {
                EnsureConnection();
                return _dbConnection.ConnectionString;
            }
            set { throw new NotSupportedException("Overwriting connection string is not suppoted."); }
        }

        public int ConnectionTimeout
        {
            get
            {
                EnsureConnection();
                return _dbConnection.ConnectionTimeout;
            }
        }

        public string Database
        {
            get
            {
                EnsureConnection();
                return _dbConnection.Database;
            }
        }

        public ConnectionState State
        {
            get
            {
                EnsureConnection();
                return _dbConnection.State;
            }
        }

        public IDbTransaction BeginTransaction()
        {
            if (_dbConnection?.State != ConnectionState.Open)
                throw new InvalidOperationException($"The connection is '{_dbConnection?.State ?? ConnectionState.Closed}'.");

            DbTransaction = _dbConnection.BeginTransaction();
            return DbTransaction;
        }

        public IDbTransaction BeginTransaction(IsolationLevel iso)
        {
            if (_dbConnection?.State != ConnectionState.Open)
                throw new InvalidOperationException($"The connection is '{_dbConnection?.State ?? ConnectionState.Closed}'.");

            DbTransaction = _dbConnection.BeginTransaction(iso);
            return DbTransaction;
        }

        public void ChangeDatabase(string databaseName)
        {
            EnsureConnection();
            _dbConnection.ChangeDatabase(databaseName);
        }

        public void Close()
        {
            if (DbTransaction is object)
            { 
                DbTransaction.Dispose();
                DbTransaction = null; //ensure null, it drives the IsTransactional property
            }

            if (_dbConnection is object && _dbConnection.State != ConnectionState.Closed)
                _dbConnection.Close();
        }

        public IDbCommand CreateCommand()
        {
            EnsureConnection();
            return _dbConnection.CreateCommand();
        }

        public void Open()
        {
            EnsureConnection();
            _dbConnection.Open();
        }
        #endregion

        #region i disposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (DbTransaction is object)
                    {
                        DbTransaction.Dispose();
                        DbTransaction = null; //ensure null, it drives the IsTransactional property
                    }

                    if (_dbConnection is object)
                    {
                        _dbConnection.Dispose();
                        _dbConnection = null;
                    }
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
