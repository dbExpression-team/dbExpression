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

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class EnumExpressionMediator<TEnum> :
        ExpressionMediator<TEnum>,
        EnumElement<TEnum>,
        AnyEnumElement<TEnum>,
        IEquatable<EnumExpressionMediator<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        protected EnumExpressionMediator()
        {
        }

        public EnumExpressionMediator(IExpressionElement expression) : base(expression)
        {
        }

        protected EnumExpressionMediator(IExpressionElement expression, string alias) : base(expression, alias)
        {
        }

        protected EnumExpressionMediator(IExpressionElement expression, Type declaredType, string alias) : base(expression, declaredType, alias)
        {
        }
        #endregion

        #region as
        public EnumElement<TEnum> As(string alias)
            => new EnumSelectExpression<TEnum>(this).As(alias);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new EnumExpressionMediator<TEnum>(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new EnumExpressionMediator<TEnum>(this), OrderExpressionDirection.DESC);
        #endregion

        #region equals
        public bool Equals(EnumExpressionMediator<TEnum> obj)
            => obj is EnumExpressionMediator<TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is EnumExpressionMediator<TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region filter operators
        public static FilterExpressionSet operator ==(EnumExpressionMediator<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(EnumExpressionMediator<TEnum> a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(EnumExpressionMediator<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(EnumExpressionMediator<TEnum> a, NullableEnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(AliasExpression a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(AliasExpression a, EnumExpressionMediator<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(EnumExpressionMediator<TEnum> a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(EnumExpressionMediator<TEnum> a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

    }
}
