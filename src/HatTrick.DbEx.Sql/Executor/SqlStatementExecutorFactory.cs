using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Executor
{
    public class SqlStatementExecutorFactory : ISqlStatementExecutorFactory
    {
        private IDictionary<SqlStatementExecutionType, Func<ISqlStatementExecutor>> executors { get; } = new Dictionary<SqlStatementExecutionType, Func<ISqlStatementExecutor>>();

        public virtual void RegisterDefaultExecutors()
        {
            executors.Add(SqlStatementExecutionType.Get, () => new SelectTypeSqlStatementExecutor());
            executors.Add(SqlStatementExecutionType.GetDynamic, () => new SelectDynamicSqlStatmentExecutor());
            executors.Add(SqlStatementExecutionType.GetValue, () => new SelectValueSqlStatementExecutor());
            executors.Add(SqlStatementExecutionType.GetList, () => new SelectTypeListSqlStatementExecutor());
            executors.Add(SqlStatementExecutionType.GetDynamicList, () => new SelectDynamicListSqlStatementExecutor());
            executors.Add(SqlStatementExecutionType.GetValueList, () => new SelectValueListSqlStatementExecutor());
            executors.Add(SqlStatementExecutionType.Insert, () => new InsertSqlStatementExecutor());
            executors.Add(SqlStatementExecutionType.Update, () => new UpdateSqlStatementExecutor());
            executors.Add(SqlStatementExecutionType.Delete, () => new DeleteSqlStatementExecutor());
        }

        public void RegisterExecutor<T>(SqlStatementExecutionType executionContext)
            where T : class, ISqlStatementExecutor, new()
        {
            executors[executionContext] = () => new T();
        }

        public void RegisterExecutor(SqlStatementExecutionType executionContext, ISqlStatementExecutor executor)
        {
            executors[executionContext] = () => executor;
        }

        public ISqlStatementExecutor CreateSqlStatementExecutor(ExpressionSet expression)
        {
            return executors[expression.ExecutionContext]();
        }
    }
}
