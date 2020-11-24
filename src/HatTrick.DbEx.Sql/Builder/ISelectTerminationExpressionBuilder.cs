using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder
{
    public interface ISelectTerminationExpressionBuilder :
        AnySelectSubquery,
        ITerminationExpressionBuilder
    {
    }
}
