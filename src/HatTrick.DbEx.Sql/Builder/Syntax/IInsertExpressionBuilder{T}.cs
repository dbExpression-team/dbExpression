using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IInsertExpressionBuilder<T> :
        IExpressionBuilder<T>,
        IContinuationExpressionBuilder<T>
        where T : class, IDbEntity
    {
        IInsertTerminationExpressionBuilder<T> Into<U>(U entity)
            where U : EntityExpression<T>;
    }
}
