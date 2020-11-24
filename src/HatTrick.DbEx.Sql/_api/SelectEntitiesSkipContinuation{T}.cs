namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectEntitiesSkipContinuation<TEntity> :
#pragma warning restore IDE1006 // Naming Styles
        Limit<SelectEntitiesOrderByContinuation<TEntity>>,
        SelectEntitiesTermination<TEntity>
        where TEntity : class, IDbEntity
    {
    }
}
