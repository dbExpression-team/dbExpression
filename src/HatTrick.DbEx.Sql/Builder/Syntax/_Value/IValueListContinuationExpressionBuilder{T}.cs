using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IValueListContinuationExpressionBuilder<T> : 
        IContinuationExpressionBuilder<T>, 
        IValueListTerminationExpressionBuilder<T>,
        ISubqueryTerminationExpressionBuilder
    {
    }
}
