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
    public class NullableValueConverter<T> : NullableValueConverter, IValueConverter<T?>
    {
        public NullableValueConverter() : base(typeof(T))
        {
        }

        public override object? ConvertFromDatabase(object? value)
            => ConvertValue(value);

        T? IValueConverter<T?>.ConvertFromDatabase(object? value)
            => (T?)ConvertValue(value);

        private object? ConvertValue(object? value)
        {
            if (value is null)
                return default;

            if (typeof(T) == value.GetType())
                return value;

            try
            {
                var underlying = Nullable.GetUnderlyingType(typeof(T));
                if (underlying == value.GetType())
                    return value;

                return Convert.ChangeType(value, underlying ?? typeof(T));
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<object?>(value, value?.GetType(), typeof(T), e);
            }
        }
    }
}
