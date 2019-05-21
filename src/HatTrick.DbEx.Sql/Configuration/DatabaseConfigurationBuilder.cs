using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using HatTrick.DbEx.Sql.Pipeline;
using System;

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
            var factory = new T();
            Database.StatementBuilderFactory = factory;
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
            var factory = new T();
            Database.AppenderFactory = factory;
        }

        public void UseDefaultAppenderFactory()
        {
            var factory = new AppenderFactory();
            Database.AppenderFactory = factory;
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
            var factory = new T();
            Database.ParameterBuilderFactory = factory;
        }
        #endregion

        #region executor factory
        public void UseExecutorFactory(ISqlStatementExecutorFactory factory)
        {
            UseExecutorFactory(factory, (Action<SqlStatementExecutorFactoryConfigurationBuilder>)null);
        }

        public void UseExecutorFactory(ISqlStatementExecutorFactory factory, Action<SqlStatementExecutorFactoryConfigurationBuilder> configure)
        {
            configure?.Invoke(new SqlStatementExecutorFactoryConfigurationBuilder(factory));
            Database.ExecutorFactory = factory;
        }

        public void UseExecutorFactory<T>()
            where T : class, ISqlStatementExecutorFactory, new()
        {
            UseExecutorFactory<T>((Action<SqlStatementExecutorFactoryConfigurationBuilder>)null);
        }

        public void UseExecutorFactory<T>(Action<SqlStatementExecutorFactoryConfigurationBuilder> configure)
            where T : class, ISqlStatementExecutorFactory, new()
        {
            var factory = new T();
            configure?.Invoke(new SqlStatementExecutorFactoryConfigurationBuilder(factory));
            Database.ExecutorFactory = factory;
        }

        public void UseDefaultExecutorFactory()
        {
            UseDefaultExecutorFactory((Action<SqlStatementExecutorFactoryConfigurationBuilder>)null);
        }

        public void UseDefaultExecutorFactory(Action<SqlStatementExecutorFactoryConfigurationBuilder> configure)
        {
            var factory = new SqlStatementExecutorFactory();
            factory.RegisterDefaultExecutors();
            configure?.Invoke(new SqlStatementExecutorFactoryConfigurationBuilder(factory));
            Database.ExecutorFactory = factory;
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
            Database.ConnectionFactory = new T();
        }
        #endregion

        #region mapper factory
        public void UseMapperFactory(IMapperFactory factory)
        {
            UseMapperFactory(factory, (Action<MapperFactoryConfigurationBuilder>)null);
        }

        public void UseMapperFactory(IMapperFactory factory, Action<MapperFactoryConfigurationBuilder> configure)
        {
            configure?.Invoke(new MapperFactoryConfigurationBuilder(factory));
            Database.MapperFactory = factory;
        }

        public void UseMapperFactory<T>()
            where T : class, IMapperFactory, new()
        {
            UseMapperFactory<T>((Action<MapperFactoryConfigurationBuilder>)null);
        }

        public void UseMapperFactory<T>(Action<MapperFactoryConfigurationBuilder> configure)
            where T : class, IMapperFactory, new()
        {
            var factory = new T();
            configure?.Invoke(new MapperFactoryConfigurationBuilder(factory));
            Database.MapperFactory = factory;
        }

        public void UseDefaultMapperFactory()
        {
            UseDefaultMapperFactory((Action<MapperFactoryConfigurationBuilder>)null);
        }

        public void UseDefaultMapperFactory(Action<MapperFactoryConfigurationBuilder> configure)
        {
            var mapperFactory = new MapperFactory();
            mapperFactory.RegisterDefaultMappers();
            configure?.Invoke(new MapperFactoryConfigurationBuilder(mapperFactory));
            Database.MapperFactory = mapperFactory;
        }
        #endregion

        #region entity factory
        public void UseEntityFactory(IEntityFactory factory)
        {
            UseEntityFactory(factory, (Action<EntityFactoryConfigurationBuilder>)null);
        }

        public void UseEntityFactory(IEntityFactory factory, Action<EntityFactoryConfigurationBuilder> configure)
        {
            configure?.Invoke(new EntityFactoryConfigurationBuilder(factory));
            Database.EntityFactory = factory;
        }

        public void UseEntityFactory<T>()
            where T : class, IEntityFactory, new()
        {
            UseEntityFactory<T>((Action<EntityFactoryConfigurationBuilder>)null);
        }

        public void UseEntityFactory<T>(Action<EntityFactoryConfigurationBuilder> configure)
            where T : class, IEntityFactory, new()
        {
            var factory = new T();
            configure?.Invoke(new EntityFactoryConfigurationBuilder(factory));
            Database.EntityFactory = factory;
        }

        public void UseDefaultEntityFactory()
        {
            UseDefaultEntityFactory(null);
        }

        public void UseDefaultEntityFactory(Action<EntityFactoryConfigurationBuilder> configure)
        {
            var facgtory = new EntityFactory();
            facgtory.RegisterDefaultFactories();
            configure?.Invoke(new EntityFactoryConfigurationBuilder(facgtory));
            Database.EntityFactory = facgtory;
        }
        #endregion

        #region hooks
        public void OnAssemblingSqlStatement(Action<BeforeAssemblyContext> action)
        {
            Database.ExecutionPipelineFactory.BeforeAssembly.AddToEnd(action);
        }

        public void OnAssembledSqlStatement(Action<AfterAssemblyContext> action)
        {
            Database.ExecutionPipelineFactory.AfterAssembly.AddToEnd(action);
        }

        public void OnInsertingEntity(Action<BeforeInsertContext> action)
        {
            Database.ExecutionPipelineFactory.BeforeInsert.AddToEnd(action);
        }

        public void OnInsertedEntity(Action<AfterInsertContext> action)
        {
            Database.ExecutionPipelineFactory.AfterInsert.AddToEnd(action);
        }
        #endregion
        #endregion
    }
}
