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
        private IDictionary<SqlStatementExecutionType, Func<ISqlStatementExecutor>> Executors { get; } = new Dictionary<SqlStatementExecutionType, Func<ISqlStatementExecutor>>();

        public virtual void RegisterDefaultExecutors()
        {
            Executors.Add(SqlStatementExecutionType.SelectOneType, () => sqlStatementExecutor);
            Executors.Add(SqlStatementExecutionType.SelectOneDynamic, () => sqlStatementExecutor);
            Executors.Add(SqlStatementExecutionType.SelectOneValue, () => sqlStatementExecutor);
            Executors.Add(SqlStatementExecutionType.SelectManyType, () => sqlStatementExecutor);
            Executors.Add(SqlStatementExecutionType.SelectManyDynamic, () => sqlStatementExecutor);
            Executors.Add(SqlStatementExecutionType.SelectManyValue, () => sqlStatementExecutor);
            Executors.Add(SqlStatementExecutionType.Insert, () => sqlStatementExecutor);
            Executors.Add(SqlStatementExecutionType.Update, () => sqlStatementExecutor);
            Executors.Add(SqlStatementExecutionType.Delete, () => sqlStatementExecutor);
        }

        public void RegisterExecutor<T>(SqlStatementExecutionType statementExecutionType)
            where T : class, ISqlStatementExecutor, new()
        {
            Executors[statementExecutionType] = () => new T();
        }

        public void RegisterExecutor(SqlStatementExecutionType statementExecutionType, ISqlStatementExecutor executor)
        {
            Executors[statementExecutionType] = () => executor;
        }

        public void RegisterExecutor(SqlStatementExecutionType statementExecutionType, Func<ISqlStatementExecutor> executorFactory)
        {
            Executors[statementExecutionType] = executorFactory;
        }

        public ISqlStatementExecutor CreateSqlStatementExecutor(ExpressionSet expression)
        {
            if (Executors.TryGetValue(expression.StatementExecutionType, out var executor))
                return executor();
            throw new DbExpressionConfigurationException($"Could not resolve a sql statement executor, please ensure an executor has been registered for sql statement execution type of '{expression.StatementExecutionType}'");
        }
    }
}
