using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SqlExpressionBuilder<T, U> : SqlExpressionBuilder<T>,
        IValueContinuationExpressionBuilder<T, U>,
        IValueListContinuationExpressionBuilder<T, U>,
        ITypeContinuationBuilder<T, U>,
        ITypeListContinuationBuilder<T, U>,
        IValueListSkipContinuationExpressionBuilder<T, U>,
        ITypeListSkipContinuationBuilder<T, U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        #region constructors
        public SqlExpressionBuilder(ExpressionSet expression) : base(expression)
        { }
        #endregion

        #region distinct
        private void Distinct()
        {
            Expression.Distinct = true;
        }
        #endregion

        #region order by
        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.OrderBy(OrderByExpressionSet orderBy)
        {
            OrderBy(orderBy);
            return this;
        }
        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.OrderBy(params OrderByExpression[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        ITypeListContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.OrderBy(OrderByExpressionSet orderBy)
        {
            OrderBy(orderBy);
            return this;
        }
        ITypeListContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.OrderBy(params OrderByExpression[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        private void OrderBy(OrderByExpressionSet orderBy)
        {
            Expression.OrderBy &= orderBy;
        }

        private void OrderBy(params OrderByExpression[] orderBy)
        {
            foreach (var o in orderBy)
                Expression.OrderBy &= o;
        }
        #endregion

        #region group by
        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.GroupBy(params GroupByExpression[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        ITypeListContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.GroupBy(params GroupByExpression[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        private void GroupBy(params GroupByExpression[] groupBy)
        {
            foreach (var grouping in groupBy)
                Expression.GroupBy &= grouping;
        }
        #endregion

        #region having
        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.Having(HavingExpression having)
        {
            Having(having);
            return this;
        }

        ITypeListContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.Having(HavingExpression having)
        {
            Having(having);
            return this;
        }

        private void Having(HavingExpression having)
        {
            Expression.Having &= having;
        }
        #endregion

        #region top
        IValueListContinuationExpressionBuilder<T, U> IValueListContinuationExpressionBuilder<T, U>.Top(int count)
        {
            Top(count);
            return this;
        }

        ITypeListContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.Top(int count)
        {
            Top(count);
            return this;
        }

        private void Top(int count)
        {
            Expression.Top = count;
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

        ITypeListContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.Where(FilterExpression expression)
        {
            return Where<T, U>(expression) as ITypeListContinuationBuilder<T, U>;
        }

        ITypeListContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.Where(FilterExpressionSet expression)
        {
            return Where<T, U>(expression) as ITypeListContinuationBuilder<T, U>;
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

        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.InnerJoin(EntityExpression entity)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(entity, JoinOperationExpressionOperator.INNER);
        }

        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.LeftJoin(EntityExpression entity)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(entity, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.RightJoin(EntityExpression entity)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(entity, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.FullJoin(EntityExpression entity)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(entity, JoinOperationExpressionOperator.FULL);
        }

        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.CrossJoin(EntityExpression entity)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(entity, JoinOperationExpressionOperator.CROSS);
        }

        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> IValueContinuationExpressionBuilder<T, U>.InnerJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.INNER);
        }
        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> IValueContinuationExpressionBuilder<T, U>.LeftJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> IValueContinuationExpressionBuilder<T, U>.RightJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<T, IValueContinuationExpressionBuilder<T, U>> IValueContinuationExpressionBuilder<T, U>.FullJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.FULL);
        }

        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> IValueListContinuationExpressionBuilder<T, U>.InnerJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueListContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.INNER);
        }
        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> IValueListContinuationExpressionBuilder<T, U>.LeftJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueListContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> IValueListContinuationExpressionBuilder<T, U>.RightJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueListContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<T, IValueListContinuationExpressionBuilder<T, U>> IValueListContinuationExpressionBuilder<T, U>.FullJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, IValueListContinuationExpressionBuilder<T, U>>(subquery, JoinOperationExpressionOperator.FULL);
        }

        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.InnerJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(subquery, JoinOperationExpressionOperator.INNER);
        }
        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.LeftJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(subquery, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.RightJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(subquery, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.FullJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(subquery, JoinOperationExpressionOperator.FULL);
        }

        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.InnerJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(subquery, JoinOperationExpressionOperator.INNER);
        }

        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.LeftJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(subquery, JoinOperationExpressionOperator.LEFT);
        }

        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.RightJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(subquery, JoinOperationExpressionOperator.RIGHT);
        }

        IJoinExpressionBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.FullJoin(ISubqueryTerminationExpressionBuilder subquery)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(subquery, JoinOperationExpressionOperator.FULL);
        }
        #endregion

        #region skip/limit
        IValueListSkipContinuationExpressionBuilder<T,U> IValueListContinuationExpressionBuilder<T, U>.Skip(int skipValue)
        {
            Skip(skipValue);
            return this as IValueListSkipContinuationExpressionBuilder<T, U>;
        }

        ITypeListSkipContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.Skip(int skipValue)
        {
            Skip(skipValue);
            return this as ITypeListSkipContinuationBuilder<T, U>;
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

        ITypeListContinuationBuilder<T, U> ITypeListSkipContinuationBuilder<T, U>.Limit(int limitValue)
        {
            Limit(limitValue);
            return this as ITypeListContinuationBuilder<T, U>;
        }

        private void Limit(int limitValue)
        {
            Expression.LimitValue = limitValue;
        }
        #endregion
    }
}
