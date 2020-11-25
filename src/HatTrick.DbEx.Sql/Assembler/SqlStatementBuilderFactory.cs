using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Assembler
{
    public abstract class SqlStatementBuilderFactory : ISqlStatementBuilderFactory
    {
        #region internals
        private Func<Type, ISqlStatementAssembler> _statementAssemblerFactory;

        private readonly ConcurrentDictionary<Type, Func<ISqlStatementAssembler>> _statementAssemblers = new ConcurrentDictionary<Type, Func<ISqlStatementAssembler>>();
        #endregion

        #region interface
        public virtual Func<Type, ISqlStatementAssembler> AssemblerFactory
            => _statementAssemblerFactory ?? (_statementAssemblerFactory = new Func<Type, ISqlStatementAssembler>(sqlExecutionType =>
                {
                    var factory = ResolveAssemblerFactory(sqlExecutionType, sqlExecutionType);

                    if (factory is object)
                        return factory();

                    throw new DbExpressionConfigurationException($"Could not resolve an assembler, please ensure an executor has been registered for sql statement execution type of '{sqlExecutionType}'");
                }));
        #endregion

        #region methods
        public virtual void RegisterStatementAssembler<T, U>()
            where T : QueryExpression
            where U : class, ISqlStatementAssembler, new()
            => _statementAssemblers.AddOrUpdate(typeof(T), () => new U(), (t, f) => () => new U());

        public virtual void RegisterStatementAssembler<T, U>(U assembler)
            where T : QueryExpression
            where U : class, ISqlStatementAssembler
            => _statementAssemblers.AddOrUpdate(typeof(T), () => assembler, (t, f) => () => assembler);

        public virtual void RegisterStatementAssembler<T, U>(Func<U> assemblerFactory)
            where T : QueryExpression
            where U : class, ISqlStatementAssembler
            => _statementAssemblers.AddOrUpdate(typeof(T), assemblerFactory, (t,f) => assemblerFactory);

        public virtual void RegisterDefaultStatementAssemblers()
        {

        }

        public ISqlStatementBuilder CreateSqlStatementBuilder(ISqlDatabaseMetadataProvider databaseMetadata, IExpressionElementAppenderFactory partAppenderFactory, SqlStatementAssemblerConfiguration config, QueryExpression expression, IAppender appender, ISqlParameterBuilder parameterBuilder)
            => new SqlStatementBuilder(
                databaseMetadata, 
                partAppenderFactory, 
                config, 
                expression, 
                e => AssemblerFactory(e.GetType()), 
                appender, 
                parameterBuilder
            );

        private Func<ISqlStatementAssembler> ResolveAssemblerFactory(Type current, Type original)
        {
            if (_statementAssemblers.TryGetValue(current, out Func<ISqlStatementAssembler> factory))
                return factory;

            if (current.BaseType is null)
                return null;

            factory = ResolveAssemblerFactory(current.BaseType, original);

            if (factory is object && current == original)
                //reduce runtime recursion by "registering" the original with the found factory
                _statementAssemblers.TryAdd(original, factory);

            return ResolveAssemblerFactory(current.BaseType, original);
        }
        #endregion
    }
}
