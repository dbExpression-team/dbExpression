#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

﻿using DbExpression.Sql.Assembler;
using System;

namespace DbExpression.Sql.Configuration
{
    public interface IAppenderFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use a custom factory for creating an appender used to write the state of expression elements as part of a sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IAppender"/>.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use<TAppender>()
            where TAppender : class, IAppender;

        /// <summary>
        /// Use a custom factory for creating an appender used to write the state of expression elements as part of a sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IAppender"/>.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IAppender> factory);

        /// <summary>
        /// Use the service provider for creating an appender used to write the state of expression elements as part of a sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IAppender"/>.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, IAppender> factory);
    }
}
