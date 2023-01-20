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

namespace HatTrick.DbEx.Sql.Executor
{
    public readonly struct Field : ISqlField
    {
        #region internals
        private readonly IValueConverterProvider _converters;
        #endregion

        #region interface
        public int Index { get; init; }
        public string Name { get; init; }
        public Type DataType { get; init; }
        public object RawValue { get; init; }
        #endregion

        #region constructors
        public Field(ref int index, string name, Type dataType, object value, IValueConverterProvider converters)
        {
            Index = index;
            Name = name;
            DataType = dataType;
            RawValue = value;
            _converters = converters ?? throw new ArgumentNullException(nameof(converters));
        }
        #endregion

        #region methods
        public T GetValue<T>()
        {
            var converter = _converters.FindConverter(Index, typeof(T), RawValue) 
                ?? throw new DbExpressionConfigurationException(ExceptionMessages.ServiceResolution<T>());
            return (T)converter.ConvertFromDatabase(RawValue is DBNull ? null : RawValue)!;
        }

        public object? GetValue()
        {
            var converter =_converters.FindConverter(Index, typeof(object), RawValue)
                ?? throw new DbExpressionConfigurationException(ExceptionMessages.ServiceResolution<object>());
            return converter.ConvertFromDatabase(RawValue is DBNull ? null : RawValue)!;
        }
        #endregion
    }
}
