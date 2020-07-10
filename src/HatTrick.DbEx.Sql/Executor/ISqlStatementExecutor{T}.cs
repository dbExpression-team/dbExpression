using HatTrick.DbEx.Sql.Connection;
using System.Collections.Generic;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Executor
{
    public interface ISqlStatmentExecutor<T> : ISqlStatementExecutor
    {
        T Execute(ISqlConnection connection, SqlStatement statement, int? commandTimeout = null);
    }
}
