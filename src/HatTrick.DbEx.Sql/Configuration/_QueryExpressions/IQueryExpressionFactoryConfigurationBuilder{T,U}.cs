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

using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IQueryExpressionFactoryConfigurationBuilder<TDatabase, TQuery>
        where TDatabase : class, ISqlDatabaseRuntime
        where TQuery : QueryExpression
    {
        /// <summary>
        /// For queries requiring a <typeparamref name="TQuery"/>, use the provided query expression. 
        /// </summary>
        /// <typeparam name="T">The query expression type to use in place of <typeparamref name="TQuery"/>.</param>
        IQueryExpressionFactoryContinuationConfigurationBuilder<TDatabase> Use<T>()
            where T : TQuery, new();

        /// <summary>
        /// For queries requiring a <typeparamref name="TQuery"/>, use the provided query expression. 
        /// </summary>
        /// <param name="factory">The delegate to use to create a query expression to use in place of <typeparamref name="TQuery"/>.</param>
        IQueryExpressionFactoryContinuationConfigurationBuilder<TDatabase> Use<T>(Func<T> factory)
            where T : TQuery;

        /// <summary>
        /// For queries requiring a <typeparamref name="TQuery"/>, use the provided query expression. 
        /// </summary>
        /// <param name="factory">The delegate to use to create a query expression to use in place of <typeparamref name="TQuery"/>.</param>
        IQueryExpressionFactoryContinuationConfigurationBuilder<TDatabase> Use<T>(Func<IServiceProvider, T> factory)
            where T : TQuery;
    }
}
