using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectValuesOrderByContinuation<TValue>
#pragma warning restore IDE1006 // Naming Styles
        : SelectValuesTermination<TValue>
    {
        SelectValuesSkipContinuation<TValue> Skip(int value);
        SelectValuesOrderByContinuation<TValue> GroupBy(params AnyGroupByClause[] groupBy);
        SelectValuesOrderByContinuation<TValue> GroupBy(IEnumerable<AnyGroupByClause> groupBy);
        SelectValuesOrderByContinuation<TValue> Having(AnyHavingClause having);
    }
}
