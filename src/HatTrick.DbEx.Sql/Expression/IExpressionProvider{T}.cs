namespace HatTrick.DbEx.Sql.Expression
{
    public interface IExpressionProvider<T>
        where T : IExpression
    {
        T Expression { get; }
    }
}
