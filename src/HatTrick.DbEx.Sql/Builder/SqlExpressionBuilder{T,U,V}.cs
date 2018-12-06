using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public class SqlExpressionBuilder<T, U, V> : SqlExpressionBuilder<T, U>,
        IFromExpressionBuilder<T, U, V>,
        IListFromExpressionBuilder<T, U, V>
        where U : class, IContinuationExpressionBuilder<T>
        where V : class, IContinuationExpressionBuilder<T, U>
    {
        public SqlExpressionBuilder(ExpressionSet expression) : base(expression)
        {
        }

        IFromExpressionBuilder<T, U, V> IListFromExpressionBuilder<T, U, V>.Distinct()
        {
            Expression.Distinct = true;
            return this;
        }

        V IListFromExpressionBuilder<T, U, V>.From(EntityExpression entity)
        {
            Expression.BaseEntity = entity;
            Expression.Select = new SelectExpressionSet(entity.GetInclusiveSelectExpression());
            return this as V;
        }

        V IFromExpressionBuilder<T, U, V>.From(EntityExpression entity)
        {
            Expression.BaseEntity = entity;
            Expression.Select = new SelectExpressionSet(entity.GetInclusiveSelectExpression());
            return this as V;
        }
    }
}
