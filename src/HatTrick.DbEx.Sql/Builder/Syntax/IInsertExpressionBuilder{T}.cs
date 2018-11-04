using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IInsertExpressionBuilder<T> :
        IExpressionBuilder<T>,
        IContinuationExpressionBuilder<T>
        where T : class, IDbEntity
    {
        ITerminationExpressionBuilder Into<U>(U entity)
            where U : EntityExpression<T>;
    }
}
