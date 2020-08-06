using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class DeleteSqlExpressionBuilder : SqlExpressionBuilder,
        IDeleteFromExpressionBuilder
    {
        #region constructors
        protected DeleteSqlExpressionBuilder(DatabaseConfiguration configuration, DeleteQueryExpression expression) : base(configuration, expression)
        {
        }

        protected DeleteSqlExpressionBuilder(DatabaseConfiguration configuration, DeleteQueryExpression expression, EntityExpression entity) : base(configuration, expression)
        {
            Expression.BaseEntity = entity;
        }
        #endregion

        IDeleteContinuationExpressionBuilder<T> IDeleteFromExpressionBuilder.From<T>(EntityExpression<T> entity)
        {
            return CreateTypedBuilder(Configuration, Expression as DeleteQueryExpression, entity);
        }

        protected abstract IDeleteContinuationExpressionBuilder<T> CreateTypedBuilder<T>(DatabaseConfiguration configuration, DeleteQueryExpression expression, EntityExpression<T> entity) where T : class, IDbEntity;
    }
}
