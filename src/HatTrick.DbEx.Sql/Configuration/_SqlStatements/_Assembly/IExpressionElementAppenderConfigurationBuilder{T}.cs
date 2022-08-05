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
    public interface IExpressionElementAppenderConfigurationBuilder<TDatabase, TElement>
        where TDatabase : class, ISqlDatabaseRuntime
        where TElement : class, IExpressionElement
    {
        /// <summary>
        /// Use the provided expression element appender for expression elements of type <typeparamref name="TElement"/>. 
        /// </summary>
        /// <param name="appender">The custom appender that will append the state of the element to the sql statement.</param>
        IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase> Use(IExpressionElementAppender<TElement> appender);

        /// <summary>
        /// Use the provided expression element appender for expression elements of type <typeparamref name="TElement"/>. 
        /// </summary>
        /// <typeparam name="TAppender"></typeparam>The custom appender that will append the state of the element to the sql statement.</param>
        IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase> Use<TAppender>()
            where TAppender : class, IExpressionElementAppender<TElement>, new();

        /// <summary>
        /// Use the provided delegate to provide an expression element appender for expression elements of type <typeparamref name="TElement"/>. 
        /// </summary>
        /// <param name="appender"></param>A delegate providing the custom appender that will append the state of the element to the sql statement.</param>
        IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IExpressionElementAppender<TElement>> appender);

        /// <summary>
        /// Use the provided delegate to provide an expression element appender for expression elements of type <typeparamref name="TElement"/>. 
        /// </summary>
        /// <param name="appender"></param>A delegate providing the custom appender that will append the state of the element to the sql statement.</param>
        IExpressionElementAppenderFactoryContinuationConfigurationBuilder<TDatabase> Use(Func<IServiceProvider, IExpressionElementAppender<TElement>> appender);
    }
}
