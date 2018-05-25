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
    public class DeleteMsSqlBuilder<T> : MsSqlBuilder<T>
    {
        #region constructors
        public DeleteMsSqlBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity) : base(connectionStringName, baseEntity)
        {
        }

        public DeleteMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity) : base(connectionStringSettings, baseEntity)
        {
            BaseEntity = baseEntity;
        }
        #endregion

        #region assemble delete sql
        private string AssembleDeleteSql()
        {
            string join = string.Empty;
            string where = string.Empty;
            string topExpression = string.Empty;

            if (Expression.Joins != null)
            {
                join = " " + Expression.Joins.ToParameterizedString(base.DbParams, this.SqlClient);
            }
            if (Expression.Where != null)
            {
                where = " WHERE " + Expression.Where.ToParameterizedString(base.DbParams, this.SqlClient);
            }
            if (TopValue.HasValue)
            {
                topExpression = string.Concat("TOP (", base.TopValue.Value.ToString(), ")", Environment.NewLine);
            }

            string sql;
            sql = string.Format("DELETE {0} {1} FROM {1}{2}{3};", topExpression, base.BaseEntity.ToString(), join, where);
            return sql;
        }
        #endregion
    }
}
