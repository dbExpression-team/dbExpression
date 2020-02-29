
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeMaximumFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTime>(DateTimeMaximumFunctionExpression a) => new SelectExpression<DateTime>(new ExpressionContainer(a));
        public static implicit operator DateTimeExpressionMediator(DateTimeMaximumFunctionExpression a) => new DateTimeExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(DateTimeMaximumFunctionExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, byte b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, byte b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(byte a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(byte a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, byte? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, byte? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(byte? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(byte? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, decimal b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, decimal b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(decimal a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(decimal a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, decimal? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, decimal? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(decimal? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(decimal? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, double b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, double b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(double a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(double a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, double? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, double? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(double? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(double? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, float b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, float b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(float a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(float a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, float? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, float? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(float? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(float? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, short b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, short b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(short a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(short a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, short? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, short? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(short? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(short? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, int b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, int b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(int a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(int a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, int? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, int? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(int? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(int? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, long b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, long b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(long a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(long a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, long? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, long? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(long? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(long? a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #endregion

        #region mediator
        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, ByteExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, ByteExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, DecimalExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, DecimalExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, Int16ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, Int16ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, Int32ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, Int32ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTime
        public static FilterExpression<DateTime> operator ==(DateTimeMaximumFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTimeMaximumFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTimeMaximumFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTimeMaximumFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTimeMaximumFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTimeMaximumFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTime a, DateTimeMaximumFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTime a, DateTimeMaximumFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTime a, DateTimeMaximumFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTime a, DateTimeMaximumFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTime a, DateTimeMaximumFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTime a, DateTimeMaximumFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTimeMaximumFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTimeMaximumFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTimeMaximumFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTimeMaximumFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTimeMaximumFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTimeMaximumFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTime? a, DateTimeMaximumFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTime? a, DateTimeMaximumFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTime? a, DateTimeMaximumFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTime? a, DateTimeMaximumFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTime? a, DateTimeMaximumFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTime? a, DateTimeMaximumFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<DateTime> operator ==(DateTimeMaximumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTimeMaximumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTimeMaximumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTimeMaximumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTimeMaximumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTimeMaximumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(DateTimeMaximumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime?> operator !=(DateTimeMaximumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime?> operator <(DateTimeMaximumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime?> operator <=(DateTimeMaximumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime?> operator >(DateTimeMaximumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime?> operator >=(DateTimeMaximumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
