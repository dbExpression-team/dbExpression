using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlStatementExecutor
    {
        int ExecuteNonQuery(SqlStatement statement, SqlConnection connection, int? commandTimeout = null);
        Task<int> ExecuteNonQueryAsync(SqlStatement statement, SqlConnection connection, int? commandTimeout = null);
        ISqlRowReader ExecuteQuery(SqlStatement statement, SqlConnection connection, int? commandTimeout = null);
        Task<ISqlRowReader> ExecuteQueryAsync(SqlStatement statement, SqlConnection connection, int? commandTimeout = null);
    }
}
