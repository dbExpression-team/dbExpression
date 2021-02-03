using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class SelectQueryExpressionBuilder : QueryExpressionBuilder
    {
        #region internals
        protected SelectQueryExpression Expression { get; private set; }
        #endregion

        #region constructors
        protected SelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, SelectQueryExpression expression)
            : base(config, expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        protected virtual void From<T>(Entity<T> entity)
            where T : class, IDbEntity
        {
            if (!(entity is EntityExpression e))
                throw new DbExpressionException($"Expected {nameof(entity)} to be of type {nameof(EntityExpression)}.");          
            Expression.BaseEntity = e;
        }

        protected void Top(int value)
        {
            Expression.Top = value;
        }

        protected void Distinct()
        {
            Expression.Distinct = true;
        }


        protected void Where(AnyWhereClause expression)
        {
            if (expression is null)
                return;

            if (!(expression is FilterExpressionSet set))
                throw new DbExpressionException($"Expected {nameof(expression)} to be of type {nameof(FilterExpressionSet)}.");

            if (Expression.Where is null || Expression.Where.IsEmpty)
                Expression.Where = set;
            else
                Expression.Where &= set;
        }

        protected void OrderBy(IEnumerable<AnyOrderByClause> orderBy)
        {
            if (orderBy is null || !orderBy.Any())
                return;

            Expression.OrderBy &= new OrderByExpressionSet(orderBy);
        }

        protected void GroupBy(IEnumerable<AnyGroupByClause> groupBy)
        {
            if (groupBy is null || !groupBy.Any())
                return;

            Expression.GroupBy &= new GroupByExpressionSet(groupBy);
        }

        protected void Having(AnyHavingClause having)
        {
            if (having is null)
                return;

            if (!(having is FilterExpressionSet set))
                throw new DbExpressionException($"Expected {nameof(having)} to be of type {nameof(FilterExpressionSet)}.");

            Expression.Having &= new HavingExpression(set);
        }

        protected void Skip(int value)
            => Expression.Skip = value;

        protected void Limit(int value)
            => Expression.Limit = value;
        #endregion
    }
}
