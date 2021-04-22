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
    public interface IAppenderFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory for creating an appender used to emit elements of a query expression into a resulting sql statement.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use(IAppenderFactory factory);

        /// <summary>
        /// Use a custom factory for creating an appender used to emit elements of a query expression into a resulting sql statement.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use<TAppenderFactory>()
            where TAppenderFactory : class, IAppenderFactory, new();

        /// <summary>
        /// Use a custom factory for creating an appender used to emit elements of a query expression into a resulting sql statement.
        /// </summary>
        /// <param name="configureFactory">Configure the <typeparamref name="TAppenderFactory"/> factory.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use<TAppenderFactory>(Action<TAppenderFactory> configureFactory)
            where TAppenderFactory : class, IAppenderFactory, new();

        /// <summary>
        /// Use a custom factory for creating an appender used to emit elements of a query expression into a resulting sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IAppender"/>.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<IAppender> factory);

        /// <summary>
        /// Use the default factory for creating an appender used to emit elements of a query expression into a resulting sql statement.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders UseDefaultFactory();
    }
}
