using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlStatementExecutorFactory
    {
        void RegisterExecutor<T>(SqlStatementExecutionType executionContext)
            where T : class, ISqlStatementExecutor, new();

        void RegisterExecutor(SqlStatementExecutionType executionContext, ISqlStatementExecutor executor);

        void RegisterExecutor(SqlStatementExecutionType executionContext, Func<ISqlStatementExecutor> executorFactory);

        ISqlStatementExecutor CreateSqlStatementExecutor(ExpressionSet expression);
    }
}
