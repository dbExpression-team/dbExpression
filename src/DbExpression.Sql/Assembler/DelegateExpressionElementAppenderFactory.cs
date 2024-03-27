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

﻿using DbExpression.Sql.Expression;
using System;
using System.Collections.Generic;

namespace DbExpression.Sql.Assembler
{
    public class DelegateExpressionElementAppenderFactory : IExpressionElementAppenderFactory
    {
        #region internals
        private readonly Func<Type, IExpressionElementAppender> factory;
        private readonly Dictionary<Type, Type> map = new();
        #endregion

        #region constructors
        public DelegateExpressionElementAppenderFactory(Func<Type, IExpressionElementAppender> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        #endregion

        #region methods
        public IExpressionElementAppender CreateElementAppender(Type elementType)
        {
            if (elementType is null)
                throw new ArgumentNullException(nameof(elementType));

            if (map.TryGetValue(elementType, out Type? value))
                return factory(value);

            map.Add(elementType, typeof(IExpressionElementAppender<>).MakeGenericType(new[] { elementType }));

            return factory(map[elementType]);
        }

        public IExpressionElementAppender<T> CreateElementAppender<T>()
            where T : class, IExpressionElement
            => (CreateElementAppender(typeof(T)) as IExpressionElementAppender<T>)!;
        #endregion
    }
}
