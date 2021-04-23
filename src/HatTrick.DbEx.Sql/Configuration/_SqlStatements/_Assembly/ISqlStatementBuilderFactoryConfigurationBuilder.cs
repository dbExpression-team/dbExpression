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

using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlStatementBuilderFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory for creating a builder responsible for creating a sql statement from a query expression.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use(ISqlStatementBuilderFactory factory);

        /// <summary>
        /// Use a custom factory for creating a builder responsible for creating a sql statement from a query expression.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use<TSqlStatementBuilderFactory>()
            where TSqlStatementBuilderFactory : class, ISqlStatementBuilderFactory, new();

        /// <summary>
        /// Use a custom factory for creating a builder responsible for creating a sql statement from a query expression.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating a <see cref="ISqlStatementBuilder"/> given a plethora of other things.</param>
        ISqlStatementAssemblyGroupingConfigurationBuilders Use(Func<RuntimeSqlDatabaseConfiguration, QueryExpression, ISqlStatementBuilder> factory);

        /// <summary>
        /// Use the default factory for creating a builder responsible for creating a sql statement from a query expression.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders UseDefaultFactory();
    }
}
