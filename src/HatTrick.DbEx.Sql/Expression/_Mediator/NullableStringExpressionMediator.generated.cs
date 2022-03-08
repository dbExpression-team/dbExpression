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

#nullable enable

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableStringExpressionMediator
    {
        #region arithmetic operators 
        #region data type 













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

        #region string?
        public static NullableStringExpressionMediator operator +(NullableStringExpressionMediator a, StringFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));

        public static NullableStringExpressionMediator operator +(NullableStringExpressionMediator a, NullableStringFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        #endregion

        #region TimeSpan

        #endregion

        #endregion

        #region mediator













        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(NullableStringExpressionMediator a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableStringExpressionMediator a, DBNull b) => new(new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<string?>(b, field) : new LiteralExpression<string?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringExpressionMediator a, DBNull b) => new(new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<string?>(b, field) : new LiteralExpression<string?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableStringExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<string?>(a), b.Expression is FieldExpression field ? new LiteralExpression<string?>(a, field) : new LiteralExpression<string?>(a), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableStringExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<string?>(a), b.Expression is FieldExpression field ? new LiteralExpression<string?>(a, field) : new LiteralExpression<string?>(a), FilterExpressionOperator.NotEqual));
        #endregion

        #region data type
        #region string?
        public static FilterExpressionSet operator ==(NullableStringExpressionMediator a, string? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringExpressionMediator a, string? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringExpressionMediator a, string? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableStringExpressionMediator a, string? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableStringExpressionMediator a, string? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableStringExpressionMediator a, string? b) => new(new FilterExpression<bool?>(a, new LiteralExpression<string?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(string? a, NullableStringExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(string? a, NullableStringExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(string? a, NullableStringExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(string? a, NullableStringExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(string? a, NullableStringExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(string? a, NullableStringExpressionMediator b) => new(new FilterExpression<bool?>(new LiteralExpression<string?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion
        #endregion

        #region fields

        public static FilterExpressionSet operator ==(NullableStringExpressionMediator a, StringFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));

        public static FilterExpressionSet operator !=(NullableStringExpressionMediator a, StringFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));

        public static FilterExpressionSet operator <(NullableStringExpressionMediator a, StringFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));

        public static FilterExpressionSet operator >(NullableStringExpressionMediator a, StringFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));

        public static FilterExpressionSet operator <=(NullableStringExpressionMediator a, StringFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));

        public static FilterExpressionSet operator >=(NullableStringExpressionMediator a, StringFieldExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion
        
        #region mediator
        public static FilterExpressionSet operator ==(NullableStringExpressionMediator a, StringExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringExpressionMediator a, StringExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringExpressionMediator a, StringExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableStringExpressionMediator a, StringExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableStringExpressionMediator a, StringExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableStringExpressionMediator a, StringExpressionMediator b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableStringExpressionMediator a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringExpressionMediator a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringExpressionMediator a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableStringExpressionMediator a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableStringExpressionMediator a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableStringExpressionMediator a, AliasExpression b) => new(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        public static FilterExpressionSet operator ==(NullableStringExpressionMediator a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableStringExpressionMediator a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableStringExpressionMediator a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableStringExpressionMediator a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableStringExpressionMediator a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableStringExpressionMediator a, (string TableName, string FieldName) b) => new(new FilterExpression<bool?>(a, new AliasExpression(b.TableName, b.FieldName), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
