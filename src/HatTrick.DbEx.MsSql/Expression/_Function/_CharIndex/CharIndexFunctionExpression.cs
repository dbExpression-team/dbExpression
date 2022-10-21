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
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Expression
{
    public abstract class CharIndexFunctionExpression : StringFunctionExpression,
        IExpressionProvider<CharIndexFunctionExpression.CharIndexFunctionExpressionElements>,
        IEquatable<CharIndexFunctionExpression>
    {
        #region internals
        private readonly CharIndexFunctionExpressionElements elements;
        #endregion

        #region interface
        CharIndexFunctionExpressionElements IExpressionProvider<CharIndexFunctionExpressionElements>.Expression => elements;
        #endregion

        #region constructors
        protected CharIndexFunctionExpression(IExpressionElement pattern, IExpressionElement expression, Type convertToType)
            : base(convertToType)
        {
            this.elements = new CharIndexFunctionExpressionElements(pattern, expression, null);
        }

        protected CharIndexFunctionExpression(IExpressionElement pattern, IExpressionElement expression, IExpressionElement? startSearchPosition, Type convertToType)
            : base(convertToType)
        {
            this.elements = new CharIndexFunctionExpressionElements(pattern, expression, startSearchPosition);
        }
        #endregion

        #region to string
        public override string ToString() => $"CHARINDEX({elements.Pattern}, {elements.ToSearch}{(elements.StartSearchPosition is object ? $", {elements.StartSearchPosition}" : string.Empty)})";
        #endregion

        #region equals
        public bool Equals(CharIndexFunctionExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (elements is null && obj.elements is not null) return false;
            if (elements is not null && obj.elements is null) return false;
            if (elements is not null && !elements.Equals(obj.elements)) return false;

            return true;
        }

        public override bool Equals(object? obj)
         => obj is CharIndexFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (elements is object ? elements.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region classes
        public class CharIndexFunctionExpressionElements : IExpressionElement,
            IEquatable<CharIndexFunctionExpressionElements>
        {
            #region interface
            public IExpressionElement Pattern { get; private set; }
            public IExpressionElement ToSearch { get; private set; }
            public IExpressionElement? StartSearchPosition { get; private set; }
            #endregion

            #region constructors
            public CharIndexFunctionExpressionElements(IExpressionElement pattern, IExpressionElement toSearch, IExpressionElement? startSearchPosition)
            {
                this.Pattern = pattern ?? throw new ArgumentNullException(nameof(pattern));
                this.ToSearch = toSearch ?? throw new ArgumentNullException(nameof(toSearch));
                this.StartSearchPosition = startSearchPosition;
            }
            #endregion

            #region equals
            public bool Equals(CharIndexFunctionExpressionElements? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;

                if (Pattern is null && obj.Pattern is object) return false;
                if (Pattern is object && obj.Pattern is null) return false;
                if (Pattern is object && !Pattern.Equals(obj.Pattern)) return false;

                if (ToSearch is null && obj.ToSearch is object) return false;
                if (ToSearch is object && obj.ToSearch is null) return false;
                if (ToSearch is object && !ToSearch.Equals(obj.ToSearch)) return false;

                if (StartSearchPosition is null && obj.StartSearchPosition is object) return false;
                if (StartSearchPosition is object && obj.StartSearchPosition is null) return false;
                if (StartSearchPosition is object && !StartSearchPosition.Equals(obj.StartSearchPosition)) return false;

                return true;
            }

            public override bool Equals(object? obj)
                => obj is CharIndexFunctionExpressionElements exp && Equals(exp);

            public override int GetHashCode()
            {
                unchecked
                {
                    const int multiplier = 16777619;

                    int hash = base.GetHashCode();
                    hash = (hash * multiplier) ^ (Pattern is object ? Pattern.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (ToSearch is object ? ToSearch.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (StartSearchPosition is object ? StartSearchPosition.GetHashCode() : 0);
                    return hash;
                }
            }
            #endregion
        }
        #endregion
    }
}
