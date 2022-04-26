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
    public partial class DateTimeExpressionMediator
    {
        #region arithmetic operators
        #region data type
        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, byte b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, byte b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(byte a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(byte a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, byte? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<byte?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(byte? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(byte? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<byte?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, decimal b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, decimal b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(decimal a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(decimal a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, decimal? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<decimal?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(decimal? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(decimal? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<decimal?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTime b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTime b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTime a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTime a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTime? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTime? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTime?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTime? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTime? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTime?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region DateTimeOffset
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTimeOffset b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTimeOffset b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTimeOffset a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeOffset a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTimeOffset? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTimeOffset? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<DateTimeOffset?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTimeOffset? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeOffset? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<DateTimeOffset?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region double
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, double b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, double b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<double>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(double a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(double a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, double? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<double?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(double? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(double? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<double?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region float
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, float b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, float b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<float>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(float a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(float a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, float? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<float?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(float? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(float? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<float?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region short
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, short b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, short b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<short>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(short a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(short a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, short? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<short?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(short? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(short? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<short?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region int
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, int b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, int b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<int>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(int a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(int a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, int? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<int?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(int? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(int? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<int?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region long
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, long b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, long b)
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<long>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(long a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(long a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, long? b) 
        {
            if (a.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new LiteralExpression<long?>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        }

        public static DateTimeExpressionMediator operator +(long? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(long? a, DateTimeExpressionMediator b) 
        {
            if (b.Expression is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, new LiteralExpression<long?>(a));
                return b;
            }
            return new(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region string?
        #endregion
        
        #region TimeSpan
        #endregion
        
        #endregion

        #region fields
        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, ByteFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableByteFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableByteFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DecimalFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableDecimalFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableDecimalFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTimeFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableDateTimeFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableDateTimeFieldExpression b)
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
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTimeOffsetFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTimeOffsetFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableDateTimeOffsetFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableDateTimeOffsetFieldExpression b)
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
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DoubleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableDoubleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableDoubleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region float
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, SingleFieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableSingleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableSingleFieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region short
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, Int16FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableInt16FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableInt16FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region int
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, Int32FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableInt32FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableInt32FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #region long
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, Int64FieldExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableInt64FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableInt64FieldExpression b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion

        #endregion

        #region mediators
        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, ByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableByteExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableDecimalExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return b;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region DateTimeOffset
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region double
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableDoubleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region float
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, SingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableSingleExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region short
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, Int16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableInt16ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region int
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, Int32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableInt32ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region long
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, Int64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableInt64ExpressionMediator b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return new(a.Expression);
            }
            if (b.Expression is ArithmeticExpression bm && bm is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> be && be.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                be.Expression.Args.Insert(0, a);
                return new(b.Expression);
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        
        #region TimeSpan
        #endregion
        
        #endregion

        #region alias
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, AliasExpression b) 
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(b);
                return a;
            }
            return new(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        }


        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, (string TableAlias, string FieldAlias) b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Add)
            {
                ae.Expression.Args.Add(new AliasExpression<DateTime>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        }

        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, (string TableAlias, string FieldAlias) b)
        {
            if (a.Expression is ArithmeticExpression am && am is IExpressionProvider<ArithmeticExpression.ArithmeticExpressionElements> ae && ae.Expression.ArithmeticOperator == ArithmeticExpressionOperator.Subtract)
            {
                ae.Expression.Args.Add(new AliasExpression<DateTime>(b));
                return a;
            }
            return new(new ArithmeticExpression(a, new AliasExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));
        }

        #endregion
        #endregion

        #region filter operators
        #region DateTime
        public static FilterExpression operator ==(DateTimeExpressionMediator a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DateTimeExpressionMediator a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(DateTimeExpressionMediator a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(DateTimeExpressionMediator a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(DateTimeExpressionMediator a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(DateTimeExpressionMediator a, DateTime b) => new FilterExpression<bool>(a, new LiteralExpression<DateTime>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(DateTime a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DateTime a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(DateTime a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(DateTime a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(DateTime a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(DateTime a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new LiteralExpression<DateTime>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region fields
        public static FilterExpression operator ==(DateTimeExpressionMediator a, DateTimeFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DateTimeExpressionMediator a, DateTimeFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(DateTimeExpressionMediator a, DateTimeFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(DateTimeExpressionMediator a, DateTimeFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(DateTimeExpressionMediator a, DateTimeFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(DateTimeExpressionMediator a, DateTimeFieldExpression b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(DateTimeExpressionMediator a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DateTimeExpressionMediator a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(DateTimeExpressionMediator a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(DateTimeExpressionMediator a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(DateTimeExpressionMediator a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(DateTimeExpressionMediator a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediators
        public static FilterExpression operator ==(DateTimeExpressionMediator a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DateTimeExpressionMediator a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(DateTimeExpressionMediator a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(DateTimeExpressionMediator a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(DateTimeExpressionMediator a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(DateTimeExpressionMediator a, DateTimeExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression operator ==(DateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(DateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(DateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(DateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(DateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region alias
        public static FilterExpression operator ==(DateTimeExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DateTimeExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(DateTimeExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(DateTimeExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(DateTimeExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(DateTimeExpressionMediator a, AliasExpression b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        public static FilterExpression operator ==(DateTimeExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime>(b), FilterExpressionOperator.Equal);
        public static FilterExpression operator !=(DateTimeExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression operator <(DateTimeExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression operator >(DateTimeExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression operator <=(DateTimeExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression operator >=(DateTimeExpressionMediator a, (string TableName, string FieldName) b) => new FilterExpression<bool?>(a, new AliasExpression<DateTime>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
