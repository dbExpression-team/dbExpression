using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using HatTrick.DbEx.MsSql.Types;
using ht = HatTrick.DbEx.Sql;

namespace HatTrick.DbEx.MsSql
{
    public class MsSqlConnection : ht.SqlConnection
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
            if (_dbConnection == null)
            {
                _dbConnection = new SqlConnection(ConnectionSettings.ConnectionString);
            }
        }
        #endregion

        #region helper methods
        public override DbCommand GetDbCommand() => new SqlCommand();

        public override DbParameter GetDbParameter(string name, object value) => this.GetDbParameter(name, value, null);

        public override DbParameter GetDbParameter(string name, object value, Type valueType) => this.GetDbParameter(name, value, valueType, null);

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
            return new SqlParameter(name, val);
        }

        public override void DeriveParameters(IDbCommand cmd) => SqlCommandBuilder.DeriveParameters((SqlCommand)cmd);

        public override IDataAdapter GetDbDataAdapter(DbCommand cmd) => new SqlDataAdapter
            {
                SelectCommand = (SqlCommand)cmd
            };

        public override void FillDataTable(IDataAdapter da, DataTable dt) => (da as SqlDataAdapter).Fill(dt);
        #endregion

        #region get expression builder
        //public SqlExpressionBuilder GetSelectMsSqlBuilder<T>(DBExpressionEntity<T> entity) => new SelectMsSqlBuilder<T>(ConnectionSettings, entity).Enlist(this);
        //public SqlExpressionBuilder GetInsertMsSqlBuilder<T>(DBExpressionEntity<T> entity, T record) => new InsertMsSqlBuilder<T>(ConnectionSettings, entity, record).Enlist(this);
        //public SqlExpressionBuilder GetUpdateMsSqlBuilder<T>(DBExpressionEntity<T> entity) => new UpdateMsSqlBuilder<T>(ConnectionSettings, entity).Enlist(this);
        //public SqlExpressionBuilder GetDeleteMsSqlBuilder<T>(DBExpressionEntity<T> entity) => new DeleteMsSqlBuilder<T>(ConnectionSettings, entity).Enlist(this);
        #endregion
    }
}
