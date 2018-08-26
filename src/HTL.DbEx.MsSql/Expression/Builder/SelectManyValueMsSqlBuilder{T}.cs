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
    public class SelectManyValueMsSqlBuilder<T> : SelectMsSqlBuilder<T>
    {
        #region private
        private DBExpressionEntity<T> _typedEntity;
        #endregion

        #region constructors
        public SelectManyValueMsSqlBuilder(string connectionStringName, DBExpressionEntity baseEntity, DBSelectExpression select) : base(connectionStringName, baseEntity, ExecutionContext.GetValueList)
        {
            base.Expression &= select;
        }

        public SelectManyValueMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity, DBSelectExpression select) : base(connectionStringSettings, baseEntity, ExecutionContext.GetValueList)
        {
            base.Expression &= select;
        }
        #endregion

        #region execute
        public IList<T> Execute()
        {
            Validate();

            string sql = base.SkipValue.HasValue ? base.AssembleSkipTakeRestrictedQuery() : base.AssembleQuery();

            IList<T> lst = base.GetValueList<T>(sql);

            return lst;
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();

            //if (SkipValue.HasValue && LimitValue.Value > 1)
            //{
            //    throw new InvalidOperationException("An attempt to execute a Skip/Take expression within a 'GetValue' execution context failed.  'GetValue' returns only a single value and the Take declaration was > 1.");
            //}
            //if (Expression.Select != null)
            //{
            //    throw new InvalidOperationException("An attempt to set a 'Select Expression' within a 'GetValue' execution context failed.  'GetValue' returns a single value that represents the field specified in parameter 'field' and does not allow a consumer to specify specific fields for selection.");
            //}
        }
        #endregion

        #region enlist
        public new SelectManyValueMsSqlBuilder<T> Enlist(SqlConnection sqlClient)
        {
            base.Enlist(sqlClient);
            return this;
        }
        #endregion

        #region select
        public new SelectManyValueMsSqlBuilder<T> Select(params DBSelectExpression[] selectExpressions)
        {
            base.Select(selectExpressions);
            return this;
        }
        #endregion

        #region distinct
        public new SelectManyValueMsSqlBuilder<T> Distinct()
        {
            base.Distinct();
            return this;
        }
        #endregion

        #region skip
        //public new DBSkipDirective Skip(int count)
        //{
        //    base.SkipValue = count;
        //    return new DBSkipDirective(this);
        //}

        public new SelectManyValueDBSkipDirective<T> Skip(int count)
        {
            base.SkipValue = count;
            return new SelectManyValueDBSkipDirective<T>(this);
        }
        #endregion

        #region set fields
        //HACK
        private new SelectManyValueMsSqlBuilder<T> SetFields(params DBAssignmentExpression[] assignmentExpressions)
        {
            base.SetFields(assignmentExpressions);
            return this;
        }
        #endregion

        #region set fields
        //HACK
        private new SelectManyValueMsSqlBuilder<T> SetFields(DBAssignmentExpressionSet assignmentExpressionSet)
        {
            base.SetFields(assignmentExpressionSet);
            return this;
        }
        #endregion

        #region where 
        public new SelectManyValueMsSqlBuilder<T> Where(DBFilterExpressionSet filter)
        {
            base.Where(filter);
            return this;
        }
        #endregion

        #region order by
        public new SelectManyValueMsSqlBuilder<T> OrderBy(DBOrderByExpressionSet orderBy)
        {
            base.OrderBy(orderBy);
            return this;
        }
        #endregion

        #region group by
        public new SelectManyValueMsSqlBuilder<T> GroupBy(params DBGroupByExpression[] groupBy)
        {
            base.GroupBy(groupBy);
            return this;
        }
        #endregion

        #region having
        public new SelectManyValueMsSqlBuilder<T> Having(DBHavingExpression havingCondition)
        {
            base.Having(havingCondition);
            return this;
        }
        #endregion

        #region top
        public new SelectManyValueMsSqlBuilder<T> Top(int count)
        {
            base.Top(count);
            return this;
        }
        #endregion

        #region inner join
        public new SelectManyValueDBJoinDirective<T> InnerJoin(DBExpressionEntity joinTo)
        {
            return new SelectManyValueDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.INNER);
        }
        #endregion

        #region left join
        public new SelectManyValueDBJoinDirective<T> LeftJoin(DBExpressionEntity joinTo)
        {
            return new SelectManyValueDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.LEFT);
        }
        #endregion

        #region right join
        public new SelectManyValueDBJoinDirective<T> RightJoin(DBExpressionEntity joinTo)
        {
            return new SelectManyValueDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.RIGHT);
        }
        #endregion

        #region full join
        public new SelectManyValueDBJoinDirective<T> FullJoin(DBExpressionEntity joinTo)
        {
            return new SelectManyValueDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.FULL);
        }
        #endregion
    }
}
