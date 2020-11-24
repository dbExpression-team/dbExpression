using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectValuesContinuation<TValue> : SelectValuesTermination<TValue>
#pragma warning restore IDE1006 // Naming Styles
    {
        SelectValuesContinuation<TValue> Where(AnyWhereClause where);
        SelectValuesOrderByContinuation<TValue> OrderBy(params AnyOrderByClause[] orderBy);
        SelectValuesOrderByContinuation<TValue> OrderBy(IEnumerable<AnyOrderByClause> orderBy);
        SelectValuesContinuation<TValue> GroupBy(params AnyGroupByClause[] groupBy);
        SelectValuesContinuation<TValue> GroupBy(IEnumerable<AnyGroupByClause> groupBy);
        SelectValuesContinuation<TValue> Having(AnyHavingClause having);
        JoinOn<SelectValuesContinuation<TValue>> InnerJoin(AnyEntity entity);
        JoinOnWithAlias<SelectValuesContinuation<TValue>> InnerJoin(AnySelectSubquery subquery);
        JoinOn<SelectValuesContinuation<TValue>> LeftJoin(AnyEntity entity);
        JoinOnWithAlias<SelectValuesContinuation<TValue>> LeftJoin(AnySelectSubquery subquery);
        JoinOn<SelectValuesContinuation<TValue>> RightJoin(AnyEntity entity);
        JoinOnWithAlias<SelectValuesContinuation<TValue>> RightJoin(AnySelectSubquery subquery);
        JoinOn<SelectValuesContinuation<TValue>> FullJoin(AnyEntity entity);
        JoinOnWithAlias<SelectValuesContinuation<TValue>> FullJoin(AnySelectSubquery subquery);
        JoinOn<SelectValuesContinuation<TValue>> CrossJoin(AnyEntity entity);
    }
}
