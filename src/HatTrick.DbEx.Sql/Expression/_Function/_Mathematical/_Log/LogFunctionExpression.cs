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
using static HatTrick.DbEx.Sql.Expression.CastFunctionExpression;
using static HatTrick.DbEx.Sql.Expression.LogFunctionExpression;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class LogFunctionExpression : MathematicalFunctionExpression,
        IExpressionProvider<IExpressionElement>,
        IExpressionProvider<LogFunctionExpressionOptions>,
        IEquatable<LogFunctionExpression>
    {
        #region internals
        private readonly IExpressionElement expression;
        private readonly LogFunctionExpressionOptions options;
        #endregion

        #region interface
        IExpressionElement IExpressionProvider<IExpressionElement>.Expression => expression;
        LogFunctionExpressionOptions IExpressionProvider<LogFunctionExpressionOptions>.Expression => options;
        #endregion

        #region constructors
        protected LogFunctionExpression(IExpressionElement expression, Type declaredType) : base(declaredType)
        {
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
            options = new LogFunctionExpressionOptions();
        }

        protected LogFunctionExpression(IExpressionElement expression, IExpressionElement @base, Type declaredType) : base(declaredType)
        {
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
            options = new LogFunctionExpressionOptions(@base) ?? throw new ArgumentNullException(nameof(@base));
        }
        #endregion

        #region to string
        public override string? ToString() => options is null ? $"LOG({expression})" : $"LOG({expression},{options})";
        #endregion

        #region equals
        public bool Equals(LogFunctionExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (expression is null && obj.expression is not null) return false;
            if (expression is not null && obj.expression is null) return false;
            if (expression is not null && !expression.Equals(obj.expression)) return false;

            if (options is null && obj.options is not null) return false;
            if (options is not null && obj.options is null) return false;
            if (options is not null && !options.Equals(obj.expression)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is LogFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (expression is not null ? expression.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (options is not null ? options.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region classes
        public class LogFunctionExpressionOptions :
            IExpressionElement,
            IEquatable<LogFunctionExpressionOptions>
        {
            #region interface
            public IExpressionElement? Base { get; set; }
            #endregion

            #region constructors
            public LogFunctionExpressionOptions()
            {

            }

            public LogFunctionExpressionOptions(IExpressionElement @base)
            {
                Base = @base ?? throw new ArgumentNullException(nameof(@base));
            }
            #endregion

            public override string? ToString()
                => Base?.ToString();

            #region equals
            public bool Equals(LogFunctionExpressionOptions? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;

                if (Base is null && obj.Base is not null) return false;
                if (Base is not null && obj.Base is null) return false;
                if (Base is not null && !Base.Equals(obj.Base)) return false;

                return true;
            }

            public override bool Equals(object? obj)
                => obj is LogFunctionExpressionOptions exp && Equals(exp);

            public override int GetHashCode()
            {
                unchecked
                {
                    const int multiplier = 16777619;

                    int hash = base.GetHashCode();
                    hash = (hash * multiplier) ^ (Base is not null ? Base?.GetHashCode() ?? 0 : 0);
                    return hash;
                }
            }
            #endregion
        }
        #endregion
    }
}
