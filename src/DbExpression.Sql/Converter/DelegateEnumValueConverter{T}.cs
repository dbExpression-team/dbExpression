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
    public class DelegateEnumValueConverter<TEnum> : IValueConverter<TEnum>
    {
        private readonly Func<TEnum, object> convertToDatabase;
        private readonly Func<object, TEnum> convertFromDatabase;
        private readonly Type underlyingType;

        public DelegateEnumValueConverter(Func<TEnum, object> convertToDatabase, Func<object, TEnum> convertFromDatabase)
        {
            if (!typeof(TEnum).IsEnum)
                DbExpressionConfigurationException.ThrowWrongType<TEnum>(null);

            this.convertToDatabase = convertToDatabase ?? throw new ArgumentNullException(nameof(convertToDatabase));
            this.convertFromDatabase = convertFromDatabase ?? throw new ArgumentNullException(nameof(convertFromDatabase));
            this.underlyingType = typeof(TEnum).GetFields()[0].FieldType;
        }

        public (Type Type, object? ConvertedValue) ConvertToDatabase(object? value)
        {
            if (value is null)
                DbExpressionConversionException.ThrowValueConversionFailed<TEnum>(value, value?.GetType());

            try
            {
                return (underlyingType, convertToDatabase((TEnum)Enum.ToObject(typeof(TEnum), Convert.ChangeType(value!, underlyingType))));
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<(Type Type, object? ConvertedValue)>(value, value?.GetType(), underlyingType, e);
            }
        }

        object? IValueConverter.ConvertFromDatabase(object? value)
        {
            if (value is null)
                DbExpressionConversionException.ThrowValueConversionFailed<TEnum>(value, value?.GetType());

            try
            {
                return convertFromDatabase(value);
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ValueConversionFailedWithReturn<object?, TEnum>(value, value?.GetType(), e);
            }
        }

        public TEnum? ConvertFromDatabase(object? value)
        {
            if (value is null)
                DbExpressionConversionException.ThrowValueConversionFailed<TEnum>(value, value?.GetType());

            try
            {
                return (TEnum?)Convert.ChangeType(convertFromDatabase(value), typeof(TEnum));
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<TEnum?>(value, value?.GetType(), e);
            }
        }
    }
}
