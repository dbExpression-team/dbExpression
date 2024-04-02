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

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace DbExpression.Sql.Converter
{
    public sealed class DefaultValueConverterFactoryWithDiscovery : IValueConverterFactory
    {
        #region internals
        private readonly ILogger<DefaultValueConverterFactoryWithDiscovery> logger;
        private readonly Func<Type, IValueConverter?> overrides;

        private readonly ConcurrentDictionary<TypeDictionaryKey, Type?> converterTypes = new();
        private readonly ConcurrentDictionary<TypeDictionaryKey, IValueConverter> defaultConverters = new();
        #endregion

        #region constructors
        public DefaultValueConverterFactoryWithDiscovery(
            ILogger<DefaultValueConverterFactoryWithDiscovery> logger, 
            Func<Type, IValueConverter?> overrides
        )
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.overrides = overrides ?? throw new ArgumentNullException(nameof(overrides));
        }
        #endregion

        #region methods
        public IValueConverter<T> CreateConverter<T>()
        {
            var converter = CreateConverter(typeof(T));
            return (converter as IValueConverter<T>)!;
        }

        public IValueConverter CreateConverter(Type type)
        {
            if (TryResolveValueConverter(type, out IValueConverter? converter))
                return converter!;

            return DbExpressionConfigurationException.ThrowServiceResolutionWithReturn<IValueConverter>();
        }

        private bool TryResolveValueConverter(Type type, out IValueConverter? converter)
        {
            converter = default;
            try
            {
                converter = ResolveValueConverter(type, type);
                if (converter is not null)
                {
                    return true;
                }
                if (TryCreateValueConverter(type, out converter))
                    defaultConverters.TryAdd(new TypeDictionaryKey(type.TypeHandle.Value), converter!);
            }
            catch
            {
                if (logger.IsEnabled(LogLevel.Warning))
                    logger.LogWarning("Resolving a value converter for {converterType} failed.", type);
                return false;
            }
            return converter is not null;
        }

        private IValueConverter? ResolveValueConverter(Type currentType, Type requestedType)
        {
            if (currentType is null)
                return null;

            var key = new TypeDictionaryKey(currentType.TypeHandle.Value);
            if (!converterTypes.TryGetValue(key, out Type? _))
            {
                converterTypes.TryAdd(key, typeof(IValueConverter<>).MakeGenericType(new[] { currentType }));
            }

            if (defaultConverters.TryGetValue(key, out IValueConverter? converter))
            {
                return converter;
            }

            var @override = overrides(converterTypes[key]!);
            if (@override is not null)
            {
                return @override;
            }

            if (IsEnum(currentType))
                return null;

            if (currentType.BaseType is null)
                return null;

            return ResolveValueConverter(currentType.BaseType, requestedType);
        }

        private bool TryCreateValueConverter(Type type, out IValueConverter? converter)
        {
            converter = default;
            try
            {
                converter = IsEnum(type) ? CreateEnumValueConverter(type) : CreateValueConverter(type);

                if (converter is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Adding value converter {converterType} to internal cache.", converter.GetType());
                    defaultConverters.TryAdd(new TypeDictionaryKey(type.TypeHandle.Value), converter);
                }
                return converter is not null;
            }
            catch (Exception ex)
            {
                if (logger.IsEnabled(LogLevel.Warning))
                    logger.LogWarning(ex, "Creating a value converter for {converterType} failed.", type);
                return false;
            }
        }

        private IValueConverter? CreateValueConverter(Type type)
        {
            if (type.IsNullableType())
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Creating a value converter for {valueType} using type {converterType}.", type, typeof(NullableValueConverter<>));
                return Activator.CreateInstance(typeof(NullableValueConverter<>).MakeGenericType(new[] { type })) as IValueConverter;
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating a value converter for {valueType} using type {converterType}.", type, typeof(ValueConverter<>));
            return Activator.CreateInstance(typeof(ValueConverter<>).MakeGenericType(new[] { type })) as IValueConverter;
        }

        private IValueConverter? CreateEnumValueConverter(Type type)
        {
            if (type.IsNullableType())
            {
                if (logger.IsEnabled(LogLevel.Trace))
                    logger.LogTrace("Creating a value converter for {enumType} using type {converterType}.", type, typeof(NullableEnumValueConverter<>));
                return Activator.CreateInstance(typeof(NullableEnumValueConverter<>).MakeGenericType(new[] { type })) as IValueConverter;
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating a value converter for {enumType} using type {converterType}.", type, typeof(EnumValueConverter<>));
            return Activator.CreateInstance(typeof(EnumValueConverter<>).MakeGenericType(new[] { type })) as IValueConverter;
        }

        private bool IsEnum(Type type)
        {
            if (type.IsEnum)
                return true;

            var nullable = Nullable.GetUnderlyingType(type);
            if (nullable is not null && nullable.IsEnum)
                return true;

            return false;
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
