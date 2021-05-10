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

using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class DelegateValueConverterFactory : IValueConverterFactory
    {
        #region internals
        private readonly Func<Type, IValueConverter> factory;
        #endregion

        #region constructors
        public DelegateValueConverterFactory(Func<Type, IValueConverter> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        #endregion

        #region methods
        public IValueConverter CreateConverter<T>()
            => factory(typeof(T)) ?? throw new DbExpressionConfigurationException($"Could not resolve a converter for type '{typeof(T)}', please ensure a converter has been registered.");

        public IValueConverter CreateConverter(Type type)
            => factory(type) ?? throw new DbExpressionConfigurationException($"Could not resolve a converter for type '{type}', please ensure a converter has been registered.");

        public void RegisterConverter<T>(IValueConverter converter)
            => throw new DbExpressionConfigurationException($"Value converters are deferred to a delegate, custom registration is not supported.");

        public void RegisterConverter<T, U>()
            where U : class, IValueConverter, new()
            => throw new DbExpressionConfigurationException($"Value converters are deferred to a delegate, custom registration is not supported.");

        public void RegisterConverter(Type type, Func<IValueConverter> converter)
            => throw new DbExpressionConfigurationException($"Value converters are deferred to a delegate, custom registration is not supported.");
        #endregion
    }
}
