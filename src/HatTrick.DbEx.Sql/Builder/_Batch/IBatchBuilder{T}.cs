using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Builder
{
    public interface IBatchBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        IBatchContinuationBuilder<TDatabase> Add(params INonQueryTerminationExpressionBuilder<TDatabase>[] expressions);
        IBatchContinuationBuilder<TDatabase> Add(IList<INonQueryTerminationExpressionBuilder<TDatabase>> expressions);
        IBatchContinuationBuilder<TDatabase> Add(IEnumerable<INonQueryTerminationExpressionBuilder<TDatabase>> expressions);
    }
}
