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
        private static readonly SqlStatementExecutor sqlStatementExecutor = new SqlStatementExecutor();
        private IDictionary<SqlStatementExecutionType, Func<ISqlStatementExecutor>> executors { get; } = new Dictionary<SqlStatementExecutionType, Func<ISqlStatementExecutor>>();

        public virtual void RegisterDefaultExecutors()
        {
            executors.Add(SqlStatementExecutionType.SelectOneType, () => sqlStatementExecutor);
            executors.Add(SqlStatementExecutionType.SelectOneDynamic, () => sqlStatementExecutor);
            executors.Add(SqlStatementExecutionType.SelectOneValue, () => sqlStatementExecutor);
            executors.Add(SqlStatementExecutionType.SelectManyType, () => sqlStatementExecutor);
            executors.Add(SqlStatementExecutionType.SelectManyDynamic, () => sqlStatementExecutor);
            executors.Add(SqlStatementExecutionType.SelectManyValue, () => sqlStatementExecutor);
            executors.Add(SqlStatementExecutionType.Insert, () => sqlStatementExecutor);
            executors.Add(SqlStatementExecutionType.Update, () => sqlStatementExecutor);
            executors.Add(SqlStatementExecutionType.Delete, () => sqlStatementExecutor);
        }

        public void RegisterExecutor<T>(SqlStatementExecutionType statementExecutionType)
            where T : class, ISqlStatementExecutor, new()
        {
            executors[statementExecutionType] = () => new T();
        }

        public void RegisterExecutor(SqlStatementExecutionType statementExecutionType, ISqlStatementExecutor executor)
        {
            executors[statementExecutionType] = () => executor;
        }

        public ISqlStatementExecutor CreateSqlStatementExecutor(ExpressionSet expression)
        {
            return executors[expression.StatementExecutionType]();
        }
    }
}
