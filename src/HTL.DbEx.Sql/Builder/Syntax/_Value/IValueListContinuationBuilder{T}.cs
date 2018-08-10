using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IValueListContinuationBuilder<T> : IContinuationBuilder<T>, IValueListTerminationBuilder<T>
    {
    }
}
