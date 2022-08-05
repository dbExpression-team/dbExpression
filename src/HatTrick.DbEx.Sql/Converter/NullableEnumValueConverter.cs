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
    public abstract class NullableEnumValueConverter : IValueConverter
    {
        #region internals
        private readonly Type type;
        #endregion

        #region interface
        protected Type UnderlyingType { get; private set; }
        protected StringEnumValueConverter StringConverter { get; private set; }
        #endregion

        #region methods
        public NullableEnumValueConverter(Type type)
        {
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            if (!type.IsEnum)
                throw new ArgumentException($"Expected an enum type, but was provided the type '{type}'");
            this.UnderlyingType = type.GetFields()[0].FieldType;
            this.StringConverter = new StringEnumValueConverter(type);
        }

        public virtual object? ConvertFromDatabase(object? value)
            => value is string ? StringConverter.ConvertFromDatabase(value) : value is null ? null : Enum.ToObject(type, value);

        public virtual (Type Type, object? ConvertedValue) ConvertToDatabase(object? value)
            => (UnderlyingType, value is null ? null : Convert.ChangeType(value, UnderlyingType));
        #endregion
    }
}
