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

using DbExpression.Sql.Expression;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace DbExpression.Sql
{
    [Serializable]
    public partial class DbExpressionMappingException : DbExpressionException
    {
        public IExpressionElement Expression { get; init; }

        public DbExpressionMappingException(IExpressionElement expression, string message) 
            : base(message)
        {
            Expression = expression;
        }

        public DbExpressionMappingException(IExpressionElement expression, string message, Exception innerException) 
            : base(message, innerException)
        {
            Expression = expression;
        }

#if !NET8_0_OR_GREATER
        protected DbExpressionMappingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Expression = (IExpressionElement)info.GetValue("Expression", typeof(IExpressionElement))!;
        }
#endif

        [DoesNotReturn]
        public static void ThrowDataMappingFailed<T>(
            QueryExpression expression,
            Exception innerException,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionMappingException(expression, ExceptionMessages.DataMappingFailed(typeof(T)), innerException);

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
        private static void Throw(IExpressionElement value, string message)
            => throw new DbExpressionMappingException(value, message);

        [DoesNotReturn]
        private static void Throw(IExpressionElement value, string message, Exception innerException)
            => throw new DbExpressionMappingException(value, message, innerException);
    }
}
