using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Executor
{
    public class SqlStatementExecutorFactory : ISqlStatementExecutorFactory
    {
        private static readonly ISqlStatementExecutor sqlStatementExecutor = new SqlStatementExecutor();

        protected IDictionary<Type, Func<ISqlStatementExecutor>> Executors { get; } = new Dictionary<Type, Func<ISqlStatementExecutor>>();

        public virtual void RegisterDefaultExecutors()
        {
            Executors.Add(typeof(SelectQueryExpression), () => sqlStatementExecutor);
            Executors.Add(typeof(InsertQueryExpression), () => sqlStatementExecutor);
            Executors.Add(typeof(UpdateQueryExpression), () => sqlStatementExecutor);
            Executors.Add(typeof(DeleteQueryExpression), () => sqlStatementExecutor);
        }

        protected void RegisterQueryExpressionWithDefaultExecutor<T>()
            where T : QueryExpression
        {
            Executors[typeof(T)] = () => sqlStatementExecutor;
        }

        public void RegisterExecutor<T, U>()
            where T : QueryExpression
            where U : class, ISqlStatementExecutor, new()
        {
            Executors[typeof(T)] = () => new U();
        }

        public void RegisterExecutor<T>(ISqlStatementExecutor executor)
            where T : QueryExpression
        {
            Executors[typeof(T)] = () => executor;
        }

        public void RegisterExecutor<T>(Func<ISqlStatementExecutor> executorFactory)
            where T : QueryExpression
        {
            Executors[typeof(T)] = executorFactory;
        }

        public ISqlStatementExecutor CreateSqlStatementExecutor(QueryExpression expression)
        {
            if (Executors.TryGetValue(expression.GetType(), out var executor))
                return executor();
            throw new DbExpressionConfigurationException($"Could not resolve a sql statement executor, please ensure an executor has been registered for expression type '{expression.GetType()}'");
        }
    }
}
