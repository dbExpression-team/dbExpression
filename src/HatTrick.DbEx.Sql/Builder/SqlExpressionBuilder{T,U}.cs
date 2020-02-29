using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SqlExpressionBuilder<T, U> : SqlExpressionBuilder<T>,
        IValueContinuationExpressionBuilder<T, U>,
        IValueListContinuationExpressionBuilder<T, U>,
        ITypeContinuationBuilder<T, U>,
        ITypeListContinuationExpressionBuilder<T, U>,
        IValueListSkipContinuationExpressionBuilder<T, U>,
        ITypeListSkipContinuationExpressionBuilder<T, U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        #region constructors
        public SqlExpressionBuilder(ExpressionSet expression) : base(expression)
        { }
        #endregion

        #region order by
        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.OrderBy(params OrderByExpression[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        IValueContinuationExpressionBuilder<T, U> IValueContinuationExpressionBuilder<T, U>.OrderBy(params OrderByExpression[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        ITypeListContinuationExpressionBuilder<T, U> ITypeListContinuationExpressionBuilder<T, U>.OrderBy(params OrderByExpression[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        private void OrderBy(params OrderByExpression[] orderBy)
        {
            foreach (var o in orderBy)
                Expression.OrderBy.Expressions.Add(o);
        }
        #endregion

        #region group by
        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.GroupBy(params GroupByExpression[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        IValueContinuationExpressionBuilder<T, U> IValueContinuationExpressionBuilder<T, U>.GroupBy(params GroupByExpression[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        ITypeListContinuationExpressionBuilder<T, U> ITypeListContinuationExpressionBuilder<T, U>.GroupBy(params GroupByExpression[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        private void GroupBy(params GroupByExpression[] groupBy)
        {
            foreach (var grouping in groupBy)
                Expression.GroupBy.Expressions.Add(grouping);
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

        private void Having(HavingExpression having)
        {
            if (Expression.Having?.Expression == null || Expression.Having.Expression == default)
            {
                Expression.Having = having;
                return;
            }
            Expression.Having &= having;
        }
        #endregion

        #region where
        IValueContinuationExpressionBuilder<T, U> IValueContinuationExpressionBuilder<T, U>.Where(FilterExpression expression)
        {
            return Where<T, U>(expression) as IValueContinuationExpressionBuilder<T, U>;
        }

        IValueContinuationExpressionBuilder<T, U> IValueContinuationExpressionBuilder<T, U>.Where(FilterExpressionSet expression)
        {
            return Where<T, U>(expression) as IValueContinuationExpressionBuilder<T, U>;
        }

        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.Where(FilterExpression expression)
        {
            return Where<T, U>(expression) as IValueListContinuationExpressionBuilder<T, U>;
        }

        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.Where(FilterExpressionSet expression)
        {
            return Where<T, U>(expression) as IValueListContinuationExpressionBuilder<T, U>;
        }

        ITypeContinuationBuilder<T, U> ITypeContinuationBuilder<T, U>.Where(FilterExpression expression)
        {
            return Where<T, U>(expression) as ITypeContinuationBuilder<T, U>;
        }

        ITypeContinuationBuilder<T, U> ITypeContinuationBuilder<T, U>.Where(FilterExpressionSet expression)
        {
            return Where<T, U>(expression) as ITypeContinuationBuilder<T, U>;
        }

        ITypeListContinuationExpressionBuilder<T, U> ITypeListContinuationExpressionBuilder<T, U>.Where(FilterExpression expression)
        {
            return Where<T, U>(expression) as ITypeListContinuationExpressionBuilder<T, U>;
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

        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.InnerJoin(EntityExpression entity)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(entity, JoinOperationExpressionOperator.INNER);
        }
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.LeftJoin(EntityExpression entity)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(entity, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.RightJoin(EntityExpression entity)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(entity, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.FullJoin(EntityExpression entity)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(entity, JoinOperationExpressionOperator.FULL);
        }

        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.CrossJoin(EntityExpression entity)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(entity, JoinOperationExpressionOperator.CROSS);
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

        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.InnerJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(subquery, JoinOperationExpressionOperator.INNER);
        }

        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.LeftJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(subquery, JoinOperationExpressionOperator.LEFT);
        }

        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.RightJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(subquery, JoinOperationExpressionOperator.RIGHT);
        }

        IAliasRequiredJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.FullJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(subquery, JoinOperationExpressionOperator.FULL);
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
            return this as IValueListSkipContinuationExpressionBuilder<T, U>;
        }

        ITypeListSkipContinuationExpressionBuilder<T, U> ITypeListContinuationExpressionBuilder<T, U>.Skip(int skipValue)
        {
            Skip(skipValue);
            return this as ITypeListSkipContinuationExpressionBuilder<T, U>;
        }

        private void Skip(int skipValue)
        {
            Expression.SkipValue = skipValue;
        }

        IValueListContinuationExpressionBuilder<T, U> IValueListSkipContinuationExpressionBuilder<T, U>.Limit(int limitValue)
        {
            Limit(limitValue);
            return this as IValueListContinuationExpressionBuilder<T, U>;
        }

        ITypeListContinuationExpressionBuilder<T, U> ITypeListSkipContinuationExpressionBuilder<T, U>.Limit(int limitValue)
        {
            Limit(limitValue);
            return this as ITypeListContinuationExpressionBuilder<T, U>;
        }

        private void Limit(int limitValue)
        {
            Expression.LimitValue = limitValue;
        }
        #endregion
    }
}
