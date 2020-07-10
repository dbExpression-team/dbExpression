using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class DatabaseConfigurationBuilder
    {
        #region internals
        private readonly DatabaseConfiguration Database;
        #endregion

        #region constructors
        public DatabaseConfigurationBuilder(DatabaseConfiguration database)
        {
            Database = database;
        }
        #endregion

        #region methods
        public void ConfigureAssembler(Action<DbExpressionAssemblerConfiguration> config)
        {
            config(Database.AssemblerConfiguration);
        }

        #region sql statement builder factory
        public void UseStatementBuilderFactory(ISqlStatementBuilderFactory factory)
        {
            Database.StatementBuilderFactory = factory;
        }

        public void UseStatementBuilderFactory<T>()
            where T : class, ISqlStatementBuilderFactory, new()
        {
            UseStatementBuilderFactory((Action<T>)null);
        }

        public void UseStatementBuilderFactory<T>(Action<T> configure)
            where T : class, ISqlStatementBuilderFactory, new()
        {
            var factory = new T();
            configure?.Invoke(factory);
            Database.StatementBuilderFactory = factory;
        }

        public void UseStatementBuilderFactory(Func<DbExpressionAssemblerConfiguration, ExpressionSet, IAppender, ISqlParameterBuilder, ISqlStatementBuilder> factory)
        {
            Database.StatementBuilderFactory = new DelegateSqlStatementBuilderFactory(factory);
        }

        public void UseStatementBuilderFactory(Func<ISqlStatementBuilderFactory> factory)
        {
            Database.StatementBuilderFactory = new DelegateSqlStatementBuilderFactory(factory);
        }
        #endregion

        #region appender factory
        public void UseAppenderFactory(IAppenderFactory factory)
        {
            Database.AppenderFactory = factory;
        }

        public void UseAppenderFactory<T>()
            where T : class, IAppenderFactory, new()
        {
            UseAppenderFactory((Action<T>)null);
        }

        public void UseAppenderFactory<T>(Action<T> configure)
            where T : class, IAppenderFactory, new()
        {
            var factory = new T();
            configure?.Invoke(factory);
            Database.AppenderFactory = factory;
        }

        public void UseAppenderFactory(Func<IAppender> factory)
        {
            Database.AppenderFactory = new DelegateAppenderFactory(factory);
        }

        public void UseAppenderFactory(Func<IAppenderFactory> factory)
        {
            Database.AppenderFactory = new DelegateAppenderFactory(factory);
        }
        #endregion

        #region parameter builder factory
        public void UseParameterBuilderFactory(ISqlParameterBuilderFactory factory)
        {
            Database.ParameterBuilderFactory = factory;
        }

        public void UseParameterBuilderFactory<T>()
            where T : class, ISqlParameterBuilderFactory, new()
        {
            Database.ParameterBuilderFactory = new T();
        }

        public void UseParameterBuilderFactory(Func<ISqlParameterBuilder> factory)
        {
            Database.ParameterBuilderFactory = new DelegateSqlParameterBuilderFactory(factory);
        }

        public void UseParameterBuilderFactory(Func<ISqlParameterBuilderFactory> factory)
        {
            Database.ParameterBuilderFactory = new DelegateSqlParameterBuilderFactory(factory);
        }
        #endregion

        #region executor factory
        public void UseExecutorFactory(ISqlStatementExecutorFactory factory)
        {
            Database.ExecutorFactory = factory;
        }

        public void UseExecutorFactory<T>()
            where T : class, ISqlStatementExecutorFactory, new()
        {
            UseExecutorFactory((Action<T>)null);
        }

        public void UseExecutorFactory<T>(Action<T> configure)
            where T : class, ISqlStatementExecutorFactory, new()
        {
            var factory = new T();
            configure?.Invoke(factory);
            Database.ExecutorFactory = factory;
        }

        public void UseExecutorFactory(Func<ExpressionSet,ISqlStatementExecutor> factory)
        {
            Database.ExecutorFactory = new DelegateSqlStatementExecutorFactory(factory);
        }

        public void UseExecutorFactory(Func<ISqlStatementExecutorFactory> factory)
        {
            Database.ExecutorFactory = new DelegateSqlStatementExecutorFactory(factory);
        }
        #endregion

        #region connection factory
        public void UseConnectionFactory(ISqlConnectionFactory factory)
        {
            Database.ConnectionFactory = factory;
        }

        public void UseConnectionFactory<T>()
            where T : ISqlConnectionFactory, new()
        {
            UseConnectionFactory((Action<T>)null);
        }

        public void UseConnectionFactory<T>(Action<T> configure)
            where T : ISqlConnectionFactory, new()
        {
            var factory = new T();
            configure?.Invoke(factory);
            Database.ConnectionFactory = factory;
        }

        public void UseConnectionFactory(Func<SqlConnection> factory)
        {
            Database.ConnectionFactory = new DelegateSqlConnectionFactory(factory);
        }

        public void UseConnectionFactory(Func<ISqlConnectionFactory> factory)
        {
            Database.ConnectionFactory = new DelegateSqlConnectionFactory(factory);
        }
        #endregion

        #region mapper factory
        public void UseMapperFactory(IMapperFactory factory)
        {
            Database.MapperFactory = factory;
        }

        public void UseMapperFactory<T>()
            where T : class, IMapperFactory, new()
        {
            var factory = new T();
            if (factory is MapperFactory m)
                m.RegisterDefaultMappers();
            Database.MapperFactory = factory;
        }

        public void UseMapperFactory<T>(Action<MapperFactoryConfigurationBuilder> configure)
            where T : MapperFactory, new()
        {
            var factory = new T();
            factory.RegisterDefaultMappers();
            configure?.Invoke(new MapperFactoryConfigurationBuilder(factory));
            Database.MapperFactory = factory;
        }

        public void UseEntityMapperFactory(Func<IMapperFactory> factory)
        {
            Database.MapperFactory = new DelegateMapperFactory(factory);
        }

        #endregion

        #region entity factory
        public void UseEntityFactory(IEntityFactory factory)
        {
            Database.EntityFactory = factory;
        }

        public void UseEntityFactory<T>()
            where T : class, IEntityFactory, new()
        {
            var factory = new T();
            if (factory is EntityFactory m)
                m.RegisterDefaultFactories();
            Database.EntityFactory = factory;

        }

        public void UseEntityFactory<T>(Func<IEntityFactory> factory)
            where T : class, IDbEntity, new()
        {
            Database.EntityFactory = new DelegateEntityFactory(factory);
        }
        #endregion

        #region hooks
        public IPipelineEventActionBuilder<BeforeAssemblyPipelineExecutionContext> BeforeAssemblingSqlStatement(Action<BeforeAssemblyPipelineExecutionContext> action)
            => Database.ExecutionPipelineFactory.BeforeAssembly.AddToEnd(action);

        public IPipelineEventActionBuilder<AfterAssemblyPipelineExecutionContext> AfterAssemblingSqlStatement(Action<AfterAssemblyPipelineExecutionContext> action)
            => Database.ExecutionPipelineFactory.AfterAssembly.AddToEnd(action);

        public IPipelineEventActionBuilder<BeforeInsertPipelineExecutionContext> BeforeInsertingEntity(Action<BeforeInsertPipelineExecutionContext> action)
            => Database.ExecutionPipelineFactory.BeforeInsert.AddToEnd(action);

        public IPipelineEventActionBuilder<AfterInsertPipelineExecutionContext> AfterInsertingEntity(Action<AfterInsertPipelineExecutionContext> action)
            => Database.ExecutionPipelineFactory.AfterInsert.AddToEnd(action);

        public IPipelineEventActionBuilder<BeforeExecutionPipelineExecutionContext> BeforeExecutingCommand(Action<BeforeExecutionPipelineExecutionContext> action)
             => Database.ExecutionPipelineFactory.BeforeExecution.AddToEnd(action);
        #endregion
        #endregion
    }
}
