using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IValueListContinuationBuilder<T> : IContinuationExpressionBuilder<T>, IValueListTerminationExpressionBuilder<T>
    {
    }
}
