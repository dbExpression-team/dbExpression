using HTL.DbEx.Sql.Builder.Syntax;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder
{
    public class SqlBuilder<T, U, V> : SqlBuilder<T, U>,
        IFromBuilder<T, U, V>,
        IListFromBuilder<T, U, V>
        where U : class, IContinuationBuilder<T>
        where V : class, IContinuationBuilder<T, U>
    {
        public SqlBuilder(DBExpressionSet expression) : base(expression)
        {
        }

        IFromBuilder<T, U, V> IListFromBuilder<T, U, V>.Distinct()
        {
            Expression.Distinct = true;
            return this;
        }

        V IListFromBuilder<T, U, V>.From(DBExpressionEntity entity)
        {
            Expression.BaseEntity = entity;
            if (Expression.Select == null)
                Expression &= entity.GetInclusiveSelectExpression();
            return this as V;
        }

        V IFromBuilder<T, U, V>.From(DBExpressionEntity entity)
        {
            Expression.BaseEntity = entity;
            if (Expression.Select == null)
                Expression &= entity.GetInclusiveSelectExpression();
            return this as V;
        }
    }
}
