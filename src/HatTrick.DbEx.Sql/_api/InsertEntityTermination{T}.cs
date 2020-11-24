using HatTrick.DbEx.Sql.Builder;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface InsertEntityTermination<TEntity> : IInsertTerminationExpressionBuilder<TEntity>
#pragma warning restore IDE1006 // Naming Styles
        where TEntity : class, IDbEntity
    {
    }
}
