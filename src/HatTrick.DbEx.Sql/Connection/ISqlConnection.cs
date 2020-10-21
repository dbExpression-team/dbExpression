using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Connection
{
    public interface ISqlConnection : IDbConnection
    {
        /**** Original ****/
        IDbConnection DbConnection { get; }
        IDbTransaction DbTransaction { get; }
        bool IsTransactional { get; }
        //bool IsTransactional { get; }
        //DbCommand CreateDbCommand();
        void EnsureOpen();
        Task EnsureOpenAsync(CancellationToken ct);
        //ISqlConnection BeginTransaction();
        //ISqlConnection BeginTransaction(IsolationLevel iso);
        void CommitTransaction();
        void RollbackTransaction();
        //void Disconnect();

        /**** IDbConnection ****/
        //string ConnectionString { get; set; }
        //int ConnectionTimeout { get; }
        //string Database { get; }
        //ConnectionState State { get; }
        //IDbTransaction BeginTransaction();
        //IDbTransaction BeginTransaction(IsolationLevel il);
        //void ChangeDatabase(string databaseName);
        //void Close();
        //IDbCommand CreateCommand();
        //void Open();
    }
}
