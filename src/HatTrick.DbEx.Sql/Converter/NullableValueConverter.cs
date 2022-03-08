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
    public class NullableValueConverter : IValueConverter
    {
        private readonly Type type;
        private readonly Type underlyingType;

        public NullableValueConverter(Type type)
        {
            this.type = type;
            this.underlyingType = Nullable.GetUnderlyingType(type)!;
        }

        public virtual (Type Type, object? ConvertedValue) ConvertToDatabase(object? value)
        {
            if (value is null)
                return (type, default);

            if (type == value.GetType())
                return (type, value);

            if (type == underlyingType)
                return (type, value);

            return (type, Convert.ChangeType(value, underlyingType));
        }

        public virtual object? ConvertFromDatabase(object? value)
        {
            if (value is null)
                return default;

            if (type == value.GetType())
                return value;

            if (type == underlyingType)
                return value;
                
            return Convert.ChangeType(value, underlyingType);
        }

        public virtual T? ConvertFromDatabase<T>(object? value)
        {
            if (value is null)
                 return default;

            if (typeof(T) == value.GetType())
                return (T)value;

            var underlying = Nullable.GetUnderlyingType(typeof(T));
            if (underlying == value.GetType())
                return (T)value;

            return (T)Convert.ChangeType(value, underlying ?? typeof(T));
        }
    }
}
