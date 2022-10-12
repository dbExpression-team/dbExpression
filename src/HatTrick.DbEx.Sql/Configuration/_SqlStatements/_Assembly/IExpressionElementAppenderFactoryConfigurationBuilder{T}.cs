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

﻿using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IExpressionElementAppenderFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use a custom factory for creating an expression element appender for appending the element's state to a sql statement writer.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(IExpressionElementAppenderFactory factory);

        /// <summary>
        /// Use a custom factory for creating an expression element appender for appending the element's state to a sql statement writer.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use<TExpressionElementAppenderFactory>()
            where TExpressionElementAppenderFactory : class, IExpressionElementAppenderFactory;

        /// <summary>
        /// Use the provided delegate to create an expression element appender for appending the element's state to a sql statement writer.
        /// </summary>
        /// <param name="factory">Returns an appender for the provided expression element type.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<Type, IExpressionElementAppender> factory);

        /// <summary>
        /// Use the service provider for creating an expression element appender for appending the element's state to a sql statement writer.
        /// </summary>
        /// <param name="factory">Returns an appender for the provided expression element type.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, Type, IExpressionElementAppender> factory);

        /// <summary>
        /// Use a custom factory for creating an expression element appender for appending the element's state to a sql statement writer.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IExpressionElementAppenderFactory> factory);

        /// <summary>
        /// Use a custom factory for creating an expression element appender for appending the element's state to a sql statement writer.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, IExpressionElementAppenderFactory> factory);

        /// <summary>
        /// Use a custom factory for creating an expression element appender for appending the element's state to a sql statement writer.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, IExpressionElementAppenderFactory> factory, Action<IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase>> configureElementTypes);

        /// <summary>
        /// Configure specific element types that are returned from a configured <see cref="IExpressionElementAppenderFactory"/> factory.
        /// </summary>
        /// <param name="configureElementTypes">A delegate allowing configuration of specific expression element types.</param>
        /// <remarks>
        /// Typically used when the factory has already been specified, and overrides to that factory are needed.
        /// This simply registers each provided type with the service provider.
        /// <para>
        /// <strong>NOTE:</strong> Based on the type of <see cref="IExpressionElementAppenderFactory"/> used, this may or may not provide the desired
        /// results from the overrides - use when you are certain the registered <see cref="IExpressionElementAppenderFactory"/> uses the service
        /// provider to create new instances of expression element appenders.  The default <see cref="IExpressionElementAppenderFactory"/> honors the overrides provided.
        /// </para>
        /// </remarks>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> ForElementTypes(Action<IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase>> configureElementTypes);
    }
}
