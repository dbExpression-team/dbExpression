using HTL.DbEx.Sql.Builder.Syntax;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder
{
    public class SqlBuilder<T, U> : SqlBuilder<T>,
        IValueContinuationBuilder<T, U>,
        IValueListContinuationBuilder<T, U>,
        ITypeContinuationBuilder<T, U>,
        ITypeListContinuationBuilder<T, U>,
        IValueListSkipContinuationBuilder<T, U>,
        ITypeListSkipContinuationBuilder<T, U>
        where U : class, IContinuationBuilder<T>
    {
        #region constructors
        public SqlBuilder(DBExpressionSet expression) : base(expression)
        { }
        #endregion

        #region distinct
        private void Distinct()
        {
            Expression.Distinct = true;
        }
        #endregion

        #region order by
        IValueListContinuationBuilder<T, U> IValueListContinuationBuilder<T, U>.OrderBy(DBOrderByExpressionSet orderBy)
        {
            OrderBy(orderBy);
            return this;
        }
        IValueListContinuationBuilder<T, U> IValueListContinuationBuilder<T, U>.OrderBy(params DBOrderByExpression[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        ITypeListContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.OrderBy(DBOrderByExpressionSet orderBy)
        {
            OrderBy(orderBy);
            return this;
        }
        ITypeListContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.OrderBy(params DBOrderByExpression[] orderBy)
        {
            OrderBy(orderBy);
            return this;
        }

        private void OrderBy(DBOrderByExpressionSet orderBy)
        {
            Expression.OrderBy &= orderBy;
        }

        private void OrderBy(params DBOrderByExpression[] orderBy)
        {
            foreach (var o in orderBy)
                Expression.OrderBy &= o;
        }
        #endregion

        #region group by
        IValueListContinuationBuilder<T, U> IValueListContinuationBuilder<T, U>.GroupBy(params DBGroupByExpression[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        ITypeListContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.GroupBy(params DBGroupByExpression[] groupBy)
        {
            GroupBy(groupBy);
            return this;
        }

        private void GroupBy(params DBGroupByExpression[] groupBy)
        {
            foreach (var grouping in groupBy)
                Expression.GroupBy &= grouping;
        }
        #endregion

        #region having
        IValueListContinuationBuilder<T, U> IValueListContinuationBuilder<T, U>.Having(DBHavingExpression having)
        {
            Having(having);
            return this;
        }

        ITypeListContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.Having(DBHavingExpression having)
        {
            Having(having);
            return this;
        }

        private void Having(DBHavingExpression having)
        {
            Expression.Having &= having;
        }
        #endregion

        #region top
        IValueListContinuationBuilder<T, U> IValueListContinuationBuilder<T, U>.Top(int count)
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
        IValueContinuationBuilder<T, U> IValueContinuationBuilder<T, U>.Where(DBWhereExpression expression)
        {
            return Where<T, U>(expression) as IValueContinuationBuilder<T, U>;
        }

        IValueContinuationBuilder<T, U> IValueContinuationBuilder<T, U>.Where(DBWhereExpressionSet expression)
        {
            return Where<T, U>(expression) as IValueContinuationBuilder<T, U>;
        }

        IValueListContinuationBuilder<T, U> IValueListContinuationBuilder<T, U>.Where(DBWhereExpression expression)
        {
            return Where<T, U>(expression) as IValueListContinuationBuilder<T, U>;
        }

        IValueListContinuationBuilder<T, U> IValueListContinuationBuilder<T, U>.Where(DBWhereExpressionSet expression)
        {
            return Where<T, U>(expression) as IValueListContinuationBuilder<T, U>;
        }

        ITypeContinuationBuilder<T, U> ITypeContinuationBuilder<T, U>.Where(DBWhereExpression expression)
        {
            return Where<T, U>(expression) as ITypeContinuationBuilder<T, U>;
        }

        ITypeContinuationBuilder<T, U> ITypeContinuationBuilder<T, U>.Where(DBWhereExpressionSet expression)
        {
            return Where<T, U>(expression) as ITypeContinuationBuilder<T, U>;
        }

        ITypeListContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.Where(DBWhereExpression expression)
        {
            return Where<T, U>(expression) as ITypeListContinuationBuilder<T, U>;
        }

        ITypeListContinuationBuilder<T, U> ITypeListContinuationBuilder<T, U>.Where(DBWhereExpressionSet expression)
        {
            return Where<T, U>(expression) as ITypeListContinuationBuilder<T, U>;
        }
        #endregion

        #region join
        IJoinBuilder<T, IValueContinuationBuilder<T, U>> IValueContinuationBuilder<T, U>.InnerJoin(DBExpressionEntity entity)
        {
            return Join<T, IValueContinuationBuilder<T, U>>(entity, DBExpressionJoinType.INNER);
        }
        IJoinBuilder<T, IValueContinuationBuilder<T, U>> IValueContinuationBuilder<T, U>.LeftJoin(DBExpressionEntity entity)
        {
            return Join<T, IValueContinuationBuilder<T, U>>(entity, DBExpressionJoinType.LEFT);
        }

        IJoinBuilder<T, IValueContinuationBuilder<T, U>> IValueContinuationBuilder<T, U>.RightJoin(DBExpressionEntity entity)
        {
            return Join<T, IValueContinuationBuilder<T, U>>(entity, DBExpressionJoinType.RIGHT);
        }

        IJoinBuilder<T, IValueContinuationBuilder<T, U>> IValueContinuationBuilder<T, U>.FullJoin(DBExpressionEntity entity)
        {
            return Join<T, IValueContinuationBuilder<T, U>>(entity, DBExpressionJoinType.FULL);
        }

        IJoinBuilder<T, IValueContinuationBuilder<T, U>> IValueContinuationBuilder<T, U>.CrossJoin(DBExpressionEntity entity)
        {
            return Join<T, IValueContinuationBuilder<T, U>>(entity, DBExpressionJoinType.CROSS);
        }

        IJoinBuilder<T, IValueListContinuationBuilder<T, U>> IValueListContinuationBuilder<T, U>.InnerJoin(DBExpressionEntity entity)
        {
            return Join<T, IValueListContinuationBuilder<T, U>>(entity, DBExpressionJoinType.INNER);
        }
        IJoinBuilder<T, IValueListContinuationBuilder<T, U>> IValueListContinuationBuilder<T, U>.LeftJoin(DBExpressionEntity entity)
        {
            return Join<T, IValueListContinuationBuilder<T, U>>(entity, DBExpressionJoinType.LEFT);
        }

        IJoinBuilder<T, IValueListContinuationBuilder<T, U>> IValueListContinuationBuilder<T, U>.RightJoin(DBExpressionEntity entity)
        {
            return Join<T, IValueListContinuationBuilder<T, U>>(entity, DBExpressionJoinType.RIGHT);
        }

        IJoinBuilder<T, IValueListContinuationBuilder<T, U>> IValueListContinuationBuilder<T, U>.FullJoin(DBExpressionEntity entity)
        {
            return Join<T, IValueListContinuationBuilder<T, U>>(entity, DBExpressionJoinType.FULL);
        }

        IJoinBuilder<T, IValueListContinuationBuilder<T, U>> IValueListContinuationBuilder<T, U>.CrossJoin(DBExpressionEntity entity)
        {
            return Join<T, IValueListContinuationBuilder<T, U>>(entity, DBExpressionJoinType.CROSS);
        }

        IJoinBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.InnerJoin(DBExpressionEntity entity)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(entity, DBExpressionJoinType.INNER);
        }
        IJoinBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.LeftJoin(DBExpressionEntity entity)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(entity, DBExpressionJoinType.LEFT);
        }

        IJoinBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.RightJoin(DBExpressionEntity entity)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(entity, DBExpressionJoinType.RIGHT);
        }

        IJoinBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.FullJoin(DBExpressionEntity entity)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(entity, DBExpressionJoinType.FULL);
        }

        IJoinBuilder<T, ITypeContinuationBuilder<T, U>> ITypeContinuationBuilder<T, U>.CrossJoin(DBExpressionEntity entity)
        {
            return Join<T, ITypeContinuationBuilder<T, U>>(entity, DBExpressionJoinType.CROSS);
        }

        IJoinBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.InnerJoin(DBExpressionEntity entity)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(entity, DBExpressionJoinType.INNER);
        }

        IJoinBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.LeftJoin(DBExpressionEntity entity)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(entity, DBExpressionJoinType.LEFT);
        }

        IJoinBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.RightJoin(DBExpressionEntity entity)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(entity, DBExpressionJoinType.RIGHT);
        }

        IJoinBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.FullJoin(DBExpressionEntity entity)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(entity, DBExpressionJoinType.FULL);
        }

        IJoinBuilder<T, ITypeListContinuationBuilder<T, U>> ITypeListContinuationBuilder<T, U>.CrossJoin(DBExpressionEntity entity)
        {
            return Join<T, ITypeListContinuationBuilder<T, U>>(entity, DBExpressionJoinType.CROSS);
        }
        #endregion

        #region skip/limit
        IValueListSkipContinuationBuilder<T,U> IValueListContinuationBuilder<T, U>.Skip(int skipValue)
        {
            Skip(skipValue);
            return this as IValueListSkipContinuationBuilder<T, U>;
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

        IValueListContinuationBuilder<T, U> IValueListSkipContinuationBuilder<T, U>.Limit(int limitValue)
        {
            Limit(limitValue);
            return this as IValueListContinuationBuilder<T, U>;
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
