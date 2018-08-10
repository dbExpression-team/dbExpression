namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface ITypeListSkipContinuationBuilder<T, U> : ITypeListContinuationBuilder<T>, IValueContinuationBuilder<T, U>
        where U : class, IContinuationBuilder<T>
    {
        ITypeListContinuationBuilder<T, U> Limit(int limitValue);
    }
}
