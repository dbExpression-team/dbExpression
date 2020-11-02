namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface ITypeContinuationExpressionBuilder<T> : 
        IContinuationExpressionBuilder<T>, 
        ITypeTerminationExpressionBuilder<T>,
        ISubqueryTerminationExpressionBuilder
    {
    }
}
