namespace HatTrick.DbEx.Sql.Expression
{
    public interface IQueryExpressionFactory
    {
        T CreateQueryExpression<T>() where T : QueryExpression, new();
    }
}
