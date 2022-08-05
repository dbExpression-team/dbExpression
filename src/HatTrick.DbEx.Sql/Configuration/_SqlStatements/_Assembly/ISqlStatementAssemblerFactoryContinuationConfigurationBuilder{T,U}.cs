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
    public interface ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase, TQuery>
        where TDatabase : class, ISqlDatabaseRuntime
        where TQuery : QueryExpression
    {
        /// <summary>
        /// Use the provided assembler for <typeparamref name="TQuery"/> query expressions.
        /// </summary>
        ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase> Use(ISqlStatementAssembler<TDatabase, TQuery> assembler);

        /// <summary>
        /// Use the <typeparamref name="TAssembler"/> assembler for <typeparamref name="TQuery"/> query expressions.
        /// </summary>
        ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase> Use<TAssembler>()
            where TAssembler : class, ISqlStatementAssembler<TDatabase, TQuery>;

        /// <summary>
        /// Use this delegate to create assemblers for <typeparamref name="TQuery"/> query expressions.
        /// </summary>
        ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<ISqlStatementAssembler<TDatabase, TQuery>> factory);

        /// <summary>
        /// Use the service provider to create assemblers for <typeparamref name="TQuery"/> query expressions.
        /// </summary>
        ISqlStatementAssemblerFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, ISqlStatementAssembler<TDatabase, TQuery>> factory);

    }
}
