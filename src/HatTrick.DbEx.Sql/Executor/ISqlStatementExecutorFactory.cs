using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlStatementExecutorFactory
    {
        void RegisterExecutor<T>(SqlStatementExecutionType executionContect)
            where T : class, ISqlStatementExecutor, new();

        void RegisterExecutor(SqlStatementExecutionType executionContect, ISqlStatementExecutor executor);

        ISqlStatementExecutor CreateSqlStatementExecutor(ExpressionSet expression);
    }
}
