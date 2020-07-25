namespace HatTrick.DbEx.Sql.Expression
{
    public class QueryExpressionFactory : IQueryExpressionFactory
    {
        public T CreateQueryExpression<T>() where T : QueryExpression, new() => new T();
    }
}
