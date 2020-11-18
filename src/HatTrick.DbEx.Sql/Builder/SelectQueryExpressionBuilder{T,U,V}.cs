using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class SelectQueryExpressionBuilder<T, U, V> : SelectQueryExpressionBuilder<T, U>,
        IFromExpressionBuilder<T, U, V>,
        IListFromExpressionBuilder<T, U, V>
        where U : class, IContinuationExpressionBuilder<T>
        where V : class, IContinuationExpressionBuilder<T, U>
    {
        public SelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, SelectQueryExpression expression) : base(configuration, expression)
        {
        }

        IListFromExpressionBuilder<T, U, V> IListFromExpressionBuilder<T, U, V>.Distinct()
        {
            Expression.Select.Distinct(true);
            return this;
        }

        IListFromExpressionBuilder<T, U, V> IListFromExpressionBuilder<T, U, V>.Top(int count)
        {
            Expression.Select.Top(count);
            return this;
        }

        V IListFromExpressionBuilder<T, U, V>.From(EntityExpression entity)
        {
            Expression.BaseEntity = entity;
            SelectExpressionSet select = Expression.Select;
            if (select is null || !select.Expressions.Any())
            {
                Expression.Select = new SelectExpressionSet((entity as IExpressionEntity<T>).BuildInclusiveSelectExpression())
                    .Distinct((select as IExpressionIsDistinctProvider).IsDistinct)
                    .Top((select as IExpressionTopProvider).Top);
            }
            return this as V;
        }

        V IFromExpressionBuilder<T, U, V>.From<W>(EntityExpression<W> entity)
        {
            Expression.BaseEntity = entity;
            SelectExpressionSet select = Expression.Select;
            if (select is null || !select.Expressions.Any())
            {
                Expression.Select = new SelectExpressionSet((entity as IExpressionEntity<W>).BuildInclusiveSelectExpression())
                    .Distinct((select as IExpressionIsDistinctProvider).IsDistinct)
                    .Top((select as IExpressionTopProvider).Top);
            }
            return this as V;
        }
    }
}
