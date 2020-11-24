namespace HatTrick.DbEx.Sql.Builder
{
    public interface IInsertTerminationExpressionBuilder<TEntity> : ITerminationExpressionBuilder
        where TEntity : class, IDbEntity
    {
    }
}
