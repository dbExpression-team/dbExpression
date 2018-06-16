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

        #region enlist
        public new DeleteMsSqlBuilder<T> Enlist(SqlConnection sqlClient)
        {
            base.Enlist(sqlClient);
            return this;
        }
        #endregion

        #region select
        //HACK
        private new DeleteMsSqlBuilder<T> Select(params DBSelectExpression[] selectExpressions)
        {
            base.Select(selectExpressions);
            return this;
        }
        #endregion

        #region distinct
        //HACK
        private new DeleteMsSqlBuilder<T> Distinct()
        {
            base.Distinct();
            return this;
        }
        #endregion

        #region skip
        //HACK...
        private new DBSkipDirective Skip(int count)
        {
            base.SkipValue = count;
            return new DBSkipDirective(this);
        }
        #endregion

        #region set fields
        //HACK
        private new DeleteMsSqlBuilder<T> SetFields(params DBAssignmentExpression[] assignmentExpressions)
        {
            base.SetFields(assignmentExpressions);
            return this;
        }
        #endregion

        #region set fields
        //HACK
        private new DeleteMsSqlBuilder<T> SetFields(DBAssignmentExpressionSet assignmentExpressionSet)
        {
            base.SetFields(assignmentExpressionSet);
            return this;
        }
        #endregion

        #region where 
        public new DeleteMsSqlBuilder<T> Where(DBFilterExpressionSet filter)
        {
            base.Where(filter);
            return this;
        }
        #endregion

        #region order by
        public new DeleteMsSqlBuilder<T> OrderBy(DBOrderByExpressionSet orderBy)
        {
            base.OrderBy(orderBy);
            return this;
        }
        #endregion

        #region group by
        public new DeleteMsSqlBuilder<T> GroupBy(params DBGroupByExpression[] groupBy)
        {
            base.GroupBy(groupBy);
            return this;
        }
        #endregion

        #region having
        public new DeleteMsSqlBuilder<T> Having(DBHavingExpression havingCondition)
        {
            base.Having(havingCondition);
            return this;
        }
        #endregion

        #region top
        public new DeleteMsSqlBuilder<T> Top(int count)
        {
            base.Top(count);
            return this;
        }
        #endregion

        #region inner join
        public new DeleteDBJoinDirective<T> InnerJoin(DBExpressionEntity joinTo)
        {
            return new DeleteDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.INNER);
        }
        #endregion

        #region left join
        public new DeleteDBJoinDirective<T> LeftJoin(DBExpressionEntity joinTo)
        {
            return new DeleteDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.LEFT);
        }
        #endregion

        #region right join
        public new DeleteDBJoinDirective<T> RightJoin(DBExpressionEntity joinTo)
        {
            return new DeleteDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.RIGHT);
        }
        #endregion

        #region full join
        public new DeleteDBJoinDirective<T> FullJoin(DBExpressionEntity joinTo)
        {
            return new DeleteDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.FULL);
        }
        #endregion
    }
}
