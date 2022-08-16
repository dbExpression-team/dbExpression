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
        /// Configures <typeparamref name="TDatabase"/> as a Microsoft Sql Server 2005 database for runtime use with dbExpression.
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

            dbRegistrar.Register<TDatabase>().AddMsSqlCommon<TDatabase>(b =>
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
        /// Configures <typeparamref name="TDatabase"/> as a Microsoft Sql Server 2008 database for runtime use with dbExpression.
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
            
            dbRegistrar.Register<TDatabase>().AddMsSqlCommon<TDatabase>(b =>
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
        /// Configures <typeparamref name="TDatabase"/> as a Microsoft Sql Server 2012 database for runtime use with dbExpression.
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
            
            dbRegistrar.Register<TDatabase>().AddMsSqlCommon<TDatabase>(b =>
            {
                configureRuntime.Invoke(b);
                b.SqlStatements.Assembly.ElementAppender.ForElementTypes(x => x.ForElementType<TrimFunctionExpression>().Use<HatTrick.DbEx.MsSql.Assembler.v2012.TrimFunctionExpressionAppender>());
            });
        }
        #endregion

        #region 2014
        /// <summary>
        /// Configures <typeparamref name="TDatabase"/> as a Microsoft Sql Server 2014 database for runtime use with dbExpression.
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

            dbRegistrar.Register<TDatabase>().AddMsSqlCommon<TDatabase>(b =>
            {
                configureRuntime.Invoke(b);
                b.SqlStatements.Assembly.ElementAppender.ForElementTypes(x => x.ForElementType<TrimFunctionExpression>().Use<HatTrick.DbEx.MsSql.Assembler.v2014.TrimFunctionExpressionAppender>());
            });
        }
        #endregion

        #region 2016
        /// <summary>
        /// Configures <typeparamref name="TDatabase"/> as a Microsoft Sql Server 2016 database for runtime use with dbExpression.
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

            dbRegistrar.Register<TDatabase>().AddMsSqlCommon<TDatabase>(b =>
            {
                configureRuntime.Invoke(b);
                b.SqlStatements.Assembly.ElementAppender.ForElementTypes(x => x.ForElementType<TrimFunctionExpression>().Use<HatTrick.DbEx.MsSql.Assembler.v2016.TrimFunctionExpressionAppender>());
            });
        }
        #endregion

        #region 2017
        /// <summary>
        /// Configures <typeparamref name="TDatabase"/> as a Microsoft Sql Server 2017 database for runtime use with dbExpression.
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

            dbRegistrar.Register<TDatabase>().AddMsSqlCommon<TDatabase>(configureRuntime);
        }
        #endregion

        #region 2019
        /// <summary>
        /// Configures <typeparamref name="TDatabase"/> as a Microsoft Sql Server 2019 database for runtime use with dbExpression.
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

            dbRegistrar.Register<TDatabase>().AddMsSqlCommon<TDatabase>(configureRuntime);
        }
        #endregion

        #region common
        private static void AddMsSqlCommon<TDatabase>(
            this SqlDatabaseRuntimeRegistrar registrar,
            Action<ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>> configureRuntime
        )
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (registrar is null)
                throw new ArgumentNullException(nameof(registrar));

            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var dbServices = new TinyIoCServiceCollection<TDatabase>();
            var builder = new MsSqlSqlDatabaseRuntimeConfigurationBuilder<TDatabase>(dbServices);
            var dbServicesBuilder = builder as ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>;

            try
            {
                configureRuntime.Invoke(dbServicesBuilder);
            }
            catch (Exception e)
            {
                throw new DbExpressionConfigurationException($"Configuration of a runtime environment for {typeof(TDatabase)} failed, see inner exception for details.", e);
            }            

            //begin registrations using builder
            dbServicesBuilder.QueryExpressions.UseDelegateQueryExpressionFactoryWithDefaults();

            dbServicesBuilder.Entities
                .UseDelegateEntityFactoryWithDiscovery()
                .UseDelegateMapperFactoryWithDiscovery();

            dbServicesBuilder.Conversions.UseDelegateValueConverterFactoryWithDiscoveryWithDefaults();

            dbServicesBuilder.SqlStatements
                .UseDelegateExpressionElementAppenderFactoryWithDefaults()
                .UseDelegateQueryExecutionPipelineFactoryWithDefaults()
                .Assembly
                    .StatementBuilder.Use<SqlStatementBuilder>()
                    .StatementAppender.Use<Appender>()
                .ParameterBuilder.Use<MsSqlParameterBuilder>()
                .QueryExecution
                    .Executor.Use<SqlStatementExecutor>()
                    .Connection.Use<MsSqlConnectionFactory>();
            //end registrations using builder

            builder.Build();

            //begin direct registrations in database service collection
            dbServices.TryAddSingleton<SqlStatementAssemblyOptions>();
            dbServices.TryAddSingleton<LoggingOptions>();
            dbServices.TryAddSingleton<IDbTypeMapFactory<SqlDbType>, MsSqlTypeMapFactory>();
            dbServices.TryAddSingleton<IQueryExpressionBuilderFactory, MsSqlQueryExpressionBuilderFactory>();
            dbServices.TryAddTransient<AssemblyContext>(sp => sp.GetRequiredService<SqlStatementAssemblyOptions>().ToAssemblyContext());
            dbServices.TryAddSingleton<PipelineEventHooks>();
            dbServices.TryAddSingleton<IExpandoObjectMapper, ExpandoObjectMapper>();
            dbServices.TryAddSingleton<ISqlDatabaseMetadataProvider>(sp => sp.GetRequiredService<TDatabase>().MetadataProvider);

            //begin direct registrations in root service collection
            registrar.Services.TryAddSingleton<ILoggerFactory, NullLoggerFactory>();
            registrar.Services.TryAddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
            registrar.Services.AddSingleton<TDatabase>(sp =>
                {
                    try
                    {
                        return (TDatabase)Activator.CreateInstance(
                            typeof(TDatabase),
                            sp.GetServiceProviderFor<TDatabase>().GetRequiredService<IQueryExpressionBuilderFactory>(),
                            sp.GetServiceProviderFor<TDatabase>().GetRequiredService<ISqlConnectionFactory>()
                        )!;
                    }
                    catch (Exception e)
                    {
                        //There are defaults for all configuration except connection strings.  Likely with this exception there is no connection string factory.
                        //As this is in startup, and an exception will be thrown either way, try and resolve a connection string to see if a better error message
                        //can be returned/thrown.
                        if (sp.GetServiceProviderFor<TDatabase>().GetService(typeof(IConnectionStringFactory)) is null)
                            throw new DbExpressionConfigurationException($"Initialization of runtime database {typeof(TDatabase)} failed.  " +
                                $"A connection string factory has not been properly registered.  Please ensure a connection string, or a delegate providing a connection string, has been provided.");

                        throw new DbExpressionConfigurationException($"Could not create an instance of database {typeof(TDatabase)}, see inner exception for details.", e);
                    }
                }
            );
            registrar.Services.AddSingleton<IServiceProvider<TDatabase>>(sp => dbServices.BuildServiceProvider(sp));
        }

        public static IServiceProvider GetServiceProviderFor<TDatabase>(this IServiceProvider sp)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            return sp.GetService<IServiceProvider<TDatabase>>()!;
        }

        private static void UseDelegateQueryExpressionFactoryWithDefaults<TDatabase>(this IQueryExpressionFactoryConfigurationBuilder<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder.Use(sp => new DefaultQueryExpressionFactoryWithDiscovery(
                    sp.GetRequiredService<ILogger<DefaultQueryExpressionFactoryWithDiscovery>>(),
                    t => sp.GetService(t) as QueryExpression //null returns are managed by the factory
                ),
                x => x.WithDefaults()
            );
        }

        private static IEntitiesConfigurationBuilderGrouping<TDatabase> UseDelegateEntityFactoryWithDiscovery<TDatabase>(this IEntitiesConfigurationBuilderGrouping<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder.Creation.Use(sp => new DefaultEntityFactoryWithFallbackConstruction(
                    sp.GetRequiredService<ILogger<DefaultEntityFactoryWithFallbackConstruction>>(),
                    t => sp.GetService(t) as IDbEntity //null returns are managed by the factory
                ) 
            );
            return builder;
        }

        private static IEntitiesConfigurationBuilderGrouping<TDatabase> UseDelegateMapperFactoryWithDiscovery<TDatabase>(this IEntitiesConfigurationBuilderGrouping<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder.Mapping.Use(
                sp => new DefaultMapperFactoryWithDiscovery(
                    sp.GetRequiredService<ILogger<DefaultMapperFactoryWithDiscovery>>(),
                    t => (sp.GetService(t) as IEntityMapper)!, //null returns are managed by the factory
                    () => sp.GetService<IExpandoObjectMapper>() ?? throw CreateNullServiceException("Entities", typeof(IExpandoObjectMapper))
                )
            );
            return builder;
        }

        private static void UseDelegateValueConverterFactoryWithDiscoveryWithDefaults<TDatabase>(this IValueConverterFactoryConfigurationBuilder<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder.Use(sp => new DefaultValueConverterFactoryWithDiscovery(
                    sp.GetRequiredService<ILogger<DefaultValueConverterFactoryWithDiscovery>>(),
                    t => sp.GetService(t) as IValueConverter //null returns are managed by the factory
                ),
                x => x.WithDefaults()
            );
        }

        private static ISqlStatementsConfigurationBuilderGrouping<TDatabase> UseDelegateExpressionElementAppenderFactoryWithDefaults<TDatabase>(this ISqlStatementsConfigurationBuilderGrouping<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder.Assembly.ElementAppender.Use(sp => new DefaultExpressionElementAppenderFactoryWithDiscovery(
                    sp.GetRequiredService<ILogger<DefaultExpressionElementAppenderFactoryWithDiscovery>>(),
                    t => (sp.GetService(t) as IExpressionElementAppender)! //null returns are managed by the factory
                ),
                x => MsSqlServices.WithDefaults(x)
            );
            return builder;
        }

        private static ISqlStatementsConfigurationBuilderGrouping<TDatabase> UseDelegateQueryExecutionPipelineFactoryWithDefaults<TDatabase>(this ISqlStatementsConfigurationBuilderGrouping<TDatabase> builder)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            builder.Assembly.QueryExecution.Pipeline.Use(sp => new DelegateQueryExecutionPipelineFactory(
                t => sp.GetService(t) as IQueryExecutionPipeline
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
