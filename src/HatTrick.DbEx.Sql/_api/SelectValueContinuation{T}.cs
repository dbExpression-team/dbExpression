using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectValueContinuation<TValue> : SelectValueTermination<TValue>
#pragma warning restore IDE1006 // Naming Styles
    {
        SelectValueContinuation<TValue> Where(AnyWhereClause where);
        SelectValueContinuation<TValue> OrderBy(params AnyOrderByClause[] orderBy);
        SelectValueContinuation<TValue> OrderBy(IEnumerable<AnyOrderByClause> orderBy);
        SelectValueContinuation<TValue> GroupBy(params AnyGroupByClause[] groupBy);
        SelectValueContinuation<TValue> GroupBy(IEnumerable<AnyGroupByClause> groupBy);
        SelectValueContinuation<TValue> Having(AnyHavingClause having);

        JoinOn<SelectValueContinuation<TValue>> InnerJoin(AnyEntity entity);
        JoinOnWithAlias<SelectValueContinuation<TValue>> InnerJoin(AnySelectSubquery subquery);
        JoinOn<SelectValueContinuation<TValue>> LeftJoin(AnyEntity entity);
        JoinOnWithAlias<SelectValueContinuation<TValue>> LeftJoin(AnySelectSubquery subquery);
        JoinOn<SelectValueContinuation<TValue>> RightJoin(AnyEntity entity);
        JoinOnWithAlias<SelectValueContinuation<TValue>> RightJoin(AnySelectSubquery subquery);
        JoinOn<SelectValueContinuation<TValue>> FullJoin(AnyEntity entity);
        JoinOnWithAlias<SelectValueContinuation<TValue>> FullJoin(AnySelectSubquery subquery);
        JoinOn<SelectValueContinuation<TValue>> CrossJoin(AnyEntity entity);
    }
}
