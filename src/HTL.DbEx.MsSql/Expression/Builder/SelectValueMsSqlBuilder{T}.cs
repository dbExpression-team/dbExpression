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
    public class SelectValueMsSqlBuilder<T> : SelectMsSqlBuilder<T>
    {
        #region internals
        #endregion

        #region constructors
        public SelectValueMsSqlBuilder(string connectionStringName, DBExpressionEntity baseEntity) 
             : base(connectionStringName, baseEntity, ExecutionContext.GetValue)
        {
        }

        public SelectValueMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity) 
             : base(connectionStringSettings, baseEntity, ExecutionContext.GetValue)
        {
            BaseEntity = baseEntity;
        }
        #endregion

        #region execute
        public T Execute()
        {
            Validate();

            string sql = base.SkipValue.HasValue ? base.AssembleSkipTakeRestrictedQuery() : base.AssembleQuery();

            T obj = base.GetValue<T>(sql);

            return obj;
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();

            if (SkipValue.HasValue && LimitValue.Value > 1)
            {
                throw new InvalidOperationException("An attempt to execute a Skip/Take expression within a 'GetValue' execution context failed.  'GetValue' returns only a single value and the Limit declaration was > 1.");
            }
        }
        #endregion

        #region enlist
        public new SelectValueMsSqlBuilder<T> Enlist(SqlConnection sqlClient)
        {
            base.Enlist(sqlClient);
            return this;
        }
        #endregion

        #region select
        public new SelectValueMsSqlBuilder<T> Select(params DBSelectExpression[] selectExpressions)
        {
            base.Select(selectExpressions);
            return this;
        }
        #endregion

        #region distinct
        public new SelectValueMsSqlBuilder<T> Distinct()
        {
            base.Distinct();
            return this;
        }
        #endregion

        #region skip
        public new DBSkipDirective Skip(int count)
        {
            base.SkipValue = count;
            return new DBSkipDirective(this);
        }
        #endregion

        #region set fields
        //HACK
        private new SelectValueMsSqlBuilder<T> SetFields(params DBAssignmentExpression[] assignmentExpressions)
        {
            base.SetFields(assignmentExpressions);
            return this;
        }
        #endregion

        #region set fields
        //HACK
        private new SelectValueMsSqlBuilder<T> SetFields(DBAssignmentExpressionSet assignmentExpressionSet)
        {
            base.SetFields(assignmentExpressionSet);
            return this;
        }
        #endregion

        #region where 
        public new SelectValueMsSqlBuilder<T> Where(DBFilterExpressionSet filter)
        {
            base.Where(filter);
            return this;
        }
        #endregion

        #region order by
        public new SelectValueMsSqlBuilder<T> OrderBy(DBOrderByExpressionSet orderBy)
        {
            base.OrderBy(orderBy);
            return this;
        }
        #endregion

        #region group by
        public new SelectValueMsSqlBuilder<T> GroupBy(params DBGroupByExpression[] groupBy)
        {
            base.GroupBy(groupBy);
            return this;
        }
        #endregion

        #region having
        public new SelectValueMsSqlBuilder<T> Having(DBHavingExpression havingCondition)
        {
            base.Having(havingCondition);
            return this;
        }
        #endregion

        #region top
        public new SelectValueMsSqlBuilder<T> Top(int count)
        {
            base.Top(count);
            return this;
        }
        #endregion

        #region inner join
        public new SelectValueDBJoinDirective<T> InnerJoin(DBExpressionEntity joinTo)
        {
            return new SelectValueDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.INNER);
        }
        #endregion

        #region left join
        public new SelectValueDBJoinDirective<T> LeftJoin(DBExpressionEntity joinTo)
        {
            return new SelectValueDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.LEFT);
        }
        #endregion

        #region right join
        public new SelectValueDBJoinDirective<T> RightJoin(DBExpressionEntity joinTo)
        {
            return new SelectValueDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.RIGHT);
        }
        #endregion

        #region full join
        public new SelectValueDBJoinDirective<T> FullJoin(DBExpressionEntity joinTo)
        {
            return new SelectValueDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.FULL);
        }
        #endregion
    }
}
