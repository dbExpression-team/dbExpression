using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface ITypeListContinuationBuilder<T> : IContinuationBuilder<T>, ITypeListTerminationBuilder<T>
    {
    }
}
