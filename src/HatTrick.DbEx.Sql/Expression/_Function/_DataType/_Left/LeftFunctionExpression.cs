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
    public abstract class LeftFunctionExpression : ConversionFunctionExpression,
        IExpressionProvider<IExpressionElement>,
        IExpressionProvider<Int32Element>,
        IEquatable<LeftFunctionExpression>
    {
        #region internals
        private readonly IExpressionElement expression;
        private readonly Int32Element characterCount;
        #endregion

        #region interface
        IExpressionElement IExpressionProvider<IExpressionElement>.Expression => expression;
        Int32Element IExpressionProvider<Int32Element>.Expression => characterCount;
        #endregion

        #region constructors
        protected LeftFunctionExpression(IExpressionElement expression, Int32Element characterCount, Type convertToType)
            : base(convertToType)
        {
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
            this.characterCount = characterCount ?? throw new ArgumentNullException(nameof(characterCount));
        }
        #endregion

        #region to string
        public override string ToString() => $"LEFT({expression})";
        #endregion

        #region equals
        public bool Equals(LeftFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (expression is null && obj.expression is object) return false;
            if (expression is object && obj.expression is null) return false;
            if (!expression.Equals(obj.expression)) return false;

            if (characterCount is null && obj.characterCount is object) return false;
            if (characterCount is object && obj.characterCount is null) return false;
            if (!characterCount.Equals(obj.characterCount)) return false;

            return true;
        }

        public override bool Equals(object obj)
         => obj is LeftFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (expression is object ? expression.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (characterCount is object ? characterCount.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion
    }
}
