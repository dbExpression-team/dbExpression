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
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Assembler
{
    public sealed class DefaultExpressionElementAppenderFactoryWithDiscovery : IExpressionElementAppenderFactory
    {
        #region internals
        private readonly Func<Type, IExpressionElementAppender?> overrides;
        private readonly ConcurrentDictionary<TypeDictionaryKey, Type?> appenderTypes = new();
        #endregion

        #region constructors
        public DefaultExpressionElementAppenderFactoryWithDiscovery(Func<Type, IExpressionElementAppender?> overrides)
        {
            this.overrides = overrides ?? throw new ArgumentNullException(nameof(overrides));
        }
        #endregion

        #region methods
        public IExpressionElementAppender<T> CreateElementAppender<T>()
            where T : class, IExpressionElement
            => (CreateElementAppender(typeof(T)) as IExpressionElementAppender<T>)!;

        public IExpressionElementAppender CreateElementAppender(Type type)
        {
            if (TryResolveElementAppender(type, out IExpressionElementAppender? appender))
                return appender!;

            throw new DbExpressionConfigurationException(ExceptionMessages.ServiceResolution(type));
        }

        private bool TryResolveElementAppender(Type type, out IExpressionElementAppender? appender)
        {
            appender = default;
            try
            {
                appender = ResolveElementAppender(type, type);
            }
            catch
            {
                return false;
            }
            return appender is not null;
        }

        private IExpressionElementAppender? ResolveElementAppender(Type currentType, Type requestedType)
        {
            if (currentType is null)
                return null;

            var key = new TypeDictionaryKey(currentType.TypeHandle.Value);
            if (!appenderTypes.TryGetValue(key, out Type? _))
            {
                appenderTypes.TryAdd(key, typeof(IExpressionElementAppender<>).MakeGenericType(new[] { currentType }));
            }

            var @override = overrides(appenderTypes[key]!);
            if (@override is not null)
            {
                return @override;
            }

            if (currentType.BaseType is null)
                return null;

            return ResolveElementAppender(currentType.BaseType, requestedType);
        }
        #endregion

        #region classes
        private readonly struct TypeDictionaryKey : IEquatable<TypeDictionaryKey>
        {
            #region interface
            public readonly IntPtr Ptr;
            #endregion

            #region constructors
            public TypeDictionaryKey(IntPtr key) => Ptr = key;
            #endregion

            #region methods
            public bool Equals(TypeDictionaryKey other)
                => Ptr == other.Ptr;

            public override int GetHashCode() => Ptr.GetHashCode();

            public override bool Equals(object? obj)
                => obj is TypeDictionaryKey other && Equals(other);
            #endregion
        }
        #endregion
    }
}
