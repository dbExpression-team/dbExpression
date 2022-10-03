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
    public partial class ByteExpressionMediator
    {
        #region arithmetic operators
        #region data type
        #region byte
        public static ByteExpressionMediator operator +(ByteExpressionMediator a, byte b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        }

        public static ByteExpressionMediator operator -(ByteExpressionMediator a, byte b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static ByteExpressionMediator operator *(ByteExpressionMediator a, byte b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static ByteExpressionMediator operator /(ByteExpressionMediator a, byte b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        }

        public static ByteExpressionMediator operator %(ByteExpressionMediator a, byte b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static ByteExpressionMediator operator +(byte a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static ByteExpressionMediator operator -(byte a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static ByteExpressionMediator operator *(byte a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static ByteExpressionMediator operator /(byte a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static ByteExpressionMediator operator %(byte a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static ByteExpressionMediator operator +(ByteExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        }

        public static ByteExpressionMediator operator -(ByteExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static ByteExpressionMediator operator *(ByteExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static ByteExpressionMediator operator /(ByteExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static ByteExpressionMediator operator %(ByteExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static ByteExpressionMediator operator +(byte? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static ByteExpressionMediator operator -(byte? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static ByteExpressionMediator operator *(byte? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static ByteExpressionMediator operator /(byte? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static ByteExpressionMediator operator %(byte? a, ByteExpressionMediator b) 
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
        public static DecimalExpressionMediator operator +(ByteExpressionMediator a, decimal b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        }

        public static DecimalExpressionMediator operator -(ByteExpressionMediator a, decimal b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DecimalExpressionMediator operator *(ByteExpressionMediator a, decimal b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DecimalExpressionMediator operator /(ByteExpressionMediator a, decimal b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DecimalExpressionMediator operator %(ByteExpressionMediator a, decimal b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DecimalExpressionMediator operator +(decimal a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DecimalExpressionMediator operator -(decimal a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DecimalExpressionMediator operator *(decimal a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DecimalExpressionMediator operator /(decimal a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DecimalExpressionMediator operator %(decimal a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static DecimalExpressionMediator operator +(ByteExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DecimalExpressionMediator operator -(ByteExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DecimalExpressionMediator operator *(ByteExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DecimalExpressionMediator operator /(ByteExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DecimalExpressionMediator operator %(ByteExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DecimalExpressionMediator operator +(decimal? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DecimalExpressionMediator operator -(decimal? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DecimalExpressionMediator operator *(decimal? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DecimalExpressionMediator operator /(decimal? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DecimalExpressionMediator operator %(decimal? a, ByteExpressionMediator b) 
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
        public static DateTimeExpressionMediator operator +(ByteExpressionMediator a, DateTime b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(ByteExpressionMediator a, DateTime b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTime a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTime a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(ByteExpressionMediator a, DateTime? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(ByteExpressionMediator a, DateTime? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTime? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTime? a, ByteExpressionMediator b) 
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
        public static DateTimeOffsetExpressionMediator operator +(ByteExpressionMediator a, DateTimeOffset b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeOffsetExpressionMediator operator -(ByteExpressionMediator a, DateTimeOffset b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeOffsetExpressionMediator operator +(ByteExpressionMediator a, DateTimeOffset? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeOffsetExpressionMediator operator -(ByteExpressionMediator a, DateTimeOffset? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, ByteExpressionMediator b) 
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
        public static DoubleExpressionMediator operator +(ByteExpressionMediator a, double b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(ByteExpressionMediator a, double b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(ByteExpressionMediator a, double b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(ByteExpressionMediator a, double b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(ByteExpressionMediator a, double b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(double a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(double a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(double a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(double a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(double a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(ByteExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(ByteExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(ByteExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(ByteExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(ByteExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static DoubleExpressionMediator operator +(double? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(double? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(double? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(double? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(double? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region float
        public static SingleExpressionMediator operator +(ByteExpressionMediator a, float b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        }

        public static SingleExpressionMediator operator -(ByteExpressionMediator a, float b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static SingleExpressionMediator operator *(ByteExpressionMediator a, float b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static SingleExpressionMediator operator /(ByteExpressionMediator a, float b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        }

        public static SingleExpressionMediator operator %(ByteExpressionMediator a, float b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static SingleExpressionMediator operator +(float a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static SingleExpressionMediator operator -(float a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static SingleExpressionMediator operator *(float a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static SingleExpressionMediator operator /(float a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static SingleExpressionMediator operator %(float a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static SingleExpressionMediator operator +(ByteExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        }

        public static SingleExpressionMediator operator -(ByteExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static SingleExpressionMediator operator *(ByteExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static SingleExpressionMediator operator /(ByteExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static SingleExpressionMediator operator %(ByteExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static SingleExpressionMediator operator +(float? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static SingleExpressionMediator operator -(float? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static SingleExpressionMediator operator *(float? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static SingleExpressionMediator operator /(float? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static SingleExpressionMediator operator %(float? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region short
        public static Int16ExpressionMediator operator +(ByteExpressionMediator a, short b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        }

        public static Int16ExpressionMediator operator -(ByteExpressionMediator a, short b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static Int16ExpressionMediator operator *(ByteExpressionMediator a, short b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static Int16ExpressionMediator operator /(ByteExpressionMediator a, short b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        }

        public static Int16ExpressionMediator operator %(ByteExpressionMediator a, short b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static Int16ExpressionMediator operator +(short a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static Int16ExpressionMediator operator -(short a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static Int16ExpressionMediator operator *(short a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static Int16ExpressionMediator operator /(short a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static Int16ExpressionMediator operator %(short a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static Int16ExpressionMediator operator +(ByteExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        }

        public static Int16ExpressionMediator operator -(ByteExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static Int16ExpressionMediator operator *(ByteExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static Int16ExpressionMediator operator /(ByteExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static Int16ExpressionMediator operator %(ByteExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static Int16ExpressionMediator operator +(short? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static Int16ExpressionMediator operator -(short? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static Int16ExpressionMediator operator *(short? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static Int16ExpressionMediator operator /(short? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static Int16ExpressionMediator operator %(short? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region int
        public static Int32ExpressionMediator operator +(ByteExpressionMediator a, int b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        }

        public static Int32ExpressionMediator operator -(ByteExpressionMediator a, int b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static Int32ExpressionMediator operator *(ByteExpressionMediator a, int b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static Int32ExpressionMediator operator /(ByteExpressionMediator a, int b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        }

        public static Int32ExpressionMediator operator %(ByteExpressionMediator a, int b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static Int32ExpressionMediator operator +(int a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static Int32ExpressionMediator operator -(int a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static Int32ExpressionMediator operator *(int a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static Int32ExpressionMediator operator /(int a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static Int32ExpressionMediator operator %(int a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static Int32ExpressionMediator operator +(ByteExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        }

        public static Int32ExpressionMediator operator -(ByteExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static Int32ExpressionMediator operator *(ByteExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static Int32ExpressionMediator operator /(ByteExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static Int32ExpressionMediator operator %(ByteExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static Int32ExpressionMediator operator +(int? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static Int32ExpressionMediator operator -(int? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static Int32ExpressionMediator operator *(int? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static Int32ExpressionMediator operator /(int? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static Int32ExpressionMediator operator %(int? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region long
        public static Int64ExpressionMediator operator +(ByteExpressionMediator a, long b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        }

        public static Int64ExpressionMediator operator -(ByteExpressionMediator a, long b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static Int64ExpressionMediator operator *(ByteExpressionMediator a, long b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static Int64ExpressionMediator operator /(ByteExpressionMediator a, long b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        }

        public static Int64ExpressionMediator operator %(ByteExpressionMediator a, long b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static Int64ExpressionMediator operator +(long a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static Int64ExpressionMediator operator -(long a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static Int64ExpressionMediator operator *(long a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static Int64ExpressionMediator operator /(long a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static Int64ExpressionMediator operator %(long a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        public static Int64ExpressionMediator operator +(ByteExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        }

        public static Int64ExpressionMediator operator -(ByteExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static Int64ExpressionMediator operator *(ByteExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static Int64ExpressionMediator operator /(ByteExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        }

        public static Int64ExpressionMediator operator %(ByteExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));
        }

        public static Int64ExpressionMediator operator +(long? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static Int64ExpressionMediator operator -(long? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static Int64ExpressionMediator operator *(long? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        }

        public static Int64ExpressionMediator operator /(long? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        }

        public static Int64ExpressionMediator operator %(long? a, ByteExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        
        #region string?
        #endregion
        
        #region TimeSpan
        #endregion
        
        #endregion

        #region fields
        #region byte
        public static ByteExpressionMediator operator +(ByteExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static ByteExpressionMediator operator -(ByteExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static ByteExpressionMediator operator *(ByteExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static ByteExpressionMediator operator /(ByteExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static ByteExpressionMediator operator %(ByteExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableByteExpressionMediator operator +(ByteExpressionMediator a, NullableByteFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableByteExpressionMediator operator -(ByteExpressionMediator a, NullableByteFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableByteExpressionMediator operator *(ByteExpressionMediator a, NullableByteFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableByteExpressionMediator operator /(ByteExpressionMediator a, NullableByteFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableByteExpressionMediator operator %(ByteExpressionMediator a, NullableByteFieldExpression b)
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
        public static DecimalExpressionMediator operator +(ByteExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DecimalExpressionMediator operator -(ByteExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DecimalExpressionMediator operator *(ByteExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DecimalExpressionMediator operator /(ByteExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DecimalExpressionMediator operator %(ByteExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDecimalExpressionMediator operator +(ByteExpressionMediator a, NullableDecimalFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDecimalExpressionMediator operator -(ByteExpressionMediator a, NullableDecimalFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDecimalExpressionMediator operator *(ByteExpressionMediator a, NullableDecimalFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDecimalExpressionMediator operator /(ByteExpressionMediator a, NullableDecimalFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDecimalExpressionMediator operator %(ByteExpressionMediator a, NullableDecimalFieldExpression b)
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
        public static DateTimeExpressionMediator operator +(ByteExpressionMediator a, DateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(ByteExpressionMediator a, DateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(ByteExpressionMediator a, NullableDateTimeFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(ByteExpressionMediator a, NullableDateTimeFieldExpression b)
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
        public static DateTimeOffsetExpressionMediator operator +(ByteExpressionMediator a, DateTimeOffsetFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeOffsetExpressionMediator operator -(ByteExpressionMediator a, DateTimeOffsetFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeOffsetExpressionMediator operator +(ByteExpressionMediator a, NullableDateTimeOffsetFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeOffsetExpressionMediator operator -(ByteExpressionMediator a, NullableDateTimeOffsetFieldExpression b)
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
        public static DoubleExpressionMediator operator +(ByteExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DoubleExpressionMediator operator -(ByteExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static DoubleExpressionMediator operator *(ByteExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static DoubleExpressionMediator operator /(ByteExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static DoubleExpressionMediator operator %(ByteExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableDoubleExpressionMediator operator +(ByteExpressionMediator a, NullableDoubleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDoubleExpressionMediator operator -(ByteExpressionMediator a, NullableDoubleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDoubleExpressionMediator operator *(ByteExpressionMediator a, NullableDoubleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableDoubleExpressionMediator operator /(ByteExpressionMediator a, NullableDoubleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableDoubleExpressionMediator operator %(ByteExpressionMediator a, NullableDoubleFieldExpression b)
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
        public static SingleExpressionMediator operator +(ByteExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static SingleExpressionMediator operator -(ByteExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static SingleExpressionMediator operator *(ByteExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static SingleExpressionMediator operator /(ByteExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static SingleExpressionMediator operator %(ByteExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableSingleExpressionMediator operator +(ByteExpressionMediator a, NullableSingleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableSingleExpressionMediator operator -(ByteExpressionMediator a, NullableSingleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableSingleExpressionMediator operator *(ByteExpressionMediator a, NullableSingleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableSingleExpressionMediator operator /(ByteExpressionMediator a, NullableSingleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableSingleExpressionMediator operator %(ByteExpressionMediator a, NullableSingleFieldExpression b)
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
        public static Int16ExpressionMediator operator +(ByteExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static Int16ExpressionMediator operator -(ByteExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static Int16ExpressionMediator operator *(ByteExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static Int16ExpressionMediator operator /(ByteExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static Int16ExpressionMediator operator %(ByteExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt16ExpressionMediator operator +(ByteExpressionMediator a, NullableInt16FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt16ExpressionMediator operator -(ByteExpressionMediator a, NullableInt16FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt16ExpressionMediator operator *(ByteExpressionMediator a, NullableInt16FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt16ExpressionMediator operator /(ByteExpressionMediator a, NullableInt16FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt16ExpressionMediator operator %(ByteExpressionMediator a, NullableInt16FieldExpression b)
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
        public static Int32ExpressionMediator operator +(ByteExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static Int32ExpressionMediator operator -(ByteExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static Int32ExpressionMediator operator *(ByteExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static Int32ExpressionMediator operator /(ByteExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static Int32ExpressionMediator operator %(ByteExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt32ExpressionMediator operator +(ByteExpressionMediator a, NullableInt32FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt32ExpressionMediator operator -(ByteExpressionMediator a, NullableInt32FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt32ExpressionMediator operator *(ByteExpressionMediator a, NullableInt32FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt32ExpressionMediator operator /(ByteExpressionMediator a, NullableInt32FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt32ExpressionMediator operator %(ByteExpressionMediator a, NullableInt32FieldExpression b)
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
        public static Int64ExpressionMediator operator +(ByteExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static Int64ExpressionMediator operator -(ByteExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static Int64ExpressionMediator operator *(ByteExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static Int64ExpressionMediator operator /(ByteExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static Int64ExpressionMediator operator %(ByteExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }

        public static NullableInt64ExpressionMediator operator +(ByteExpressionMediator a, NullableInt64FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableInt64ExpressionMediator operator -(ByteExpressionMediator a, NullableInt64FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableInt64ExpressionMediator operator *(ByteExpressionMediator a, NullableInt64FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static NullableInt64ExpressionMediator operator /(ByteExpressionMediator a, NullableInt64FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static NullableInt64ExpressionMediator operator %(ByteExpressionMediator a, NullableInt64FieldExpression b)
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
        public static ByteExpressionMediator operator +(ByteExpressionMediator a, ByteExpressionMediator b) 
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

        public static ByteExpressionMediator operator -(ByteExpressionMediator a, ByteExpressionMediator b) 
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

        public static ByteExpressionMediator operator *(ByteExpressionMediator a, ByteExpressionMediator b) 
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

        public static ByteExpressionMediator operator /(ByteExpressionMediator a, ByteExpressionMediator b) 
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

        public static ByteExpressionMediator operator %(ByteExpressionMediator a, ByteExpressionMediator b) 
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

        public static NullableByteExpressionMediator operator +(ByteExpressionMediator a, NullableByteExpressionMediator b) 
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

        public static NullableByteExpressionMediator operator -(ByteExpressionMediator a, NullableByteExpressionMediator b) 
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

        public static NullableByteExpressionMediator operator *(ByteExpressionMediator a, NullableByteExpressionMediator b) 
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

        public static NullableByteExpressionMediator operator /(ByteExpressionMediator a, NullableByteExpressionMediator b) 
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

        public static NullableByteExpressionMediator operator %(ByteExpressionMediator a, NullableByteExpressionMediator b) 
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
        
        #region decimal
        public static DecimalExpressionMediator operator +(ByteExpressionMediator a, DecimalExpressionMediator b) 
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

        public static DecimalExpressionMediator operator -(ByteExpressionMediator a, DecimalExpressionMediator b) 
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

        public static DecimalExpressionMediator operator *(ByteExpressionMediator a, DecimalExpressionMediator b) 
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

        public static DecimalExpressionMediator operator /(ByteExpressionMediator a, DecimalExpressionMediator b) 
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

        public static DecimalExpressionMediator operator %(ByteExpressionMediator a, DecimalExpressionMediator b) 
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

        public static NullableDecimalExpressionMediator operator +(ByteExpressionMediator a, NullableDecimalExpressionMediator b) 
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

        public static NullableDecimalExpressionMediator operator -(ByteExpressionMediator a, NullableDecimalExpressionMediator b) 
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

        public static NullableDecimalExpressionMediator operator *(ByteExpressionMediator a, NullableDecimalExpressionMediator b) 
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

        public static NullableDecimalExpressionMediator operator /(ByteExpressionMediator a, NullableDecimalExpressionMediator b) 
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

        public static NullableDecimalExpressionMediator operator %(ByteExpressionMediator a, NullableDecimalExpressionMediator b) 
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
        public static DateTimeExpressionMediator operator +(ByteExpressionMediator a, DateTimeExpressionMediator b) 
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

        public static DateTimeExpressionMediator operator -(ByteExpressionMediator a, DateTimeExpressionMediator b) 
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

        public static NullableDateTimeExpressionMediator operator +(ByteExpressionMediator a, NullableDateTimeExpressionMediator b) 
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

        public static NullableDateTimeExpressionMediator operator -(ByteExpressionMediator a, NullableDateTimeExpressionMediator b) 
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
        public static DateTimeOffsetExpressionMediator operator +(ByteExpressionMediator a, DateTimeOffsetExpressionMediator b) 
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

        public static DateTimeOffsetExpressionMediator operator -(ByteExpressionMediator a, DateTimeOffsetExpressionMediator b) 
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

        public static NullableDateTimeOffsetExpressionMediator operator +(ByteExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) 
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

        public static NullableDateTimeOffsetExpressionMediator operator -(ByteExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) 
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
        public static DoubleExpressionMediator operator +(ByteExpressionMediator a, DoubleExpressionMediator b) 
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

        public static DoubleExpressionMediator operator -(ByteExpressionMediator a, DoubleExpressionMediator b) 
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

        public static DoubleExpressionMediator operator *(ByteExpressionMediator a, DoubleExpressionMediator b) 
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

        public static DoubleExpressionMediator operator /(ByteExpressionMediator a, DoubleExpressionMediator b) 
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

        public static DoubleExpressionMediator operator %(ByteExpressionMediator a, DoubleExpressionMediator b) 
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

        public static NullableDoubleExpressionMediator operator +(ByteExpressionMediator a, NullableDoubleExpressionMediator b) 
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

        public static NullableDoubleExpressionMediator operator -(ByteExpressionMediator a, NullableDoubleExpressionMediator b) 
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

        public static NullableDoubleExpressionMediator operator *(ByteExpressionMediator a, NullableDoubleExpressionMediator b) 
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

        public static NullableDoubleExpressionMediator operator /(ByteExpressionMediator a, NullableDoubleExpressionMediator b) 
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

        public static NullableDoubleExpressionMediator operator %(ByteExpressionMediator a, NullableDoubleExpressionMediator b) 
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
        public static SingleExpressionMediator operator +(ByteExpressionMediator a, SingleExpressionMediator b) 
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

        public static SingleExpressionMediator operator -(ByteExpressionMediator a, SingleExpressionMediator b) 
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

        public static SingleExpressionMediator operator *(ByteExpressionMediator a, SingleExpressionMediator b) 
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

        public static SingleExpressionMediator operator /(ByteExpressionMediator a, SingleExpressionMediator b) 
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

        public static SingleExpressionMediator operator %(ByteExpressionMediator a, SingleExpressionMediator b) 
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

        public static NullableSingleExpressionMediator operator +(ByteExpressionMediator a, NullableSingleExpressionMediator b) 
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

        public static NullableSingleExpressionMediator operator -(ByteExpressionMediator a, NullableSingleExpressionMediator b) 
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

        public static NullableSingleExpressionMediator operator *(ByteExpressionMediator a, NullableSingleExpressionMediator b) 
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

        public static NullableSingleExpressionMediator operator /(ByteExpressionMediator a, NullableSingleExpressionMediator b) 
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

        public static NullableSingleExpressionMediator operator %(ByteExpressionMediator a, NullableSingleExpressionMediator b) 
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
        
        #region short
        public static Int16ExpressionMediator operator +(ByteExpressionMediator a, Int16ExpressionMediator b) 
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

        public static Int16ExpressionMediator operator -(ByteExpressionMediator a, Int16ExpressionMediator b) 
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

        public static Int16ExpressionMediator operator *(ByteExpressionMediator a, Int16ExpressionMediator b) 
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

        public static Int16ExpressionMediator operator /(ByteExpressionMediator a, Int16ExpressionMediator b) 
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

        public static Int16ExpressionMediator operator %(ByteExpressionMediator a, Int16ExpressionMediator b) 
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

        public static NullableInt16ExpressionMediator operator +(ByteExpressionMediator a, NullableInt16ExpressionMediator b) 
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

        public static NullableInt16ExpressionMediator operator -(ByteExpressionMediator a, NullableInt16ExpressionMediator b) 
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

        public static NullableInt16ExpressionMediator operator *(ByteExpressionMediator a, NullableInt16ExpressionMediator b) 
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

        public static NullableInt16ExpressionMediator operator /(ByteExpressionMediator a, NullableInt16ExpressionMediator b) 
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

        public static NullableInt16ExpressionMediator operator %(ByteExpressionMediator a, NullableInt16ExpressionMediator b) 
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
        
        #region int
        public static Int32ExpressionMediator operator +(ByteExpressionMediator a, Int32ExpressionMediator b) 
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

        public static Int32ExpressionMediator operator -(ByteExpressionMediator a, Int32ExpressionMediator b) 
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

        public static Int32ExpressionMediator operator *(ByteExpressionMediator a, Int32ExpressionMediator b) 
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

        public static Int32ExpressionMediator operator /(ByteExpressionMediator a, Int32ExpressionMediator b) 
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

        public static Int32ExpressionMediator operator %(ByteExpressionMediator a, Int32ExpressionMediator b) 
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

        public static NullableInt32ExpressionMediator operator +(ByteExpressionMediator a, NullableInt32ExpressionMediator b) 
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

        public static NullableInt32ExpressionMediator operator -(ByteExpressionMediator a, NullableInt32ExpressionMediator b) 
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

        public static NullableInt32ExpressionMediator operator *(ByteExpressionMediator a, NullableInt32ExpressionMediator b) 
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

        public static NullableInt32ExpressionMediator operator /(ByteExpressionMediator a, NullableInt32ExpressionMediator b) 
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

        public static NullableInt32ExpressionMediator operator %(ByteExpressionMediator a, NullableInt32ExpressionMediator b) 
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
        
        #region long
        public static Int64ExpressionMediator operator +(ByteExpressionMediator a, Int64ExpressionMediator b) 
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

        public static Int64ExpressionMediator operator -(ByteExpressionMediator a, Int64ExpressionMediator b) 
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

        public static Int64ExpressionMediator operator *(ByteExpressionMediator a, Int64ExpressionMediator b) 
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

        public static Int64ExpressionMediator operator /(ByteExpressionMediator a, Int64ExpressionMediator b) 
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

        public static Int64ExpressionMediator operator %(ByteExpressionMediator a, Int64ExpressionMediator b) 
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

        public static NullableInt64ExpressionMediator operator +(ByteExpressionMediator a, NullableInt64ExpressionMediator b) 
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

        public static NullableInt64ExpressionMediator operator -(ByteExpressionMediator a, NullableInt64ExpressionMediator b) 
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

        public static NullableInt64ExpressionMediator operator *(ByteExpressionMediator a, NullableInt64ExpressionMediator b) 
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

        public static NullableInt64ExpressionMediator operator /(ByteExpressionMediator a, NullableInt64ExpressionMediator b) 
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

        public static NullableInt64ExpressionMediator operator %(ByteExpressionMediator a, NullableInt64ExpressionMediator b) 
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
        
        #region TimeSpan
        #endregion
        
        #endregion

        #region alias
        public static ByteExpressionMediator operator +(ByteExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static ByteExpressionMediator operator -(ByteExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static ByteExpressionMediator operator *(ByteExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        }

        public static ByteExpressionMediator operator /(ByteExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        }

        public static ByteExpressionMediator operator %(ByteExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        }


        public static ByteExpressionMediator operator +(ByteExpressionMediator a, (string TableAlias, string FieldAlias) b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new AliasExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<byte>(b), ArithmeticExpressionOperator.Add));
        }

        public static ByteExpressionMediator operator -(ByteExpressionMediator a, (string TableAlias, string FieldAlias) b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new AliasExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static ByteExpressionMediator operator *(ByteExpressionMediator a, (string TableAlias, string FieldAlias) b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Multiply)
            {
                ae.Expression.Args.Add(new AliasExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        }

        public static ByteExpressionMediator operator /(ByteExpressionMediator a, (string TableAlias, string FieldAlias) b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Divide)
            {
                ae.Expression.Args.Add(new AliasExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        }

        public static ByteExpressionMediator operator %(ByteExpressionMediator a, (string TableAlias, string FieldAlias) b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Modulo)
            {
                ae.Expression.Args.Add(new AliasExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<byte>(b), ArithmeticExpressionOperator.Modulo));
        }

        #endregion
        #endregion

        #region filter operators
        #region byte
        public static FilterExpression operator ==(ByteExpressionMediator a, byte b) => new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ByteExpressionMediator a, byte b) => new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(ByteExpressionMediator a, byte b) => new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(ByteExpressionMediator a, byte b) => new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(ByteExpressionMediator a, byte b) => new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(ByteExpressionMediator a, byte b) => new FilterExpression<bool>(a, new LiteralExpression<byte>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(byte a, ByteExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(byte a, ByteExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(byte a, ByteExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(byte a, ByteExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(byte a, ByteExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(byte a, ByteExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<byte>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region fields
        public static FilterExpression operator ==(ByteExpressionMediator a, ByteFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ByteExpressionMediator a, ByteFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(ByteExpressionMediator a, ByteFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(ByteExpressionMediator a, ByteFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(ByteExpressionMediator a, ByteFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(ByteExpressionMediator a, ByteFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(ByteExpressionMediator a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ByteExpressionMediator a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(ByteExpressionMediator a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(ByteExpressionMediator a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(ByteExpressionMediator a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(ByteExpressionMediator a, NullableByteFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediators
        public static FilterExpression operator ==(ByteExpressionMediator a, ByteExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ByteExpressionMediator a, ByteExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(ByteExpressionMediator a, ByteExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(ByteExpressionMediator a, ByteExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(ByteExpressionMediator a, ByteExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(ByteExpressionMediator a, ByteExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(ByteExpressionMediator a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ByteExpressionMediator a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(ByteExpressionMediator a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(ByteExpressionMediator a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(ByteExpressionMediator a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(ByteExpressionMediator a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region alias
        public static FilterExpression operator ==(ByteExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ByteExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(ByteExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(ByteExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(ByteExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(ByteExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        public static FilterExpression operator ==(ByteExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<byte>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(ByteExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<byte>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(ByteExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<byte>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(ByteExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<byte>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(ByteExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<byte>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(ByteExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<byte>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
