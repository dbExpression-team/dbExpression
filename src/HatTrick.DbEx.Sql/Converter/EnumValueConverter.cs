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
        private Type type;

        public EnumValueConverter(Type type)
        {
            this.type = type;
        }

        public virtual object ConvertFromDatabase(object value)
        {
            if (value is null)
                return default;

            if (value is string persistedAsString)
            {
                try
                {
                    return Enum.Parse(type, persistedAsString, true);
                }
                catch { }
            }
            return Enum.ToObject(type, value);
        }

        public virtual T ConvertFromDatabase<T>(object value)
        {
            if (value is null)
                return default;

            if (value is string persistedAsString)
            {
                try
                {
                    return (T)Enum.Parse(typeof(T), persistedAsString, true);
                }
                catch { }
            }
            return (T)Enum.ToObject(typeof(T), value);
        }

        public virtual (Type, object) ConvertToDatabase(object value)
            => (typeof(int), Convert.ToInt32(value));
    }
}
