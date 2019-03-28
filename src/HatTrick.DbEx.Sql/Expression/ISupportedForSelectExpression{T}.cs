namespace HatTrick.DbEx.Sql.Expression
{
    public interface ISupportedForSelectExpression<TEntity> : ISupportedForSelectExpression
        where TEntity : IDbEntity
    {
    }
}
