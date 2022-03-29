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
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Reflection;

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
        /// <param name="configureRuntime">A delegate to configure the <see cref="MsSqlSqlDatabaseRuntimeConfiguration" /> using a <see cref="ISqlDatabaseRuntimeConfigurationBuilder"/>.</param>        
        public static void AddMsSql2005Database<TDatabase>(this IDbExpressionConfigurationBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            builder.ConfigureMsSqlCommon<TDatabase, MsSqlSqlDatabaseRuntimeConfiguration>(
                b =>
                {
                    b.SqlStatements.Assembly.StatementAssembler.Use<Assembler.v2005.MsSqlStatementAssemblerFactory>();
                    b.SqlStatements.Assembly.ElementAppender.Use<MsSqlExpressionElementAppenderFactory>(f => f.RegisterElementAppender<TrimFunctionExpression, Assembler.v2005.TrimFunctionExpressionAppender>());
                    configureRuntime.Invoke(b);
                }
            );
        }
        #endregion

        #region 2008
        /// <summary>
        /// Configures dbExpression to use a SqlServer 2008 database.
        /// </summary>
        /// <typeparam name="T">The (code-generated) database you want to configure for use with dbExpression.</typeparam>
        /// <param name="builder">The <see cref="IDbExpressionConfigurationBuilder" />, the fluent entry point for configuring the runtime environment for <typeparam name="T">. </param>
        /// <param name="configureRuntime">A delegate to configure the <see cref="MsSqlSqlDatabaseRuntimeConfiguration" /> using a <see cref="ISqlDatabaseRuntimeConfigurationBuilder"/>.</param>        
        public static void AddMsSql2008Database<TDatabase>(this IDbExpressionConfigurationBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            builder.ConfigureMsSqlCommon<TDatabase, MsSqlSqlDatabaseRuntimeConfiguration>(
                b =>
                {
                    b.SqlStatements.Assembly.StatementAssembler.Use<Assembler.v2008.MsSqlStatementAssemblerFactory>();
                    b.SqlStatements.Assembly.ElementAppender.Use<MsSqlExpressionElementAppenderFactory>(f => f.RegisterElementAppender<TrimFunctionExpression, Assembler.v2008.TrimFunctionExpressionAppender>());
                    configureRuntime.Invoke(b);
                }
            );
        }
        #endregion

        #region 2012
        /// <summary>
        /// Configures dbExpression to use a SqlServer 2012 database.
        /// </summary>
        /// <typeparam name="T">The (code-generated) database you want to configure for use with dbExpression.</typeparam>
        /// <param name="builder">The <see cref="IDbExpressionConfigurationBuilder" />, the fluent entry point for configuring the runtime environment for <typeparam name="T">. </param>
        /// <param name="configureRuntime">A delegate to configure the <see cref="MsSqlSqlDatabaseRuntimeConfiguration" /> using a <see cref="ISqlDatabaseRuntimeConfigurationBuilder"/>.</param>        
        public static void AddMsSql2012Database<TDatabase>(this IDbExpressionConfigurationBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            builder.ConfigureMsSqlCommon<TDatabase, MsSqlSqlDatabaseRuntimeConfiguration>(
                b =>
                {
                    b.SqlStatements.Assembly.ElementAppender.Use<MsSqlExpressionElementAppenderFactory>(f => f.RegisterElementAppender<TrimFunctionExpression, Assembler.v2012.TrimFunctionExpressionAppender>());
                    configureRuntime.Invoke(b);
                }
            );
        }
        #endregion

        #region 2014
        /// <summary>
        /// Configures dbExpression to use a SqlServer 2014 database.
        /// </summary>
        /// <typeparam name="T">The (code-generated) database you want to configure for use with dbExpression.</typeparam>
        /// <param name="builder">The <see cref="IDbExpressionConfigurationBuilder" />, the fluent entry point for configuring the runtime environment for <typeparam name="T">. </param>
        /// <param name="configureRuntime">A delegate to configure the <see cref="MsSqlSqlDatabaseRuntimeConfiguration" /> using a <see cref="ISqlDatabaseRuntimeConfigurationBuilder"/>.</param>        
        public static void AddMsSql2014Database<TDatabase>(this IDbExpressionConfigurationBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            builder.ConfigureMsSqlCommon<TDatabase, MsSqlSqlDatabaseRuntimeConfiguration>(
                b =>
                {
                    b.SqlStatements.Assembly.ElementAppender.Use<MsSqlExpressionElementAppenderFactory>(f => f.RegisterElementAppender<TrimFunctionExpression, Assembler.v2014.TrimFunctionExpressionAppender>());
                    configureRuntime.Invoke(b);
                }
            );
        }
        #endregion

        #region 2016
        /// <summary>
        /// Configures dbExpression to use a SqlServer 2016 database.
        /// </summary>
        /// <typeparam name="T">The (code-generated) database you want to configure for use with dbExpression.</typeparam>
        /// <param name="builder">The <see cref="IDbExpressionConfigurationBuilder" />, the fluent entry point for configuring the runtime environment for <typeparam name="T">. </param>
        /// <param name="configureRuntime">A delegate to configure the <see cref="MsSqlSqlDatabaseRuntimeConfiguration" /> using a <see cref="ISqlDatabaseRuntimeConfigurationBuilder"/>.</param>        
        public static void AddMsSql2016Database<TDatabase>(this IDbExpressionConfigurationBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            builder.ConfigureMsSqlCommon<TDatabase, MsSqlSqlDatabaseRuntimeConfiguration>(
                b =>
                {
                    b.SqlStatements.Assembly.ElementAppender.Use<MsSqlExpressionElementAppenderFactory>(f => f.RegisterElementAppender<TrimFunctionExpression, Assembler.v2016.TrimFunctionExpressionAppender>());
                    configureRuntime.Invoke(b);
                }
            ); 
        }
        #endregion

        #region 2017
        /// <summary>
        /// Configures dbExpression to use a SqlServer 2017 database.
        /// </summary>
        /// <typeparam name="T">The (code-generated) database you want to configure for use with dbExpression.</typeparam>
        /// <param name="builder">The <see cref="IDbExpressionConfigurationBuilder" />, the fluent entry point for configuring the runtime environment for <typeparam name="T">. </param>
        /// <param name="configureRuntime">A delegate to configure the <see cref="MsSqlSqlDatabaseRuntimeConfiguration" /> using a <see cref="ISqlDatabaseRuntimeConfigurationBuilder"/>.</param>        
        public static void AddMsSql2017Database<TDatabase>(this IDbExpressionConfigurationBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            builder.ConfigureMsSqlCommon<TDatabase, MsSqlSqlDatabaseRuntimeConfiguration>(configureRuntime);
        }
        #endregion

        #region 2019
        /// <summary>
        /// Configures dbExpression to use a SqlServer 2019 database.
        /// </summary>
        /// <typeparam name="T">The (code-generated) database you want to configure for use with dbExpression.</typeparam>
        /// <param name="builder">The <see cref="IDbExpressionConfigurationBuilder" />, the fluent entry point for configuring the runtime environment for <typeparam name="T">. </param>
        /// <param name="configureRuntime">A delegate to configure the <see cref="MsSqlSqlDatabaseRuntimeConfiguration" /> using a <see cref="ISqlDatabaseRuntimeConfigurationBuilder"/>.</param>        
        public static void AddMsSql2019Database<TDatabase>(this IDbExpressionConfigurationBuilder builder, Action<ISqlDatabaseRuntimeConfigurationBuilder> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (configureRuntime is null)
                throw new ArgumentNullException(nameof(configureRuntime));

            builder.ConfigureMsSqlCommon<TDatabase, MsSqlSqlDatabaseRuntimeConfiguration>(configureRuntime);
        }
        #endregion

        private static void ConfigureMsSqlCommon<TDatabase, TConfig>(this IDbExpressionConfigurationBuilder _, Action<ISqlDatabaseRuntimeConfigurationBuilder> configureRuntime)
            where TDatabase : class, ISqlDatabaseRuntime
            where TConfig : MsSqlSqlDatabaseRuntimeConfiguration, new()
        {
            var config = new TConfig();

            var builder = new MsSqlSqlDatabaseRuntimeConfigurationBuilder<TConfig>(config);

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
                    .ParameterBuilder.Use(new MsSqlParameterBuilderFactory(new MsSqlTypeMapFactory(), config.ValueConverterFactory))
                .QueryExecution
                    .Executor.UseDefaultFactory()
                    .Pipeline.UseDefaultFactory()
                    .Connection.Use<MsSqlConnectionFactory>();

            configureRuntime?.Invoke(builder);

            TDatabase db;
            var ctor = typeof(TDatabase).GetConstructor(new Type[1] { typeof(TConfig) })!;
            try
            {
                db = (ctor.Invoke(new object[1] { config }) as TDatabase)!;
            }
            catch (TargetInvocationException ex)
            { 
                if (ex.InnerException is DbExpressionException dbex)
                    throw dbex;
                throw new DbExpressionException($"Configuration of runtime databse type '{typeof(TDatabase)}' failed.", ex);
            }
            db.InitializeStaticRuntime();
        }
    }
}
