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

using System;
using DbExpression.Sql;

#nullable disable

namespace DbExpression.Sql.Expression
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class DateTimeOffsetDateAddFunctionExpression
    {
        #region implicit operators
        public static implicit operator DateTimeOffsetExpressionMediator(DateTimeOffsetDateAddFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        
        public static DateTimeExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));
        
        public static DateTimeExpressionMediator operator +(DateTime a, DateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        
        public static DateTimeExpressionMediator operator -(DateTime a, DateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(DateTime? a, DateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, DateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));
        
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #endregion

        #region fields
        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static DateTimeExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        #endregion        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        #endregion        
        #endregion

        #region mediators
        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
 
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
 
        #endregion

        #region alias
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion
        #endregion

        #region filter operators
        #region null
        public static FilterExpression<bool?> operator ==(DateTimeOffsetDateAddFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTimeOffsetDateAddFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data types
        #region DateTime
        public static FilterExpression<bool> operator ==(DateTimeOffsetDateAddFunctionExpression a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DateTimeOffsetDateAddFunctionExpression a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DateTimeOffsetDateAddFunctionExpression a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DateTimeOffsetDateAddFunctionExpression a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DateTimeOffsetDateAddFunctionExpression a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DateTimeOffsetDateAddFunctionExpression a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool> operator ==(DateTime a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DateTime a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DateTime a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DateTime a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DateTime a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DateTime a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTimeOffsetDateAddFunctionExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTimeOffsetDateAddFunctionExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTimeOffsetDateAddFunctionExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTimeOffsetDateAddFunctionExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTimeOffsetDateAddFunctionExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTimeOffsetDateAddFunctionExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTime? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTime? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTime? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTime? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTime? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTime? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool> operator ==(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool> operator ==(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DateTimeOffset a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTimeOffset? a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region fields
        public static FilterExpression<bool> operator ==(DateTimeOffsetDateAddFunctionExpression a, DateTimeFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DateTimeOffsetDateAddFunctionExpression a, DateTimeFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DateTimeOffsetDateAddFunctionExpression a, DateTimeFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DateTimeOffsetDateAddFunctionExpression a, DateTimeFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DateTimeOffsetDateAddFunctionExpression a, DateTimeFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DateTimeOffsetDateAddFunctionExpression a, DateTimeFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool> operator ==(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region mediators
        #region DateTime
        public static FilterExpression<bool> operator ==(DateTimeOffsetDateAddFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DateTimeOffsetDateAddFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DateTimeOffsetDateAddFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DateTimeOffsetDateAddFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DateTimeOffsetDateAddFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DateTimeOffsetDateAddFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool> operator ==(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DateTimeOffsetDateAddFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTimeOffsetDateAddFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(DateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTimeOffsetDateAddFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTimeOffset>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<DateTimeOffset>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(DateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTimeOffset>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<DateTimeOffset>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(DateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator <((string TableName, string FieldName) a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(DateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator >((string TableName, string FieldName) a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(DateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator <=((string TableName, string FieldName) a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(DateTimeOffsetDateAddFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator >=((string TableName, string FieldName) a, DateTimeOffsetDateAddFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
