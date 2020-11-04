using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class UpdateQueryExpressionBuilder : QueryExpressionBuilder,
        IUpdateFromExpressionBuilder
    {
        #region interface
        public new UpdateQueryExpression Expression => base.Expression as UpdateQueryExpression;
        #endregion

        #region constructors
        protected UpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression) : base(configuration, expression)
        {

        }

        protected UpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression entity) : base(configuration, expression)
        {
            Expression.BaseEntity = entity;
        }
        #endregion

        #region methods
        IUpdateContinuationExpressionBuilder<T> IUpdateFromExpressionBuilder.From<T>(EntityExpression<T> entity)
        {
            return CreateTypedBuilder(Configuration, Expression, entity);
        }

        protected abstract IUpdateContinuationExpressionBuilder<T> CreateTypedBuilder<T>(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<T> entity) 
            where T : class, IDbEntity;
        #endregion
    }
}
