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
using System.ComponentModel;

namespace HatTrick.DbEx.Sql.Converter
{
    public class ValueConverter : IValueConverter
    {
        private readonly Type type;

        public ValueConverter(Type type)
        {
            this.type = type;
        }

        public virtual (Type Type, object? ConvertedValue) ConvertToDatabase(object? value)
        {
            if (value is null)
                throw new DbExpressionException("Expected a non-null value from the database, but received a null value.");

            if (type == value.GetType())
                return (type, value);

            return (type, Convert.ChangeType(value, type));
        }

        public virtual object? ConvertFromDatabase(object? value)
        {
            if (value is null)
                throw new DbExpressionException("Expected a non-null value from the database, but received a null value.");

            if (type == value.GetType())
                return value;

            return Convert.ChangeType(value, type);
        }
    }
}
