#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

﻿using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Connection
{
    public class SqlConnector<TDatabase> : ISqlConnection
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region i sql connection
        private bool disposed;
        protected IDbConnection? _dbConnection;
        protected IConnectionStringFactory<TDatabase> _connectionStringFactory;
        protected ISqlConnectionFactory<TDatabase> _connectionFactory;

        public IDbTransaction? DbTransaction { get; private set; }

        public IDbConnection DbConnection
        {
            get
            {
                EnsureConnection();
                return _dbConnection!;
            }
            protected set
            {
                _dbConnection = value;
            }
        }

        public bool IsTransactional => DbTransaction is not null;

        public SqlConnector(IConnectionStringFactory<TDatabase> connectionStringFactory, ISqlConnectionFactory<TDatabase> connectionFactory)
        {
            _connectionStringFactory = connectionStringFactory ?? throw new ArgumentNullException(nameof(connectionStringFactory));
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        protected void EnsureConnection()
        {
            if (_dbConnection is null)
                _dbConnection = _connectionFactory.CreateSqlConnection(_connectionStringFactory.GetConnectionString());
        }

        public void EnsureOpen()
        {
            EnsureConnection();
            if (_dbConnection!.State != ConnectionState.Open)
                _dbConnection.Open();
        }

        public async Task EnsureOpenAsync()
        {
            await EnsureOpenAsync(default);
        }

        public async Task EnsureOpenAsync(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();
            EnsureConnection();
            if (_dbConnection!.State != ConnectionState.Open)
            {
                if (_dbConnection is DbConnection concrete)
                    await concrete.OpenAsync(ct);
                else
                    _dbConnection.Open();
            }
        }

        public void CommitTransaction()
        {
            if (DbTransaction is null)
                throw new DbExpressionException("'CommitTransaction' failed.  No pending transaction exists.");

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
            if (DbTransaction is not null) //should allow multi rollback calls without error.
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
                return _dbConnection!.ConnectionString;
            }
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
            // System.Data.IDbConnection is a "string", not a "string?", cannot eliminate warnings.
            set => throw new NotSupportedException("Overwriting connection string is not supported.");
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
        }

        public int ConnectionTimeout
        {
            get
            {
                EnsureConnection();
                return _dbConnection!.ConnectionTimeout;
            }
        }

        public string Database
        {
            get
            {
                EnsureConnection();
                return _dbConnection!.Database;
            }
        }

        public ConnectionState State
        {
            get
            {
                EnsureConnection();
                return _dbConnection!.State;
            }
        }

        public IDbTransaction BeginTransaction()
        {
            if (_dbConnection?.State != ConnectionState.Open)
                throw new DbExpressionException($"The connection is '{_dbConnection?.State ?? ConnectionState.Closed}'.");

            if (DbTransaction != null)
                throw new DbExpressionException("A pending transaction already exists for this connection.  Parallel transactions are not supported.");

            DbTransaction = _dbConnection.BeginTransaction();
            return DbTransaction;
        }

        public IDbTransaction BeginTransaction(IsolationLevel iso)
        {
            if (_dbConnection?.State != ConnectionState.Open)
                throw new DbExpressionException($"The connection is '{_dbConnection?.State ?? ConnectionState.Closed}'.");

            if (DbTransaction != null)
                throw new DbExpressionException("A pending transaction already exists for this connection.  Parallel transactions are not supported.");

            DbTransaction = _dbConnection.BeginTransaction(iso);
            return DbTransaction;
        }

        public void ChangeDatabase(string databaseName)
        {
            EnsureConnection();
            _dbConnection!.ChangeDatabase(databaseName);
        }

        public void Close()
        {
            if (DbTransaction is not null)
            { 
                DbTransaction.Dispose();
                DbTransaction = null; //ensure null, it drives the IsTransactional property
            }

            if (_dbConnection is not null && _dbConnection.State != ConnectionState.Closed)
                _dbConnection.Close();
        }

        public IDbCommand CreateCommand()
        {
            EnsureConnection();
            return _dbConnection!.CreateCommand();
        }

        public void Open()
        {
            EnsureConnection();
            _dbConnection!.Open();
        }
        #endregion

        #region i disposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (DbTransaction is not null)
                    {
                        DbTransaction.Dispose();
                        DbTransaction = null; //ensure null, it drives the IsTransactional property
                    }

                    if (_dbConnection is not null)
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
