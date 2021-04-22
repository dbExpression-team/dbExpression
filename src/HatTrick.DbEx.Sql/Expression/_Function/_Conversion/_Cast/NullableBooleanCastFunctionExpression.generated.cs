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
    public partial class NullableBooleanCastFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableBooleanExpressionMediator(NullableBooleanCastFunctionExpression a) => new NullableBooleanExpressionMediator(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region bool



        
        #endregion
        
        #region byte



        
        #endregion
        
        #region decimal



        
        #endregion
        
        #region DateTime



        
        #endregion
        
        #region DateTimeOffset



        
        #endregion
        
        #region double



        
        #endregion
        
        #region float



        
        #endregion
        
        #region Guid



        
        #endregion
        
        #region short



        
        #endregion
        
        #region int



        
        #endregion
        
        #region long



        
        #endregion
        
        #region string
        
        #endregion
        
        #region TimeSpan



        
        #endregion
        
        #endregion

        #region fields
        #region bool

        #endregion        
        #region byte

        #endregion        
        #region decimal

        #endregion        
        #region DateTime

        #endregion        
        #region DateTimeOffset

        #endregion        
        #region double

        #endregion        
        #region float

        #endregion        
        #region Guid

        #endregion        
        #region short

        #endregion        
        #region int

        #endregion        
        #region long

        #endregion        
        #region string

        #endregion        
        #region TimeSpan

        #endregion        
        #endregion

        #region mediator
        #region bool

        #endregion
        
        #region byte

        #endregion
        
        #region decimal

        #endregion
        
        #region DateTime

        #endregion
        
        #region DateTimeOffset

        #endregion
        
        #region double

        #endregion
        
        #region float

        #endregion
        
        #region Guid

        #endregion
        
        #region short

        #endregion
        
        #region int

        #endregion
        
        #region long

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion

        #region alias
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableBooleanCastFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<bool?>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanCastFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<bool?>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableBooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<bool?>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableBooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<bool?>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data type
        #region bool
        public static FilterExpressionSet operator ==(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<bool>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanCastFunctionExpression a, bool b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<bool>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<bool>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(bool a, NullableBooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<bool>(a), b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanCastFunctionExpression a, bool? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<bool?>(b), FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(bool? a, NullableBooleanCastFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<bool?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableBooleanCastFunctionExpression a, BooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanCastFunctionExpression a, BooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        
        public static FilterExpressionSet operator ==(NullableBooleanCastFunctionExpression a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanCastFunctionExpression a, NullableBooleanFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanCastFunctionExpression a, BooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator ==(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanCastFunctionExpression a, NullableBooleanExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableBooleanCastFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableBooleanCastFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        #endregion

        #endregion
    }
}
