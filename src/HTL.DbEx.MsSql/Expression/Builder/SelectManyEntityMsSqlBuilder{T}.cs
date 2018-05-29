using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using HTL.DbEx.Sql.Expression;
using HTL.DbEx.Sql;

namespace HTL.DbEx.MsSql.Expression
{
    public class SelectManyEntityMsSqlBuilder<T> : SelectMsSqlBuilder<T> where T : class, IDBEntity, new()
    {
        #region private
        private DBExpressionEntity<T> _typedEntity;
        #endregion

        #region constructors
        public SelectManyEntityMsSqlBuilder(string connectionStringName, DBExpressionEntity<T> baseEntity) : base(connectionStringName, baseEntity, ExecutionContext.GetList)
        {
            _typedEntity = baseEntity;
            base.Expression &= baseEntity.GetInclusiveSelectExpression();
        }

        public SelectManyEntityMsSqlBuilder(ConnectionStringSettings connectionStringSettings, DBExpressionEntity<T> baseEntity) : base(connectionStringSettings, baseEntity, ExecutionContext.GetList)
        {
            _typedEntity = baseEntity;
            base.Expression &= baseEntity.GetInclusiveSelectExpression();
        }
        #endregion

        #region execute
        public  IList<T> Execute()
        {
            Validate();

            string sql = base.SkipValue.HasValue ? base.AssembleSkipTakeRestrictedQuery() : base.AssembleQuery();

            IList<T> lst = base.GetList<T>(sql, _typedEntity.FillObject);

            return lst;
        }
        #endregion

        #region validate
        protected override void Validate()
        {
            base.Validate();
        }
        #endregion

        #region enlist
        public new SelectManyEntityMsSqlBuilder<T> Enlist(SqlConnection sqlClient)
        {
            base.Enlist(sqlClient);
            return this;
        }
        #endregion

        #region select
        public new SelectManyEntityMsSqlBuilder<T> Select(params DBSelectExpression[] selectExpressions)
        {
            base.Select(selectExpressions);
            return this;
        }
        #endregion

        #region distinct
        public new SelectManyEntityMsSqlBuilder<T> Distinct()
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
        private new SelectManyEntityMsSqlBuilder<T> SetFields(params DBAssignmentExpression[] assignmentExpressions)
        {
            base.SetFields(assignmentExpressions);
            return this;
        }
        #endregion

        #region set fields
        //HACK
        private new SelectManyEntityMsSqlBuilder<T> SetFields(DBAssignmentExpressionSet assignmentExpressionSet)
        {
            base.SetFields(assignmentExpressionSet);
            return this;
        }
        #endregion

        #region where 
        public new SelectManyEntityMsSqlBuilder<T> Where(DBFilterExpressionSet filter)
        {
            base.Where(filter);
            return this;
        }
        #endregion

        #region order by
        public new SelectManyEntityMsSqlBuilder<T> OrderBy(DBOrderByExpressionSet orderBy)
        {
            base.OrderBy(orderBy);
            return this;
        }
        #endregion

        #region group by
        public new SelectManyEntityMsSqlBuilder<T> GroupBy(params DBGroupByExpression[] groupBy)
        {
            base.GroupBy(groupBy);
            return this;
        }
        #endregion

        #region having
        public new SelectManyEntityMsSqlBuilder<T> Having(DBHavingExpression havingCondition)
        {
            base.Having(havingCondition);
            return this;
        }
        #endregion

        #region top
        public new SelectManyEntityMsSqlBuilder<T> Top(int count)
        {
            base.Top(count);
            return this;
        }
        #endregion

        #region inner join
        public new SelectManyEntityDBJoinDirective<T> InnerJoin(DBExpressionEntity joinTo)
        {
            return new SelectManyEntityDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.INNER);
        }
        #endregion

        #region left join
        public new SelectManyEntityDBJoinDirective<T> LeftJoin(DBExpressionEntity joinTo)
        {
            return new SelectManyEntityDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.LEFT);
        }
        #endregion

        #region right join
        public new SelectManyEntityDBJoinDirective<T> RightJoin(DBExpressionEntity joinTo)
        {
            return new SelectManyEntityDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.RIGHT);
        }
        #endregion

        #region full join
        public new SelectManyEntityDBJoinDirective<T> FullJoin(DBExpressionEntity joinTo)
        {
            return new SelectManyEntityDBJoinDirective<T>(this, joinTo, DBExpressionJoinType.FULL);
        }
        #endregion
    }
}
