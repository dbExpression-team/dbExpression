using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using HTL.DbEx.Configuration;
using HTL.DbEx.MsSql.Types;
using HTL.DbEx.Sql.Expression;
using HTL.DbEx.MsSql.Expression;
using htl = HTL.DbEx.Sql;

namespace HTL.DbEx.MsSql
{
    public class MsSqlConnection : htl.SqlConnection
    {
        #region constructors
        public MsSqlConnection() : base()
        {
        }

        public MsSqlConnection(string connectionStringName) : base(connectionStringName)
        {
        }

        public MsSqlConnection(ConnectionStringSettings settings) : base(settings)
        {
        }
        #endregion

        #region concrete connection provider 
        protected override void EnsureConnection()
        {
            if (base._dbConnection == null)
            {
                base._dbConnection = new SqlConnection(_connectionSettings.ConnectionString);
            }
        }
        #endregion

        #region helper methods
        public override DbCommand GetDbCommand()
        {
            return new SqlCommand();
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
            if (MsSqlTypeMap.IsSqlTypeKnown(valueType))
            {
                if (size.HasValue)
                {
                    return new SqlParameter(name, MsSqlTypeMap.GetSqlType(valueType), size.Value) { Value = val };
                }
                else
                {
                    return new SqlParameter(name, MsSqlTypeMap.GetSqlType(valueType)) { Value = val };
                }
            }
            else
            {
                return new SqlParameter(name, val);
            }
        }

        public override void DeriveParameters(IDbCommand cmd)
        {
            SqlCommandBuilder.DeriveParameters((SqlCommand)cmd);
        }

        public override IDataAdapter GetDbDataAdapter(DbCommand cmd)
        {
            IDataAdapter ida = null;
            SqlDataAdapter sqlda = new SqlDataAdapter();
            sqlda.SelectCommand = (SqlCommand)cmd;
            ida = sqlda;
            return ida;
        }

        public override void FillDataTable(IDataAdapter da, DataTable dt)
        {
            (da as SqlDataAdapter).Fill(dt);
        }
        #endregion

        #region get expression builder
        public SqlExpressionBuilder<T> GetExpressionBuilder<T>(DBExpressionEntity entity) where T : new()
        {
            return new MsSqlExpressionBuilder<T>(_connectionSettings.Name, entity).Enlist(this);
        }
        #endregion
    }
}
