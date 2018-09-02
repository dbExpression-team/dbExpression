using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlStatementExecutorFactory
    {
        void RegisterExecutor<T>(ExecutionContext executionContect)
            where T : class, ISqlStatementExecutor, new();

        void RegisterExecutor(ExecutionContext executionContect, ISqlStatementExecutor executor);

        ISqlStatementExecutor CreateSqlStatementExecutor(ExpressionSet expression);
    }
}
