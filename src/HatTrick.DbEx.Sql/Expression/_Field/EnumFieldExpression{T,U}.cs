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

namespace HatTrick.DbEx.Sql.Expression
{
    public class EnumFieldExpression<TEntity, TEnum> : EnumFieldExpression<TEnum>,
        IEquatable<EnumFieldExpression<TEntity, TEnum>>
        where TEntity : class, IDbEntity
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public EnumFieldExpression(int identifier, string name, Table entity) : base(identifier, name, typeof(TEnum), entity)
        {

        }
        #endregion

        #region equals
        public bool Equals(EnumFieldExpression<TEntity, TEnum>? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is EnumFieldExpression<TEntity, TEnum> exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator EnumExpressionMediator<TEnum>(EnumFieldExpression<TEntity, TEnum> a) => new(a);
        #endregion

        #region filter operators
        #region TEnum
        public static FilterExpression operator ==(EnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpression<TEnum>(a, new LiteralExpression<TEnum>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(EnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpression<TEnum>(a, new LiteralExpression<TEnum>(b, a), FilterExpressionOperator.NotEqual);

        public static FilterExpression operator ==(TEnum a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum>(new LiteralExpression<TEnum>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(TEnum a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum>(new LiteralExpression<TEnum>(a, b), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator ==(EnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpression<TEnum?>(a, new LiteralExpression<TEnum?>(b, a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(EnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpression<TEnum?>(a, new LiteralExpression<TEnum?>(b, a), FilterExpressionOperator.NotEqual);

        public static FilterExpression operator ==(TEnum? a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum?>(a, b), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(TEnum? a, EnumFieldExpression<TEntity, TEnum> b) => new FilterExpression<TEnum?>(new LiteralExpression<TEnum?>(a, b), b, FilterExpressionOperator.NotEqual);
        #endregion

        #region mediator
        public static FilterExpression operator ==(EnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(EnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator ==(EnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(EnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpression<TEnum?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion
        #endregion
    }
}
