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
    public abstract class EnumValueConverter : IValueConverter
    {
        #region internals
        private readonly Type type;
        #endregion

        #region interface
        protected StringEnumValueConverter StringConverter { get; private set; }
        protected Type UnderlyingType { get; private set; }
        #endregion

        #region constructors
        public EnumValueConverter(Type type)
        {
            this.type = type ?? throw new ArgumentNullException(nameof(type));
            if (!type.IsEnum)
                DbExpressionConfigurationException.ThrowWrongType<Enum>(type);
            this.UnderlyingType = type.GetFields()[0].FieldType;
            this.StringConverter = new StringEnumValueConverter(type);
        }
        #endregion

        #region methods
        public virtual object? ConvertFromDatabase(object? value)
        {
            if (value is null)
                DbExpressionConversionException.ThrowValueConversionFailed<Enum>(value, value?.GetType());

            if (value is string)
                return StringConverter.ConvertFromDatabase(value);

            try
            {
                return Enum.ToObject(type, value);
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<object?>(value, value?.GetType(), type, e);
            }
        }

        public virtual T? ConvertFromDatabase<T>(object? value)
        {
            if (value is null)
                DbExpressionConversionException.ThrowValueConversionFailed<Enum>(value, value?.GetType());

            if (value is string)
                return (T?)StringConverter.ConvertFromDatabase(value);

            try
            {
                return (T)Enum.ToObject(type, value);
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<T?>(value, value?.GetType(), type, e);
            }
        }

        public virtual (Type Type, object? ConvertedValue) ConvertToDatabase(object? value)
        {
            if (value is null)
                DbExpressionConversionException.ThrowValueConversionFailed<Enum>(value, value?.GetType());

            try
            {
                return (UnderlyingType, Convert.ChangeType(value, UnderlyingType));
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<(Type Type, object? ConvertedValue)>(value, value?.GetType(), type, e);
            }
        }
        #endregion
    }
}
