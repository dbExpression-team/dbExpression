using System.Collections.Generic;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Builder
{
    public interface IBatchTerminationBuilder
    {
        IDictionary<int, object?> Execute();
        Task<IDictionary<int, object?>> ExecuteAsync();
    }
}
