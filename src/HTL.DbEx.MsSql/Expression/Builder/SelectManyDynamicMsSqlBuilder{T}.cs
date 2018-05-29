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
    public class SelectManyDynamicMsSqlBuilder<T> : SelectMsSqlBuilder<T>
    {
        #region constructors
        public SelectManyDynamicMsSqlBuilder(string connectionStringName, DBExpressionEntity baseEntity, DBSelectExpressionSet select) : base(connectionStringName, baseEntity, ExecutionContext.GetDynamicList)
        {
            base.Expression &= select;
        }

        public SelectManyDynamicMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity, DBSelectExpressionSet select) : base(connectionStringSettings, baseEntity, ExecutionContext.GetDynamicList)
        {
            base.Expression &= select;
        }
        #endregion

        #region execute
        public IList<dynamic> Execute()
        {
            string sql = base.SkipValue.HasValue ? base.AssembleSkipTakeRestrictedQuery() : base.AssembleQuery();

            IList<dynamic> vals = base.GetDynamicList(sql);

            return vals;
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();
        }
        #endregion

        #region enlist
        public new SelectManyDynamicMsSqlBuilder<T> Enlist(SqlConnection sqlClient)
        {
            base.Enlist(sqlClient);
            return this;
        }
        #endregion

        #region select
        public new SelectManyDynamicMsSqlBuilder<T> Select(params DBSelectExpression[] selectExpressions)
        {
            base.Select(selectExpressions);
            return this;
        }
        #endregion

        #region distinct
        public new SelectManyDynamicMsSqlBuilder<T> Distinct()
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
        private new SelectManyDynamicMsSqlBuilder<T> SetFields(params DBAssignmentExpression[] assignmentExpressions)
        {
            base.SetFields(assignmentExpressions);
            return this;
        }
        #endregion

        #region set fields
        //HACK
        private new SelectManyDynamicMsSqlBuilder<T> SetFields(DBAssignmentExpressionSet assignmentExpressionSet)
        {
            base.SetFields(assignmentExpressionSet);
            return this;
        }
        #endregion

        #region where 
        public new SelectManyDynamicMsSqlBuilder<T> Where(DBFilterExpressionSet filter)
        {
            base.Where(filter);
            return this;
        }
        #endregion

        #region order by
        public new SelectManyDynamicMsSqlBuilder<T> OrderBy(DBOrderByExpressionSet orderBy)
        {
            base.OrderBy(orderBy);
            return this;
        }
        #endregion

        #region group by
        public new SelectManyDynamicMsSqlBuilder<T> GroupBy(params DBGroupByExpression[] groupBy)
        {
            base.GroupBy(groupBy);
            return this;
        }
        #endregion

        #region having
        public new SelectManyDynamicMsSqlBuilder<T> Having(DBHavingExpression havingCondition)
        {
            base.Having(havingCondition);
            return this;
        }
        #endregion

        #region top
        public new SelectManyDynamicMsSqlBuilder<T> Top(int count)
        {
            base.Top(count);
            return this;
        }
        #endregion

        #region inner join
        public new SelectManyDynamicDBJoinDirective<T> InnerJoin(DBExpressionEntity joinTo)
        {
            return new SelectManyDynamicDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.INNER);
        }
        #endregion

        #region left join
        public new SelectManyDynamicDBJoinDirective<T> LeftJoin(DBExpressionEntity joinTo)
        {
            return new SelectManyDynamicDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.LEFT);
        }
        #endregion

        #region right join
        public new SelectManyDynamicDBJoinDirective<T> RightJoin(DBExpressionEntity joinTo)
        {
            return new SelectManyDynamicDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.RIGHT);
        }
        #endregion

        #region full join
        public new SelectManyDynamicDBJoinDirective<T> FullJoin(DBExpressionEntity joinTo)
        {
            return new SelectManyDynamicDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.FULL);
        }
        #endregion
    }
}
