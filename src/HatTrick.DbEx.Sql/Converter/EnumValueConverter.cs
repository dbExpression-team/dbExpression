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

﻿using System;

namespace HatTrick.DbEx.Sql.Converter
{
    public class EnumValueConverter : IValueConverter
    {
        private readonly Type type;
        private readonly Type underlyingType;
        private readonly StringEnumValueConverter stringConverter;

        public EnumValueConverter(Type type)
        {
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            if (!type.IsEnum)
                throw new ArgumentException($"Expected an enum type, but was provided the type '{type}'");
            this.underlyingType = type.GetFields()[0].FieldType;
            this.stringConverter = new StringEnumValueConverter(type);
        }

        public virtual object? ConvertFromDatabase(object? value)
            => value is string ? stringConverter.ConvertFromDatabase(value) : Enum.ToObject(type, value ?? throw new DbExpressionException("Expected a non-null value for conversion from the database."));

        public virtual T? ConvertFromDatabase<T>(object? value)
            => value is string ? (T?)stringConverter.ConvertFromDatabase(value) : (T)Enum.ToObject(typeof(T), value ?? throw new DbExpressionException("Expected a non-null value for conversion to the database."));

        public virtual (Type Type, object? ConvertedValue) ConvertToDatabase(object? value)
            => (underlyingType, Convert.ChangeType(value ?? throw new DbExpressionException("Expected a non-null value for conversion to the database."), underlyingType));
    }
}
