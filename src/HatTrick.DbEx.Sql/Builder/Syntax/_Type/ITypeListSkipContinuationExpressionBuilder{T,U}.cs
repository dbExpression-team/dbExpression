namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface ITypeListSkipContinuationExpressionBuilder<T, U> : ITypeListContinuationExpressionBuilder<T>, IValueContinuationExpressionBuilder<T, U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        ITypeListContinuationExpressionBuilder<T, U> Limit(int limitValue);
    }
}
