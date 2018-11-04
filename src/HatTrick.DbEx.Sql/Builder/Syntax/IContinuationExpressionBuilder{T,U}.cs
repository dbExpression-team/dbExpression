namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IContinuationExpressionBuilder<T, U> :
        IExpressionBuilder<T>,
        IContinuationExpressionBuilder<T>
        where U : IContinuationExpressionBuilder<T>
    { }
}
