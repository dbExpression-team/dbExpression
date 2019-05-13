using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IJoinExpressionBuilder<T, U> : 
        IJoinExpressionBuilder<U>
        where U : IExpressionBuilder<T>
    {
        IJoinExpressionBuilder<T, U> As(string alias);
    }

    public interface IAliasRequiredJoinExpressionBuilder<T, U>
        where U : IExpressionBuilder<T>
    {
        IJoinExpressionBuilder<T, U> As(string alias);
    }
}
