using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IJoinExpressionBuilder<T, U> : 
        IJoinExpressionBuilder<U>
        where U : IExpressionBuilder<T>
    {
    }
}
