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

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace DbExpression.Sql
{
    [Serializable]
    public partial class DbExpressionConversionException : DbExpressionException
    {
        public object? Value { get; init; }

        public DbExpressionConversionException(object? value, string message)
            : base(message)
        {
            Value = value;
        }

        public DbExpressionConversionException(object? value, string message, Exception innerException)
            : base(message, innerException)
        {
            Value = value;
        }

 #if !NET8_0_OR_GREATER
        protected DbExpressionConversionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Value = info.GetValue("Value", typeof(object))!;
        }
#endif

        [DoesNotReturn]
        public static void ThrowValueConversionFailed(
            object? value,
            Type? actualType,
            Type expectedType,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionConversionException(value, ExceptionMessages.ValueConversionFailed(value, actualType, expectedType));

        [DoesNotReturn]
        public static void ThrowValueConversionFailed<T>(
            object? value,
            Type? actualType,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionConversionException(value, ExceptionMessages.ValueConversionFailed(value, actualType, typeof(T)));

        [DoesNotReturn]
        public static void ThrowDateConversionCausesLossOfTimeZoneInformation(
            object? value,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionConversionException(value, ExceptionMessages.DateConversionCausesLossOfTimeZoneInformation(typeof(DateTime), typeof(DateTimeOffset)));

        public static T ThrowValueConversionFailedWithReturn<T>(
            object? value,
            Type? actualType,
            Type expectedType,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(value, ExceptionMessages.ValueConversionFailed(value, actualType, expectedType));
            return default;
        }

        public static T ThrowValueConversionFailedWithReturn<T>(
            object? value,
            Type? actualType,
            Type expectedType,
            Exception innerException,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(value, ExceptionMessages.ValueConversionFailed(value, actualType, expectedType), innerException);
            return default;
        }

        public static T ThrowValueConversionFailedWithReturn<T>(
            object? value,
            Type? actualType,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(value, ExceptionMessages.ValueConversionFailed(value, actualType, typeof(T)));
            return default;
        }

        public static T ThrowValueConversionFailedWithReturn<T>(
            object? value,
            Type? actualType,
            Exception innerException,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(value, ExceptionMessages.ValueConversionFailed(value, actualType, typeof(T)), innerException);
            return default;
        }

        public static TReturn ThrowValueConversionFailed<TReturn, TExpected>(
            object? value,
            Type? actualType,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(value, ExceptionMessages.ValueConversionFailed(value, actualType, typeof(TReturn)));
            return default;
        }

        public static TReturn ValueConversionFailedWithReturn<TReturn, TExpected>(
            object? value,
            Type? actualType,
            Exception innerException,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(value, ExceptionMessages.ValueConversionFailed(value, actualType, typeof(TReturn)), innerException);
            return default;
        }

        [DoesNotReturn]
        private static void Throw(object? value, string message)
            => throw new DbExpressionConversionException(value, message);

        [DoesNotReturn]
        private static void Throw(object? value, string message, Exception innerException)
            => throw new DbExpressionConversionException(value, message, innerException);
    }
}
