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
using HatTrick.DbEx.Sql;

#nullable disable

namespace HatTrick.DbEx.Sql.Expression
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class NullableSingleLogFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableSingleExpressionMediator(NullableSingleLogFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region float
        public static NullableSingleExpressionMediator operator +(NullableSingleLogFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableSingleExpressionMediator operator -(NullableSingleLogFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableSingleExpressionMediator operator *(NullableSingleLogFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableSingleExpressionMediator operator /(NullableSingleLogFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableSingleExpressionMediator operator %(NullableSingleLogFunctionExpression a, float b) => new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableSingleExpressionMediator operator +(float a, NullableSingleLogFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableSingleExpressionMediator operator -(float a, NullableSingleLogFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableSingleExpressionMediator operator *(float a, NullableSingleLogFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableSingleExpressionMediator operator /(float a, NullableSingleLogFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableSingleExpressionMediator operator %(float a, NullableSingleLogFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableSingleExpressionMediator operator +(NullableSingleLogFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableSingleExpressionMediator operator -(NullableSingleLogFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableSingleExpressionMediator operator *(NullableSingleLogFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableSingleExpressionMediator operator /(NullableSingleLogFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableSingleExpressionMediator operator %(NullableSingleLogFunctionExpression a, float? b) => new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));
        
        public static NullableSingleExpressionMediator operator +(float? a, NullableSingleLogFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableSingleExpressionMediator operator -(float? a, NullableSingleLogFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableSingleExpressionMediator operator *(float? a, NullableSingleLogFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableSingleExpressionMediator operator /(float? a, NullableSingleLogFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        
        public static NullableSingleExpressionMediator operator %(float? a, NullableSingleLogFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        
        #endregion
        
        #endregion

        #region fields
        #region float
        public static NullableSingleExpressionMediator operator +(NullableSingleLogFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableSingleExpressionMediator operator -(NullableSingleLogFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableSingleExpressionMediator operator *(NullableSingleLogFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableSingleExpressionMediator operator /(NullableSingleLogFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableSingleExpressionMediator operator %(NullableSingleLogFunctionExpression a, SingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableSingleExpressionMediator operator +(NullableSingleLogFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableSingleExpressionMediator operator -(NullableSingleLogFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableSingleExpressionMediator operator *(NullableSingleLogFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableSingleExpressionMediator operator /(NullableSingleLogFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableSingleExpressionMediator operator %(NullableSingleLogFunctionExpression a, NullableSingleFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #endregion

        #region mediator
        #region float
        public static NullableSingleExpressionMediator operator +(NullableSingleLogFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableSingleExpressionMediator operator -(NullableSingleLogFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableSingleExpressionMediator operator *(NullableSingleLogFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableSingleExpressionMediator operator /(NullableSingleLogFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableSingleExpressionMediator operator %(NullableSingleLogFunctionExpression a, SingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableSingleExpressionMediator operator +(NullableSingleLogFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableSingleExpressionMediator operator -(NullableSingleLogFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableSingleExpressionMediator operator *(NullableSingleLogFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableSingleExpressionMediator operator /(NullableSingleLogFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableSingleExpressionMediator operator %(NullableSingleLogFunctionExpression a, NullableSingleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #endregion

        #region alias
        public static NullableSingleExpressionMediator operator +(NullableSingleLogFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableSingleExpressionMediator operator -(NullableSingleLogFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableSingleExpressionMediator operator *(NullableSingleLogFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        
        public static NullableSingleExpressionMediator operator /(NullableSingleLogFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        
        public static NullableSingleExpressionMediator operator %(NullableSingleLogFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        
        public static NullableSingleExpressionMediator operator +(NullableSingleLogFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<float?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableSingleExpressionMediator operator -(NullableSingleLogFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableSingleExpressionMediator operator *(NullableSingleLogFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        
        public static NullableSingleExpressionMediator operator /(NullableSingleLogFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        
        public static NullableSingleExpressionMediator operator %(NullableSingleLogFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<float?>(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion
        #endregion

        #region filter operators
        #region null
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data type
        #region byte
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, byte b) => new FilterExpression<bool?>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(byte a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(byte a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(byte a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(byte a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(byte a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(byte a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, byte? b) => new FilterExpression<bool?>(a, new LiteralExpression<byte?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(byte? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(byte? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(byte? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(byte? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(byte? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(byte? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<byte?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region decimal
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, decimal b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(decimal a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(decimal a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(decimal a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(decimal a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(decimal a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(decimal a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, decimal? b) => new FilterExpression<bool?>(a, new LiteralExpression<decimal?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(decimal? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(decimal? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(decimal? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(decimal? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(decimal? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(decimal? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<decimal?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region double
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, double b) => new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(double a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(double a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(double a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(double a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(double a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(double a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, double? b) => new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(double? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(double? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(double? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(double? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(double? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(double? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region float
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, float b) => new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(float a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(float a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(float a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(float a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(float a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(float a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, float? b) => new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(float? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(float? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(float? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(float? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(float? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(float? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region short
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, short b) => new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(short a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(short a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(short a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(short a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(short a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(short a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, short? b) => new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(short? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(short? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(short? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(short? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(short? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(short? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region int
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, int b) => new FilterExpression<bool?>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(int a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(int a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(int a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(int a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(int a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(int a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, int? b) => new FilterExpression<bool?>(a, new LiteralExpression<int?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(int? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(int? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(int? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(int? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(int? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(int? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<int?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region long
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(long a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(long a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(long a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(long a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(long a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(long a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(long? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(long? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(long? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(long? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(long? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(long? a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region fields
        #region byte
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, ByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region decimal
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, DecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region double
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, DoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region float
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, SingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region short
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, Int16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region int
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, Int32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region long
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region mediators
        #region byte
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region decimal
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, DecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region double
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, DoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region float
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region short
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, Int16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region int
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region long
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableSingleLogFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<float>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<float>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableSingleLogFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<float>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<float>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(NullableSingleLogFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<float>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator <((string TableName, string FieldName) a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<float>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(NullableSingleLogFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<float>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator >((string TableName, string FieldName) a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<float>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(NullableSingleLogFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<float>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator <=((string TableName, string FieldName) a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<float>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(NullableSingleLogFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<float>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator >=((string TableName, string FieldName) a, NullableSingleLogFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<float>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #endregion
    }
}
