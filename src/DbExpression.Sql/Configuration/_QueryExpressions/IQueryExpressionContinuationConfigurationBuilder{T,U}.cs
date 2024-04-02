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

using DbExpression.Sql.Expression;
using System;

namespace DbExpression.Sql.Configuration
{
    public interface IQueryExpressionContinuationConfigurationBuilder<TDatabase, TQuery>
        where TDatabase : class, ISqlDatabaseRuntime
        where TQuery : QueryExpression
    {
        /// <summary>
        /// Use a different query expression type for the <typeparamref name="TQuery"/> query expression.
        /// </summary>
        IQueryExpressionContinuationConfigurationBuilder<TDatabase> Use<TUseQuery>()
            where TUseQuery : TQuery;

        /// <summary>
        /// Use the provided delegate to create a query expression for the <typeparamref name="TQuery"/> query expression.
        /// </summary>
        IQueryExpressionContinuationConfigurationBuilder<TDatabase> Use(Func<TQuery> factory);

        /// <summary>
        /// Use the service provider to create a query expression for the <typeparamref name="TQuery"/> query expression.
        /// </summary>
        IQueryExpressionContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, TQuery> factory);
    }
}
