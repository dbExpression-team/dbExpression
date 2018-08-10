namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IValueListSkipContinuationBuilder<T, U> : IValueListContinuationBuilder<T>, IValueContinuationBuilder<T, U>
        where U : class, IContinuationBuilder<T>
    {
        IValueListContinuationBuilder<T, U> Limit(int limitValue);
    }
}
