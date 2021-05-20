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

﻿using HatTrick.DbEx.MsSql.Assembler;
using HatTrick.DbEx.MsSql.Connection;
using HatTrick.DbEx.MsSql.Types;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Configuration;
using System;

namespace HatTrick.DbEx.MsSql.Configuration
{
    public static partial class DatabaseConfigurationBuilderExtensions
    {
        #region 2005
        /// <summary>
        /// Configures dbExpression to use a SqlServer 2005 database.
        /// </summary>
        /// <typeparam name="T">The (code-generated) database you want to configure for use with dbExpression.</typeparam>
        /// <param name="builder">The <see cref="IDbExpressionConfigurationBuilder" />, the fluent entry point for configuring the runtime environment for <typeparam name="T">. </param>
        /// <param name="configureRuntime">
        ///     <para>A delegate to configure the <see cref="RuntimeSqlDatabaseConfiguration" /> using a <see cref="IRuntimeSqlDatabaseConfigurationBuilder"/>.</para>
        /// </param>        
        public static void AddMsSql2005Database<T>(this IDbExpressionConfigurationBuilder builder, Action<IRuntimeSqlDatabaseConfigurationBuilder> configureRuntime)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();

            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);
            configBuilder.ConfigureMsSqlCommon(b => 
                { 
                    b.SqlStatements.Assembly.StatementAssembler.Use<Assembler.v2005.MsSqlStatementAssemblerFactory>(); 
                    configureRuntime.Invoke(b); 
                }, 
                runtime.Metadata
            );
            config.Validate();

            runtime.Database.UseConfigurationFactory(new DelegateRuntimeSqlDatabaseConfigurationFactory(() => config));
        }
        #endregion

        #region 2008
        /// <summary>
        /// Configures dbExpression to use a SqlServer 2008 database.
        /// </summary>
        /// <typeparam name="T">The (code-generated) database you want to configure for use with dbExpression.</typeparam>
        /// <param name="builder">The <see cref="IDbExpressionConfigurationBuilder" />, the fluent entry point for configuring the runtime environment for <typeparam name="T">. </param>
        /// <param name="configureRuntime">
        ///     <para>A delegate to configure the <see cref="RuntimeSqlDatabaseConfiguration" /> using a <see cref="IRuntimeSqlDatabaseConfigurationBuilder"/>.</para>
        /// </param>        
        public static void AddMsSql2008Database<T>(this IDbExpressionConfigurationBuilder builder, Action<IRuntimeSqlDatabaseConfigurationBuilder> configureRuntime)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();

            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);
                configBuilder.ConfigureMsSqlCommon(b =>
                {
                    b.SqlStatements.Assembly.StatementAssembler.Use<Assembler.v2008.MsSqlStatementAssemblerFactory>();
                    configureRuntime.Invoke(b);
                },
                runtime.Metadata
            );
            config.Validate();

            runtime.Database.UseConfigurationFactory(new DelegateRuntimeSqlDatabaseConfigurationFactory(() => config));
        }
        #endregion

        #region 2012
        /// <summary>
        /// Configures dbExpression to use a SqlServer 2012 database.
        /// </summary>
        /// <typeparam name="T">The (code-generated) database you want to configure for use with dbExpression.</typeparam>
        /// <param name="builder">The <see cref="IDbExpressionConfigurationBuilder" />, the fluent entry point for configuring the runtime environment for <typeparam name="T">. </param>
        /// <param name="configureRuntime">
        ///     <para>A delegate to configure the <see cref="RuntimeSqlDatabaseConfiguration" /> using a <see cref="IRuntimeSqlDatabaseConfigurationBuilder"/>.</para>
        /// </param>        
        public static void AddMsSql2012Database<T>(this IDbExpressionConfigurationBuilder builder, Action<IRuntimeSqlDatabaseConfigurationBuilder> configureRuntime)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();

            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);
            configBuilder.ConfigureMsSqlCommon(configureRuntime, runtime.Metadata);
            config.Validate();

            runtime.Database.UseConfigurationFactory(new DelegateRuntimeSqlDatabaseConfigurationFactory(() => config));
        }
        #endregion

        #region 2014
        /// <summary>
        /// Configures dbExpression to use a SqlServer 2014 database.
        /// </summary>
        /// <typeparam name="T">The (code-generated) database you want to configure for use with dbExpression.</typeparam>
        /// <param name="builder">The <see cref="IDbExpressionConfigurationBuilder" />, the fluent entry point for configuring the runtime environment for <typeparam name="T">. </param>
        /// <param name="configureRuntime">
        ///     <para>A delegate to configure the <see cref="RuntimeSqlDatabaseConfiguration" /> using a <see cref="IRuntimeSqlDatabaseConfigurationBuilder"/>.</para>
        /// </param>        
        public static void AddMsSql2014Database<T>(this IDbExpressionConfigurationBuilder builder, Action<IRuntimeSqlDatabaseConfigurationBuilder> configureRuntime)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();

            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);
            configBuilder.ConfigureMsSqlCommon(configureRuntime, runtime.Metadata);
            config.Validate();

            runtime.Database.UseConfigurationFactory(new DelegateRuntimeSqlDatabaseConfigurationFactory(() => config));
        }
        #endregion

        #region 2016
        /// <summary>
        /// Configures dbExpression to use a SqlServer 2016 database.
        /// </summary>
        /// <typeparam name="T">The (code-generated) database you want to configure for use with dbExpression.</typeparam>
        /// <param name="builder">The <see cref="IDbExpressionConfigurationBuilder" />, the fluent entry point for configuring the runtime environment for <typeparam name="T">. </param>
        /// <param name="configureRuntime">
        ///     <para>A delegate to configure the <see cref="RuntimeSqlDatabaseConfiguration" /> using a <see cref="IRuntimeSqlDatabaseConfigurationBuilder"/>.</para>
        /// </param>        
        public static void AddMsSql2016Database<T>(this IDbExpressionConfigurationBuilder builder, Action<IRuntimeSqlDatabaseConfigurationBuilder> configureRuntime)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();

            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);
            configBuilder.ConfigureMsSqlCommon(configureRuntime, runtime.Metadata);
            config.Validate();

            runtime.Database.UseConfigurationFactory(new DelegateRuntimeSqlDatabaseConfigurationFactory(() => config));
        }
        #endregion

        #region 2017
        /// <summary>
        /// Configures dbExpression to use a SqlServer 2017 database.
        /// </summary>
        /// <typeparam name="T">The (code-generated) database you want to configure for use with dbExpression.</typeparam>
        /// <param name="builder">The <see cref="IDbExpressionConfigurationBuilder" />, the fluent entry point for configuring the runtime environment for <typeparam name="T">. </param>
        /// <param name="configureRuntime">
        ///     <para>A delegate to configure the <see cref="RuntimeSqlDatabaseConfiguration" /> using a <see cref="IRuntimeSqlDatabaseConfigurationBuilder"/>.</para>
        /// </param>        
        public static void AddMsSql2017Database<T>(this IDbExpressionConfigurationBuilder builder, Action<IRuntimeSqlDatabaseConfigurationBuilder> configureRuntime)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();

            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);
            configBuilder.ConfigureMsSqlCommon(configureRuntime, runtime.Metadata);
            config.Validate();

            runtime.Database.UseConfigurationFactory(new DelegateRuntimeSqlDatabaseConfigurationFactory(() => config));
        }
        #endregion

        #region 2019
        /// <summary>
        /// Configures dbExpression to use a SqlServer 2019 database.
        /// </summary>
        /// <typeparam name="T">The (code-generated) database you want to configure for use with dbExpression.</typeparam>
        /// <param name="builder">The <see cref="IDbExpressionConfigurationBuilder" />, the fluent entry point for configuring the runtime environment for <typeparam name="T">. </param>
        /// <param name="configureRuntime">
        ///     <para>A delegate to configure the <see cref="RuntimeSqlDatabaseConfiguration" /> using a <see cref="IRuntimeSqlDatabaseConfigurationBuilder"/>.</para>
        /// </param>        
        public static void AddMsSql2019Database<T>(this IDbExpressionConfigurationBuilder builder, Action<IRuntimeSqlDatabaseConfigurationBuilder> configureRuntime)
            where T : class, IRuntimeEnvironmentSqlDatabase, new()
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            var runtime = new T();
            var config = new RuntimeSqlDatabaseConfiguration();

            var configBuilder = new RuntimeSqlDatabaseConfigurationBuilder(config);
            configBuilder.ConfigureMsSqlCommon(configureRuntime, runtime.Metadata);
            config.Validate();

            runtime.Database.UseConfigurationFactory(new DelegateRuntimeSqlDatabaseConfigurationFactory(() => config));
        }
        #endregion

        private static void ConfigureMsSqlCommon(this IRuntimeSqlDatabaseConfigurationBuilder builder, Action<IRuntimeSqlDatabaseConfigurationBuilder> configuration, ISqlDatabaseMetadataProvider metadata)
        {
            builder.SchemaMetadata.Use(metadata);

            builder.QueryExpressions.UseDefaultFactory();

            builder.Entities
                .Creation.UseDefaultFactory()
                .Mapping.UseDefaultFactory();

            builder.Conversions.UseDefaultFactory();

            builder.SqlStatements
                .Assembly
                    .StatementAssembler.Use<MsSqlStatementAssemblerFactory>()
                    .StatementBuilder.UseDefaultFactory()
                    .StatementAppender.UseDefaultFactory()
                    .ElementAppender.Use<MsSqlExpressionElementAppenderFactory>()
                    .ParameterBuilder.Use(new MsSqlParameterBuilderFactory(new MsSqlTypeMapFactory(), (builder as IRuntimeSqlDatabaseConfigurationProvider).Configuration.ValueConverterFactory))
                    .ConfigureOutputSettings(
                        a => a.PrependCommaOnSelectClause = false
                    )
                .Execution
                    .Executor.UseDefaultFactory()
                    .Pipeline.UseDefaultFactory()
                    .Connection.Use<MsSqlConnectionFactory>();

            configuration?.Invoke(builder);
        }
    }
}
