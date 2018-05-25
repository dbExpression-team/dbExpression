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
    public class UpdateMsSqlBuilder<T> : MsSqlBuilder<T>
    {
        #region constructors
        public UpdateMsSqlBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity) : base(connectionStringName, baseEntity)
        {
        }

        public UpdateMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity) : base(connectionStringSettings, baseEntity)
        {
            BaseEntity = baseEntity;
        }
        #endregion

        #region assemble update sql
        private string AssembleUpdateSql()
        {
            string join = string.Empty;
            string where = string.Empty;
            string topExpression = string.Empty;

            string assignmentClause = base.Expression.Assign.ToParameterizedString(base.DbParams, this.SqlClient);

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
            sql = string.Format("UPDATE {0} {1} SET {2} FROM {1}{3}{4};", topExpression, base.BaseEntity.ToString(), assignmentClause, join, where);
            return sql;
        }
        #endregion
    }
}
