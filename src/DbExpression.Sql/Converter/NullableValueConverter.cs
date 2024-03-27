#region license
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

﻿using System;

namespace DbExpression.Sql.Converter
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

            try
            {
                return (type, Convert.ChangeType(value, underlyingType));
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<(Type Type, object? ConvertedValue)>(value, value?.GetType(), type, e);
            }
        }

        public virtual object? ConvertFromDatabase(object? value)
        {
            if (value is null)
                return default;

            if (type == value.GetType())
                return value;

            if (type == underlyingType)
                return value;
                
            try
            {
                return Convert.ChangeType(value, underlyingType);
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<object?>(value, value?.GetType(), type, e);
            }
        }
    }
}
