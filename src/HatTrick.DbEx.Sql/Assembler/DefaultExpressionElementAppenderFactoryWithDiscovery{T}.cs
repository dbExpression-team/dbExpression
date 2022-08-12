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
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DefaultExpressionElementAppenderFactoryWithDiscovery<TDatabase> : IExpressionElementAppenderFactory<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly ILogger<DefaultExpressionElementAppenderFactoryWithDiscovery<TDatabase>> logger;
        private readonly Func<Type, IExpressionElementAppender?> overrides;
        private readonly ConcurrentDictionary<Type, Func<Type, IExpressionElementAppender?>> appenders = new();
        #endregion

        #region constructors
        public DefaultExpressionElementAppenderFactoryWithDiscovery(ILogger<DefaultExpressionElementAppenderFactoryWithDiscovery<TDatabase>> logger, Func<Type, IExpressionElementAppender> overrides)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.overrides = overrides ?? throw new ArgumentNullException(nameof(overrides));
        }
        #endregion

        #region methods
        public virtual IExpressionElementAppender<T> CreateElementAppender<T>()
            where T : class, IExpressionElement
            => (CreateElementAppender(typeof(T)) as IExpressionElementAppender<T>)!;

        public virtual IExpressionElementAppender CreateElementAppender(Type type)
        {
            if (TryResolveElementAppender(type, out IExpressionElementAppender? appender))
                return appender!;

            throw new DbExpressionConfigurationException($"Could not resolve an element appender for type '{type}'.");
        }

        protected virtual bool TryResolveElementAppender(Type type, out IExpressionElementAppender? appender)
        {
            appender = default;
            try
            {
                var factory = ResolveElementAppender(type, type);
                if (factory is not null)
                    appender = factory(type);
            }
            catch
            {
                return false;
            }
            return appender is not null;
        }

        protected virtual Func<Type, IExpressionElementAppender?>? ResolveElementAppender(Type currentType, Type requestedType)
        {
            if (currentType is null)
                return null;

            if (appenders.TryGetValue(currentType, out Func<Type, IExpressionElementAppender?>? factory))
            {
                if (currentType != requestedType)
                    appenders.TryAdd(requestedType, factory);
                return factory;
            }

            var elementAppenderType = typeof(IExpressionElementAppender<>).MakeGenericType(new[] { currentType });
            var @override = overrides(elementAppenderType);
            if (@override is not null)
            {
                appenders.TryAdd(requestedType, t => overrides(elementAppenderType));
                return appenders[requestedType];
            }

            if (currentType.BaseType is null)
                return null;

            return ResolveElementAppender(currentType.BaseType, requestedType);
        }
        #endregion
    }
}
