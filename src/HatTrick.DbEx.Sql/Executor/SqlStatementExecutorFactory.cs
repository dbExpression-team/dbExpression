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
        private IDictionary<ExecutionContext, Func<ISqlStatementExecutor>> executors { get; } = new Dictionary<ExecutionContext, Func<ISqlStatementExecutor>>();

        public virtual void RegisterDefaultExecutors()
        {
            executors.Add(ExecutionContext.Get, () => new SelectTypeSqlStatementExecutor());
            executors.Add(ExecutionContext.GetDynamic, () => new SelectDynamicSqlStatmentExecutor());
            executors.Add(ExecutionContext.GetValue, () => new SelectValueSqlStatementExecutor());
            executors.Add(ExecutionContext.GetList, () => new SelectTypeListSqlStatementExecutor());
            executors.Add(ExecutionContext.GetDynamicList, () => new SelectDynamicListSqlStatementExecutor());
            executors.Add(ExecutionContext.GetValueList, () => new SelectValueListSqlStatementExecutor());
            executors.Add(ExecutionContext.Insert, () => new InsertSqlStatementExecutor());
            executors.Add(ExecutionContext.Update, () => new UpdateSqlStatementExecutor());
            executors.Add(ExecutionContext.Delete, () => new DeleteSqlStatementExecutor());
        }

        public void RegisterExecutor<T>(ExecutionContext executionContext)
            where T : class, ISqlStatementExecutor, new()
        {
            executors[executionContext] = () => new T();
        }

        public void RegisterExecutor(ExecutionContext executionContext, ISqlStatementExecutor executor)
        {
            executors[executionContext] = () => executor;
        }

        public ISqlStatementExecutor CreateSqlStatementExecutor(ExpressionSet expression)
        {
            return executors[expression.ExecutionContext]();
        }
    }
}
