using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IValueListContinuationExpressionBuilder<T> :
        IExpressionBuilder<T>,
        IContinuationExpressionBuilder<T>, 
        IValueListTerminationExpressionBuilder<T>,
        ISubqueryTerminationExpressionBuilder
    {
    }
}
