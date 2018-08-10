using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Executor
{
    public class SqlExecutorFactory : ISqlExecutorFactory
    {
        private IDictionary<ExecutionContext, Func<ISqlExecutor>> executors { get; } = new Dictionary<ExecutionContext, Func<ISqlExecutor>>();

        public virtual void RegisterDefaultExecutors()
        {
            executors.Add(ExecutionContext.Get, () => new SelectTypeSqlExecutor());
            executors.Add(ExecutionContext.GetDynamic, () => new SelectDynamicSqlExecutor());
            executors.Add(ExecutionContext.GetValue, () => new SelectValueSqlExecutor());
            executors.Add(ExecutionContext.GetList, () => new SelectTypeListSqlExecutor());
            executors.Add(ExecutionContext.GetDynamicList, () => new SelectDynamicListSqlExecutor());
            executors.Add(ExecutionContext.GetValueList, () => new SelectValueListSqlExecutor());
            executors.Add(ExecutionContext.Insert, () => new InsertSqlExecutor());
            executors.Add(ExecutionContext.Update, () => new UpdateSqlExecutor());
            executors.Add(ExecutionContext.Delete, () => new DeleteSqlExecutor());
        }

        public void RegisterExecutor<T>(ExecutionContext executionContext)
            where T : class, ISqlExecutor, new()
        {
            executors[executionContext] = () => new T();
        }

        public void RegisterExecutor(ExecutionContext executionContext, ISqlExecutor executor)
        {
            executors[executionContext] = () => executor;
        }

        public ISqlExecutor CreateSqlStatementExecutor(DBExpressionSet expression)
        {
            return executors[expression.ExecutionContext]();
        }
    }
}
