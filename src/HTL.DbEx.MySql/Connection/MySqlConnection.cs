using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using HTL.DbEx.MySql.Types;
using HTL.DbEx.Sql.Expression;
using HTL.DbEx.MySql.Expression;
using htl = HTL.DbEx.Sql;
using my = MySql.Data.MySqlClient;

namespace HTL.DbEx.MySql
{
    public class MySqlConnection : htl.SqlConnection
    {
        #region constructors
        public MySqlConnection() : base()
        {
        }

        public MySqlConnection(string connectionStringName) : base(connectionStringName)
        {
            
        }

        public MySqlConnection(ConnectionStringSettings settings) : base(settings)
        {
        }
        #endregion

        #region concrete connection provider
        protected override void EnsureConnection()
        {
            if (DbConnection == null)
            {
                DbConnection = new my.MySqlConnection(ConnectionSettings.ConnectionString);
            }
        }
        #endregion

        #region helper methods
        public override DbCommand GetDbCommand()
        {
            return new my.MySqlCommand();
        }

        public override DbParameter GetDbParameter(string name, object value)
        {
            return this.GetDbParameter(name, value, null);
        }

        public override DbParameter GetDbParameter(string name, object value, Type valueType)
        {
            return this.GetDbParameter(name, value, valueType, null);
        }

        public override DbParameter GetDbParameter(string name, object value, Type valueType, int? size)
        {
            object val = (value == null) ? DBNull.Value : value;
            if (MySqlTypeMap.IsSqlTypeKnown(valueType))
            {
                if (size.HasValue)
                {
                    return new my.MySqlParameter(name, MySqlTypeMap.GetSqlType(valueType), size.Value) { Value = val };
                }
                else
                {
                    return new my.MySqlParameter(name, MySqlTypeMap.GetSqlType(valueType)) { Value = val };
                }
            }
            else
            {
                return new my.MySqlParameter(name, val);
            }
        }

        public override void DeriveParameters(IDbCommand cmd)
        {
            my.MySqlCommandBuilder.DeriveParameters((my.MySqlCommand)cmd);
        }

        public override IDataAdapter GetDbDataAdapter(DbCommand cmd)
        {
            IDataAdapter ida = null;
            my.MySqlDataAdapter sqlda = new my.MySqlDataAdapter();
            sqlda.SelectCommand = (my.MySqlCommand)cmd;
            ida = sqlda;
            return ida;
        }

        public override void FillDataTable(IDataAdapter da, DataTable dt)
        {
            (da as my.MySqlDataAdapter).Fill(dt);
        }
        #endregion

        #region get expression builder
        public SqlExpressionBuilder<T> GetExpressionBuilder<T>(DBExpressionEntity entity) where T : new()
        {
            return new MySqlExpressionBuilder<T>(ConnectionSettings.Name, entity).Enlist(this);
        }
        #endregion
    }
}
