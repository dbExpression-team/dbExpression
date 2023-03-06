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
    public class DelegateValueConverter<T> : IValueConverter<T>
    {
        #region internals
        private readonly Func<T?, object?> convertToDatabase;
        private readonly Func<object?, T?> convertFromDatabase;
        #endregion

        #region constructors
        public DelegateValueConverter(Func<T?, object?> convertToDatabase, Func<object?, T?> convertFromDatabase)
        {
            if (convertToDatabase is null)
                throw new ArgumentNullException(nameof(convertToDatabase));

            if (convertFromDatabase is null)
                throw new ArgumentNullException(nameof(convertFromDatabase));

            this.convertToDatabase = convertToDatabase;
            this.convertFromDatabase = convertFromDatabase;
        }
        #endregion

        #region methods
        public (Type Type, object? ConvertedValue) ConvertToDatabase(object? value)
        {
            try
            {
                return (typeof(T), convertToDatabase((T?)value));
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<(Type Type, object? ConvertedValue)>(value, value?.GetType(), typeof(T), e);
            }
        }

        object? IValueConverter.ConvertFromDatabase(object? value)
        {
            try
            {
                return value is null ? null : convertFromDatabase(value);
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<object?>(value, value?.GetType(), typeof(T), e);
            }
        }

        public T? ConvertFromDatabase(object? value)
        {
            try
            {
                return convertFromDatabase(value);
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<T?>(value, value?.GetType(), typeof(T), e);
            }
        }
        #endregion
    }
}
