using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Executor
{
    public class SqlStatementExecutorFactory : ISqlStatementExecutorFactory
    {
        #region internals
        private static readonly ISqlStatementExecutor sqlStatementExecutor = new SqlStatementExecutor();
        private readonly ConcurrentDictionary<Type, Func<ISqlStatementExecutor>> statementExecutors = new ConcurrentDictionary<Type, Func<ISqlStatementExecutor>>();
        #endregion

        #region constructors
        public SqlStatementExecutorFactory()
        {
            RegisterExecutor<SelectQueryExpression>(sqlStatementExecutor);
            RegisterExecutor<InsertQueryExpression>(sqlStatementExecutor);
            RegisterExecutor<UpdateQueryExpression>(sqlStatementExecutor);
            RegisterExecutor<DeleteQueryExpression>(sqlStatementExecutor);
        }
        #endregion

        #region methods
        public void RegisterExecutor<T, U>()
            where T : QueryExpression
            where U : class, ISqlStatementExecutor, new()
            => RegisterExecutor<T>(() => new U());

        public void RegisterExecutor<T>(ISqlStatementExecutor executor)
            where T : QueryExpression
            => RegisterExecutor<T>(() => executor);

        public void RegisterExecutor<T>(Func<ISqlStatementExecutor> executorFactory)
            where T : QueryExpression
            => statementExecutors.AddOrUpdate(typeof(T), executorFactory, (t, f) => executorFactory);

        public ISqlStatementExecutor CreateSqlStatementExecutor(QueryExpression expression)
        {
            var factory = ResolveElementAppenderFactory(expression.GetType(), expression.GetType());
            return factory is object ? factory() : null;
        }

        private Func<ISqlStatementExecutor> ResolveElementAppenderFactory(Type current, Type original)
        {
            if (statementExecutors.TryGetValue(current, out Func<ISqlStatementExecutor> factory))
                return factory;

            if (current.BaseType is null)
                return null;

            factory = ResolveElementAppenderFactory(current.BaseType, original);

            if (factory is object && current == original)
                //reduce runtime recursion by "registering" the original with the found appender
                statementExecutors.TryAdd(original, factory);

            return factory;
        }
        #endregion
    }
}
