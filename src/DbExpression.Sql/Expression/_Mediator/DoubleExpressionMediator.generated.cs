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
    public partial class DoubleExpressionMediator
    {
        #region arithmetic operators
        #region data type
        #region byte
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, byte b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, byte b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, byte b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, byte b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, byte b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(byte a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(byte a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(byte a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(byte a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(byte a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(byte? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(byte? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(byte? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(byte? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(byte? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(DoubleExpressionMediator a, decimal b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        }

        public static DecimalExpressionMediator operator -(DoubleExpressionMediator a, decimal b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DecimalExpressionMediator operator *(DoubleExpressionMediator a, decimal b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DecimalExpressionMediator operator /(DoubleExpressionMediator a, decimal b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DecimalExpressionMediator operator %(DoubleExpressionMediator a, decimal b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DecimalExpressionMediator operator +(decimal a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DecimalExpressionMediator operator -(decimal a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DecimalExpressionMediator operator *(decimal a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DecimalExpressionMediator operator /(decimal a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DecimalExpressionMediator operator %(decimal a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static DecimalExpressionMediator operator +(DoubleExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DecimalExpressionMediator operator -(DoubleExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DecimalExpressionMediator operator *(DoubleExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DecimalExpressionMediator operator /(DoubleExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DecimalExpressionMediator operator %(DoubleExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DecimalExpressionMediator operator +(decimal? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DecimalExpressionMediator operator -(decimal? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DecimalExpressionMediator operator *(decimal? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DecimalExpressionMediator operator /(decimal? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DecimalExpressionMediator operator %(decimal? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(DoubleExpressionMediator a, DateTime b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DoubleExpressionMediator a, DateTime b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTime a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTime a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DoubleExpressionMediator a, DateTime? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DoubleExpressionMediator a, DateTime? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTime? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTime? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DoubleExpressionMediator a, DateTimeOffset b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeOffsetExpressionMediator operator -(DoubleExpressionMediator a, DateTimeOffset b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeOffsetExpressionMediator operator +(DoubleExpressionMediator a, DateTimeOffset? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeOffsetExpressionMediator operator -(DoubleExpressionMediator a, DateTimeOffset? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region double
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, double b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, double b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, double b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, double b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, double b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(double a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(double a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(double a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(double a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(double a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(double? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(double? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(double? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(double? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(double? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region float
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, float b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, float b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, float b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, float b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, float b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(float a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(float a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(float a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(float a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(float a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(float? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(float? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(float? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(float? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(float? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region short
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, short b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, short b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, short b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, short b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, short b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(short a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(short a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(short a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(short a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(short a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(short? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(short? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(short? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(short? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(short? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region int
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, int b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, int b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, int b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, int b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, int b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(int a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(int a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(int a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(int a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(int a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(int? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(int? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(int? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(int? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(int? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region long
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, long b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, long b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, long b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, long b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, long b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(long a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(long a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(long a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(long a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(long a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(long? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(long? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(long? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(long? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(long? a, DoubleExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region string
        #endregion
        
        #region TimeSpan
        #endregion
        
        #endregion

        #region fields
        #region byte
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableByteFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableByteFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableByteFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableByteFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableByteFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(DoubleExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DecimalExpressionMediator operator -(DoubleExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DecimalExpressionMediator operator *(DoubleExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DecimalExpressionMediator operator /(DoubleExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DecimalExpressionMediator operator %(DoubleExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDecimalExpressionMediator operator +(DoubleExpressionMediator a, NullableDecimalFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(DoubleExpressionMediator a, NullableDecimalFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(DoubleExpressionMediator a, NullableDecimalFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(DoubleExpressionMediator a, NullableDecimalFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(DoubleExpressionMediator a, NullableDecimalFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(DoubleExpressionMediator a, DateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DoubleExpressionMediator a, DateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DoubleExpressionMediator a, NullableDateTimeFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DoubleExpressionMediator a, NullableDateTimeFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DoubleExpressionMediator a, DateTimeOffsetFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeOffsetExpressionMediator operator -(DoubleExpressionMediator a, DateTimeOffsetFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeOffsetExpressionMediator operator +(DoubleExpressionMediator a, NullableDateTimeOffsetFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(DoubleExpressionMediator a, NullableDateTimeOffsetFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region double
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableDoubleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableDoubleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableDoubleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableDoubleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableDoubleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region float
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableSingleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableSingleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableSingleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableSingleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableSingleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region short
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableInt16FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableInt16FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableInt16FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableInt16FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableInt16FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region int
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableInt32FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableInt32FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableInt32FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableInt32FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableInt32FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region long
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableInt64FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableInt64FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableInt64FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableInt64FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableInt64FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #endregion

        #region mediators
        #region byte
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(DoubleExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DecimalExpressionMediator operator -(DoubleExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DecimalExpressionMediator operator *(DoubleExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DecimalExpressionMediator operator /(DoubleExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DecimalExpressionMediator operator %(DoubleExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDecimalExpressionMediator operator +(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(DoubleExpressionMediator a, DateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DoubleExpressionMediator a, DateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DoubleExpressionMediator a, NullableDateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DoubleExpressionMediator a, NullableDateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DoubleExpressionMediator a, DateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeOffsetExpressionMediator operator -(DoubleExpressionMediator a, DateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeOffsetExpressionMediator operator +(DoubleExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(DoubleExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region double
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region float
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region short
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region int
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region long
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region TimeSpan
        #endregion
        
        #endregion

        #region alias
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }


        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, (string TableAlias, string FieldAlias) b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new AliasExpression<double>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<double>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, (string TableAlias, string FieldAlias) b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new AliasExpression<double>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, (string TableAlias, string FieldAlias) b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new AliasExpression<double>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, (string TableAlias, string FieldAlias) b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new AliasExpression<double>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<double>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, (string TableAlias, string FieldAlias) b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new AliasExpression<double>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<double>(b), ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        #endregion

        #region filter operators
        #region null
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullElement b) => new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<double?>(b, field) : b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullElement b) => new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<double?>(b, field) : b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, DoubleExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b.Expression is FieldExpression field ? new LiteralExpression<double?>(a, field) : a, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, DoubleExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<double?>(a), b.Expression is FieldExpression field ? new LiteralExpression<double?>(a, field) : a, FilterExpressionOperator.NotEqual);
        #endregion

        #region byte
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, byte b) => new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, byte b) => new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, byte b) => new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, byte b) => new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, byte b) => new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, byte b) => new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool> operator ==(byte a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(byte a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(byte a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(byte a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(byte a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(byte a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region decimal
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, decimal b) => new FilterExpression<bool>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, decimal b) => new FilterExpression<bool>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, decimal b) => new FilterExpression<bool>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, decimal b) => new FilterExpression<bool>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, decimal b) => new FilterExpression<bool>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, decimal b) => new FilterExpression<bool>(a, new LiteralExpression<decimal>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool> operator ==(decimal a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(decimal a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(decimal a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(decimal a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(decimal a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(decimal a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<decimal>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region double
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, double b) => new FilterExpression<bool>(a, new LiteralExpression<double>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, double b) => new FilterExpression<bool>(a, new LiteralExpression<double>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, double b) => new FilterExpression<bool>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, double b) => new FilterExpression<bool>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, double b) => new FilterExpression<bool>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, double b) => new FilterExpression<bool>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool> operator ==(double a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<double>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(double a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<double>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(double a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(double a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(double a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(double a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region float
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, float b) => new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, float b) => new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, float b) => new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, float b) => new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, float b) => new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, float b) => new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool> operator ==(float a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(float a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(float a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(float a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(float a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(float a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region short
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, short b) => new FilterExpression<bool>(a, new LiteralExpression<short>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, short b) => new FilterExpression<bool>(a, new LiteralExpression<short>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, short b) => new FilterExpression<bool>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, short b) => new FilterExpression<bool>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, short b) => new FilterExpression<bool>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, short b) => new FilterExpression<bool>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool> operator ==(short a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<short>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(short a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<short>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(short a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(short a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(short a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(short a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region int
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, int b) => new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, int b) => new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, int b) => new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, int b) => new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, int b) => new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, int b) => new FilterExpression<bool>(a, new LiteralExpression<int>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool> operator ==(int a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(int a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(int a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(int a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(int a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(int a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<int>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region long
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, long b) => new FilterExpression<bool>(a, new LiteralExpression<long>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, long b) => new FilterExpression<bool>(a, new LiteralExpression<long>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, long b) => new FilterExpression<bool>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, long b) => new FilterExpression<bool>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, long b) => new FilterExpression<bool>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, long b) => new FilterExpression<bool>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool> operator ==(long a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<long>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(long a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<long>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(long a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(long a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(long a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(long a, DoubleExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion


        #region fields
        #region Byte
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, ByteFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, ByteFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, ByteFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, ByteFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, ByteFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, ByteFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region Decimal
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, DecimalFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, DecimalFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, DecimalFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, DecimalFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, DecimalFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, DecimalFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region Double
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, DoubleFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, DoubleFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, DoubleFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, DoubleFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, DoubleFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, DoubleFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region Single
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, SingleFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, SingleFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, SingleFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, SingleFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, SingleFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, SingleFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region Int16
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, Int16FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, Int16FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, Int16FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, Int16FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, Int16FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, Int16FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region Int32
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, Int32FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, Int32FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, Int32FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, Int32FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, Int32FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, Int32FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region Int64
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region mediators
        #region byte
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, ByteExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, ByteExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, ByteExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, ByteExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, ByteExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, ByteExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region decimal
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, DecimalExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, DecimalExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, DecimalExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, DecimalExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, DecimalExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, DecimalExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region double
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, DoubleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, DoubleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, DoubleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, DoubleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, DoubleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, DoubleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region float
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, SingleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, SingleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, SingleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, SingleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, SingleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, SingleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region short
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, Int16ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, Int16ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, Int16ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, Int16ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, Int16ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, Int16ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region int
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, Int32ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, Int32ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, Int32ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, Int32ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, Int32ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, Int32ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region long
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, DoubleExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<double>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, DoubleExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<double>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator <((string TableName, string FieldName) a, DoubleExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<double>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator >((string TableName, string FieldName) a, DoubleExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<double>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator <=((string TableName, string FieldName) a, DoubleExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<double>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<double>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator >=((string TableName, string FieldName) a, DoubleExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<double>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
