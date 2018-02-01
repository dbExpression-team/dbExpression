using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Configuration;
using System.Dynamic;
using HTL.DbEx.Configuration;

namespace HTL.DbEx.Sql
{
    public abstract class SqlConnection
    {
        #region internals
        protected ConnectionStringSettings _connectionSettings;
        protected DbConnection _dbConnection;
        protected DbTransaction _dbTransaction;
        #endregion

        #region interface properties
        public string ConnectionString
        {
            get
            {
                return _connectionSettings.ConnectionString;
            }
        }

        public string ConnectionName
        {
            get
            {
                return _connectionSettings.Name;
            }
        }

        public string ProviderName
        {
            get
            {
                return _connectionSettings.ProviderName;
            }
        }

        public DbConnection DbConnection
        {
            get
            {
                this.EnsureConnection();
                return _dbConnection;
            }
        }

        public bool IsTransactional
        {
            get
            {
                return (_dbTransaction != null);
            }
        }
        #endregion

        #region constructors
        public SqlConnection() : this(ConfigurationService.Database.DefaultDatabase)
        {
        }

        public SqlConnection(string connectionStringName)
        {
            if (string.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentNullException(nameof(connectionStringName));
            }

            ConnectionStringSettings settings;

            settings = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (settings == null)
            {
                throw new ArgumentException("no connection string found for provided name: " + connectionStringName, nameof(connectionStringName));
            }
            _connectionSettings = settings;
        }

        public SqlConnection(ConnectionStringSettings settings)
        {
            if (settings == null) { throw new ArgumentNullException("settings"); }
            _connectionSettings = settings;
        }
        #endregion

        #region connection management methods
        protected void EnsureOpenConnection()
        {
            this.EnsureConnection();
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }
        }

        protected abstract void EnsureConnection();

        public void Disconnect()
        {
            if (_dbConnection != null)
            {
                if (_dbConnection.State != ConnectionState.Closed)
                {
                    _dbConnection.Close();
                }
                _dbConnection.Dispose();
                _dbConnection = null;
            }

            if (_dbTransaction != null)
            {
                _dbTransaction.Dispose();
                _dbTransaction = null;
            }
        }
        #endregion

        #region transaction methods
        public SqlConnection BeginTransaction()
        {
            this.EnsureOpenConnection();
            _dbTransaction = _dbConnection.BeginTransaction();
            return this;
        }

        public SqlConnection BeginTransaction(IsolationLevel iso)
        {
            this.EnsureOpenConnection();
            _dbTransaction = _dbConnection.BeginTransaction(iso);
            return this;
        }

        public void CommitTransaction()
        {
            if (_dbTransaction == null)
            {
                throw new InvalidOperationException("'CommitTransaction' failed.  A transaction was not started.");
            }
            _dbTransaction.Commit();
            this.Disconnect();
        }

        public void RollbackTransaction()
        {
            if (this.IsTransactional)
            {
                _dbTransaction.Rollback();
            }
            this.Disconnect();
        }
        #endregion

        #region abstract methods
        public abstract DbCommand GetDbCommand();
        public abstract DbParameter GetDbParameter(string name, object value);
        public abstract DbParameter GetDbParameter(string name, object value, Type valueType);
        public abstract DbParameter GetDbParameter(string name, object value, Type valueType, int? size);
        public abstract void DeriveParameters(IDbCommand cmd);
        public abstract IDataAdapter GetDbDataAdapter(DbCommand cmd);
        public abstract void FillDataTable(IDataAdapter da, DataTable dt);
        #endregion

        #region execution methods
        public void Execute(string executionCommand, DbCommandType commandType, List<DbParameter> param, int? commandTimeout = null)
        {
            DbCommand cmd = this.GetDbCommand();
            cmd.Connection = this.DbConnection;
            cmd.Transaction = this.IsTransactional ? _dbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (commandTimeout.HasValue)
            {
                cmd.CommandTimeout = commandTimeout.Value;
            }
            if (param != null) { cmd.Parameters.AddRange(param.ToArray()); }
            try
            {
                this.EnsureOpenConnection();
                cmd.ExecuteNonQuery();
                if (!this.IsTransactional) { this.Disconnect(); }
            }
            catch
            {
                if (this.IsTransactional)
                {
                    this.RollbackTransaction();
                }
                else
                {
                    this.Disconnect();
                }
                throw;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
            }
        }

        public object ExecuteScalar(string executionCommand, DbCommandType commandType, List<DbParameter> param)
        {
            object ret;
            DbCommand cmd = this.GetDbCommand();

            cmd.Connection = this.DbConnection;
            cmd.Transaction = this.IsTransactional ? _dbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (param != null) { cmd.Parameters.AddRange(param.ToArray()); }
            try
            {
                this.EnsureOpenConnection();
                ret = cmd.ExecuteScalar();
                if (ret == DBNull.Value) ret = null;
                if (!this.IsTransactional) { this.Disconnect(); }
            }
            catch
            {
                if (this.IsTransactional)
                {
                    this.RollbackTransaction();
                }
                else
                {
                    this.Disconnect();
                }
                throw;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
            }

            return ret;
        }

        public virtual IDataReader ExecuteReader(string executionCommand, DbCommandType commandType, List<DbParameter> param)
        {
            DbCommand cmd = this.GetDbCommand();
            IDataReader dr = null;
            cmd.Connection = this.DbConnection;
            cmd.Transaction = this.IsTransactional ? _dbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (param != null) { cmd.Parameters.AddRange(param.ToArray()); }
            try
            {
                this.EnsureOpenConnection();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                if (dr != null && !dr.IsClosed) { dr.Close(); } //redundant, but required for sqlCe before rollback...
                if (this.IsTransactional)
                {
                    this.RollbackTransaction();
                }
                else
                {
                    this.Disconnect();
                }
                throw;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
            }
            return dr;
        }

        public T ExecuteObject<T>(string executionCommand, DbCommandType commandType, List<DbParameter> param, FillObjectCallback<T> fillCallback) where T : new()
        {
            T obj = default(T);
            DbCommand cmd = this.GetDbCommand();
            IDataReader dr = null;
            cmd.Connection = this.DbConnection;
            cmd.Transaction = this.IsTransactional ? _dbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (param != null) { cmd.Parameters.AddRange(param.ToArray()); }
            //if (fillCallback == null) { fillCallback = this.FillObject; }
            try
            {
                this.EnsureOpenConnection();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj = new T();
                    if (fillCallback != null)
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        fillCallback(obj, values);
                    }
                    else
                    {
                        this.FillObject<T>(obj, dr);
                    }
                }
                dr.Close();
                if (!this.IsTransactional) { this.Disconnect(); }
            }
            catch
            {
                if (dr != null && !dr.IsClosed) { dr.Close(); } //redundant, but required for sqlCe before rollback...
                if (this.IsTransactional)
                {
                    this.RollbackTransaction();
                }
                else
                {
                    this.Disconnect();
                }
                throw;
            }
            finally
            {
                if (dr != null && !dr.IsClosed) { dr.Close(); }
                if (cmd != null) { cmd.Dispose(); }
            }
            return obj;
        }

        public List<T> ExecuteObjectList<T>(string executionCommand, DbCommandType commandType, List<DbParameter> param, FillObjectCallback<T> fillCallback) where T : new()
        {
            List<T> list = new List<T>();

            DbCommand cmd = this.GetDbCommand();
            IDataReader dr = null;
            cmd.Connection = this.DbConnection;
            cmd.Transaction = this.IsTransactional ? _dbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (param != null) { cmd.Parameters.AddRange(param.ToArray()); }
            //if (fillCallback == null) { fillCallback = this.FillObject; }
            try
            {
                this.EnsureOpenConnection();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    T obj = new T();
                    if (fillCallback != null)
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        fillCallback(obj, values);
                    }
                    else
                    {
                        this.FillObject<T>(obj, dr);
                    }
                    list.Add(obj);
                }
                dr.Close();
                if (!this.IsTransactional) { this.Disconnect(); }
            }
            catch
            {
                if (dr != null && !dr.IsClosed) { dr.Close(); } //redundant, but required for sqlCe before rollback...
                if (this.IsTransactional)
                {
                    this.RollbackTransaction();
                }
                else
                {
                    this.Disconnect();
                }
                throw;
            }
            finally
            {
                if (dr != null && !dr.IsClosed) { dr.Close(); }
                if (cmd != null) { cmd.Dispose(); }
            }
            return list;
        }

        public List<T> ExecuteValueList<T>(string executionCommand, DbCommandType commandType, List<DbParameter> param)
        {
            List<T> list = new List<T>();

            DbCommand cmd = this.GetDbCommand();
            IDataReader dr = null;
            cmd.Connection = this.DbConnection;
            cmd.Transaction = this.IsTransactional ? _dbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (param != null) { cmd.Parameters.AddRange(param.ToArray()); }
            try
            {
                this.EnsureOpenConnection();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add((dr[0] != DBNull.Value) ? (T)dr[0] : default(T));
                    //list.Add((T)dr[0]);
                }
                dr.Close();
                if (!this.IsTransactional) { this.Disconnect(); }
            }
            catch
            {
                if (dr != null && !dr.IsClosed) { dr.Close(); } //redundant, but required for sqlCe before rollback...
                if (this.IsTransactional)
                {
                    this.RollbackTransaction();
                }
                else
                {
                    this.Disconnect();
                }
                throw;
            }
            finally
            {
                if (dr != null && !dr.IsClosed) { dr.Close(); }
                if (cmd != null) { cmd.Dispose(); }
            }
            return list;
        }

        public DataTable ExecuteDataTable(string executionCommand, DbCommandType commandType, List<DbParameter> param)
        {
            DbCommand cmd = this.GetDbCommand();
            cmd.Connection = this.DbConnection;
            cmd.Transaction = this.IsTransactional ? _dbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (param != null) { cmd.Parameters.AddRange(param.ToArray()); }

            DataTable dt = new DataTable();
            IDataAdapter da = this.GetDbDataAdapter(cmd);
            try
            {
                this.EnsureOpenConnection();
                this.FillDataTable(da, dt);
                if (!this.IsTransactional) { this.Disconnect(); }
            }
            catch
            {
                if (this.IsTransactional)
                {
                    this.RollbackTransaction();
                }
                else
                {
                    this.Disconnect();
                }
                throw;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
            }
            return dt;
        }

        public DataSet ExecuteDataSet(string executionCommand, DbCommandType commandType, List<DbParameter> param)
        {
            DbCommand cmd = this.GetDbCommand();
            cmd.Connection = this.DbConnection;
            cmd.Transaction = this.IsTransactional ? _dbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (param != null) { cmd.Parameters.AddRange(param.ToArray()); }

            DataSet ds = new DataSet();
            IDataAdapter da = this.GetDbDataAdapter(cmd);
            try
            {
                this.EnsureOpenConnection();
                da.Fill(ds);
                if (!this.IsTransactional) { this.Disconnect(); }
            }
            catch
            {
                if (this.IsTransactional)
                {
                    this.RollbackTransaction();
                }
                else
                {
                    this.Disconnect();
                }
                throw;
            }
            finally
            {
                if (cmd != null) { cmd.Dispose(); }
            }

            return ds;
        }

        public dynamic ExecuteDynamic(string executionCommand, DbCommandType commandType, List<DbParameter> param)
        {
            ExpandoObject obj = null;

            DbCommand cmd = this.GetDbCommand();
            IDataReader dr = null;
            cmd.Connection = this.DbConnection;
            cmd.Transaction = this.IsTransactional ? _dbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (param != null) { cmd.Parameters.AddRange(param.ToArray()); }

            try
            {
                this.EnsureOpenConnection();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    obj = this.BuildObject(dr, this.GetColumnNames(dr));
                }
                dr.Close();
                if (!this.IsTransactional) { this.Disconnect(); }
            }
            catch
            {
                if (dr != null && !dr.IsClosed) { dr.Close(); } //redundant, but required for sqlCe before rollback...
                if (this.IsTransactional)
                {
                    this.RollbackTransaction();
                }
                else
                {
                    this.Disconnect();
                }
                throw;
            }
            finally
            {
                if (dr != null && !dr.IsClosed) { dr.Close(); }
                if (cmd != null) { cmd.Dispose(); }
            }
            return obj;
        }

        public List<dynamic> ExecuteDynamicList(string executionCommand, DbCommandType commandType, List<DbParameter> param)
        {
            List<dynamic> list = new List<dynamic>();

            DbCommand cmd = this.GetDbCommand();
            IDataReader dr = null;
            cmd.Connection = this.DbConnection;
            cmd.Transaction = this.IsTransactional ? _dbTransaction : null;
            cmd.CommandText = executionCommand;
            cmd.CommandType = (commandType == DbCommandType.Sproc) ? CommandType.StoredProcedure : CommandType.Text;
            if (param != null) { cmd.Parameters.AddRange(param.ToArray()); }
            try
            {
                this.EnsureOpenConnection();
                dr = cmd.ExecuteReader();
                string[] columns = this.GetColumnNames(dr);
                while (dr.Read())
                {
                    ExpandoObject obj = this.BuildObject(dr, columns);
                    list.Add(obj);
                }
                dr.Close();
                if (!this.IsTransactional) { this.Disconnect(); }
            }
            catch
            {
                if (dr != null && !dr.IsClosed) { dr.Close(); } //redundant, but required for sqlCe before rollback...
                if (this.IsTransactional)
                {
                    this.RollbackTransaction();
                }
                else
                {
                    this.Disconnect();
                }
                throw;
            }
            finally
            {
                if (dr != null && !dr.IsClosed) { dr.Close(); }
                if (cmd != null) { cmd.Dispose(); }
            }
            return list;
        }
        #endregion

        #region helper methods
        protected bool IsNullable(Type t)
        {
            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        //It will fill any object generically, but it is SLOW!!! Beware (JRod)
        protected void FillObject<T>(T obj, IDataReader dr) where T : new()
        {
            int cols = dr.FieldCount;
            Type type = obj.GetType();
            for (int i = 0; i < cols; i++)
            {
                string colName = dr.GetName(i);
                FieldInfo fi = type.GetField(colName);
                if (fi != null)
                {
                    if (!dr.IsDBNull(i))
                        fi.SetValue(obj, dr[i]);
                }
                PropertyInfo pi = type.GetProperty(colName);
                if (pi != null)
                {
                    if (!dr.IsDBNull(i))
                    {
                        //deal with the case of nullable types and nullable enums
                        if (this.IsNullable(pi.PropertyType))
                        {
                            Type[] typeCol = pi.PropertyType.GetGenericArguments();
                            Type nullableType;
                            if (typeCol.Length > 0)
                            {
                                nullableType = typeCol[0];
                                if (nullableType.BaseType == typeof(Enum))
                                {
                                    object o = Enum.ToObject(nullableType, dr[i]);
                                    pi.SetValue(obj, o, null);
                                }
                                else
                                {
                                    pi.SetValue(obj, dr[i], null);
                                }
                            }
                        }
                        else if (pi.PropertyType.IsEnum)
                        {
                            pi.SetValue(obj, Enum.ToObject(pi.PropertyType, dr[i]), null);
                        }
                        else
                        {
                            pi.SetValue(obj, dr[i], null);
                        }
                    }
                }
            }
        }

        private string[] GetColumnNames(IDataReader dr)
        {
            int cnt = dr.FieldCount;
            string[] columns = null;
            if (cnt > 0)
            {
                columns = new string[cnt];
                for (int i = 0; i < cnt; i++)
                {
                    columns[i] = dr.GetName(i);
                }
            }
            return (columns == null) ? new string[0] : columns;
        }

        protected ExpandoObject BuildObject(IDataReader dr, string[] columns)
        {
            ExpandoObject o = new ExpandoObject();
            IDictionary<string, object> iDict = (o as IDictionary<string, object>);

            for (int i = 0; i < columns.Length; i++)
            {
                iDict.Add(columns[i], (dr.IsDBNull(i)) ? null : dr[i]);
            }

            return o;
        }
        #endregion
    }
}
