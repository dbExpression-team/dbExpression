﻿using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class SelectQueryExpressionBuilder<T, U> : SelectQueryExpressionBuilder<T>,
        IValueContinuationExpressionBuilder<T, U>,
        IValueListContinuationExpressionBuilder<T, U>,
        ITypeContinuationExpressionBuilder<T, U>,
        ITypeListContinuationExpressionBuilder<T, U>,
        IValueListSkipContinuationExpressionBuilder<T, U>,
        ITypeListSkipContinuationExpressionBuilder<T, U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        #region internals
        public new SelectQueryExpression Expression => base.Expression as SelectQueryExpression;
        #endregion

        #region constructors
        protected SelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, SelectQueryExpression expression) : base(configuration, expression)
        { }
        #endregion

        #region order by
        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.OrderBy(params OrderByExpression[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.OrderBy(IEnumerable<OrderByExpression> orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        IValueContinuationExpressionBuilder<T, U> IValueContinuationExpressionBuilder<T, U>.OrderBy(params OrderByExpression[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        IValueContinuationExpressionBuilder<T, U> IValueContinuationExpressionBuilder<T, U>.OrderBy(IEnumerable<OrderByExpression> orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        ITypeListContinuationExpressionBuilder<T, U> ITypeListContinuationExpressionBuilder<T, U>.OrderBy(params OrderByExpression[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        ITypeListContinuationExpressionBuilder<T, U> ITypeListContinuationExpressionBuilder<T, U>.OrderBy(IEnumerable<OrderByExpression> orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        ITypeContinuationExpressionBuilder<T, U> ITypeContinuationExpressionBuilder<T, U>.OrderBy(params OrderByExpression[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        ITypeContinuationExpressionBuilder<T, U> ITypeContinuationExpressionBuilder<T, U>.OrderBy(IEnumerable<OrderByExpression> orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        private void OrderBy(IEnumerable<OrderByExpression> orderBy)
        {
            Expression.OrderBy = new OrderByExpressionSet(Expression.OrderBy.Expressions.Concat(orderBy));
        }
        #endregion

        #region group by
        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.GroupBy(params GroupByExpression[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.GroupBy(IEnumerable<GroupByExpression> groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        IValueContinuationExpressionBuilder<T, U> IValueContinuationExpressionBuilder<T, U>.GroupBy(params GroupByExpression[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        IValueContinuationExpressionBuilder<T, U> IValueContinuationExpressionBuilder<T, U>.GroupBy(IEnumerable<GroupByExpression> groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        ITypeListContinuationExpressionBuilder<T, U> ITypeListContinuationExpressionBuilder<T, U>.GroupBy(params GroupByExpression[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        ITypeListContinuationExpressionBuilder<T, U> ITypeListContinuationExpressionBuilder<T, U>.GroupBy(IEnumerable<GroupByExpression> groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        ITypeContinuationExpressionBuilder<T, U> ITypeContinuationExpressionBuilder<T, U>.GroupBy(params GroupByExpression[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        ITypeContinuationExpressionBuilder<T, U> ITypeContinuationExpressionBuilder<T, U>.GroupBy(IEnumerable<GroupByExpression> groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        private void GroupBy(IEnumerable<GroupByExpression> groupBy)
        {
            Expression.GroupBy = new GroupByExpressionSet(Expression.GroupBy.Expressions.Concat(groupBy));
        }
        #endregion

        #region having
        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.Having(HavingExpression having)
        {
            Having(having);
            return this;
        }

        IValueContinuationExpressionBuilder<T, U> IValueContinuationExpressionBuilder<T, U>.Having(HavingExpression having)
        {
            Having(having);
            return this;
        }

        ITypeListContinuationExpressionBuilder<T, U> ITypeListContinuationExpressionBuilder<T, U>.Having(HavingExpression having)
        {
            Having(having);
            return this;
        }

        ITypeContinuationExpressionBuilder<T, U> ITypeContinuationExpressionBuilder<T, U>.Having(HavingExpression having)
        {
            Having(having);
            return this;
        }

        private void Having(HavingExpression having)
        {
            if (having is null)
                return;

            if (Expression.Having?.Expression is null || Expression.Having.Expression == default)
            {
                Expression.Having = having;
                return;
            }
            Expression.Having &= having;
        }
        #endregion

        #region where
        IValueContinuationExpressionBuilder<T, U> IValueContinuationExpressionBuilder<T, U>.Where(FilterExpressionSet expression)
        {
            return Where<T, U>(expression) as IValueContinuationExpressionBuilder<T, U>;
        }

        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.Where(FilterExpressionSet expression)
        {
            return Where<T, U>(expression) as IValueListContinuationExpressionBuilder<T, U>;
        }

        ITypeContinuationExpressionBuilder<T, U> ITypeContinuationExpressionBuilder<T, U>.Where(FilterExpressionSet expression)
        {
            return Where<T, U>(expression) as ITypeContinuationExpressionBuilder<T, U>;
        }

        ITypeListContinuationExpressionBuilder<T, U> ITypeListContinuationExpressionBuilder<T, U>.Where(FilterExpressionSet expression)
        {
            return Where<T, U>(expression) as ITypeListContinuationExpressionBuilder<T, U>;
        }
        #endregion

        #region join
        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> IValueContinuationExpressionBuilder<T, U>.InnerJoin(EntityExpression entity)
        {
            return Join<T, IValueContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.INNER);
        }
        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> IValueContinuationExpressionBuilder<T, U>.LeftJoin(EntityExpression entity)
        {
            return Join<T, IValueContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> IValueContinuationExpressionBuilder<T, U>.RightJoin(EntityExpression entity)
        {
            return Join<T, IValueContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> IValueContinuationExpressionBuilder<T, U>.FullJoin(EntityExpression entity)
        {
            return Join<T, IValueContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.FULL);
        }

        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> IValueContinuationExpressionBuilder<T, U>.CrossJoin(EntityExpression entity)
        {
            return Join<T, IValueContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.CROSS);
        }

        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> IValueListContinuationExpressionBuilder<T, U>.InnerJoin(EntityExpression entity)
        {
            return Join<T, IValueListContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.INNER);
        }
        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> IValueListContinuationExpressionBuilder<T, U>.LeftJoin(EntityExpression entity)
        {
            return Join<T, IValueListContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> IValueListContinuationExpressionBuilder<T, U>.RightJoin(EntityExpression entity)
        {
            return Join<T, IValueListContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> IValueListContinuationExpressionBuilder<T, U>.FullJoin(EntityExpression entity)
        {
            return Join<T, IValueListContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.FULL);
        }

        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> IValueListContinuationExpressionBuilder<T, U>.CrossJoin(EntityExpression entity)
        {
            return Join<T, IValueListContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.CROSS);
        }

        IJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> ITypeContinuationExpressionBuilder<T, U>.InnerJoin(EntityExpression entity)
        {
            return Join<T, ITypeContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.INNER);
        }
        IJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> ITypeContinuationExpressionBuilder<T, U>.LeftJoin(EntityExpression entity)
        {
            return Join<T, ITypeContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> ITypeContinuationExpressionBuilder<T, U>.RightJoin(EntityExpression entity)
        {
            return Join<T, ITypeContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> ITypeContinuationExpressionBuilder<T, U>.FullJoin(EntityExpression entity)
        {
            return Join<T, ITypeContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.FULL);
        }

        IJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> ITypeContinuationExpressionBuilder<T, U>.CrossJoin(EntityExpression entity)
        {
            return Join<T, ITypeContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.CROSS);
        }

        IJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> ITypeListContinuationExpressionBuilder<T, U>.InnerJoin(EntityExpression entity)
        {
            return Join<T, ITypeListContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.INNER);
        }

        IJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> ITypeListContinuationExpressionBuilder<T, U>.LeftJoin(EntityExpression entity)
        {
            return Join<T, ITypeListContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> ITypeListContinuationExpressionBuilder<T, U>.RightJoin(EntityExpression entity)
        {
            return Join<T, ITypeListContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> ITypeListContinuationExpressionBuilder<T, U>.FullJoin(EntityExpression entity)
        {
            return Join<T, ITypeListContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.FULL);
        }

        IJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> ITypeListContinuationExpressionBuilder<T, U>.CrossJoin(EntityExpression entity)
        {
            return Join<T, ITypeListContinuationExpressionBuilder<T, U>>(entity, JoinOperationExpressionOperator.CROSS);
        }

        #region aliased join
        IAliasRequiredJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> IValueContinuationExpressionBuilder<T, U>.InnerJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.INNER);
        }

        IAliasRequiredJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> IValueContinuationExpressionBuilder<T, U>.LeftJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.LEFT);
        }

        IAliasRequiredJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> IValueContinuationExpressionBuilder<T, U>.RightJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.RIGHT);
        }

        IAliasRequiredJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> IValueContinuationExpressionBuilder<T, U>.FullJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.FULL);
        }

        IAliasRequiredJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> IValueListContinuationExpressionBuilder<T, U>.InnerJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueListContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.INNER);
        }

        IAliasRequiredJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> IValueListContinuationExpressionBuilder<T, U>.LeftJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueListContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.LEFT);
        }

        IAliasRequiredJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> IValueListContinuationExpressionBuilder<T, U>.RightJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueListContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.RIGHT);
        }

        IAliasRequiredJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> IValueListContinuationExpressionBuilder<T, U>.FullJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueListContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.FULL);
        }

        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> ITypeContinuationExpressionBuilder<T, U>.InnerJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.INNER);
        }

        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> ITypeContinuationExpressionBuilder<T, U>.LeftJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.LEFT);
        }

        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> ITypeContinuationExpressionBuilder<T, U>.RightJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.RIGHT);
        }

        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationExpressionBuilder<T, U>> ITypeContinuationExpressionBuilder<T, U>.FullJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.FULL);
        }

        IAliasRequiredJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> ITypeListContinuationExpressionBuilder<T, U>.InnerJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeListContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.INNER);
        }

        IAliasRequiredJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> ITypeListContinuationExpressionBuilder<T, U>.LeftJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeListContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.LEFT);
        }

        IAliasRequiredJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> ITypeListContinuationExpressionBuilder<T, U>.RightJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeListContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.RIGHT);
        }

        IAliasRequiredJoinExpressionBuilder<T, ITypeListContinuationExpressionBuilder<T, U>> ITypeListContinuationExpressionBuilder<T, U>.FullJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeListContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.FULL);
        }
        #endregion
        #endregion

        #region skip/limit
        IValueListSkipContinuationExpressionBuilder<T,U> IValueListContinuationExpressionBuilder<T, U>.Skip(int skipValue)
        {
            Skip(skipValue);
            return this;
        }

        ITypeListSkipContinuationExpressionBuilder<T, U> ITypeListContinuationExpressionBuilder<T, U>.Skip(int skipValue)
        {
            Skip(skipValue);
            return this;
        }

        private void Skip(int skipValue)
        {
            Expression.SkipValue = skipValue;
        }

        IValueListContinuationExpressionBuilder<T, U> IValueListSkipContinuationExpressionBuilder<T, U>.Limit(int limitValue)
        {
            Limit(limitValue);
            return this;
        }

        ITypeListContinuationExpressionBuilder<T, U> ITypeListSkipContinuationExpressionBuilder<T, U>.Limit(int limitValue)
        {
            Limit(limitValue);
            return this;
        }

        private void Limit(int limitValue)
        {
            Expression.LimitValue = limitValue;
        }
        #endregion
    }
}
