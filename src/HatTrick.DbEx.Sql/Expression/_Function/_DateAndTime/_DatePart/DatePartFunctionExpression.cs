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
    public abstract class DatePartFunctionExpression : DateAndTimeFunctionExpression,
        IExpressionProvider<IExpressionElement>,
        IExpressionProvider<DatePartsExpression>,
        IEquatable<DatePartFunctionExpression>
    {
        #region internals
        private readonly IExpressionElement expression;
        private readonly DatePartsExpression datePart;
        #endregion

        #region interface
        IExpressionElement IExpressionProvider<IExpressionElement>.Expression => expression;
        DatePartsExpression IExpressionProvider<DatePartsExpression>.Expression => datePart;
        #endregion

        #region constructors
        protected DatePartFunctionExpression(DatePartsExpression datePart, IExpressionElement expression, Type declaredType) : base(declaredType)
        {
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
            this.datePart = datePart ?? throw new ArgumentNullException(nameof(datePart));
        }
        #endregion

        #region to string
        public override string? ToString() => $"DATEPART({datePart.ToString()?.ToLower()}, {expression})";
        #endregion

        #region equals
        public bool Equals(DatePartFunctionExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (expression is null && obj.expression is not null) return false;
            if (expression is not null && obj.expression is null) return false;
            if (expression is not null && !expression.Equals(obj.expression)) return false;

            if (datePart is null && obj.datePart is not null) return false;
            if (datePart is not null && obj.datePart is null) return false;
            if (datePart is not null && !datePart.Equals(obj.datePart)) return false;

            return true;
        }

        public override bool Equals(object? obj)
         => obj is DatePartFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (expression is not null ? expression.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (datePart is not null ? datePart.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region implicit operators
        public static implicit operator GroupByExpression(DatePartFunctionExpression datePart) 
            => new(new Int32ExpressionMediator(datePart));
        #endregion
    }
}
