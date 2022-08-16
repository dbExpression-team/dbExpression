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
    public interface IQueryExpressionFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use a custom factory to create query expressions used in fluent builders.
        /// </summary>
        void Use(IQueryExpressionFactory factory);

        /// <summary>
        /// Use the specified factory to create query expressions used in fluent builders.
        /// </summary>
        void Use<TQueryExpressionFactory>()
            where TQueryExpressionFactory : class, IQueryExpressionFactory;

        /// <summary>
        /// Use the provided factory to create query expressions used in fluent builders.
        /// </summary>
        void Use(Func<IQueryExpressionFactory> factory);

        /// <summary>
        /// Use the service provider to create query expressions used in fluent builders.
        /// </summary>
        void Use(Func<IServiceProvider, IQueryExpressionFactory> factory);

        /// <summary>
        /// Use the service provider to resolve a factory responsible for creating query expressions used in fluent builders.
        /// </summary>
        void Use(Func<IServiceProvider, IQueryExpressionFactory> factory, Action<IQueryExpressionContinuationConfigurationBuilder<TDatabase>> configureFactory);

        /// <summary>
        /// Use the service provider to resolve query expressions used in fluent builders.
        /// </summary>
        void Use(Func<IServiceProvider, Type, QueryExpression> factory);

        /// <summary>
        /// Use the service provider to resolve query expressions used in fluent builders and provide overrides for specific query expression types.
        /// </summary>
        void Use(Func<IServiceProvider, Type, QueryExpression> factory, Action<IQueryExpressionContinuationConfigurationBuilder<TDatabase>> configureFactory);

        /// <summary>
        /// Provide overrides for specific query expression types.
        /// </summary>
        /// <remarks>
        /// Typically used when the factory has already been specified, and overrides to that factory are needed.
        /// This simply registers each provided type with the service provider.
        /// <para>
        /// <strong>NOTE:</strong> Based on the type of <see cref="IQueryExpressionFactory{TDatabase}"/> used, this may or may not provide the desired
        /// results from the overrides - use when you are certain the registered <see cref="IQueryExpressionFactory{TDatabase}"/> uses the service
        /// provider to resolve query expressions.  The default <see cref="IQueryExpressionFactory{TDatabase}"/> honors the overrides provided.
        /// </para>
        /// </remarks>
        void ForQueryTypes(Action<IQueryExpressionContinuationConfigurationBuilder<TDatabase>> configureQueryTypes);
    }
}
