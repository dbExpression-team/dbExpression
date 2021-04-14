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
    public class StringEnumValueConverter : IValueConverter
    {
        private readonly Type type;

        public StringEnumValueConverter(Type enumType)
        {
            type = enumType ?? throw new ArgumentNullException(nameof(enumType));
            if (!enumType.IsEnum)
                throw new ArgumentException($"Expected {nameof(enumType)} to be of type Enum.");
        }

        public object ConvertFromDatabase(object value)
            => value is null ? default : Enum.Parse(type, value as string, true);

        public T ConvertFromDatabase<T>(object value)
            => value is null ? default : (T)Enum.Parse(typeof(T), value as string);

        public (Type, object) ConvertToDatabase(object value)
            => value is null ? (typeof(string), null) : (typeof(string), value.ToString());
    }
}
