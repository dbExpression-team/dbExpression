using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface ITypeListContinuationBuilder<T> : IContinuationExpressionBuilder<T>, ITypeListTerminationBuilder<T>
    {
    }
}
