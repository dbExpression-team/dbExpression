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

using HatTrick.DbEx.Sql.Converter;
using System;

namespace HatTrick.DbEx.Sql.Executor
{
    public class Field : ISqlField    
    {
        #region internals
        protected Func<ISqlField, Type, IValueConverter?> FindValueConverter { get; private set; }
        #endregion

        #region interface
        public int Index { get; private set; }
        public string Name { get; private set; }
        public Type DataType { get; private set; }
        public object RawValue { get; private set; }
        #endregion

        #region constructors
        public Field(int index, string name, Type dataType, object value, Func<ISqlField, Type, IValueConverter?> findValueConverter)
        {
            Index = index;
            Name = name;
            DataType = dataType;
            RawValue = value;
            FindValueConverter = findValueConverter ?? throw new ArgumentNullException(nameof(findValueConverter));
        }
        #endregion

        #region methods
        public T GetValue<T>()
        {
            var converter = FindValueConverter(this, typeof(T)) ?? throw new DbExpressionException($"Expected to find a value converter for type {typeof(T)}, but none was found.");

            return (T)converter.ConvertFromDatabase(RawValue is DBNull ? null : RawValue)!;
        }

        public object? GetValue()
        {
            var converter = FindValueConverter(this, typeof(object)) ?? throw new DbExpressionException($"Expected to find a value converter for type {typeof(object)}, but none was found.");

            return converter.ConvertFromDatabase(RawValue is DBNull ? null : RawValue)!;
        }
        #endregion
    }
}
