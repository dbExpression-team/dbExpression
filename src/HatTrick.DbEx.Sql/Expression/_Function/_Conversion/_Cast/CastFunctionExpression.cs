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
    public abstract class CastFunctionExpression : ConversionFunctionExpression,
        IExpressionProvider<IExpressionElement>,
        IExpressionProvider<CastFunctionExpression.CastFunctionExpressionOptions>,
        IEquatable<CastFunctionExpression>
    {
        #region internals
        private readonly IExpressionElement expression;
        private readonly CastFunctionExpressionOptions options;
        #endregion

        #region interface
        IExpressionElement IExpressionProvider<IExpressionElement>.Expression => expression;
        CastFunctionExpressionOptions IExpressionProvider<CastFunctionExpressionOptions>.Expression => options;
        #endregion

        #region constructors
        protected CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, Type convertToType) : base(convertToType)
        {
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
            options = new CastFunctionExpressionOptions
            {
                ConvertToDbType = convertToDbType ?? throw new ArgumentNullException(nameof(convertToDbType))
            };
        }

        protected CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, Type convertToType, int size) : base(convertToType)
        {
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
            options = new CastFunctionExpressionOptions
            {
                ConvertToDbType = convertToDbType ?? throw new ArgumentNullException(nameof(convertToDbType)),
                Size = size
            }; 
        }

        protected CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, Type convertToType, int precision, int? scale) : base(convertToType)
        {
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
            options = new CastFunctionExpressionOptions
            {
                ConvertToDbType = convertToDbType ?? throw new ArgumentNullException(nameof(convertToDbType)),
                Precision = precision,
                Scale = scale
            };
        }
        #endregion

        #region to string
        public override string ToString()
            => $"CAST({expression} AS {options.ConvertToDbType}{(options.Size.HasValue ? $"({options.Size})" : "")})";
        #endregion

        #region equals
        public bool Equals(CastFunctionExpression obj)
        {
            if (!base.Equals(obj)) return false;

            if (expression is null && obj.expression is object) return false;
            if (expression is object && obj.expression is null) return false;
            if (!expression.Equals(obj.expression)) return false;

            if (this.options is null && obj.options is object) return false;
            if (this.options is object && obj.options is null) return false;
            if (!this.options.Equals(obj.options)) return false;

            return true;
        }

        public override bool Equals(object obj)
            => obj is CastFunctionExpression exp ? Equals(exp) : false;

        public override int GetHashCode()
        {
            unchecked
            {
                const int multiplier = 16777619;

                int hash = base.GetHashCode();
                hash = (hash * multiplier) ^ (expression is object ? expression.GetHashCode() : 0);
                hash = (hash * multiplier) ^ (options is object ? options.GetHashCode() : 0);
                return hash;
            }
        }
        #endregion

        #region classes
        public class CastFunctionExpressionOptions : 
            IExpressionElement,
            IEquatable<CastFunctionExpressionOptions>
        {
            public DbTypeExpression ConvertToDbType { get; set; }
            public int? Size { get; set; }
            public int? Precision { get; set; }
            public int? Scale { get; set; }

            #region equals
            public bool Equals(CastFunctionExpressionOptions obj)
            {
                if (!base.Equals(obj)) return false;

                if (this.ConvertToDbType is null && obj.ConvertToDbType is object) return false;
                if (this.ConvertToDbType is object && obj.ConvertToDbType is null) return false;
                if (!this.ConvertToDbType.Equals(obj.ConvertToDbType)) return false;

                if (this.Size is null && obj.Size is object) return false;
                if (this.Size is object && obj.Size is null) return false;
                if (!this.Size.Equals(obj.Size)) return false;

                if (this.Scale is null && obj.Scale is object) return false;
                if (this.Scale is object && obj.Scale is null) return false;
                if (!this.Scale.Equals(obj.Scale)) return false;

                return true;
            }

            public override bool Equals(object obj)
                => obj is CastFunctionExpressionOptions exp ? Equals(exp) : false;

            public override int GetHashCode()
            {
                unchecked
                {
                    const int multiplier = 16777619;

                    int hash = base.GetHashCode();
                    hash = (hash * multiplier) ^ (ConvertToDbType is object ? ConvertToDbType.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (Size is object ? Size?.GetHashCode() ?? 0 : 0);
                    hash = (hash * multiplier) ^ (Precision is object ? Precision?.GetHashCode() ?? 0 : 0);
                    hash = (hash * multiplier) ^ (Scale is object ? Scale?.GetHashCode() ?? 0 : 0);
                    return hash;
                }
            }
            #endregion
        }
        #endregion
    }
}
