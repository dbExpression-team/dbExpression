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
    public class NullableEnumValueConverter : EnumValueConverter
    {
        private Type type;

        public NullableEnumValueConverter(Type type) : base(Nullable.GetUnderlyingType(type))
        {
            this.type = type;
        }

        public override object ConvertFromDatabase(object value)
            => value is object ? base.ConvertFromDatabase(value) : default;

        public override T ConvertFromDatabase<T>(object value)
            => value is object ? (T)base.ConvertFromDatabase(value) : default;

        public override (Type, object) ConvertToDatabase(object value)
        {
            if (value is null)
                return (type, DBNull.Value);
            
            return (type, Convert.ToInt32(value));
        }
    }
}
