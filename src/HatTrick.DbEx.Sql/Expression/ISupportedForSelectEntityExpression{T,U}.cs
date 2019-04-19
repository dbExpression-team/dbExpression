namespace HatTrick.DbEx.Sql.Expression
{
    public interface ISupportedForSelectEntityExpression<TEntity, TValue> : ISupportedForSelectEntityExpression<TEntity>
        where TEntity : IDbEntity
    {
    }
}
