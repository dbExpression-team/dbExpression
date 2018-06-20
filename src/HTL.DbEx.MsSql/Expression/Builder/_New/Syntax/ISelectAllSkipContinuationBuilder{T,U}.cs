using HTL.DbEx.MsSql.Expression._New;

namespace HTL.DbEx.MsSql.Expression._New
{
    public interface ISelectAllSkipContinuationBuilder<T, U> : ISelectAllContinuationBuilder<T>, ISelectContinuationBuilder<T, U>
        where U : class, IContinuationBuilder<T>
    {
        ISelectAllContinuationBuilder<T, U> Limit(int limitValue);
    }
}
