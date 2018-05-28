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
        public DeleteMsSqlBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity) : base(connectionStringName, baseEntity, ExecutionContext.Delete)
        {
        }

        public DeleteMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity) : base(connectionStringSettings, baseEntity, ExecutionContext.Delete)
        {
            BaseEntity = baseEntity;
        }
        #endregion

        #region execute
        public void Execute()
        {
            Validate();

            string sql = AssembleDeleteSql();

            base.Delete(sql);
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();

            if (Expression.Assign != null)
            {
                throw new InvalidOperationException("An attempt to set an 'Assignment Expression' within a 'Delete' execution context failed.  'Delete' does not allow a consumer to specify any fields for assignment.");
            }
            if (Expression.OrderBy != null)
            {
                throw new InvalidOperationException("An attempt to set an 'Order Expression' within a 'Delete' execution context failed.  An 'Order Expression' cannot be applied to a 'Delete' execution request.");
            }
            if (Expression.GroupBy != null)
            {
                throw new InvalidOperationException("An attempt to set a 'Group By Expression' within a 'Delete' execution context failed.  An 'Group By Expression' cannot be applied to a 'Delete' execution request.");
            }
            if (Expression.Select != null)
            {
                throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'Delete' execution context failed.  A 'Select Expression' cannot be applied to a 'Delete' execution request.");
            }
            if (SkipValue.HasValue)
            {
                throw new InvalidOperationException("An attempt to set a 'Skip/Take' Expression' within a 'Delete' execution context failed.  A 'Skip/Take Expression' cannot be applied to a 'Delete' execution request.");
            }
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
