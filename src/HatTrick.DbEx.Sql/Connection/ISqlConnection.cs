using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Connection
{
    public interface ISqlConnection
    {
        DbConnection DbConnection { get; }
        DbTransaction DbTransaction { get; }
        bool IsTransactional { get; }
        DbCommand CreateDbCommand();
        void EnsureOpenConnection();
        Task EnsureOpenConnectionAsync();
        ISqlConnection BeginTransaction();
        ISqlConnection BeginTransaction(IsolationLevel iso);
        void CommitTransaction();
        void RollbackTransaction();
        void Disconnect();
    }
}
