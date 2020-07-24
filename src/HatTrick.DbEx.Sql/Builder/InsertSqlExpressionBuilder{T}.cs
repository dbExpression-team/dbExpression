using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class InsertSqlExpressionBuilder<T> : SqlExpressionBuilder<T>, 
        IInsertExpressionBuilder<T>,
        IInsertTerminationExpressionBuilder
        where T : class, IDbEntity
    {
        private InsertQueryExpression insert => Expression as InsertQueryExpression;

        protected InsertSqlExpressionBuilder(DatabaseConfiguration configuration, InsertQueryExpression expression) : base(configuration, expression)
        {

        }

        IInsertTerminationExpressionBuilder IInsertExpressionBuilder<T>.Into<U>(U entity)
        {
            insert.BaseEntity = entity;
            insert.Insert = (entity as IDbExpressionEntity<T>).BuildInclusiveInsertExpression((T)insert.Instance);
            return this;
        }
    }
}
