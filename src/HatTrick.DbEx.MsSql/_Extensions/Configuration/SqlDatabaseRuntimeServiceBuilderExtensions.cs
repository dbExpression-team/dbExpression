#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

using HatTrick.DbEx.MsSql.Assembler;
using HatTrick.DbEx.MsSql.Builder;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Types;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using HatTrick.DbEx.Sql.Pipeline;
using HatTrick.DbEx.Sql.Types;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Data;

using MsSqlServices = HatTrick.DbEx.MsSql.Configuration.SqlDatabaseRuntimeServiceBuilderExtensions;

namespace HatTrick.DbEx.MsSql.Configuration
{
    public static partial class SqlDatabaseRuntimeServiceBuilderExtensions
    {
        #region 2005
        /// <summary>
        /// Configures a dbExpression runtime environment for a Microsoft Sql Server 2005 database.
        /// </summary>
        /// <param name="builder">A <see cref="ISqlDatabaseRuntimeServicesBuilder" />, the fluent entry point for configuring the runtime environment for a database.</param>
        /// <param name="configureRuntime">A delegate to provide additional configuration of the runtime environment for the <typeparam name="TDatabase">database</typeparam>.</param>        
        /// <typeparam name="TDatabase">The database to configure.</typeparam>
        public static void AddMsSql2005Database<TDatabase>(this ISqlDatabaseRuntimeServicesBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var dbRegistrar = builder as ISqlDatabaseRuntimeServicesRegistrar
                ?? throw new DbExpressionConfigurationException($"Expected builder to also be of type {typeof(ISqlDatabaseRuntimeServicesRegistrar)}.");

            dbRegistrar.ServicesFor<TDatabase>().AddMsSqlCommon<TDatabase>(b =>
            {
                configureRuntime.Invoke(b);
                b.SqlStatements.Assembly.ElementAppender.ForElementTypes(x => x
                    .ForElementType<InsertQueryExpression>().Use<HatTrick.DbEx.MsSql.Assembler.v2005.MsSqlInsertQueryExpressionAppender>()
                    .ForElementType<SelectQueryExpression>().Use<HatTrick.DbEx.MsSql.Assembler.v2005.MsSqlSelectQueryExpressionAppender>()
                    .ForElementType<TrimFunctionExpression>().Use<HatTrick.DbEx.MsSql.Assembler.v2005.TrimFunctionExpressionAppender>()
                );
            });
        }
        #endregion

        #region 2008
        /// <summary>
        /// Configures a dbExpression runtime environment for a Microsoft Sql Server 2008 database.
        /// </summary>
        /// <param name="builder">A <see cref="ISqlDatabaseRuntimeServicesBuilder" />, the fluent entry point for configuring the runtime environment for a database.</param>
        /// <param name="configureRuntime">A delegate to provide additional configuration of the runtime environment for the <typeparam name="TDatabase">database</typeparam>.</param>        
        /// <typeparam name="TDatabase">The database to configure.</typeparam>
        public static void AddMsSql2008Database<TDatabase>(this ISqlDatabaseRuntimeServicesBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var dbRegistrar = builder as ISqlDatabaseRuntimeServicesRegistrar
                ?? throw new DbExpressionConfigurationException($"Expected builder to also be of type {typeof(ISqlDatabaseRuntimeServicesRegistrar)}.");
            
            dbRegistrar.ServicesFor<TDatabase>().AddMsSqlCommon<TDatabase>(b =>
            {
                configureRuntime.Invoke(b);
                b.SqlStatements.Assembly.ElementAppender.ForElementTypes(x => x
                    .ForElementType<SelectQueryExpression>().Use<HatTrick.DbEx.MsSql.Assembler.v2008.MsSqlSelectQueryExpressionAppender>()
                    .ForElementType<TrimFunctionExpression>().Use<HatTrick.DbEx.MsSql.Assembler.v2008.TrimFunctionExpressionAppender>()
                );
            });
        }
        #endregion

        #region 2012
        /// <summary>
        /// Configures a dbExpression runtime environment for a Microsoft Sql Server 2012 database.
        /// </summary>
        /// <param name="builder">A <see cref="ISqlDatabaseRuntimeServicesBuilder" />, the fluent entry point for configuring the runtime environment for a database.</param>
        /// <param name="configureRuntime">A delegate to provide additional configuration of the runtime environment for the <typeparam name="TDatabase">database</typeparam>.</param>        
        /// <typeparam name="TDatabase">The database to configure.</typeparam>
        public static void AddMsSql2012Database<TDatabase>(this ISqlDatabaseRuntimeServicesBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var dbRegistrar = builder as ISqlDatabaseRuntimeServicesRegistrar
                ?? throw new DbExpressionConfigurationException($"Expected builder to also be of type {typeof(ISqlDatabaseRuntimeServicesRegistrar)}.");
            
            dbRegistrar.ServicesFor<TDatabase>().AddMsSqlCommon<TDatabase>(b =>
            {
                configureRuntime.Invoke(b);
                b.SqlStatements.Assembly.ElementAppender.ForElementTypes(x => x.ForElementType<TrimFunctionExpression>().Use<HatTrick.DbEx.MsSql.Assembler.v2012.TrimFunctionExpressionAppender>());
            });
        }
        #endregion

        #region 2014
        /// <summary>
        /// Configures a dbExpression runtime environment for a Microsoft Sql Server 2014 database.
        /// </summary>
        /// <param name="builder">A <see cref="ISqlDatabaseRuntimeServicesBuilder" />, the fluent entry point for configuring the runtime environment for a database.</param>
        /// <param name="configureRuntime">A delegate to provide additional configuration of the runtime environment for the <typeparam name="TDatabase">database</typeparam>.</param>        
        /// <typeparam name="TDatabase">The database to configure.</typeparam>
        public static void AddMsSql2014Database<TDatabase>(this ISqlDatabaseRuntimeServicesBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var dbRegistrar = builder as ISqlDatabaseRuntimeServicesRegistrar
                ?? throw new DbExpressionConfigurationException($"Expected builder to also be of type {typeof(ISqlDatabaseRuntimeServicesRegistrar)}.");

            dbRegistrar.ServicesFor<TDatabase>().AddMsSqlCommon<TDatabase>(b =>
            {
                configureRuntime.Invoke(b);
                b.SqlStatements.Assembly.ElementAppender.ForElementTypes(x => x.ForElementType<TrimFunctionExpression>().Use<HatTrick.DbEx.MsSql.Assembler.v2014.TrimFunctionExpressionAppender>());
            });
        }
        #endregion

        #region 2016
        /// <summary>
        /// Configures a dbExpression runtime environment for a Microsoft Sql Server 2016 database.
        /// </summary>
        /// <param name="builder">A <see cref="ISqlDatabaseRuntimeServicesBuilder" />, the fluent entry point for configuring the runtime environment for a database.</param>
        /// <param name="configureRuntime">A delegate to provide additional configuration of the runtime environment for the <typeparam name="TDatabase">database</typeparam>.</param>        
        /// <typeparam name="TDatabase">The database to configure.</typeparam>
        public static void AddMsSql2016Database<TDatabase>(this ISqlDatabaseRuntimeServicesBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var dbRegistrar = builder as ISqlDatabaseRuntimeServicesRegistrar
                ?? throw new DbExpressionConfigurationException($"Expected builder to also be of type {typeof(ISqlDatabaseRuntimeServicesRegistrar)}.");

            dbRegistrar.ServicesFor<TDatabase>().AddMsSqlCommon<TDatabase>(b =>
            {
                configureRuntime.Invoke(b);
                b.SqlStatements.Assembly.ElementAppender.ForElementTypes(x => x.ForElementType<TrimFunctionExpression>().Use<HatTrick.DbEx.MsSql.Assembler.v2016.TrimFunctionExpressionAppender>());
            });
        }
        #endregion

        #region 2017
        /// <summary>
        /// Configures a dbExpression runtime environment for a Microsoft Sql Server 2017 database.
        /// </summary>
        /// <param name="builder">A <see cref="ISqlDatabaseRuntimeServicesBuilder" />, the fluent entry point for configuring the runtime environment for a database.</param>
        /// <param name="configureRuntime">A delegate to provide additional configuration of the runtime environment for the <typeparam name="TDatabase">database</typeparam>.</param>        
        /// <typeparam name="TDatabase">The database to configure.</typeparam>
        public static void AddMsSql2017Database<TDatabase>(this ISqlDatabaseRuntimeServicesBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var dbRegistrar = builder as ISqlDatabaseRuntimeServicesRegistrar
                ?? throw new DbExpressionConfigurationException($"Expected builder to also be of type {typeof(ISqlDatabaseRuntimeServicesRegistrar)}.");

            dbRegistrar.ServicesFor<TDatabase>().AddMsSqlCommon<TDatabase>(configureRuntime);
        }
        #endregion

        #region 2019
        /// <summary>
        /// Configures a dbExpression runtime environment for a Microsoft Sql Server 2019 database.
        /// </summary>
        /// <param name="builder">A <see cref="ISqlDatabaseRuntimeServicesBuilder" />, the fluent entry point for configuring the runtime environment for a database.</param>
        /// <param name="configureRuntime">A delegate to provide additional configuration of the runtime environment for the <typeparam name="TDatabase">database</typeparam>.</param>        
        /// <typeparam name="TDatabase">The database to configure.</typeparam>
        public static void AddMsSql2019Database<TDatabase>(this ISqlDatabaseRuntimeServicesBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var dbRegistrar = builder as ISqlDatabaseRuntimeServicesRegistrar
                ?? throw new DbExpressionConfigurationException($"Expected builder to also be of type {typeof(ISqlDatabaseRuntimeServicesRegistrar)}.");

            dbRegistrar.ServicesFor<TDatabase>().AddMsSqlCommon<TDatabase>(configureRuntime);
        }
        #endregion

        #region common
        public static void AddMsSqlCommon<TDatabase>(
            this IServiceCollection services,
            Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>> configureRuntime
        )
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var typedBuilder = new MsSqlSqlDatabaseRuntimeConfigurationBuilder<TDatabase>(services);
            var builder = typedBuilder as ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>;

            try
            {
                configureRuntime.Invoke(builder);
            }
            catch (Exception e)
            {
                throw new DbExpressionConfigurationException($"Configuration of a runtime environment for {typeof(TDatabase)} failed, see inner exception for details.", e);
            }            

            //begin registrations using builder
            builder.QueryExpressions.UseDelegateQueryExpressionFactoryWithDefaults();

            builder.Entities
                .UseDelegateEntityFactoryWithDiscovery()
                .UseDelegateMapperFactoryWithDiscovery();

            builder.Conversions.UseDelegateValueConverterFactoryWithDiscoveryWithDefaults();

            builder.SqlStatements
                .UseDelegateExpressionElementAppenderFactoryWithDefaults()
                .UseDelegateQueryExecutionPipelineFactoryWithDefaults()
                .Assembly
                    .StatementBuilder.Use<SqlStatementBuilder<TDatabase>>()
                    .StatementAppender.Use<Appender>()
                .ParameterBuilder.Use<MsSqlParameterBuilder<TDatabase>>()
                .QueryExecution
                    .Executor.Use<SqlStatementExecutor<TDatabase>>()
                    .Connection.Use<MsSqlConnectionFactory<TDatabase>>();
            //end registrations using builder

            typedBuilder.Build();

            //begin direct registrations
            services.TryAddSingleton<ILoggerFactory, NullLoggerFactory>();
            services.TryAddSingleton<SqlStatementAssemblyOptions>();
            services.TryAddSingleton<LoggingOptions>();

            services.TryAddSingleton<IDbTypeMapFactory<SqlDbType>, MsSqlTypeMapFactory>();
            services.TryAddSingleton<IQueryExpressionBuilderFactory<TDatabase>, MsSqlQueryExpressionBuilderFactory<TDatabase>>();
            services.TryAddTransient<AssemblyContext>(sp => sp.GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext());
            services.TryAddSingleton<PipelineEventHooks<TDatabase>>(sp => new PipelineEventHooks<TDatabase>());
            services.TryAddSingleton<IExpandoObjectMapper, ExpandoObjectMapper>();

            services.TryAddSingleton<SingletonSqlDatabaseRuntimeFactory<TDatabase>>(sp =>
                new SingletonSqlDatabaseRuntimeFactory<TDatabase>(() => (sp.GetService(typeof(TDatabase)) as ISqlDatabaseRuntime)!)
            );
            services.AddSingleton<TDatabase>(sp =>
                (TDatabase)Activator.CreateInstance(
                    typeof(TDatabase),
                    sp.GetService(typeof(IQueryExpressionBuilderFactory<TDatabase>)),
                    sp.GetService(typeof(IConnectionStringFactory<TDatabase>)),
                    sp.GetService(typeof(ISqlConnectionFactory<TDatabase>))
                )!
            );
            //end direct registrations

        }

        private static void UseDelegateQueryExpressionFactoryWithDefaults<TDatabase>(this IQueryExpressionFactoryConfigurationBuilder<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder.Use(sp => new DefaultQueryExpressionFactoryWithDiscovery<TDatabase>(
                    sp.GetRequiredService<ILoggerFactory>().CreateLogger<DefaultQueryExpressionFactoryWithDiscovery<TDatabase>>(),
                    t => sp.GetService(t) as QueryExpression //null returns are managed by the factory
                ),
                x => x.WithDefaults()
            );
        }

        private static IEntitiesConfigurationBuilderGrouping<TDatabase> UseDelegateEntityFactoryWithDiscovery<TDatabase>(this IEntitiesConfigurationBuilderGrouping<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder.Creation.Use(sp => new DefaultEntityFactoryWithFallbackConstruction<TDatabase>(
                    sp.GetRequiredService<ILoggerFactory>().CreateLogger<DefaultEntityFactoryWithFallbackConstruction<TDatabase>>(),
                    t => sp.GetService(t) as IDbEntity //null returns are managed by the factory
                ) 
            );
            return builder;
        }

        private static IEntitiesConfigurationBuilderGrouping<TDatabase> UseDelegateMapperFactoryWithDiscovery<TDatabase>(this IEntitiesConfigurationBuilderGrouping<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder.Mapping.Use(
                sp => new DefaultMapperFactoryWithDiscovery<TDatabase>(
                    sp.GetRequiredService<ILoggerFactory>().CreateLogger<DefaultMapperFactoryWithDiscovery<TDatabase>>(),
                    t => (sp.GetService(t) as IEntityMapper)!, //null returns are managed by the factory
                    () => sp.GetService<IExpandoObjectMapper>() ?? throw CreateNullServiceException("Entities", typeof(IExpandoObjectMapper))
                )
            );
            return builder;
        }

        private static void UseDelegateValueConverterFactoryWithDiscoveryWithDefaults<TDatabase>(this IValueConverterFactoryConfigurationBuilder<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder.Use(sp => new DefaultValueConverterFactoryWithDiscovery<TDatabase>(
                    sp.GetRequiredService<ILoggerFactory>().CreateLogger<DefaultValueConverterFactoryWithDiscovery<TDatabase>>(),
                    t => sp.GetService(t) as IValueConverter //null returns are managed by the factory
                ),
                x => x.WithDefaults()
            );
        }

        private static ISqlStatementsConfigurationBuilderGrouping<TDatabase> UseDelegateExpressionElementAppenderFactoryWithDefaults<TDatabase>(this ISqlStatementsConfigurationBuilderGrouping<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder.Assembly.ElementAppender.Use(sp => new DefaultExpressionElementAppenderFactoryWithDiscovery<TDatabase>(
                    sp.GetRequiredService<ILoggerFactory>().CreateLogger<DefaultExpressionElementAppenderFactoryWithDiscovery<TDatabase>>(),
                    t => (sp.GetService(t) as IExpressionElementAppender)! //null returns are managed by the factory
                ),
                x => MsSqlServices.WithDefaults(x)
            );
            return builder;
        }

        private static ISqlStatementsConfigurationBuilderGrouping<TDatabase> UseDelegateQueryExecutionPipelineFactoryWithDefaults<TDatabase>(this ISqlStatementsConfigurationBuilderGrouping<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder.Assembly.QueryExecution.Pipeline.Use(sp => new DelegateQueryExecutionPipelineFactory<TDatabase>(
                t => sp.GetService(t) as IQueryExecutionPipeline<TDatabase>
                        ?? throw CreateNullServiceException(nameof(builder.Assembly.QueryExecution.Pipeline), t)
                ),
                x => x.WithDefaults()
            );
            return builder;
        }

        private static DbExpressionConfigurationException CreateNullServiceException(string factoryName, Type serviceType)
            => new($"Expected registrations provided in {factoryName} to return a non-null service of type {serviceType.FullName}, but <null> was returned.");
        #endregion
    }
}
