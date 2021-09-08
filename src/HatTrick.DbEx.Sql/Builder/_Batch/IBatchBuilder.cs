using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Builder
{
    public interface IBatchBuilder
    {
        IBatchContinuationBuilder Add(params INonQueryTerminationExpressionBuilder[] expressions);
        IBatchContinuationBuilder Add(IList<INonQueryTerminationExpressionBuilder> expressions);
        IBatchContinuationBuilder Add(IEnumerable<INonQueryTerminationExpressionBuilder> expressions);
    }
}
