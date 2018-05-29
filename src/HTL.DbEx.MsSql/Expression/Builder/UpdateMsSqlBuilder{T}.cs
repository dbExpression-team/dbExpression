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
        public UpdateMsSqlBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity) : base(connectionStringName, baseEntity, ExecutionContext.Update)
        {
        }

        public UpdateMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity) : base(connectionStringSettings, baseEntity, ExecutionContext.Update)
        {
            BaseEntity = baseEntity;
        }
        #endregion

        #region execute
        public void Execute()
        {
            Validate();

            string sql = this.AssembleUpdateSql();

            base.Update(sql);
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();

            if (Expression.Assign == null)
            {
                throw new InvalidOperationException("An attempt to execute an empty/null 'Assignmnet Expression' within an 'Update' execution context failed.  'Update' requires a valid 'Assignment Expression'.");
            }
            if (Expression.OrderBy != null)
            {
                throw new InvalidOperationException("An attempt to set an 'Order Expression' within an 'Update' execution context failed.  An 'Order Expression' cannot be applied to an 'Update' execution request.");
            }
            if (Expression.GroupBy != null)
            {
                throw new InvalidOperationException("An attempt to set a 'Group By Expression' within an 'Update' execution context failed.  A 'Group By Expression' cannot be applied to an 'Update' execution request.");
            }
            if (Expression.Select != null)
            {
                throw new InvalidOperationException("An attempt to set a 'Select Expression' within an 'Update' execution context failed.  A 'Select Expression' cannot be applied to an 'Update' execution request.");
            }
            if (SkipValue.HasValue || LimitValue.HasValue)
            {
                throw new InvalidOperationException("An attempt to set a 'Skip/Take' Expression' within an 'Update' execution context failed.  A 'Skip/Take Expression' cannot be applied to an 'Update' execution request.");
            }
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

        #region enlist
        public new UpdateMsSqlBuilder<T> Enlist(SqlConnection sqlClient)
        {
            base.Enlist(sqlClient);
            return this;
        }
        #endregion

        #region select
        //HACK
        private new UpdateMsSqlBuilder<T> Select(params DBSelectExpression[] selectExpressions)
        {
            base.Select(selectExpressions);
            return this;
        }
        #endregion

        #region distinct
        //HACK
        private new UpdateMsSqlBuilder<T> Distinct()
        {
            base.Distinct();
            return this;
        }
        #endregion

        #region skip
        //HACK
        private new DBSkipDirective Skip(int count)
        {
            base.SkipValue = count;
            return new DBSkipDirective(this);
        }
        #endregion

        #region set fields
        public new UpdateMsSqlBuilder<T> SetFields(params DBAssignmentExpression[] assignmentExpressions)
        {
            base.SetFields(assignmentExpressions);
            return this;
        }
        #endregion

        #region set fields
        public new UpdateMsSqlBuilder<T> SetFields(DBAssignmentExpressionSet assignmentExpressionSet)
        {
            base.SetFields(assignmentExpressionSet);
            return this;
        }
        #endregion

        #region where 
        public new UpdateMsSqlBuilder<T> Where(DBFilterExpressionSet filter)
        {
            base.Where(filter);
            return this;
        }
        #endregion

        #region order by
        public new UpdateMsSqlBuilder<T> OrderBy(DBOrderByExpressionSet orderBy)
        {
            base.OrderBy(orderBy);
            return this;
        }
        #endregion

        #region group by
        public new UpdateMsSqlBuilder<T> GroupBy(params DBGroupByExpression[] groupBy)
        {
            base.GroupBy(groupBy);
            return this;
        }
        #endregion

        #region having
        public new UpdateMsSqlBuilder<T> Having(DBHavingExpression havingCondition)
        {
            base.Having(havingCondition);
            return this;
        }
        #endregion

        #region top
        public new UpdateMsSqlBuilder<T> Top(int count)
        {
            base.Top(count);
            return this;
        }
        #endregion

        #region inner join
        public new UpdateDBJoinDirective<T> InnerJoin(DBExpressionEntity joinTo)
        {
            return new UpdateDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.INNER);
        }
        #endregion

        #region left join
        public new UpdateDBJoinDirective<T> LeftJoin(DBExpressionEntity joinTo)
        {
            return new UpdateDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.LEFT);
        }
        #endregion

        #region right join
        public new UpdateDBJoinDirective<T> RightJoin(DBExpressionEntity joinTo)
        {
            return new UpdateDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.RIGHT);
        }
        #endregion

        #region full join
        public new UpdateDBJoinDirective<T> FullJoin(DBExpressionEntity joinTo)
        {
            return new UpdateDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.FULL);
        }
        #endregion
    }
}
