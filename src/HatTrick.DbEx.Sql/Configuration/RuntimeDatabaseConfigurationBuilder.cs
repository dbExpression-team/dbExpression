using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using HatTrick.DbEx.Sql.Pipeline;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class RuntimeDatabaseConfigurationBuilder : IRuntimeSqlDatabaseConfigurationBuilder
    {
        #region internals
        private readonly DatabaseConfiguration configuration;
        #endregion

        #region interface
        DatabaseConfiguration IRuntimeSqlDatabaseConfigurationBuilder.Configuration => configuration;
        #endregion

        #region constructors
        public RuntimeDatabaseConfigurationBuilder(DatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion

        #region methods
        #region assembler
        public void ConfigureAssembler(Action<SqlStatementAssemblerConfiguration> config)
        {
            config(configuration.AssemblerConfiguration);
        }
        #endregion

        #region query expression factory
        public void UseQueryExpressionFactory(IQueryExpressionFactory factory)
        {
            configuration.QueryExpressionFactory = factory;
        }

        public void UseQueryExpressionFactory<T>()
            where T : class, IQueryExpressionFactory, new()
        {
            configuration.QueryExpressionFactory = new T();
        }

        public void UseQueryExpressionFactory<T>(Func<T> factory)
            where T : QueryExpression, new()
        {
            configuration.QueryExpressionFactory = new DelegateQueryExpressionFactory(new Func<Type,QueryExpression>(t => factory()));
        }
        #endregion

        #region execution pipeline factory
        public void UseExecutionPipelineFactory(IExecutionPipelineFactory factory)
        {
            configuration.ExecutionPipelineFactory = factory;
        }

        public void UseExecutionPipelineFactory<T>()
            where T : class, IExecutionPipelineFactory, new()
        {
            UseExecutionPipelineFactory((Action<T>)null);
        }

        public void UseExecutionPipelineFactory<T>(Action<T> configure)
            where T : class, IExecutionPipelineFactory, new()
        {
            var factory = new T();
            configure?.Invoke(factory);
            configuration.ExecutionPipelineFactory = factory;
        }
        #endregion

        #region sql statement builder factory
        public void UseStatementBuilderFactory(ISqlStatementBuilderFactory factory)
        {
            configuration.StatementBuilderFactory = factory;
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
            configuration.StatementBuilderFactory = factory;
        }

        public void UseStatementBuilderFactory(Func<SqlStatementAssemblerConfiguration, QueryExpression, IAppender, ISqlParameterBuilder, ISqlStatementBuilder> factory)
        {
            configuration.StatementBuilderFactory = new DelegateSqlStatementBuilderFactory(factory);
        }

        public void UseStatementBuilderFactory(Func<ISqlStatementBuilderFactory> factory)
        {
            configuration.StatementBuilderFactory = new DelegateSqlStatementBuilderFactory(factory);
        }
        #endregion

        #region appender factory
        public void UseAppenderFactory(IAppenderFactory factory)
        {
            configuration.AppenderFactory = factory;
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
            configuration.AppenderFactory = factory;
        }

        public void UseAppenderFactory(Func<IAppender> factory)
        {
            configuration.AppenderFactory = new DelegateAppenderFactory(factory);
        }

        public void UseAppenderFactory(Func<IAppenderFactory> factory)
        {
            configuration.AppenderFactory = new DelegateAppenderFactory(factory);
        }
        #endregion

        #region parameter builder factory
        public void UseParameterBuilderFactory(ISqlParameterBuilderFactory factory)
        {
            configuration.ParameterBuilderFactory = factory;
        }

        public void UseParameterBuilderFactory<T>()
            where T : class, ISqlParameterBuilderFactory, new()
        {
            configuration.ParameterBuilderFactory = new T();
        }

        public void UseParameterBuilderFactory(Func<ISqlParameterBuilder> factory)
        {
            configuration.ParameterBuilderFactory = new DelegateSqlParameterBuilderFactory(factory);
        }

        public void UseParameterBuilderFactory(Func<ISqlParameterBuilderFactory> factory)
        {
            configuration.ParameterBuilderFactory = new DelegateSqlParameterBuilderFactory(factory);
        }
        #endregion

        #region executor factory
        public void UseSqlStatementExecutorFactory(ISqlStatementExecutorFactory factory)
        {
            configuration.ExecutorFactory = factory;
        }

        public void UseSqlStatementExecutorFactory<T>()
            where T : class, ISqlStatementExecutorFactory, new()
        {
            UseSqlStatementExecutorFactory((Action<T>)null);
        }

        public void UseSqlStatementExecutorFactory<T>(Action<T> configure)
            where T : class, ISqlStatementExecutorFactory, new()
        {
            var factory = new T();
            configure?.Invoke(factory);
            configuration.ExecutorFactory = factory;
        }

        public void UseSqlStatementExecutorFactory(Func<QueryExpression,ISqlStatementExecutor> factory)
        {
            configuration.ExecutorFactory = new DelegateSqlStatementExecutorFactory(factory);
        }

        public void UseSqlStatementExecutorFactory(Func<ISqlStatementExecutorFactory> factory)
        {
            configuration.ExecutorFactory = new DelegateSqlStatementExecutorFactory(factory);
        }
        #endregion

        #region connection factory
        public void UseConnectionFactory(ISqlConnectionFactory factory)
        {
            configuration.ConnectionFactory = factory;
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
            configuration.ConnectionFactory = factory;
        }

        public void UseConnectionFactory(Func<SqlConnection> factory)
        {
            configuration.ConnectionFactory = new DelegateSqlConnectionFactory(factory);
        }

        public void UseConnectionFactory(Func<ISqlConnectionFactory> factory)
        {
            configuration.ConnectionFactory = new DelegateSqlConnectionFactory(factory);
        }
        #endregion

        #region mapper factory
        public void UseMapperFactory(IMapperFactory factory)
        {
            configuration.MapperFactory = factory;
        }

        public void UseMapperFactory<T>()
            where T : class, IMapperFactory, new()
        {
            configuration.MapperFactory = new T();
        }

        public void UseMapperFactory<T>(Action<MapperFactoryConfigurationBuilder> configure)
            where T : MapperFactory, new()
        {
            var factory = new T();
            configure?.Invoke(new MapperFactoryConfigurationBuilder(factory));
            configuration.MapperFactory = factory;
        }

        public void UseEntityMapperFactory(Func<IMapperFactory> factory)
        {
            configuration.MapperFactory = new DelegateMapperFactory(factory);
        }

        #endregion

        #region value converter factory
        public void UseValueConverterFactory(IValueConverterFactory factory)
        {
            configuration.ValueConverterFactory = factory;
        }

        public void UseValueConverterFactory<T>()
            where T : class, IValueConverterFactory, new()
        {
            var factory = new T();
            if (factory is ValueConverterFactory m)
                m.RegisterDefaultConverters();
            configuration.ValueConverterFactory = factory;
        }

        public void UseValueConverterFactory<T>(Action<ValueConverterFactoryConfigurationBuilder> configure)
            where T : ValueConverterFactory, new()
        {
            var factory = new T();
            factory.RegisterDefaultConverters();
            configure?.Invoke(new ValueConverterFactoryConfigurationBuilder(factory));
            configuration.ValueConverterFactory = factory;
        }

        public ValueConverterFactoryConfigurationBuilder WithValueConverterFactory()
        {
            return new ValueConverterFactoryConfigurationBuilder(configuration.ValueConverterFactory as ValueConverterFactory);
        }

        #endregion

        #region entity factory
        public void UseEntityFactory(IEntityFactory factory)
        {
            configuration.EntityFactory = factory;
        }

        public void UseEntityFactory<T>()
            where T : class, IEntityFactory, new()
        {
            var factory = new T();
            if (factory is EntityFactory m)
                m.RegisterDefaultFactories();
            configuration.EntityFactory = factory;

        }

        public void UseEntityFactory<T>(Func<IEntityFactory> factory)
            where T : class, IDbEntity, new()
        {
            configuration.EntityFactory = new DelegateEntityFactory(factory);
        }
        #endregion

        #region hooks
        public IPipelineEventActionBuilder<BeforeAssemblyPipelineExecutionContext> BeforeAssemblingSqlStatement(Action<BeforeAssemblyPipelineExecutionContext> action)
            => configuration.ExecutionPipelineFactory.BeforeAssembly.AddToEnd(action);

        public IPipelineEventActionBuilder<AfterAssemblyPipelineExecutionContext> AfterAssemblingSqlStatement(Action<AfterAssemblyPipelineExecutionContext> action)
            => configuration.ExecutionPipelineFactory.AfterAssembly.AddToEnd(action);

        public IPipelineEventActionBuilder<BeforeInsertPipelineExecutionContext> BeforeInsertingEntity(Action<BeforeInsertPipelineExecutionContext> action)
            => configuration.ExecutionPipelineFactory.BeforeInsert.AddToEnd(action);

        public IPipelineEventActionBuilder<AfterInsertPipelineExecutionContext> AfterInsertingEntity(Action<AfterInsertPipelineExecutionContext> action)
            => configuration.ExecutionPipelineFactory.AfterInsert.AddToEnd(action);

        public IPipelineEventActionBuilder<BeforeUpdatePipelineExecutionContext> BeforeUpdatingEntity(Action<BeforeUpdatePipelineExecutionContext> action)
            => configuration.ExecutionPipelineFactory.BeforeUpdate.AddToEnd(action);

        public IPipelineEventActionBuilder<AfterUpdatePipelineExecutionContext> AfterUpdatingEntity(Action<AfterUpdatePipelineExecutionContext> action)
            => configuration.ExecutionPipelineFactory.AfterUpdate.AddToEnd(action);

        public IPipelineEventActionBuilder<BeforeDeletePipelineExecutionContext> BeforeDeletingEntity(Action<BeforeDeletePipelineExecutionContext> action)
            => configuration.ExecutionPipelineFactory.BeforeDelete.AddToEnd(action);

        public IPipelineEventActionBuilder<AfterDeletePipelineExecutionContext> AfterDeletingEntity(Action<AfterDeletePipelineExecutionContext> action)
            => configuration.ExecutionPipelineFactory.AfterDelete.AddToEnd(action);

        public IPipelineEventActionBuilder<BeforeSelectPipelineExecutionContext> BeforeSelectingEntity(Action<BeforeSelectPipelineExecutionContext> action)
            => configuration.ExecutionPipelineFactory.BeforeSelect.AddToEnd(action);

        public IPipelineEventActionBuilder<AfterSelectPipelineExecutionContext> AfterSelectingEntity(Action<AfterSelectPipelineExecutionContext> action)
            => configuration.ExecutionPipelineFactory.AfterSelect.AddToEnd(action);

        public IPipelineEventActionBuilder<BeforeExecutionPipelineExecutionContext> BeforeExecutingCommand(Action<BeforeExecutionPipelineExecutionContext> action)
             => configuration.ExecutionPipelineFactory.BeforeExecution.AddToEnd(action);

        public IPipelineEventActionBuilder<AfterExecutionPipelineExecutionContext> AfterExecutingCommand(Action<AfterExecutionPipelineExecutionContext> action)
            => configuration.ExecutionPipelineFactory.AfterExecution.AddToEnd(action);
        #endregion
        #endregion
    }
}
