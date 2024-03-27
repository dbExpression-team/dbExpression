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

#nullable disable

namespace DbExpression.Sql.Expression
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
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

        #region string
        public static NullableStringExpressionMediator operator +(NullableStringExpressionMediator a, StringFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableStringExpressionMediator operator +(NullableStringExpressionMediator a, NullableStringFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        #endregion

        #region TimeSpan
        #endregion

        #endregion

        #region mediator













        #endregion

        #region alias
        public static NullableStringExpressionMediator operator +(NullableStringExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableStringExpressionMediator operator +(NullableStringExpressionMediator a, (string TableAlias, string FieldAlias) b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new AliasExpression<string>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<string>(b), ArithmeticExpressionOperator.Add));
        }

        #endregion
        #endregion

        #region filter operators
        #region null
        public static FilterExpression<bool?> operator ==(NullableStringExpressionMediator a, NullElement b) => new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<string>(b, field) : b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableStringExpressionMediator a, NullElement b) => new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<string>(b, field) : b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b.Expression is FieldExpression field ? new LiteralExpression<string>(a, field) : a, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b.Expression is FieldExpression field ? new LiteralExpression<string>(a, field) : a, FilterExpressionOperator.NotEqual);
        #endregion

        #region data type
        #region string
        public static FilterExpression<bool?> operator ==(NullableStringExpressionMediator a, string b) => new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableStringExpressionMediator a, string b) => new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableStringExpressionMediator a, string b) => new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableStringExpressionMediator a, string b) => new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableStringExpressionMediator a, string b) => new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableStringExpressionMediator a, string b) => new FilterExpression<bool?>(a, new LiteralExpression<string>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(string a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(string a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(string a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(string a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(string a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(string a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<string>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region fields
        #region string
        public static FilterExpression<bool?> operator ==(NullableStringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableStringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(NullableStringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(NullableStringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(NullableStringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(NullableStringExpressionMediator a, StringFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #endregion
        
        #region mediator
        #region string
        public static FilterExpression<bool?> operator ==(NullableStringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableStringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableStringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableStringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableStringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableStringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(NullableStringExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableStringExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableStringExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableStringExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableStringExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableStringExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableStringExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<string>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableStringExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<string>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(NullableStringExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator <((string TableName, string FieldName) a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<string>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(NullableStringExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator >((string TableName, string FieldName) a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<string>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(NullableStringExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator <=((string TableName, string FieldName) a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<string>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(NullableStringExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<string>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator >=((string TableName, string FieldName) a, NullableStringExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<string>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
