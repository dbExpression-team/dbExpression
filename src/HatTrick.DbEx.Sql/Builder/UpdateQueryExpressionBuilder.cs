using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class UpdateQueryExpressionBuilder : QueryExpressionBuilder,
        IUpdateFromExpressionBuilder
    {
        #region constructors
        protected UpdateQueryExpressionBuilder(DatabaseConfiguration configuration, UpdateQueryExpression expression) : base(configuration, expression)
        {

        }

        protected UpdateQueryExpressionBuilder(DatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression entity) : base(configuration, expression)
        {
            Expression.BaseEntity = entity;
        }
        #endregion

        IUpdateContinuationExpressionBuilder<T> IUpdateFromExpressionBuilder.From<T>(EntityExpression<T> entity)
        {
            return CreateTypedBuilder(Configuration, Expression as UpdateQueryExpression, entity);
        }

        protected abstract IUpdateContinuationExpressionBuilder<T> CreateTypedBuilder<T>(DatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<T> entity) where T : class, IDbEntity;
    }
}
