using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IJoinExpressionBuilder<T>
        where T : IExpressionBuilder
    {
        T On(JoinOnExpressionSet expression);
    }
}
