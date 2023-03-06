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
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace HatTrick.DbEx.Sql
{
    [Serializable]
    public partial class DbExpressionPipelineEventException : DbExpressionException
    {
        public IExpressionElement Expression { get; init; }

        public DbExpressionPipelineEventException(IExpressionElement expression, string message) 
            : base(message)
        {
            Expression = expression;
        }

        public DbExpressionPipelineEventException(IExpressionElement expression, string message, Exception innerException) 
            : base(message, innerException)
        {
            Expression = expression;
        }

        public DbExpressionPipelineEventException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Expression = (IExpressionElement)info.GetValue("Expression", typeof(IExpressionElement))!;
        }

        [DoesNotReturn]
        public static void ThrowPipelineEventFailed(
            QueryExpression expression,
            string eventName, 
            string queryType,
            Exception innerException,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionPipelineEventException(expression, ExceptionMessages.PipelineEventFailed(eventName, queryType), innerException);

        public static T ThrowPipelineEventFailedWithReturn<T>(
           QueryExpression expression,
           string eventName,
           string queryType,
           Exception innerException,
           [CallerMemberName] string? caller = null,
           [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(expression, ExceptionMessages.PipelineEventFailed(eventName, queryType), innerException);
            return default;
        }

        [DoesNotReturn]
        public static void ThrowUpdatePipelineEventNoFieldFound(
            QueryExpression expression,
            string fieldName,
            string entityName,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionPipelineEventException(expression, ExceptionMessages.UpdatePipelineEventNoFieldFound(fieldName, entityName));

        public static T ThrowNullValueUnexpectedWithReturn<T>(
            QueryExpression expression,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(expression, ExceptionMessages.NullValueUnexpected());
            return default;
        }

        [DoesNotReturn]
        public static void ThrowUpdatePipelineEventSetValueFailed<T>(
            IExpressionElement expression,
            string fieldName,
            string entityName,
            T value,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionPipelineEventException(expression, ExceptionMessages.UpdatePipelineEventSetValueFailed(fieldName, entityName));

        [DoesNotReturn]
        private static void Throw(IExpressionElement element, string message)
            => throw new DbExpressionPipelineEventException(element, message);

        [DoesNotReturn]
        private static void Throw(IExpressionElement element, string message, Exception innerException)
            => throw new DbExpressionPipelineEventException(element, message, innerException);
    }
}
