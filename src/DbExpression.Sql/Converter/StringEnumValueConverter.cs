﻿#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using System;

namespace DbExpression.Sql.Converter
{
    public class StringEnumValueConverter : IValueConverter
    {
        private readonly Type type;

        public StringEnumValueConverter(Type enumType)
        {
            type = enumType ?? throw new ArgumentNullException(nameof(enumType));
            if (!enumType.IsEnum)
                DbExpressionConfigurationException.ThrowWrongType<Enum>(enumType);
        }

        public virtual object? ConvertFromDatabase(object? value)
        {
            if (value is null) 
                return default;

            if (value is not string)
                DbExpressionConversionException.ThrowValueConversionFailedWithReturn<string>(value, value?.GetType());

            try
            {
                return Enum.Parse(type, (value as string)!, true);
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<object?>(value, value?.GetType(), type, e);
            }
        }

        public virtual (Type Type, object? ConvertedValue) ConvertToDatabase(object? value)
        {
            try
            {
                return (typeof(string), value?.ToString());
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<(Type Type, object? ConvertedValue)>(value, value?.GetType(), type, e);
            }
        }
    }
}
