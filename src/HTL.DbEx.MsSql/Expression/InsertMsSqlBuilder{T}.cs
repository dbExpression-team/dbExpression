using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using HTL.DbEx.Utility;
using System.Configuration;
using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression
{
    public class InsertSqlExpressionBuilder<T> : MsSqlExpressionBuilder<T>
    {
        #region internals
        private T _record;
        #endregion

        #region constructors
        public InsertSqlExpressionBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity) : base(connectionStringName, baseEntity)
        {
        }

        public InsertSqlExpressionBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity) : base(connectionStringSettings, baseEntity)
        {
            BaseEntity = baseEntity;
        }
        #endregion

        #region assemble insert sql
        private string AssembleInsertSql(bool isIdentity)
        {
            string insertClause = base.Expression.Insert.ToParameterizedString(base.DbParams, this.SqlClient);

            string sql = string.Format("INSERT INTO {0} {1};", base.BaseEntity.ToString(), insertClause);
            return (isIdentity) ? sql + " SELECT SCOPE_IDENTITY();" : sql;
        }
        #endregion
    }
}
