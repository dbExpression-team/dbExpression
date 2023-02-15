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

#nullable disable

namespace HatTrick.DbEx.Sql.Expression
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class NullableDateTimeExpressionMediator
    {
        #region arithmetic operators 
        #region data type 
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, byte b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, byte b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(byte a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(byte a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(byte? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(byte? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, decimal b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, decimal b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(decimal a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(decimal a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(decimal? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(decimal? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTime b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTime b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTime? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTime? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region DateTimeOffset
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTimeOffset b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTimeOffset b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeOffset a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeOffset a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTimeOffset? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTimeOffset? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeOffset? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeOffset? a, NullableDateTimeExpressionMediator b) 
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
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, double b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, double b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(double a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(double a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(double? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(double? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, float b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, float b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(float a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(float a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(float? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(float? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, short b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, short b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(short a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(short a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(short? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(short? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, int b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, int b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(int a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(int a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(int? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(int? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, long b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, long b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(long a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(long a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(long? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(long? a, NullableDateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion


        #region TimeSpan
        #endregion

        #endregion

        #region fields
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableDecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableDecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableDateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableDateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region DateTimeOffset
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTimeOffsetFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTimeOffsetFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetFieldExpression b) 
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
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableDoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableDoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableSingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableSingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableInt16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableInt16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableInt32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableInt32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableInt64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableInt64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region string
        #endregion

        #region TimeSpan
        #endregion

        #endregion

        #region mediator
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region DateTimeOffset
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) 
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
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion


        #region TimeSpan
        #endregion

        #endregion

        #region alias
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, (string TableAlias, string FieldAlias) b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new AliasExpression<DateTime>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, (string TableAlias, string FieldAlias) b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression!.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new AliasExpression<DateTime>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        #endregion

        #region filter operators
        #region null
        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, NullElement b) => new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<DateTime?>(b, field) : b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, NullElement b) => new FilterExpression<bool?>(a, a.Expression is FieldExpression field ? new LiteralExpression<DateTime?>(b, field) : b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator ==(NullElement a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b.Expression is FieldExpression field ? new LiteralExpression<DateTime?>(a, field) : a, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullElement a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b.Expression is FieldExpression field ? new LiteralExpression<DateTime?>(a, field) : a, FilterExpressionOperator.NotEqual);
        #endregion

        #region data type
        #region DateTime
        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, DateTime b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, DateTime b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, DateTime b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, DateTime b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, DateTime b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, DateTime b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTime a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTime a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTime a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTime a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTime a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTime a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, DateTime? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTime?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTime? a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTime? a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTime? a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTime? a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTime? a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTime? a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, DateTimeOffset b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTimeOffset a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTimeOffset a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTimeOffset a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTimeOffset a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTimeOffset a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTimeOffset a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(DateTimeOffset? a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(DateTimeOffset? a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(DateTimeOffset? a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(DateTimeOffset? a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(DateTimeOffset? a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(DateTimeOffset? a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region fields
        #region DateTime
        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, DateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, DateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, DateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, DateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, DateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, DateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion

        #endregion
        
        #region mediator
        #region DateTime
        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        #endregion

        #endregion

        #region alias
        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator ==(NullableDateTimeExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime?>(b), FilterExpressionOperator.Equal);
        
        public static FilterExpression<bool?> operator ==((string TableName, string FieldName) a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<DateTime?>(a), b, FilterExpressionOperator.Equal);

        public static FilterExpression<bool?> operator !=(NullableDateTimeExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime?>(b), FilterExpressionOperator.NotEqual);
        
        public static FilterExpression<bool?> operator !=((string TableName, string FieldName) a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<DateTime?>(a), b, FilterExpressionOperator.NotEqual);

        public static FilterExpression<bool?> operator <(NullableDateTimeExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime?>(b), FilterExpressionOperator.LessThan);
        
        public static FilterExpression<bool?> operator <((string TableName, string FieldName) a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<DateTime?>(a), b, FilterExpressionOperator.LessThan);

        public static FilterExpression<bool?> operator >(NullableDateTimeExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime?>(b), FilterExpressionOperator.GreaterThan);
        
        public static FilterExpression<bool?> operator >((string TableName, string FieldName) a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThan);

        public static FilterExpression<bool?> operator <=(NullableDateTimeExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime?>(b), FilterExpressionOperator.LessThanOrEqual);
        
        public static FilterExpression<bool?> operator <=((string TableName, string FieldName) a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<DateTime?>(a), b, FilterExpressionOperator.LessThanOrEqual);

        public static FilterExpression<bool?> operator >=(NullableDateTimeExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime?>(b), FilterExpressionOperator.GreaterThanOrEqual);
        
        public static FilterExpression<bool?> operator >=((string TableName, string FieldName) a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new AliasExpression<DateTime?>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
