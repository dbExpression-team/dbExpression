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

namespace HatTrick.DbEx.Sql.Converter
{
    public class DefaultValueConverterFactoryWithDiscovery<TDatabase> : IValueConverterFactory<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly ILogger<DefaultValueConverterFactoryWithDiscovery<TDatabase>> logger;
        private readonly Func<Type, IValueConverter?> overrides;
        private readonly ConcurrentDictionary<Type, Func<Type, IValueConverter?>> converters = new();
        #endregion

        #region constructors
        public DefaultValueConverterFactoryWithDiscovery(
            ILogger<DefaultValueConverterFactoryWithDiscovery<TDatabase>> logger, 
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

            throw new DbExpressionConfigurationException($"Could not resolve a value converter for type '{type}'.");
        }

        protected virtual bool TryResolveValueConverter(Type type, out IValueConverter? converter)
        {
            converter = default;
            try
            {
                var factory = ResolveValueConverter(type, type);
                if (factory is not null)
                {
                    converter = factory(type);
                    return true;
                }
                TryCreateValueConverter(type, out converter);
            }
            catch
            {
                if (logger.IsEnabled(LogLevel.Warning))
                    logger.LogWarning("Resolving a value converter for {converterType} failed.", type);
                return false;
            }
            return converter is not null;
        }

        protected virtual Func<Type, IValueConverter?>? ResolveValueConverter(Type currentType, Type requestedType)
        {
            if (converters.TryGetValue(currentType, out Func<Type, IValueConverter?>? converter))
            {
                if (currentType != requestedType)
                    converters.TryAdd(requestedType, converter);
                return converter;
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Value converer for {currentType} not found in internal cache.", currentType);

            var converterType = typeof(IValueConverter<>).MakeGenericType(new[] { currentType });
            var @override = overrides(converterType);
            if (@override is not null)
            {
                converters.TryAdd(requestedType, t => overrides(converterType));
                return converters[requestedType];
            }

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Value converter for {currentType} was not resolved via provided overrides.", currentType);

            if (IsEnum(currentType))
                return null;

            if (currentType.BaseType is null)
                return null;

            return ResolveValueConverter(currentType.BaseType, requestedType);
        }

        protected virtual bool TryCreateValueConverter(Type type, out IValueConverter? converter)
        {
            converter = default;
            IValueConverter? created = null;
            try
            {
                created = IsEnum(type) ? CreateEnumValueConverter(type) : CreateValueConverter(type);

                if (created is not null)
                {
                    if (logger.IsEnabled(LogLevel.Trace))
                        logger.LogTrace("Adding value converter {converterType} to internal cache.", created.GetType());
                    converters.TryAdd(type, t => created);
                    converter = created;
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

        protected virtual IValueConverter? CreateValueConverter(Type type)
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

        protected virtual IValueConverter? CreateEnumValueConverter(Type type)
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

        protected virtual bool IsEnum(Type type)
        {
            if (type.IsEnum)
                return true;

            var nullable = Nullable.GetUnderlyingType(type);
            if (nullable is not null && nullable.IsEnum)
                return true;

            return false;
        }
        #endregion
    }
}
