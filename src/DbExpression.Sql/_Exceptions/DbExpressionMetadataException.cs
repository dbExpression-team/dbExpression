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
    public partial class DbExpressionMetadataException : DbExpressionException
    {
        public DbExpressionMetadataException(string message) 
            : base(message)
        {
        }

        public DbExpressionMetadataException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected DbExpressionMetadataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public static T ThrowMetadataResolutionWithReturn<T>(
           string metadataTargetType,
           string metdataTargetName,
           [CallerMemberName] string? caller = null,
           [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(ExceptionMessages.MetadataResolution(metadataTargetType, metdataTargetName));
            return default;
        }

        [DoesNotReturn]
        private static void Throw(string message)
            => throw new DbExpressionMetadataException(message);

        [DoesNotReturn]
        private static void Throw(string message, Exception innerException)
            => throw new DbExpressionMetadataException(message, innerException);
    }
}
