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
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlStatementBuilderFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use the specified builder for building sql statements.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use<TBuilder>()
            where TBuilder : class, ISqlStatementBuilder;

        /// <summary>
        /// Use the provided delegate to provide a builder for building sql statements.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<ISqlStatementBuilder> factory);

        /// <summary>
        /// Use the service provider to provide a builder for building sql statements.
        /// </summary>
        ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, ISqlStatementBuilder> factory);
    }
}
