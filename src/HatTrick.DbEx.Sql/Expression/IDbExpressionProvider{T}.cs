namespace HatTrick.DbEx.Sql.Expression
{
    public interface IDbExpressionProvider<T>
        where T : IDbExpression
    {
        T Expression { get; }
    }
}
