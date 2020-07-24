using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlStatementExecutorFactory
    {
        ISqlStatementExecutor CreateSqlStatementExecutor(QueryExpression expression);
    }
}
