using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class DeleteQueryExpressionBuilder : QueryExpressionBuilder,
        DeleteEntities
    {
        protected DeleteQueryExpression Expression { get; private set; }

        protected DeleteQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, DeleteQueryExpression expression)
            : base(config, expression)
        {
            Expression = expression;
        }

        protected DeleteQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, DeleteQueryExpression expression, EntityExpression entity)
            : base(config, expression)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            Expression.BaseEntity = entity ?? throw new ArgumentNullException(nameof(entity));
        }



        DeleteEntitiesContinuation<TEntity> DeleteEntities.From<TEntity>(Entity<TEntity> entity)
            => CreateTypedBuilder(Configuration, Expression, entity as EntityExpression<TEntity> ?? throw new DbExpressionException($"Expected {nameof(entity)} to be of type {nameof(EntityExpression)}."));

        DeleteEntities DeleteEntities.Top(int value)
        {
            Expression.Top = value;
            return this;
        }

        protected abstract DeleteEntitiesContinuation<TEntity> CreateTypedBuilder<TEntity>(RuntimeSqlDatabaseConfiguration configuration, DeleteQueryExpression expression, EntityExpression<TEntity> entity) 
            where TEntity : class, IDbEntity;

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
    }
}
