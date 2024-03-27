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

﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DbExpression.Sql.Expression
{
    public abstract class ConcatFunctionExpression : StringFunctionExpression,
        IExpressionListProvider<IExpressionElement>,
        IEquatable<ConcatFunctionExpression>
    {
        #region internals
        private readonly IEnumerable<IExpressionElement> expressions;
        #endregion

        #region interface
        IEnumerable<IExpressionElement> IExpressionListProvider<IExpressionElement>.Expressions => expressions;
        #endregion

        #region constructors
        protected ConcatFunctionExpression(IList<AnyStringElement> expressions, Type declaredType) : base(declaredType)
        {
            this.expressions = expressions ?? throw new ArgumentNullException(nameof(expressions));
        }
        #endregion

        #region to string
        public override string? ToString() => $"CONCAT({string.Join(", ", expressions)})";
        #endregion

        #region equals
        public bool Equals(ConcatFunctionExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (expressions.Count() != obj.expressions.Count()) return false;

            foreach (var exp in expressions)
                if (!obj.expressions.Any(e => e.Equals(exp))) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is ConcatFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
