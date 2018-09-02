using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SqlInsertExpressionBuilder<T> : SqlExpressionBuilder<T>, 
        IInsertExpressionBuilder<T>,
        ITerminationExpressionBuilder, 
        IExpressionBuilder<T>
        where T : class, IDbEntity
    {
        public SqlInsertExpressionBuilder(ExpressionSet expression) : base(expression)
        {
        }

        ITerminationExpressionBuilder IInsertExpressionBuilder<T>.Into<U>(U entity)
        {
            Expression.BaseEntity = entity;
            Expression &= entity.GetInclusiveInsertExpression((T)Expression.Instance);
            return this;
        }
    }
}
