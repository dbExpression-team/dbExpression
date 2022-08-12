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

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Expression
{
    public class DefaultQueryExpressionFactoryWithDiscovery<TDatabase> : IQueryExpressionFactory<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly ILogger<DefaultQueryExpressionFactoryWithDiscovery<TDatabase>> logger;
        private readonly Func<Type, QueryExpression?> overrides;
        private readonly ConcurrentDictionary<Type, Func<Type, QueryExpression?>> factories = new();
        #endregion

        #region constructors
        public DefaultQueryExpressionFactoryWithDiscovery(ILogger<DefaultQueryExpressionFactoryWithDiscovery<TDatabase>> logger, Func<Type, QueryExpression?> overrides)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.overrides = overrides ?? throw new ArgumentNullException(nameof(overrides));
        }
        #endregion

        #region methods
        public virtual TQuery CreateQueryExpression<TQuery>()
            where TQuery : QueryExpression, new()
        {
            var expression = CreateQueryExpression(typeof(TQuery));
            if (expression is not null)
                return (expression as TQuery)!;

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Query expression factory not found in internal cache or in provided overrides, creating a factory for {query} using public parameterless constructor.", typeof(TQuery));

            factories.TryAdd(typeof(TQuery), t => new TQuery());
            return (factories[typeof(TQuery)](typeof(TQuery)) as TQuery)!;
        }

        public virtual QueryExpression CreateQueryExpression(Type type)
        {
            if (TryResolveQueryExpressionFactory(type, out QueryExpression? queryExpression))
                return queryExpression!;

            throw new DbExpressionConfigurationException($"Could not resolve a query expression for type '{type}'.");
        }

        protected virtual bool TryResolveQueryExpressionFactory(Type type, out QueryExpression? queryExpression)
        {
            queryExpression = default;
            try
            {
                var factory = ResolveQueryExpressionFactory(type, type);
                if (factory is not null)
                    queryExpression = factory(type);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected virtual Func<Type, QueryExpression?>? ResolveQueryExpressionFactory(Type currentType, Type requestedType)
        {
            if (currentType is null)
                return null;

            if (factories.TryGetValue(currentType, out Func<Type, QueryExpression?>? factory))
            {
                if (currentType != requestedType)
                    factories.TryAdd(requestedType, factory);
                return factory;
            }
            
            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Query expression factory for {currentType} not found in internal cache.", currentType);

            var @override = overrides(currentType);
            if (@override is not null)
            {
                factories.TryAdd(requestedType, t => overrides(currentType));
                return factories[requestedType];
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Query expression factory for {currentType} was not resolved via provided overrides.", currentType);

            if (currentType.BaseType is null)
                return null;

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Try and resolve query expression factory for base type of {currentType}, which is {baseType}.", currentType, currentType.BaseType);

            return ResolveQueryExpressionFactory(currentType.BaseType, requestedType);
        }
        #endregion
    }
}
