using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public class SqlBuilder<T, U> : SqlBuilder<T>,
        ISelectContinuationBuilder<T, U>,
        ISelectAllContinuationBuilder<T, U>,
        ISelectAllSkipContinuationBuilder<T, U>
        where U : class, IContinuationBuilder<T>
    {
        #region constructors
        public SqlBuilder(DBExpressionSet expression) : base(expression)
        { }
        #endregion

        #region distinct
        ISelectAllContinuationBuilder<T, U> ISelectAllContinuationBuilder<T, U>.Distinct()
        {
            Expression.Distinct = true;
            return this;
        }
        #endregion

        #region order by
        ISelectAllContinuationBuilder<T, U> ISelectAllContinuationBuilder<T, U>.OrderBy(DBOrderByExpressionSet orderBy)
        {
            Expression.OrderBy &= orderBy;
            return this;
        }
        #endregion

        #region group by
        ISelectAllContinuationBuilder<T, U> ISelectAllContinuationBuilder<T, U>.GroupBy(params DBGroupByExpression[] groupBy)
        {
            foreach (var grouping in groupBy)
                Expression.GroupBy &= grouping;
            return this;
        }
        #endregion

        #region having
        ISelectAllContinuationBuilder<T, U> ISelectAllContinuationBuilder<T, U>.Having(DBHavingExpression havingCondition)
        {
            Expression.Having &= havingCondition;
            return this;
        }
        #endregion

        #region top
        ISelectAllContinuationBuilder<T, U> ISelectAllContinuationBuilder<T, U>.Top(int count)
        {
            Expression.Top = count;
            return this;
        }
        #endregion

        #region where
        ISelectContinuationBuilder<T, U> ISelectContinuationBuilder<T, U>.Where(DBFilterExpression expression)
        {
            return Where<T, U>(expression) as ISelectContinuationBuilder<T, U>;
        }
        ISelectAllContinuationBuilder<T, U> ISelectAllContinuationBuilder<T, U>.Where(DBFilterExpression expression)
        {
            return Where<T, U>(expression) as ISelectAllContinuationBuilder<T, U>;
        }
        #endregion

        #region join
        IJoinBuilder<T, ISelectContinuationBuilder<T, U>> ISelectContinuationBuilder<T, U>.InnerJoin(DBExpressionEntity entity)
        {
            return Join<T, ISelectContinuationBuilder<T, U>>(entity, DBExpressionJoinType.INNER);
        }
        IJoinBuilder<T, ISelectContinuationBuilder<T, U>> ISelectContinuationBuilder<T, U>.LeftJoin(DBExpressionEntity entity)
        {
            return Join<T, ISelectContinuationBuilder<T, U>>(entity, DBExpressionJoinType.LEFT);
        }

        IJoinBuilder<T, ISelectContinuationBuilder<T, U>> ISelectContinuationBuilder<T, U>.RightJoin(DBExpressionEntity entity)
        {
            return Join<T, ISelectContinuationBuilder<T, U>>(entity, DBExpressionJoinType.RIGHT);
        }

        IJoinBuilder<T, ISelectContinuationBuilder<T, U>> ISelectContinuationBuilder<T, U>.FullJoin(DBExpressionEntity entity)
        {
            return Join<T, ISelectContinuationBuilder<T, U>>(entity, DBExpressionJoinType.FULL);
        }

        IJoinBuilder<T, ISelectContinuationBuilder<T, U>> ISelectContinuationBuilder<T, U>.CrossJoin(DBExpressionEntity entity)
        {
            return Join<T, ISelectContinuationBuilder<T, U>>(entity, DBExpressionJoinType.CROSS);
        }

        IJoinBuilder<T, ISelectAllContinuationBuilder<T, U>> ISelectAllContinuationBuilder<T, U>.InnerJoin(DBExpressionEntity entity)
        {
            return Join<T, ISelectAllContinuationBuilder<T, U>>(entity, DBExpressionJoinType.INNER);
        }
        IJoinBuilder<T, ISelectAllContinuationBuilder<T, U>> ISelectAllContinuationBuilder<T, U>.LeftJoin(DBExpressionEntity entity)
        {
            return Join<T, ISelectAllContinuationBuilder<T, U>>(entity, DBExpressionJoinType.LEFT);
        }

        IJoinBuilder<T, ISelectAllContinuationBuilder<T, U>> ISelectAllContinuationBuilder<T, U>.RightJoin(DBExpressionEntity entity)
        {
            return Join<T, ISelectAllContinuationBuilder<T, U>>(entity, DBExpressionJoinType.RIGHT);
        }

        IJoinBuilder<T, ISelectAllContinuationBuilder<T, U>> ISelectAllContinuationBuilder<T, U>.FullJoin(DBExpressionEntity entity)
        {
            return Join<T, ISelectAllContinuationBuilder<T, U>>(entity, DBExpressionJoinType.FULL);
        }

        IJoinBuilder<T, ISelectAllContinuationBuilder<T, U>> ISelectAllContinuationBuilder<T, U>.CrossJoin(DBExpressionEntity entity)
        {
            return Join<T, ISelectAllContinuationBuilder<T, U>>(entity, DBExpressionJoinType.CROSS);
        }

        ISelectAllSkipContinuationBuilder<T,U> ISelectAllContinuationBuilder<T, U>.Skip(int skipValue)
        {
            Expression.SkipValue = skipValue;
            return this as ISelectAllSkipContinuationBuilder<T, U>;
        }

        ISelectAllContinuationBuilder<T, U> ISelectAllSkipContinuationBuilder<T, U>.Limit(int limitValue)
        {
            Expression.LimitValue = limitValue;
            return this as ISelectAllContinuationBuilder<T, U>;
        }
        #endregion
    }
}
