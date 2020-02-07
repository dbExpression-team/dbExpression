using System;
using System.Collections.Generic;
using System.Text;

namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableExpressionMediator<TValue> : ExpressionMediator<TValue>
    {
        public NullableExpressionMediator((Type, object) function)
            : base(function)
        {
        }

        #region arithmetic operators
        #region TValue
        #region byte
        public static NullableExpressionMediator<byte?> operator +(NullableExpressionMediator<TValue> a, byte b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableExpressionMediator<TValue> a, byte b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableExpressionMediator<TValue> a, byte b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableExpressionMediator<TValue> a, byte b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableExpressionMediator<TValue> a, byte b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(byte a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(byte a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(byte a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(byte a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(byte a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(new LiteralExpression<byte>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(NullableExpressionMediator<TValue> a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableExpressionMediator<TValue> a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableExpressionMediator<TValue> a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableExpressionMediator<TValue> a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableExpressionMediator<TValue> a, byte? b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(byte? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(byte? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(byte? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(byte? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(byte? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(new LiteralExpression<byte?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTime
        public static NullableExpressionMediator<DateTime?> operator +(NullableExpressionMediator<TValue> a, DateTime b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableExpressionMediator<TValue> a, DateTime b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableExpressionMediator<TValue> a, DateTime b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableExpressionMediator<TValue> a, DateTime b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableExpressionMediator<TValue> a, DateTime b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(DateTime a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(DateTime a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(DateTime a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(DateTime a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(DateTime a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(new LiteralExpression<DateTime>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(NullableExpressionMediator<TValue> a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableExpressionMediator<TValue> a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableExpressionMediator<TValue> a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableExpressionMediator<TValue> a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableExpressionMediator<TValue> a, DateTime? b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(DateTime? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(DateTime? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(DateTime? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(DateTime? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(DateTime? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(new LiteralExpression<DateTime?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTimeOffset
        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableExpressionMediator<TValue> a, DateTimeOffset b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableExpressionMediator<TValue> a, DateTimeOffset b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableExpressionMediator<TValue> a, DateTimeOffset b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableExpressionMediator<TValue> a, DateTimeOffset b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableExpressionMediator<TValue> a, DateTimeOffset b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(DateTimeOffset a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(DateTimeOffset a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(DateTimeOffset a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(DateTimeOffset a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(DateTimeOffset a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(new LiteralExpression<DateTimeOffset>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableExpressionMediator<TValue> a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableExpressionMediator<TValue> a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableExpressionMediator<TValue> a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableExpressionMediator<TValue> a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableExpressionMediator<TValue> a, DateTimeOffset? b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(DateTimeOffset? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(DateTimeOffset? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(DateTimeOffset? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(DateTimeOffset? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(DateTimeOffset? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(new LiteralExpression<DateTimeOffset?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region decimal
        public static NullableExpressionMediator<decimal?> operator +(NullableExpressionMediator<TValue> a, decimal b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableExpressionMediator<TValue> a, decimal b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableExpressionMediator<TValue> a, decimal b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableExpressionMediator<TValue> a, decimal b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableExpressionMediator<TValue> a, decimal b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(decimal a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(new LiteralExpression<decimal>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(decimal a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(new LiteralExpression<decimal>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(decimal a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(new LiteralExpression<decimal>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(decimal a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(new LiteralExpression<decimal>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(decimal a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(new LiteralExpression<decimal>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(NullableExpressionMediator<TValue> a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableExpressionMediator<TValue> a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableExpressionMediator<TValue> a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableExpressionMediator<TValue> a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableExpressionMediator<TValue> a, decimal? b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(decimal? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(decimal? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(decimal? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(decimal? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(decimal? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(new LiteralExpression<decimal?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region double
        public static NullableExpressionMediator<double?> operator +(NullableExpressionMediator<TValue> a, double b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(NullableExpressionMediator<TValue> a, double b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(NullableExpressionMediator<TValue> a, double b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(NullableExpressionMediator<TValue> a, double b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(NullableExpressionMediator<TValue> a, double b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(double a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(double a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(double a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(double a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(double a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(new LiteralExpression<double>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(NullableExpressionMediator<TValue> a, double? b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(NullableExpressionMediator<TValue> a, double? b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(NullableExpressionMediator<TValue> a, double? b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(NullableExpressionMediator<TValue> a, double? b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(NullableExpressionMediator<TValue> a, double? b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(double? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(new LiteralExpression<double?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(double? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(new LiteralExpression<double?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(double? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(new LiteralExpression<double?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(double? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(new LiteralExpression<double?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(double? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(new LiteralExpression<double?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region float
        public static NullableExpressionMediator<float?> operator +(NullableExpressionMediator<TValue> a, float b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableExpressionMediator<TValue> a, float b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableExpressionMediator<TValue> a, float b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableExpressionMediator<TValue> a, float b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableExpressionMediator<TValue> a, float b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(float a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(new LiteralExpression<float>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(float a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(new LiteralExpression<float>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(float a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(new LiteralExpression<float>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(float a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(new LiteralExpression<float>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(float a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(new LiteralExpression<float>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(NullableExpressionMediator<TValue> a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableExpressionMediator<TValue> a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableExpressionMediator<TValue> a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableExpressionMediator<TValue> a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableExpressionMediator<TValue> a, float? b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(float? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(float? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(float? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(float? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(float? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(new LiteralExpression<float?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region Guid
        public static NullableExpressionMediator<Guid?> operator +(NullableExpressionMediator<TValue> a, Guid b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, new LiteralExpression<Guid>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<Guid?> operator -(NullableExpressionMediator<TValue> a, Guid b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, new LiteralExpression<Guid>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<Guid?> operator *(NullableExpressionMediator<TValue> a, Guid b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, new LiteralExpression<Guid>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<Guid?> operator /(NullableExpressionMediator<TValue> a, Guid b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, new LiteralExpression<Guid>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<Guid?> operator %(NullableExpressionMediator<TValue> a, Guid b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, new LiteralExpression<Guid>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<Guid?> operator +(Guid a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(new LiteralExpression<Guid>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<Guid?> operator -(Guid a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(new LiteralExpression<Guid>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<Guid?> operator *(Guid a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(new LiteralExpression<Guid>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<Guid?> operator /(Guid a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(new LiteralExpression<Guid>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<Guid?> operator %(Guid a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(new LiteralExpression<Guid>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<Guid?> operator +(NullableExpressionMediator<TValue> a, Guid? b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, new LiteralExpression<Guid?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<Guid?> operator -(NullableExpressionMediator<TValue> a, Guid? b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, new LiteralExpression<Guid?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<Guid?> operator *(NullableExpressionMediator<TValue> a, Guid? b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, new LiteralExpression<Guid?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<Guid?> operator /(NullableExpressionMediator<TValue> a, Guid? b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, new LiteralExpression<Guid?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<Guid?> operator %(NullableExpressionMediator<TValue> a, Guid? b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, new LiteralExpression<Guid?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<Guid?> operator +(Guid? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(new LiteralExpression<Guid?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<Guid?> operator -(Guid? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(new LiteralExpression<Guid?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<Guid?> operator *(Guid? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(new LiteralExpression<Guid?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<Guid?> operator /(Guid? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(new LiteralExpression<Guid?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<Guid?> operator %(Guid? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(new LiteralExpression<Guid?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region int
        public static NullableExpressionMediator<int?> operator +(NullableExpressionMediator<TValue> a, int b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableExpressionMediator<TValue> a, int b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableExpressionMediator<TValue> a, int b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableExpressionMediator<TValue> a, int b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableExpressionMediator<TValue> a, int b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(int a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(int a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(int a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(int a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(int a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(new LiteralExpression<int>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(NullableExpressionMediator<TValue> a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableExpressionMediator<TValue> a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableExpressionMediator<TValue> a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableExpressionMediator<TValue> a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableExpressionMediator<TValue> a, int? b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(int? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(int? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(int? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(int? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(int? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(new LiteralExpression<int?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region long
        public static NullableExpressionMediator<long?> operator +(NullableExpressionMediator<TValue> a, long b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableExpressionMediator<TValue> a, long b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableExpressionMediator<TValue> a, long b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableExpressionMediator<TValue> a, long b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableExpressionMediator<TValue> a, long b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(long a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(new LiteralExpression<long>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(long a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(new LiteralExpression<long>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(long a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(new LiteralExpression<long>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(long a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(new LiteralExpression<long>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(long a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(new LiteralExpression<long>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(NullableExpressionMediator<TValue> a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableExpressionMediator<TValue> a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableExpressionMediator<TValue> a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableExpressionMediator<TValue> a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableExpressionMediator<TValue> a, long? b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(long? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(long? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(long? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(long? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(long? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(new LiteralExpression<long?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region short
        public static NullableExpressionMediator<short?> operator +(NullableExpressionMediator<TValue> a, short b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableExpressionMediator<TValue> a, short b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableExpressionMediator<TValue> a, short b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableExpressionMediator<TValue> a, short b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableExpressionMediator<TValue> a, short b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(short a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(new LiteralExpression<short>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(short a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(new LiteralExpression<short>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(short a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(new LiteralExpression<short>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(short a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(new LiteralExpression<short>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(short a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(new LiteralExpression<short>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(NullableExpressionMediator<TValue> a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableExpressionMediator<TValue> a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableExpressionMediator<TValue> a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableExpressionMediator<TValue> a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableExpressionMediator<TValue> a, short? b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(short? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(short? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(short? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(short? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(short? a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(new LiteralExpression<short?>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region string
        public static NullableExpressionMediator<string> operator +(NullableExpressionMediator<TValue> a, string b) => new NullableExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, new LiteralExpression<string>(b), ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<string> operator -(NullableExpressionMediator<TValue> a, string b) => new NullableExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, new LiteralExpression<string>(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<string> operator *(NullableExpressionMediator<TValue> a, string b) => new NullableExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, new LiteralExpression<string>(b), ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<string> operator /(NullableExpressionMediator<TValue> a, string b) => new NullableExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, new LiteralExpression<string>(b), ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<string> operator %(NullableExpressionMediator<TValue> a, string b) => new NullableExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(a.Expression, new LiteralExpression<string>(b), ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<string> operator +(string a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(new LiteralExpression<string>(a), b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<string> operator -(string a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(new LiteralExpression<string>(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<string> operator *(string a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(new LiteralExpression<string>(a), b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<string> operator /(string a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(new LiteralExpression<string>(a), b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<string> operator %(string a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<string>((typeof(ArithmeticExpression<string>), new ArithmeticExpression<string>(new LiteralExpression<string>(a), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region field
        #region byte
        public static NullableExpressionMediator<byte?> operator +(NullableExpressionMediator<TValue> a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableExpressionMediator<TValue> a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableExpressionMediator<TValue> a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableExpressionMediator<TValue> a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableExpressionMediator<TValue> a, NullableByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(NullableByteFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableByteFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableByteFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableByteFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableByteFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(NullableExpressionMediator<TValue> a, ByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableExpressionMediator<TValue> a, ByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableExpressionMediator<TValue> a, ByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableExpressionMediator<TValue> a, ByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableExpressionMediator<TValue> a, ByteFieldExpression b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(ByteFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(ByteFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(ByteFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(ByteFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(ByteFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTime
        public static NullableExpressionMediator<DateTime?> operator +(NullableExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(NullableDateTimeFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableDateTimeFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableDateTimeFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableDateTimeFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableDateTimeFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(NullableExpressionMediator<TValue> a, DateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableExpressionMediator<TValue> a, DateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableExpressionMediator<TValue> a, DateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableExpressionMediator<TValue> a, DateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableExpressionMediator<TValue> a, DateTimeFieldExpression b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(DateTimeFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(DateTimeFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(DateTimeFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(DateTimeFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(DateTimeFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTimeOffset
        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableDateTimeOffsetFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableDateTimeOffsetFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableDateTimeOffsetFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableDateTimeOffsetFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableDateTimeOffsetFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(DateTimeOffsetFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(DateTimeOffsetFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(DateTimeOffsetFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(DateTimeOffsetFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(DateTimeOffsetFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion


        #region decimal
        public static NullableExpressionMediator<decimal?> operator +(NullableExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(NullableDecimalFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableDecimalFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableDecimalFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableDecimalFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableDecimalFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(NullableExpressionMediator<TValue> a, DecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableExpressionMediator<TValue> a, DecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableExpressionMediator<TValue> a, DecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableExpressionMediator<TValue> a, DecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableExpressionMediator<TValue> a, DecimalFieldExpression b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(DecimalFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(DecimalFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(DecimalFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(DecimalFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(DecimalFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region double
        public static NullableExpressionMediator<double?> operator +(NullableExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(NullableExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(NullableExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(NullableExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(NullableExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(NullableDoubleFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(NullableDoubleFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(NullableDoubleFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(NullableDoubleFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(NullableDoubleFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(NullableExpressionMediator<TValue> a, DoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(NullableExpressionMediator<TValue> a, DoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(NullableExpressionMediator<TValue> a, DoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(NullableExpressionMediator<TValue> a, DoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(NullableExpressionMediator<TValue> a, DoubleFieldExpression b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(DoubleFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(DoubleFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(DoubleFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(DoubleFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(DoubleFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region float
        public static NullableExpressionMediator<float?> operator +(NullableExpressionMediator<TValue> a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableExpressionMediator<TValue> a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableExpressionMediator<TValue> a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableExpressionMediator<TValue> a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableExpressionMediator<TValue> a, NullableFloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(NullableFloatFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableFloatFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableFloatFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableFloatFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableFloatFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(NullableExpressionMediator<TValue> a, FloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableExpressionMediator<TValue> a, FloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableExpressionMediator<TValue> a, FloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableExpressionMediator<TValue> a, FloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableExpressionMediator<TValue> a, FloatFieldExpression b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(FloatFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(FloatFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(FloatFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(FloatFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(FloatFieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region int
        public static NullableExpressionMediator<int?> operator +(NullableExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(NullableInt32FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableInt32FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableInt32FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableInt32FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableInt32FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(NullableExpressionMediator<TValue> a, Int32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableExpressionMediator<TValue> a, Int32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableExpressionMediator<TValue> a, Int32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableExpressionMediator<TValue> a, Int32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableExpressionMediator<TValue> a, Int32FieldExpression b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(Int32FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(Int32FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(Int32FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(Int32FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(Int32FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region long
        public static NullableExpressionMediator<long?> operator +(NullableExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(NullableInt64FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableInt64FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableInt64FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableInt64FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableInt64FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(NullableExpressionMediator<TValue> a, Int64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableExpressionMediator<TValue> a, Int64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableExpressionMediator<TValue> a, Int64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableExpressionMediator<TValue> a, Int64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableExpressionMediator<TValue> a, Int64FieldExpression b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(Int64FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(Int64FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(Int64FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(Int64FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(Int64FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region short
        public static NullableExpressionMediator<short?> operator +(NullableExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(NullableInt16FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableInt16FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableInt16FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableInt16FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableInt16FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(NullableExpressionMediator<TValue> a, Int16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableExpressionMediator<TValue> a, Int16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableExpressionMediator<TValue> a, Int16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableExpressionMediator<TValue> a, Int16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableExpressionMediator<TValue> a, Int16FieldExpression b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(Int16FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(Int16FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(Int16FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(Int16FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(Int16FieldExpression a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion
        #endregion

        #region mediator
        #region byte
        public static NullableExpressionMediator<byte?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<byte> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<byte> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<byte> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<byte> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<byte> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(NullableExpressionMediator<byte> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableExpressionMediator<byte> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableExpressionMediator<byte> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableExpressionMediator<byte> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableExpressionMediator<byte> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte>), new ArithmeticExpression<byte>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<byte?> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<byte?> operator +(NullableExpressionMediator<byte?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<byte?> operator -(NullableExpressionMediator<byte?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<byte?> operator *(NullableExpressionMediator<byte?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<byte?> operator /(NullableExpressionMediator<byte?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<byte?> operator %(NullableExpressionMediator<byte?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<byte?>((typeof(ArithmeticExpression<byte?>), new ArithmeticExpression<byte?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region Datetime
        public static NullableExpressionMediator<DateTime?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTime> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTime> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTime> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTime> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTime> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(NullableExpressionMediator<DateTime> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableExpressionMediator<DateTime> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableExpressionMediator<DateTime> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableExpressionMediator<DateTime> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableExpressionMediator<DateTime> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime>), new ArithmeticExpression<DateTime>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTime?> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTime?> operator +(NullableExpressionMediator<DateTime?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTime?> operator -(NullableExpressionMediator<DateTime?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTime?> operator *(NullableExpressionMediator<DateTime?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTime?> operator /(NullableExpressionMediator<DateTime?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTime?> operator %(NullableExpressionMediator<DateTime?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTime?>((typeof(ArithmeticExpression<DateTime?>), new ArithmeticExpression<DateTime?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTimeOffset
        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableExpressionMediator<DateTimeOffset> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableExpressionMediator<DateTimeOffset> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableExpressionMediator<DateTimeOffset> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableExpressionMediator<DateTimeOffset> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableExpressionMediator<DateTimeOffset> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset>), new ArithmeticExpression<DateTimeOffset>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<DateTimeOffset?> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<DateTimeOffset?> operator +(NullableExpressionMediator<DateTimeOffset?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<DateTimeOffset?> operator -(NullableExpressionMediator<DateTimeOffset?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<DateTimeOffset?> operator *(NullableExpressionMediator<DateTimeOffset?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<DateTimeOffset?> operator /(NullableExpressionMediator<DateTimeOffset?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<DateTimeOffset?> operator %(NullableExpressionMediator<DateTimeOffset?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<DateTimeOffset?>((typeof(ArithmeticExpression<DateTimeOffset?>), new ArithmeticExpression<DateTimeOffset?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region decimal
        public static NullableExpressionMediator<decimal?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<decimal> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<decimal> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<decimal> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<decimal> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<decimal> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(NullableExpressionMediator<decimal> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableExpressionMediator<decimal> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableExpressionMediator<decimal> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableExpressionMediator<decimal> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableExpressionMediator<decimal> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal>), new ArithmeticExpression<decimal>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<decimal?> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<decimal?> operator +(NullableExpressionMediator<decimal?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<decimal?> operator -(NullableExpressionMediator<decimal?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<decimal?> operator *(NullableExpressionMediator<decimal?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<decimal?> operator /(NullableExpressionMediator<decimal?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<decimal?> operator %(NullableExpressionMediator<decimal?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<decimal?>((typeof(ArithmeticExpression<decimal?>), new ArithmeticExpression<decimal?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region double
        public static NullableExpressionMediator<double?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<double> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<double> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<double> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<double> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<double> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(NullableExpressionMediator<double> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(NullableExpressionMediator<double> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(NullableExpressionMediator<double> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(NullableExpressionMediator<double> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(NullableExpressionMediator<double> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double>), new ArithmeticExpression<double>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<double?> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<double?> operator +(NullableExpressionMediator<double?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<double?> operator -(NullableExpressionMediator<double?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<double?> operator *(NullableExpressionMediator<double?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<double?> operator /(NullableExpressionMediator<double?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<double?> operator %(NullableExpressionMediator<double?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<double?>((typeof(ArithmeticExpression<double?>), new ArithmeticExpression<double?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region float
        public static NullableExpressionMediator<float?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<float> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<float> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<float> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<float> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<float> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(NullableExpressionMediator<float> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableExpressionMediator<float> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableExpressionMediator<float> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableExpressionMediator<float> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableExpressionMediator<float> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float>), new ArithmeticExpression<float>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<float?> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<float?> operator +(NullableExpressionMediator<float?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<float?> operator -(NullableExpressionMediator<float?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<float?> operator *(NullableExpressionMediator<float?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<float?> operator /(NullableExpressionMediator<float?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<float?> operator %(NullableExpressionMediator<float?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<float?>((typeof(ArithmeticExpression<float?>), new ArithmeticExpression<float?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region Guid
        public static NullableExpressionMediator<Guid?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<Guid> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<Guid?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<Guid> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<Guid?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<Guid> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<Guid?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<Guid> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<Guid?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<Guid> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<Guid?> operator +(NullableExpressionMediator<Guid> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<Guid?> operator -(NullableExpressionMediator<Guid> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<Guid?> operator *(NullableExpressionMediator<Guid> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<Guid?> operator /(NullableExpressionMediator<Guid> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<Guid?> operator %(NullableExpressionMediator<Guid> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid>), new ArithmeticExpression<Guid>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<Guid?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<Guid?> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<Guid?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<Guid?> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<Guid?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<Guid?> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<Guid?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<Guid?> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<Guid?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<Guid?> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<Guid?> operator +(NullableExpressionMediator<Guid?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<Guid?> operator -(NullableExpressionMediator<Guid?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<Guid?> operator *(NullableExpressionMediator<Guid?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<Guid?> operator /(NullableExpressionMediator<Guid?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<Guid?> operator %(NullableExpressionMediator<Guid?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<Guid?>((typeof(ArithmeticExpression<Guid?>), new ArithmeticExpression<Guid?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region int
        public static NullableExpressionMediator<int?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<int> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<int> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<int> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<int> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<int> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(NullableExpressionMediator<int> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableExpressionMediator<int> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableExpressionMediator<int> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableExpressionMediator<int> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableExpressionMediator<int> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int>), new ArithmeticExpression<int>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<int?> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<int?> operator +(NullableExpressionMediator<int?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<int?> operator -(NullableExpressionMediator<int?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<int?> operator *(NullableExpressionMediator<int?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<int?> operator /(NullableExpressionMediator<int?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<int?> operator %(NullableExpressionMediator<int?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<int?>((typeof(ArithmeticExpression<int?>), new ArithmeticExpression<int?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region long
        public static NullableExpressionMediator<long?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<long> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<long> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<long> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<long> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<long> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(NullableExpressionMediator<long> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableExpressionMediator<long> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableExpressionMediator<long> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableExpressionMediator<long> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableExpressionMediator<long> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long>), new ArithmeticExpression<long>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<long?> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<long?> operator +(NullableExpressionMediator<long?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<long?> operator -(NullableExpressionMediator<long?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<long?> operator *(NullableExpressionMediator<long?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<long?> operator /(NullableExpressionMediator<long?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<long?> operator %(NullableExpressionMediator<long?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<long?>((typeof(ArithmeticExpression<long?>), new ArithmeticExpression<long?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region short
        public static NullableExpressionMediator<short?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<short> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<short> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<short> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<short> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<short> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(NullableExpressionMediator<short> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableExpressionMediator<short> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableExpressionMediator<short> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableExpressionMediator<short> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableExpressionMediator<short> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short>), new ArithmeticExpression<short>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(NullableExpressionMediator<TValue> a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableExpressionMediator<TValue> a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableExpressionMediator<TValue> a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableExpressionMediator<TValue> a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableExpressionMediator<TValue> a, NullableExpressionMediator<short?> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static NullableExpressionMediator<short?> operator +(NullableExpressionMediator<short?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));

        public static NullableExpressionMediator<short?> operator -(NullableExpressionMediator<short?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableExpressionMediator<short?> operator *(NullableExpressionMediator<short?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Multiply)));

        public static NullableExpressionMediator<short?> operator /(NullableExpressionMediator<short?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Divide)));

        public static NullableExpressionMediator<short?> operator %(NullableExpressionMediator<short?> a, NullableExpressionMediator<TValue> b) => new NullableExpressionMediator<short?>((typeof(ArithmeticExpression<short?>), new ArithmeticExpression<short?>(a.Expression, b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #endregion
        #endregion
    }
}
