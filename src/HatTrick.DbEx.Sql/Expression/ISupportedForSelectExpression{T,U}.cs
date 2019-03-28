namespace HatTrick.DbEx.Sql.Expression
{
    public interface ISupportedForSelectExpression<TEntity, TValue> : ISupportedForSelectExpression<TEntity>
        where TEntity : IDbEntity
    {
    }
}
