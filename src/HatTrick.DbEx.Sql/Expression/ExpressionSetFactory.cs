namespace HatTrick.DbEx.Sql.Expression
{
    public class ExpressionSetFactory : IQueryExpressionFactory
    {
        public T CreateQueryExpression<T>() where T : QueryExpression, new() => new T();
    }
}
