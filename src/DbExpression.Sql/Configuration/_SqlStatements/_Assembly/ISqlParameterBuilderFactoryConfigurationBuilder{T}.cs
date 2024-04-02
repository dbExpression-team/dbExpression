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
    public interface ISqlParameterBuilderFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use a custom factory for creating a builder for creating parameters used in a parameterized sql statement.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use<TSqlParameterBuilder>()
            where TSqlParameterBuilder : class, ISqlParameterBuilder;

        /// <summary>
        /// Use the provided delegate to create a builder for creating parameters used in a parameterized sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="ISqlParameterBuilder"/>.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<ISqlParameterBuilder> factory);

        /// <summary>
        /// Use the service provider to create a builder for creating parameters used in a parameterized sql statement.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="ISqlParameterBuilder"/>.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, ISqlParameterBuilder> factory);
    }
}
