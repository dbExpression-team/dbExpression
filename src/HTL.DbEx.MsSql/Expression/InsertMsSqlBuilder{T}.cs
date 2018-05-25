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
    public class InsertMsSqlBuilder<T> : MsSqlBuilder<T>
    {
        #region internals
        private T _record;
        #endregion

        #region constructors
        public InsertMsSqlBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity, T record) : base(connectionStringName, baseEntity)
        {
            _record = record;
            base.Expression &= baseEntity.GetInclusiveInsertExpression(record);
        }

        public InsertMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity, T record) : base(connectionStringSettings, baseEntity)
        {
            BaseEntity = baseEntity;
            _record = record;
            base.Expression &= baseEntity.GetInclusiveInsertExpression(record);
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
