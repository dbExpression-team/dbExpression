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

using HatTrick.DbEx.Sql.Expression;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace HatTrick.DbEx.Sql
{
    [Serializable]
    public partial class DbExpressionQueryException : DbExpressionException
    {
        public IExpressionElement Expression { get; init; }

        public DbExpressionQueryException(IExpressionElement expression, string message) 
            : base(message)
        {
            Expression = expression;
        }

        public DbExpressionQueryException(IExpressionElement expression, string message, Exception innerException) 
            : base(message, innerException)
        {
            Expression = expression;
        }

        protected DbExpressionQueryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Expression = (IExpressionElement)info.GetValue("Expression", typeof(IExpressionElement))!;
        }

        public static T ThrowNullValueUnexpectedWithReturn<T>(
            IExpressionElement element,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(element, ExceptionMessages.NullValueUnexpected());
            return default;
        }

        [DoesNotReturn]
        public static void ThrowNullValueUnexpected(
            IExpressionElement element,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionQueryException(element, ExceptionMessages.NullValueUnexpected());

        public static T ThrowNullFactoryResultWithReturn<T>(
            IExpressionElement element,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(element, ExceptionMessages.NullValueUnexpected());
            return default;
        }

        [DoesNotReturn]
        public static void ThrowWrongType<T>(
            IExpressionElement element,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionQueryException(element, ExceptionMessages.WrongType(element.GetType(), typeof(T)));

        [DoesNotReturn]
        public static void ThrowWrongType<T>(
            IExpressionElement element,
            Type actualType,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionQueryException(element, ExceptionMessages.WrongType(actualType, typeof(T)));

        public static T ThrowWrongTypeWithReturn<T>(
            IExpressionElement element,
            Type? actualType,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(element, ExceptionMessages.WrongType(actualType, typeof(T)));
            return default;
        }

        public static void ThrowInsertExpectedIntegerAsFirstField(
           IExpressionElement element,
           [CallerMemberName] string? caller = null,
           [CallerArgumentExpression("caller")] string? paramName = null
        ) => Throw(element, ExceptionMessages.InsertExpectedIntegerAsFirstField());

        public static void ThrowInsertExpectedIntegerAsFirstField(
           IExpressionElement element,
           Exception innerException,
           [CallerMemberName] string? caller = null,
           [CallerArgumentExpression("caller")] string? paramName = null
        ) => Throw(element, ExceptionMessages.InsertExpectedIntegerAsFirstField(), innerException);

        public static T ThrowWrongDbCommandTypeWithReturn<T>(
            QueryExpression expression,
            Type actualType,
            Type expectedType,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(expression, ExceptionMessages.WrongDbCommandType(actualType, expectedType));
            return default;
        }

        [DoesNotReturn]
        private static void Throw(IExpressionElement element, string message)
            => throw new DbExpressionQueryException(element, message);

        [DoesNotReturn]
        private static void Throw(IExpressionElement element, string message, Exception innerException)
            => throw new DbExpressionQueryException(element, message, innerException);
    }
}
