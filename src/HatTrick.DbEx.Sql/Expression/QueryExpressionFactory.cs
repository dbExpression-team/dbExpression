namespace HatTrick.DbEx.Sql.Expression
{
    public class QueryExpressionFactory : IQueryExpressionFactory
    {
        public virtual T CreateQueryExpression<T>() where T : QueryExpression, new() => new T();
    }
}
