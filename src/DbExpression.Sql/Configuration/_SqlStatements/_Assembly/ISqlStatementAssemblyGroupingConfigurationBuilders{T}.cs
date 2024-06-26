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

﻿using System;

namespace DbExpression.Sql.Configuration
{
    public interface ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> : ISqlStatementConfigurationBuilderExecutionGrouping<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Configure the services used for creating an appender used to emit elements of a query expression into a resulting sql statement.
        /// </summary>
        IAppenderFactoryConfigurationBuilder<TDatabase> StatementAppender { get; }

        /// <summary>
        /// Configure the services used for appending the elements of a query expression to a sql statement writer.
        /// </summary>
        IExpressionElementAppenderFactoryConfigurationBuilder<TDatabase> ElementAppender { get; }

        /// <summary>
        /// Configure the services used for creating the parameters used in a parameterized sql statement.
        /// </summary>
        ISqlParameterBuilderFactoryConfigurationBuilder<TDatabase> ParameterBuilder { get; }

        /// <summary>
        /// Configure the services used to create the builder responsible for creating a sql statement from a query expression.
        /// </summary>
        ISqlStatementBuilderFactoryConfigurationBuilder<TDatabase> StatementBuilder { get; }

        /// <summary>
        /// Configure the settings used to construct a sql statement.
        /// </summary>
        /// <param name="configure">Configure the settings used while constructing sql statements.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> ConfigureAssemblyOptions(Action<SqlStatementAssemblyOptions> configure);
    }
}
