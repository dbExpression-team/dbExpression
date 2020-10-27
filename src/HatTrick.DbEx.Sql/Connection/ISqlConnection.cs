using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Connection
{
    public interface ISqlConnection : IDbConnection
    {
        IDbConnection DbConnection { get; }
        IDbTransaction DbTransaction { get; }
        bool IsTransactional { get; }
        void EnsureOpen();
        Task EnsureOpenAsync(CancellationToken ct);
        void CommitTransaction();
        void RollbackTransaction();
    }
}
