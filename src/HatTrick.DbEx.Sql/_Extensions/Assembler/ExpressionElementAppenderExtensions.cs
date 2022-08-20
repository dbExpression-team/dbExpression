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
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    internal static class ExpressionElementAppenderExtensions
    {
        public static bool TryFindAppenderFor(this IEnumerable<IExpressionElementAppender> appenders, Type expressionElementType, out IExpressionElementAppender? appender)
        {
            appender = null;
            try
            {
                foreach (var a in appenders)
                    if (IsAppenderFor(a, expressionElementType))
                    {
                        appender = a;
                        return true;
                    }
            }
            catch (Exception) { }
            return false;
        }

        private static bool IsAppenderFor(IExpressionElementAppender appender, Type expressionElementType)
        {
            return IsAppenderFor(appender.GetType().GetInterfaces(), expressionElementType);
        }

        private static bool IsAppenderFor(Type[] interfaces, Type expressionElementType)
        {
            var typedAppender = typeof(IExpressionElementAppender<>).MakeGenericType(new Type[] { expressionElementType });
            if (interfaces.FirstOrDefault(x => x == typedAppender) is not null)
                return true;
            if (expressionElementType.BaseType != typeof(object) && expressionElementType.BaseType is not null)
                return IsAppenderFor(interfaces, expressionElementType.BaseType);
            return false;
        }
    }
}
