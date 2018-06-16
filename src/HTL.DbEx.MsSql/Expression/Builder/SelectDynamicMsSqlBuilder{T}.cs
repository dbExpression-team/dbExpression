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
    public class SelectDynamicMsSqlBuilder<T> : SelectMsSqlBuilder<T>
    {
        #region constructors
        public SelectDynamicMsSqlBuilder(string connectionStringName, DBExpressionEntity baseEntity, DBSelectExpressionSet select) : base(connectionStringName, baseEntity, ExecutionContext.GetDynamic)
        {
            base.Expression &= select;
        }

        public SelectDynamicMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity baseEntity, DBSelectExpressionSet select) : base(connectionStringSettings, baseEntity, ExecutionContext.GetDynamic)
        {
            base.Expression &= select;
        }
        #endregion

        #region execute
        public dynamic Execute()
        {
            string sql = base.AssembleQuery();

            var val = base.GetDynamic(sql);

            return val;
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();           
        }
        #endregion

        #region enlist
        public new SelectDynamicMsSqlBuilder<T> Enlist(SqlConnection sqlClient)
        {
            base.Enlist(sqlClient);
            return this;
        }
        #endregion

        #region select
        public new SelectDynamicMsSqlBuilder<T> Select(params DBSelectExpression[] selectExpressions)
        {
            base.Select(selectExpressions);
            return this;
        }
        #endregion

        #region distinct
        public new SelectDynamicMsSqlBuilder<T> Distinct()
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
        //HACK
        private new SelectDynamicMsSqlBuilder<T> SetFields(params DBAssignmentExpression[] assignmentExpressions)
        {
            base.SetFields(assignmentExpressions);
            return this;
        }
        #endregion

        #region set fields
        //HACK
        private new SelectDynamicMsSqlBuilder<T> SetFields(DBAssignmentExpressionSet assignmentExpressionSet)
        {
            base.SetFields(assignmentExpressionSet);
            return this;
        }
        #endregion

        #region where 
        public new SelectDynamicMsSqlBuilder<T> Where(DBFilterExpressionSet filter)
        {
            base.Where(filter);
            return this;
        }
        #endregion

        #region order by
        public new SelectDynamicMsSqlBuilder<T> OrderBy(DBOrderByExpressionSet orderBy)
        {
            base.OrderBy(orderBy);
            return this;
        }
        #endregion

        #region group by
        public new SelectDynamicMsSqlBuilder<T> GroupBy(params DBGroupByExpression[] groupBy)
        {
            base.GroupBy(groupBy);
            return this;
        }
        #endregion

        #region having
        public new SelectDynamicMsSqlBuilder<T> Having(DBHavingExpression havingCondition)
        {
            base.Having(havingCondition);
            return this;
        }
        #endregion

        #region top
        public new SelectDynamicMsSqlBuilder<T> Top(int count)
        {
            base.Top(count);
            return this;
        }
        #endregion

        #region inner join
        public new SelectDynamicDBJoinDirective<T> InnerJoin(DBExpressionEntity joinTo)
        {
            return new SelectDynamicDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.INNER);
        }
        #endregion

        #region left join
        public new SelectDynamicDBJoinDirective<T> LeftJoin(DBExpressionEntity joinTo)
        {
            return new SelectDynamicDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.LEFT);
        }
        #endregion

        #region right join
        public new SelectDynamicDBJoinDirective<T> RightJoin(DBExpressionEntity joinTo)
        {
            return new SelectDynamicDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.RIGHT);
        }
        #endregion

        #region full join
        public new SelectDynamicDBJoinDirective<T> FullJoin(DBExpressionEntity joinTo)
        {
            return new SelectDynamicDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.FULL);
        }
        #endregion
    }
}
