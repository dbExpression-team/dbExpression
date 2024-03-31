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

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace DbExpression.Sql
{
    [Serializable]
    public partial class DbExpressionConfigurationException : DbExpressionException
    {
        protected DbExpressionConfigurationException(string message) : base(message)
        {
        }

        public DbExpressionConfigurationException(string message, Exception innerException) : base(message, innerException)
        {
        }


#if !NET8_0_OR_GREATER
        public DbExpressionConfigurationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
#endif

        [DoesNotReturn]
        public static void ThrowDatabaseNotRegistered(
            Type database,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionConfigurationException(ExceptionMessages.DatabaseNotRegistered(database));

        #region static runtime
        [DoesNotReturn]
        public static void ThrowInitializeStaticRuntimeOfNonStaticDatabase(
            Type database,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionConfigurationException(ExceptionMessages.InitializeStaticRuntimeOfNonStaticDatabase(database));

        [DoesNotReturn]
        public static void ThrowInitializeStaticRuntime(
            Type database,
            Exception innerException,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionConfigurationException(ExceptionMessages.InitializeStaticRuntime(database), innerException);
        #endregion

        #region database builder aggregate
        [DoesNotReturn]
        public static void ThrowDatabaseBuilderAggregate(
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionConfigurationException(ExceptionMessages.DatabaseBuilderAggregate());

        [DoesNotReturn]
        public static void ThrowDatabaseBuilderAggregate(
            IEnumerable<Exception> exceptions,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => Throw(ExceptionMessages.DatabaseBuilderAggregate(), new AggregateException(exceptions));
        #endregion

        #region service resolution
        public static T ThrowServiceResolutionWithReturn<T>(
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(ExceptionMessages.ServiceResolution<T>());
            return default;
        }

        public static T ThrowServiceResolutionWithReturn<T>(
            Type type,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(ExceptionMessages.ServiceResolution(type));
            return default;
        }

        [DoesNotReturn]
        public static void ThrowServiceResolution<T>(
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionConfigurationException(ExceptionMessages.ServiceResolution<T>());
        
        [DoesNotReturn]
        public static void ThrowServiceResolution<T>(
            Exception innerException,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionConfigurationException(ExceptionMessages.ServiceResolution<T>(), innerException);
        #endregion

        #region registration adapter
        [DoesNotReturn]
        public static void ThrowRegistrationAdapter(
            ServiceDescriptor descriptor,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            throw new DbExpressionConfigurationException(ExceptionMessages.RegistrationAdapter(descriptor));
        }
        #endregion

        #region service registration
        [DoesNotReturn]
        public static void ThrowServiceRegistration(
            Type actualType,
            Type expectedType,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionConfigurationException(ExceptionMessages.ServiceRegistration(actualType, expectedType));

        [DoesNotReturn]
        public static void ThrowServiceRegistration(
            Type actualType,
            Type expectedType,
            Exception innerException,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => Throw(ExceptionMessages.ServiceRegistration(actualType, expectedType), innerException);
        #endregion

        #region wrong type
        public static TExpected ThrowWrongType<TExpected>(
            Type? actualType,
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(
                ExceptionMessages.WrongType(
                    actualType,
                    typeof(TExpected)
                )
            );
            return default;
        }

        public static TExpected ThrowWrongTypeWithReturn<TExpected, TActual>(
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        )
        {
            Throw(
                ExceptionMessages.WrongType(
                    typeof(TActual),
                    typeof(TExpected)
                )
            );
            return default;
        }
        #endregion

        #region duplicate registration
        [DoesNotReturn]
        public static void ThrowDuplicateRegistration<T>(
            [CallerMemberName] string? caller = null,
            [CallerArgumentExpression("caller")] string? paramName = null
        ) => throw new DbExpressionConfigurationException(ExceptionMessages.DuplicateRegistration<T>());
        #endregion

        #region code gen
        [DoesNotReturn]
        public static void ThrowUnsupportedRuntimeVersion(
            string runtimeVersion,
            string templateVersion,
            IEnumerable<string> compatibleRuntimeVersions,
            [CallerArgumentExpression("runtimeVersion")] string? paramName = null
        )
        {
            throw new DbExpressionConfigurationException(
                ExceptionMessages.UnsupportedCodeGenTemplateVersion(
                    runtimeVersion,
                    templateVersion,
                    compatibleRuntimeVersions
                )
            );
        }
        #endregion

        [DoesNotReturn]
        private static void Throw(string message)
            => throw new DbExpressionConfigurationException(message);

        [DoesNotReturn]
        private static void Throw(string message, Exception innerException)
            => throw new DbExpressionConfigurationException(message, innerException);
    }
}
