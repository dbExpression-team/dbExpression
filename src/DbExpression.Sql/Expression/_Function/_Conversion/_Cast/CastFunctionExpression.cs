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

namespace DbExpression.Sql.Expression
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
            options = new CastFunctionExpressionOptions(convertToDbType ?? throw new ArgumentNullException(nameof(convertToDbType)));
        }

        protected CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, Type convertToType, int size) : base(convertToType)
        {
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
            options = new CastFunctionExpressionOptions(convertToDbType ?? throw new ArgumentNullException(nameof(convertToDbType)))
            {
                Size = size
            }; 
        }

        protected CastFunctionExpression(IExpressionElement expression, DbTypeExpression convertToDbType, Type convertToType, int precision, int? scale) : base(convertToType)
        {
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
            options = new CastFunctionExpressionOptions(convertToDbType ?? throw new ArgumentNullException(nameof(convertToDbType)))
            {
                Precision = precision,
                Scale = scale
            };
        }
        #endregion

        #region to string
        public override string? ToString()
            => $"CAST({expression} AS {options.ConvertToDbType}{(options.Size.HasValue ? $"({options.Size})" : "")})";
        #endregion

        #region equals
        public bool Equals(CastFunctionExpression? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (expression is null && obj.expression is not null) return false;
            if (expression is not null && obj.expression is null) return false;
            if (expression is not null && !expression.Equals(obj.expression)) return false;

            if (obj.options is null) return false;
            if (!options.Equals(obj.options)) return false;

            return true;
        }

        public override bool Equals(object? obj)
            => obj is CastFunctionExpression exp && Equals(exp);

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
        public class CastFunctionExpressionOptions :
            IExpressionElement,
            IEquatable<CastFunctionExpressionOptions>
        {
            #region interface
            public DbTypeExpression ConvertToDbType { get; private set; }
            public int? Size { get; set; }
            public int? Precision { get; set; }
            public int? Scale { get; set; }
            #endregion

            #region constructors
            public CastFunctionExpressionOptions(DbTypeExpression convertToDbType)
            {
                ConvertToDbType = convertToDbType;
            }
            #endregion

            #region equals
            public bool Equals(CastFunctionExpressionOptions? obj)
            {
                if (obj is null) return false;
                if (ReferenceEquals(this, obj)) return true;

                if (ConvertToDbType is null && obj.ConvertToDbType is not null) return false;
                if (ConvertToDbType is not null && obj.ConvertToDbType is null) return false;
                if (ConvertToDbType is not null && !ConvertToDbType.Equals(obj.ConvertToDbType)) return false;

                if (Size is null && obj.Size is not null) return false;
                if (Size is not null && obj.Size is null) return false;
                if (Size is not null && !Size.Equals(obj.Size)) return false;

                if (Scale is null && obj.Scale is not null) return false;
                if (Scale is not null && obj.Scale is null) return false;
                if (Scale is not null && !Scale.Equals(obj.Scale)) return false;

                return true;
            }

            public override bool Equals(object? obj)
                => obj is CastFunctionExpressionOptions exp && Equals(exp);

            public override int GetHashCode()
            {
                unchecked
                {
                    const int multiplier = 16777619;

                    int hash = base.GetHashCode();
                    hash = (hash * multiplier) ^ (ConvertToDbType is not null ? ConvertToDbType.GetHashCode() : 0);
                    hash = (hash * multiplier) ^ (Size is not null ? Size?.GetHashCode() ?? 0 : 0);
                    hash = (hash * multiplier) ^ (Precision is not null ? Precision?.GetHashCode() ?? 0 : 0);
                    hash = (hash * multiplier) ^ (Scale is not null ? Scale?.GetHashCode() ?? 0 : 0);
                    return hash;
                }
            }
            #endregion
        }
        #endregion
    }
}
