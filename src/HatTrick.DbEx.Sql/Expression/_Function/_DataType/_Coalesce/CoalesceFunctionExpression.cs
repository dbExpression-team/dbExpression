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

﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CoalesceFunctionExpression : DataTypeFunctionExpression,
        IExpressionListProvider<IExpressionElement>,
        IEquatable<CoalesceFunctionExpression>
    {
        #region internals
        private readonly IEnumerable<IExpressionElement> expressions;
        #endregion

        #region interface
        IEnumerable<IExpressionElement> IExpressionListProvider<IExpressionElement>.Expressions => expressions;
        #endregion

        #region constructors
        protected CoalesceFunctionExpression(IEnumerable<IExpressionElement> expressions, Type declaredType) 
            : base(declaredType)
        {
            this.expressions = expressions;
        }
        #endregion

        #region to string
        public override string ToString() => $"COALESCE({string.Join(", ", expressions)})";
        #endregion

        #region equals
        public bool Equals(CoalesceFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (expressions.Count() != obj.expressions.Count()) return false;

            foreach (var exp in expressions)
                if (!obj.expressions.Any(e => e.Equals(exp))) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is CoalesceFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
