namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface ITypeListSkipContinuationBuilder<T, U> : ITypeListContinuationBuilder<T>, IValueContinuationExpressionBuilder<T, U>
        where U : class, IContinuationExpressionBuilder<T>
    {
        ITypeListContinuationBuilder<T, U> Limit(int limitValue);
    }
}
