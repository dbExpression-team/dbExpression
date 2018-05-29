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
    public class SelectEntityMsSqlBuilder<T> : SelectMsSqlBuilder<T> where T :  class, IDBEntity, new()
    {
        #region private
        private DBExpressionEntity<T> _typedEntity;
        #endregion

        #region constructors
        public SelectEntityMsSqlBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity) : base(connectionStringName, baseEntity, ExecutionContext.Get)
        {
            _typedEntity = baseEntity;
            base.Expression &= baseEntity.GetInclusiveSelectExpression();
        }

        public SelectEntityMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity) : base(connectionStringSettings, baseEntity, ExecutionContext.Get)
        {
            _typedEntity = baseEntity;
            base.Expression &= baseEntity.GetInclusiveSelectExpression();
        }
        #endregion

        #region execute
        public T Execute()
        {
            Validate();

            string sql = base.SkipValue.HasValue ? base.AssembleSkipTakeRestrictedQuery() : base.AssembleQuery();

            T obj = base.Get<T>(sql, _typedEntity.FillObject);

            return obj;
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();
        }
        #endregion

        #region enlist
        public new SelectEntityMsSqlBuilder<T> Enlist(SqlConnection sqlClient)
        {
            base.Enlist(sqlClient);
            return this;
        }
        #endregion

        #region select
        public new SelectEntityMsSqlBuilder<T> Select(params DBSelectExpression[] selectExpressions)
        {
            base.Select(selectExpressions);
            return this;
        }
        #endregion

        #region distinct
        public new SelectEntityMsSqlBuilder<T> Distinct()
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
        private new SelectEntityMsSqlBuilder<T> SetFields(params DBAssignmentExpression[] assignmentExpressions)
        {
            base.SetFields(assignmentExpressions);
            return this;
        }
        #endregion

        #region set fields
        //HACK
        private new SelectEntityMsSqlBuilder<T> SetFields(DBAssignmentExpressionSet assignmentExpressionSet)
        {
            base.SetFields(assignmentExpressionSet);
            return this;
        }
        #endregion

        #region where 
        public new SelectEntityMsSqlBuilder<T> Where(DBFilterExpressionSet filter)
        {
            base.Where(filter);
            return this;
        }
        #endregion

        #region order by
        public new SelectEntityMsSqlBuilder<T> OrderBy(DBOrderByExpressionSet orderBy)
        {
            base.OrderBy(orderBy);
            return this;
        }
        #endregion

        #region group by
        public new SelectEntityMsSqlBuilder<T> GroupBy(params DBGroupByExpression[] groupBy)
        {
            base.GroupBy(groupBy);
            return this;
        }
        #endregion

        #region having
        public new SelectEntityMsSqlBuilder<T> Having(DBHavingExpression havingCondition)
        {
            base.Having(havingCondition);
            return this;
        }
        #endregion

        #region top
        public new SelectEntityMsSqlBuilder<T> Top(int count)
        {
            base.Top(count);
            return this;
        }
        #endregion

        #region inner join
        //HACK
        private new DBJoinDirective InnerJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective(this, joinTo, DBExpressionJoinType.INNER);
        }
        #endregion

        #region left join
        //HACK
        private new DBJoinDirective LeftJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective(this, joinTo, DBExpressionJoinType.LEFT);
        }
        #endregion

        #region right join
        //HACK
        private new DBJoinDirective RightJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective(this, joinTo, DBExpressionJoinType.RIGHT);
        }
        #endregion

        #region full join
        //Hack
        private new DBJoinDirective FullJoin(DBExpressionEntity joinTo)
        {
            return new DBJoinDirective(this, joinTo, DBExpressionJoinType.FULL);
        }
        #endregion

        #region inner join
        public SelectEntityDBJoinDirective<T> InnerJoin(DBExpressionEntity<T> joinTo)
        {
            return new SelectEntityDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.INNER);
        }
        #endregion

        #region left join
        public SelectEntityDBJoinDirective<T> LeftJoin(DBExpressionEntity<T> joinTo)
        {
            return new SelectEntityDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.LEFT);
        }
        #endregion

        #region right join
        public SelectEntityDBJoinDirective<T> RightJoin(DBExpressionEntity<T> joinTo)
        {
            return new SelectEntityDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.RIGHT);
        }
        #endregion

        #region full join
        public SelectEntityDBJoinDirective<T> FullJoin(DBExpressionEntity<T> joinTo)
        {
            return new SelectEntityDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.FULL);
        }
        #endregion
    }
}
