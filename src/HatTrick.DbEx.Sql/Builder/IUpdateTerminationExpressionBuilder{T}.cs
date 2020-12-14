namespace HatTrick.DbEx.Sql.Builder
{
    public interface IUpdateTerminationExpressionBuilder<TEntity> : ITerminationExpressionBuilder
        where TEntity : class, IDbEntity
    {
    }
}
