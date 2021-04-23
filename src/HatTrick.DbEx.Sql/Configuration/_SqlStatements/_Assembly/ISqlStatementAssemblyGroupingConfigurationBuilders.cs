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

﻿using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlStatementAssemblyGroupingConfigurationBuilders : ISqlStatementConfigurationBuilderExecutionGrouping
    {
        /// <summary>
        /// Configure the factory used for creating an appender used to emit elements of a query expression into a resulting sql statement.
        /// </summary>
        IAppenderFactoryConfigurationBuilder StatementAppender { get; }

        /// <summary>
        /// Configure the factory used for appending the elements of a query expression to a sql statement writer.
        /// </summary>
        IExpressionElementAppenderFactoryConfigurationBuilder ElementAppender { get; }

        /// <summary>
        /// Configure the factory used for creating the parameters used in a parameterized sql statement.
        /// </summary>
        ISqlParameterBuilderFactoryConfigurationBuilder ParameterBuilder { get; }

        /// <summary>
        /// Configure the factory used to create the builder responsible for creating a sql statement from a query expression.
        /// </summary>
        ISqlStatementBuilderFactoryConfigurationBuilder StatementBuilder { get; }

        /// <summary>
        /// Configure the factory used to create the assembler responsible for assembling a sql statement from a query expression.
        /// </summary>
        ISqlStatementAssemblerFactoryConfigurationBuilder StatementAssembler { get; }

        /// <summary>
        /// Configure the settings used to construct a sql statement.
        /// </summary>
        /// <param name="configure">Configure the settings used while constructing sql statements.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders ConfigureOutputSettings(Action<SqlStatementAssemblerConfiguration> configure);
    }
}
