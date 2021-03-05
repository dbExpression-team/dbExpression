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

namespace HatTrick.DbEx.Sql.Expression
{
    public class SelectExpression<TValue> : 
        SelectExpression,
        IEquatable<SelectExpression<TValue>>
    {
        #region constructors
        public SelectExpression(IExpressionElement expression) : base(expression)
        {

        }
        #endregion

        #region logical & operator
        public static SelectExpressionSet operator &(SelectExpression<TValue> a, SelectExpression<TValue> b) => new SelectExpressionSet(a, b);
        #endregion

        #region implicit select expression set operator
        public static implicit operator SelectExpressionSet(SelectExpression<TValue> a) => new SelectExpressionSet(a);
        #endregion

        #region equals
        public bool Equals(SelectExpression<TValue> obj)
            => obj is SelectExpression<TValue> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SelectExpression<TValue> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
