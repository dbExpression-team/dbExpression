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
using DbExpression.Sql.Expression;

#nullable disable

namespace DbExpression.MsSql.Expression
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class SysDateTimeFunctionExpression
    {
        #region implicit operators
        public static implicit operator DateTimeExpressionMediator(SysDateTimeFunctionExpression a) => new(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region DateTime
        public static DateTimeExpressionMediator operator +(SysDateTimeFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(SysDateTimeFunctionExpression a, DateTime b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(DateTime a, SysDateTimeFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime a, SysDateTimeFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(SysDateTimeFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(SysDateTimeFunctionExpression a, DateTime? b) => new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(DateTime? a, SysDateTimeFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime? a, SysDateTimeFunctionExpression b) => new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion

        #region mediators
        #region DateTime
        public static DateTimeExpressionMediator operator +(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }


        public static NullableDateTimeExpressionMediator operator +(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) 
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
        public static DateTimeExpressionMediator operator +(SysDateTimeFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        
        public static DateTimeExpressionMediator operator -(SysDateTimeFunctionExpression a, AliasExpression b) => new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        
        public static DateTimeExpressionMediator operator +(SysDateTimeFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        
        public static DateTimeExpressionMediator operator -(SysDateTimeFunctionExpression a, (string TableName, string FieldName) b) => new(new ArithmeticExpression(a, new AliasExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion
        #endregion

        #region filter operators
        #region null
        public static FilterExpression<bool?> operator ==(SysDateTimeFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(SysDateTimeFunctionExpression a, NullElement b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        #endregion

        #region data types
        #region DateTime
        public static FilterExpression<bool> operator ==(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(SysDateTimeFunctionExpression a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool> operator ==(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DateTime a, SysDateTimeFunctionExpression b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(SysDateTimeFunctionExpression a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTime? a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion
        #endregion

        #region mediators
        public static FilterExpression<bool> operator ==(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(SysDateTimeFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(SysDateTimeFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(SysDateTimeFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(SysDateTimeFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(SysDateTimeFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(SysDateTimeFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(SysDateTimeFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(SysDateTimeFunctionExpression a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(SysDateTimeFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<object>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(SysDateTimeFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<object>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(SysDateTimeFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator <((string TableName, string FieldName) a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<object>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(SysDateTimeFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator >((string TableName, string FieldName) a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<object>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(SysDateTimeFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator <=((string TableName, string FieldName) a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<object>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(SysDateTimeFunctionExpression a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<object>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator >=((string TableName, string FieldName) a, SysDateTimeFunctionExpression b) => new FilterExpression<bool?>(new AliasExpression<object>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
