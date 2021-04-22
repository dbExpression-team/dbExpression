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
    public class NullableEnumFieldExpression<TEntity, TEnum> : NullableEnumFieldExpression<TEnum>,
        IEquatable<NullableEnumFieldExpression<TEntity, TEnum>>
        where TEntity : class, IDbEntity
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public NullableEnumFieldExpression(string identifier, string name, EntityExpression entity) : base(identifier, name, entity)
        {

        }
        #endregion

        #region as
        public override NullableEnumElement<TEnum> As(string alias)
            => new NullableEnumSelectExpression<TEnum>(this).As(alias);
        #endregion

        #region in value set
        public override FilterExpressionSet In(params TEnum?[] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool?>(this, new InExpression<TEnum?>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<TEnum?> value) => value is object ? new FilterExpressionSet(new FilterExpression<bool?>(this, new InExpression<TEnum?>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(params TEnum[] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<TEnum>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<TEnum> value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<TEnum>(value), FilterExpressionOperator.None)) : null;
        #endregion

        #region equals
        public bool Equals(NullableEnumFieldExpression<TEntity, TEnum> obj)
            => obj is EnumFieldExpression<TEntity, TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableEnumFieldExpression<TEntity, TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator NullableEnumExpressionMediator<TEnum>(NullableEnumFieldExpression<TEntity, TEnum> a) => new NullableEnumExpressionMediator<TEnum>(a);
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, DBNull b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, new LiteralExpression<TEnum?>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, DBNull b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, new LiteralExpression<TEnum?>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(new LiteralExpression<TEnum?>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(new LiteralExpression<TEnum?>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region TEnum
        public static FilterExpressionSet operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, new LiteralExpression<TEnum>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, TEnum b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, new LiteralExpression<TEnum>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(TEnum a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(new LiteralExpression<TEnum>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TEnum a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(new LiteralExpression<TEnum>(a), b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, new LiteralExpression<TEnum?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, TEnum? b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, new LiteralExpression<TEnum?>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(TEnum? a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(new LiteralExpression<TEnum?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(TEnum? a, NullableEnumFieldExpression<TEntity, TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(new LiteralExpression<TEnum?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(NullableEnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableEnumFieldExpression<TEntity, TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<TEnum>(a, b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion
    }
}
