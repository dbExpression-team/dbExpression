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
    public class NullableDateTimeValueConverter : NullableValueConverter<DateTime>, IValueConverter<DateTime?>
    {
        public override (Type Type, object? ConvertedValue) ConvertToDatabase(object? value)
        {
            if (value is null)
                return (typeof(DateTime?), value);

            if (value is DateTime? || value is DateTime)
                return (typeof(DateTime), (DateTime)value);

            if (value is DateTimeOffset? || value is DateTimeOffset)
                return (typeof(DateTime), DateTime.SpecifyKind(((DateTimeOffset)value).UtcDateTime, DateTimeKind.Utc));

            return base.ConvertToDatabase(value);
        }

        DateTime? IValueConverter<DateTime?>.ConvertFromDatabase(object? value)
        {
            if (value is null)
                return null;

            if (value is DateTime? || value is DateTime)
                return (DateTime?)value;

            if (value is DateTimeOffset? && value is null)
                return default;

            try
            {
                if (value is DateTimeOffset)
                    return DateTime.SpecifyKind(((DateTimeOffset)value).UtcDateTime, DateTimeKind.Utc);

                return (DateTime?)base.ConvertFromDatabase(value);
            }
            catch (Exception e)
            {
                return DbExpressionConversionException.ThrowValueConversionFailedWithReturn<DateTime?>(value, value?.GetType(), typeof(DateTime?), e);
            }
        }
    }
}
