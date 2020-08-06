using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IDeleteFromExpressionBuilder : 
        IExpressionBuilder
    {
        IDeleteContinuationExpressionBuilder<T> From<T>(EntityExpression<T> entity)
            where T : class, IDbEntity;
    }
}
