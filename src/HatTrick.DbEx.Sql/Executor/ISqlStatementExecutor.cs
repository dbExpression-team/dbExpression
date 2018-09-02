namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlStatementExecutor
    {
        int ExecuteNonQuery(SqlStatement statement, SqlConnection connection, int? commandTimeout = null);
        SqlStatementExecutionResultSet ExecuteQuery(SqlStatement statement, SqlConnection connection, int? commandTimeout = null);
    }
}
