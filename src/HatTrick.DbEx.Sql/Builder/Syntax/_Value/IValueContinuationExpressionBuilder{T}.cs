namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IValueContinuationExpressionBuilder<T> :
        IExpressionBuilder<T>,
        IContinuationExpressionBuilder<T>, 
        IValueTerminationExpressionBuilder<T>,
        ISubqueryTerminationExpressionBuilder
    {
    }
}
