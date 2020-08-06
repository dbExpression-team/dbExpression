namespace HatTrick.DbEx.Sql.Expression
{
    public interface IQueryExpressionProvider<T> : IQueryExpressionProvider
        where T : QueryExpression
    {
        new T Expression { get; }
    }
}
