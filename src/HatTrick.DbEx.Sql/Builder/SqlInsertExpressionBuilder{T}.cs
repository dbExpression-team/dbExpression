using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SqlInsertExpressionBuilder<T> : SqlExpressionBuilder<T>, 
        IInsertExpressionBuilder<T>,
        IInsertTerminationExpressionBuilder
        where T : class, IDbEntity
    {
        public SqlInsertExpressionBuilder(DatabaseConfiguration configuration, ExpressionSet expression) : base(configuration, expression)
        {
        }

        IInsertTerminationExpressionBuilder IInsertExpressionBuilder<T>.Into<U>(U entity)
        {
            Expression.BaseEntity = entity;
            Expression.Insert = (entity as IDbExpressionEntity<T>).BuildInclusiveInsertExpression((T)Expression.Instance);
            return this;
        }
    }
}
