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
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class NullableInt64ExpressionMediator
    {
        #region arithmetic operators 
        #region data type 
        #region byte
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, byte b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, byte b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, byte b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, byte b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, byte b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(byte a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(byte a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(byte a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(byte a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(byte a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(byte? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(byte? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(byte? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(byte? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(byte? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt64ExpressionMediator a, decimal b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(NullableInt64ExpressionMediator a, decimal b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(NullableInt64ExpressionMediator a, decimal b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(NullableInt64ExpressionMediator a, decimal b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(NullableInt64ExpressionMediator a, decimal b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDecimalExpressionMediator operator +(decimal a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(decimal a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(decimal a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(decimal a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(decimal a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDecimalExpressionMediator operator +(NullableInt64ExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(NullableInt64ExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(NullableInt64ExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(NullableInt64ExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(NullableInt64ExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTime b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTime b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTime? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTime? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTimeOffset b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTimeOffset b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTimeOffset? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTimeOffset? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt64ExpressionMediator a, double b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableInt64ExpressionMediator a, double b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableInt64ExpressionMediator a, double b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableInt64ExpressionMediator a, double b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableInt64ExpressionMediator a, double b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(double a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(double a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(double a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(double a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(double a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableInt64ExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableInt64ExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableInt64ExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableInt64ExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableInt64ExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(double? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(double? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(double? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(double? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(double? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt64ExpressionMediator a, float b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableSingleExpressionMediator operator -(NullableInt64ExpressionMediator a, float b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableSingleExpressionMediator operator *(NullableInt64ExpressionMediator a, float b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableSingleExpressionMediator operator /(NullableInt64ExpressionMediator a, float b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableSingleExpressionMediator operator %(NullableInt64ExpressionMediator a, float b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableSingleExpressionMediator operator +(float a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableSingleExpressionMediator operator -(float a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableSingleExpressionMediator operator *(float a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableSingleExpressionMediator operator /(float a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableSingleExpressionMediator operator %(float a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableSingleExpressionMediator operator +(NullableInt64ExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableSingleExpressionMediator operator -(NullableInt64ExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableSingleExpressionMediator operator *(NullableInt64ExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableSingleExpressionMediator operator /(NullableInt64ExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableSingleExpressionMediator operator %(NullableInt64ExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableSingleExpressionMediator operator +(float? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableSingleExpressionMediator operator -(float? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableSingleExpressionMediator operator *(float? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableSingleExpressionMediator operator /(float? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableSingleExpressionMediator operator %(float? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region short
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, short b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, short b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, short b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, short b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, short b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(short a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(short a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(short a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(short a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(short a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(short? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(short? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(short? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(short? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(short? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region int
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, int b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, int b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, int b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, int b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, int b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(int a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(int a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(int a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(int a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(int a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(int? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(int? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(int? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(int? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(int? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, long b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, long b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, long b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, long b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, long b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(long a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(long a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(long a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(long a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(long a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(long? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(long? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(long? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(long? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(long? a, NullableInt64ExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion


        #region TimeSpan
        #endregion

        #endregion

        #region fields
        #region byte
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt64ExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(NullableInt64ExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(NullableInt64ExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(NullableInt64ExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(NullableInt64ExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDecimalExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableDecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableDecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableDecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTimeOffsetFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTimeOffsetFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDateTimeOffsetFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDateTimeOffsetFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt64ExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableInt64ExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableInt64ExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableInt64ExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableInt64ExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableDoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableDoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableDoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt64ExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableSingleExpressionMediator operator -(NullableInt64ExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableSingleExpressionMediator operator *(NullableInt64ExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableSingleExpressionMediator operator /(NullableInt64ExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableSingleExpressionMediator operator %(NullableInt64ExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableSingleExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableSingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableSingleExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableSingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableSingleExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableSingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableSingleExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableSingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableSingleExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableSingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region short
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableInt16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableInt16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableInt16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableInt16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableInt16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region int
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableInt32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableInt32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableInt32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableInt32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableInt32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region string?
        #endregion

        #region TimeSpan
        #endregion

        #endregion

        #region mediator
        #region byte
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt64ExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(NullableInt64ExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(NullableInt64ExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(NullableInt64ExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(NullableInt64ExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDecimalExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt64ExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableInt64ExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableInt64ExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableInt64ExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableInt64ExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt64ExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableSingleExpressionMediator operator -(NullableInt64ExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableSingleExpressionMediator operator *(NullableInt64ExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableSingleExpressionMediator operator /(NullableInt64ExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableSingleExpressionMediator operator %(NullableInt64ExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableSingleExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableSingleExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableSingleExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableSingleExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableSingleExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region short
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region int
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion


        #region TimeSpan
        #endregion

        #endregion

        #region alias
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, (string TableAlias, string FieldAlias) b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new AliasExpression<long>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<long>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, (string TableAlias, string FieldAlias) b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new AliasExpression<long>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, (string TableAlias, string FieldAlias) b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new AliasExpression<long>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, (string TableAlias, string FieldAlias) b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new AliasExpression<long>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<long>(b), ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, (string TableAlias, string FieldAlias) b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new AliasExpression<long>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<long>(b), ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression operator ==(NullableInt64ExpressionMediator a, DBNull b) => new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<long?>(b, field) : new LiteralExpression<long?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableInt64ExpressionMediator a, DBNull b) => new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<long?>(b, field) : new LiteralExpression<long?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator ==(DBNull a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b.Expression is FieldExpression field ? new LiteralExpression<long?>(a, field) : new LiteralExpression<long?>(a), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DBNull a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b.Expression is FieldExpression field ? new LiteralExpression<long?>(a, field) : new LiteralExpression<long?>(a), FilterExpressionOperator.NotEqual);
        #endregion

        #region data type
        #region long
        public static FilterExpression operator ==(NullableInt64ExpressionMediator a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableInt64ExpressionMediator a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableInt64ExpressionMediator a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableInt64ExpressionMediator a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableInt64ExpressionMediator a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableInt64ExpressionMediator a, long b) => new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(long a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(long a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(long a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(long a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(long a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(long a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(NullableInt64ExpressionMediator a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableInt64ExpressionMediator a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableInt64ExpressionMediator a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableInt64ExpressionMediator a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableInt64ExpressionMediator a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableInt64ExpressionMediator a, long? b) => new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(long? a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(long? a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(long? a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(long? a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(long? a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(long? a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region fields

        public static FilterExpression operator ==(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator >(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator <=(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >=(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);


        public static FilterExpression operator ==(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression operator !=(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression operator <(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression operator >(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression operator <=(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression operator >=(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression operator ==(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region alias
        public static FilterExpression operator ==(NullableInt64ExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableInt64ExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableInt64ExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableInt64ExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableInt64ExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableInt64ExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        public static FilterExpression operator ==(NullableInt64ExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<long?>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(NullableInt64ExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<long?>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(NullableInt64ExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<long?>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(NullableInt64ExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<long?>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(NullableInt64ExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<long?>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(NullableInt64ExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<long?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
