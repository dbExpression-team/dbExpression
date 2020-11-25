using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Executor
{
    public class SqlStatementExecutorFactory : ISqlStatementExecutorFactory
    {
        private static readonly ISqlStatementExecutor sqlStatementExecutor = new SqlStatementExecutor();
        private readonly ConcurrentDictionary<Type, Func<ISqlStatementExecutor>> _statementExecutors = new ConcurrentDictionary<Type, Func<ISqlStatementExecutor>>();

        public virtual void RegisterDefaultExecutors()
        {
            _statementExecutors.TryAdd(typeof(SelectQueryExpression), () => sqlStatementExecutor);
            _statementExecutors.TryAdd(typeof(InsertQueryExpression), () => sqlStatementExecutor);
            _statementExecutors.TryAdd(typeof(UpdateQueryExpression), () => sqlStatementExecutor);
            _statementExecutors.TryAdd(typeof(DeleteQueryExpression), () => sqlStatementExecutor);
        }

        protected void RegisterQueryExpressionWithDefaultExecutor<T>()
            where T : QueryExpression
            => _statementExecutors.AddOrUpdate(typeof(T), () => sqlStatementExecutor, (t, f) => () => sqlStatementExecutor);

        public void RegisterExecutor<T, U>()
            where T : QueryExpression
            where U : class, ISqlStatementExecutor, new()
            => _statementExecutors.AddOrUpdate(typeof(T), () => new U(), (t, f) => () => new U());

        public void RegisterExecutor<T>(ISqlStatementExecutor executor)
            where T : QueryExpression
            => RegisterExecutor<T>(() => executor);

        public void RegisterExecutor<T>(Func<ISqlStatementExecutor> executorFactory)
            where T : QueryExpression
            => _statementExecutors.AddOrUpdate(typeof(T), executorFactory, (t, f) => executorFactory);

        public ISqlStatementExecutor CreateSqlStatementExecutor(QueryExpression expression)
        {
            var factory = ResolveElementAppenderFactory(expression.GetType(), expression.GetType());
            return factory is object ? factory() : null;
        }

        private Func<ISqlStatementExecutor> ResolveElementAppenderFactory(Type current, Type original)
        {
            if (_statementExecutors.TryGetValue(current, out Func<ISqlStatementExecutor> factory))
                return factory;

            if (current.BaseType is null)
                return null;

            factory = ResolveElementAppenderFactory(current.BaseType, original);

            if (factory is object && current == original)
                //reduce runtime recursion by "registering" the original with the found appender
                _statementExecutors.TryAdd(original, factory);

            return factory;
        }
    }
}
