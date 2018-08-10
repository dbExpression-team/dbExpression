using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Executor
{
    public interface ISqlExecutorFactory
    {
        void RegisterExecutor<T>(ExecutionContext executionContect)
            where T : class, ISqlExecutor, new();

        void RegisterExecutor(ExecutionContext executionContect, ISqlExecutor executor);

        ISqlExecutor CreateSqlStatementExecutor(DBExpressionSet expression);
    }
}
