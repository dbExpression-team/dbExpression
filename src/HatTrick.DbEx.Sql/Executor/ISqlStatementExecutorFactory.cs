using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlStatementExecutorFactory
    {
        void RegisterExecutor<T>(SqlStatementExecutionType executionContext)
            where T : class, ISqlStatementExecutor, new();

        void RegisterExecutor(SqlStatementExecutionType executionContext, ISqlStatementExecutor executor);

        ISqlStatementExecutor CreateSqlStatementExecutor(ExpressionSet expression);
    }
}
