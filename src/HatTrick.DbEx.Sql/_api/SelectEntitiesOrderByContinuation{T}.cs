using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectEntitiesOrderByContinuation<TEntity>
#pragma warning restore IDE1006 // Naming Styles
        : SelectEntitiesTermination<TEntity>
        where TEntity : class, IDbEntity
    {
        SelectEntitiesSkipContinuation<TEntity> Skip(int value);
        SelectEntitiesOrderByContinuation<TEntity> GroupBy(params AnyGroupByClause[] groupBy);
        SelectEntitiesOrderByContinuation<TEntity> GroupBy(IEnumerable<AnyGroupByClause> groupBy);
        SelectEntitiesOrderByContinuation<TEntity> Having(AnyHavingClause having);
    }
}
