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
    public abstract class SubstringFunctionExpression : ConversionFunctionExpression,
        IExpressionProvider<SubstringFunctionExpression.SubstringFunctionExpressionElements>,
        IEquatable<SubstringFunctionExpression>
    {
        #region internals
        private readonly SubstringFunctionExpressionElements elements;
        #endregion

        #region interface
        SubstringFunctionExpressionElements IExpressionProvider<SubstringFunctionExpressionElements>.Expression => elements;
        #endregion

        #region constructors
        protected SubstringFunctionExpression(IExpressionElement expression, IExpressionElement start, IExpressionElement length, Type convertToType)
            : base(convertToType)
        {
            this.elements = new SubstringFunctionExpressionElements(expression, start, length);
        }
        #endregion

        #region to string
        public override string? ToString() => $"SUBSTRING({elements.Expression}, {elements.Start}, {elements.Length})";
        #endregion

        #region equals
        public bool Equals(SubstringFunctionExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (elements is null && obj.elements is not null) return false;
            if (elements is not null && obj.elements is null) return false;
            if (obj.elements is null) return false;
            if (elements is not null && !elements.Equals(obj.elements)) return false;

            return true;
        }

        public override bool Equals(object? obj)
         => obj is SubstringFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (elements is not null ? elements.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region classes
        public class SubstringFunctionExpressionElements : IExpressionElement,
            IEquatable<SubstringFunctionExpressionElements>
        {
            #region interface
            public IExpressionElement Expression { get; private set; }
            public IExpressionElement Start { get; private set; }
            public IExpressionElement Length { get; private set; }
            #endregion

            #region constructors
            public SubstringFunctionExpressionElements(IExpressionElement pattern, IExpressionElement toSearch, IExpressionElement startSearchPosition)
            {
                this.Expression = pattern ?? throw new ArgumentNullException(nameof(pattern));
                this.Start = toSearch ?? throw new ArgumentNullException(nameof(toSearch));
                this.Length = startSearchPosition;
            }
            #endregion

            #region equals
            public bool Equals(SubstringFunctionExpressionElements? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;

                if (Expression is null && obj.Expression is not null) return false;
                if (Expression is not null && obj.Expression is null) return false;
                if (Expression is not null && !Expression.Equals(obj.Expression)) return false;

                if (Start is null && obj.Start is not null) return false;
                if (Start is not null && obj.Start is null) return false;
                if (Start is not null && !Start.Equals(obj.Start)) return false;

                if (Length is null && obj.Length is not null) return false;
                if (Length is not null && obj.Length is null) return false;
                if (Length is not null && !Length.Equals(obj.Length)) return false;

                return true;
            }

            public override bool Equals(object? obj)
                => obj is SubstringFunctionExpressionElements && Equals(obj);

            public override int GetHashCode()
            {
                unchecked
                {
                    const int multiplier = 16777619;

                    int hash = base.GetHashCode();
                    hash = (hash * multiplier) ^ (Expression is not null ? Expression.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (Start is not null ? Start.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (Length is not null ? Length.GetHashCode() : 0);
                    return hash;
                }
            }
            #endregion
        }
        #endregion
    }
}
