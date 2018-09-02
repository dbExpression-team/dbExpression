namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IContinuationExpressionBuilder<T, U> : IContinuationExpressionBuilder<T>
        where U : IContinuationExpressionBuilder<T>
    { }
}
