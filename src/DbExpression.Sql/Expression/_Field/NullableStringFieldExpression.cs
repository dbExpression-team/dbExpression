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
    /// <summary>
    /// Field expression representing nullable strings.
    /// </summary>
    /// <remarks>
    /// Due to nullability of reference types and abstract members in base, cannot follow the same pattern for other nullable fields.
    /// MUST inherit directly from FieldExpression{String}, not NullableFieldExpression{String,String?}.
    /// </remarks>
    public abstract partial class NullableStringFieldExpression :
        NullableFieldExpression<string,string?>,
        NullableStringElement,
        IEquatable<NullableStringFieldExpression>
    {
        #region constructors
        protected NullableStringFieldExpression(int identifier, string name, Table entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public new NullableStringElement As(string alias)
            => new NullableStringSelectExpression(this, alias);
        #endregion

        #region like
        public FilterExpression Like(string phrase)
            => new FilterExpression<bool>(this, new LikeExpression(phrase), FilterExpressionOperator.None);
        #endregion

        #region equals
        public bool Equals(NullableStringFieldExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is NullableStringFieldExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region fields
        public static FilterExpression<bool?> operator ==(StringFieldExpression a, NullableStringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(StringFieldExpression a, NullableStringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(StringFieldExpression a, NullableStringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator >(StringFieldExpression a, NullableStringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator <=(StringFieldExpression a, NullableStringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >=(StringFieldExpression a, NullableStringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableStringFieldExpression a, NullableStringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableStringFieldExpression a, NullableStringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableStringFieldExpression a, NullableStringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator >(NullableStringFieldExpression a, NullableStringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator <=(NullableStringFieldExpression a, NullableStringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >=(NullableStringFieldExpression a, NullableStringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
