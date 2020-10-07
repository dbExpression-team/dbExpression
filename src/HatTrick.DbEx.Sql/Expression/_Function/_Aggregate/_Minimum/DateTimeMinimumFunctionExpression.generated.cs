
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeMinimumFunctionExpression
    {
        #region implicit operators
        public static implicit operator DateTimeExpressionMediator(DateTimeMinimumFunctionExpression a) => new DateTimeExpressionMediator(a);
        public static implicit operator OrderByExpression(DateTimeMinimumFunctionExpression a) => new OrderByExpression(new DateTimeExpressionMediator(a), OrderExpressionDirection.ASC);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new DateTimeExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new DateTimeExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, byte b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, byte b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(byte a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(byte a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, byte? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, byte? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(byte? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(byte? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, decimal b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, decimal b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(decimal a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(decimal a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, decimal? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, decimal? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(decimal? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(decimal? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, double b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, double b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(double a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(double a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, double? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, double? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(double? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(double? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region float
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, float b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, float b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(float a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(float a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, float? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, float? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(float? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(float? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region short
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, short b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, short b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(short a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(short a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, short? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, short? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(short? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(short? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region int
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, int b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, int b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(int a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(int a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, int? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, int? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(int? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(int? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region long
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, long b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, long b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(long a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(long a, DateTimeMinimumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, long? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, long? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(long? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(long? a, DateTimeMinimumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #endregion

        #region mediator
        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, ByteExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, ByteExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, DecimalExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, DecimalExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region float
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region short
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, Int16ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, Int16ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region int
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, Int32ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, Int32ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region long
        public static DateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMinimumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMinimumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTime
        public static FilterExpression<bool> operator ==(DateTimeMinimumFunctionExpression a, DateTime b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeMinimumFunctionExpression a, DateTime b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeMinimumFunctionExpression a, DateTime b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeMinimumFunctionExpression a, DateTime b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeMinimumFunctionExpression a, DateTime b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeMinimumFunctionExpression a, DateTime b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTime a, DateTimeMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTime a, DateTimeMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTime a, DateTimeMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTime a, DateTimeMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTime a, DateTimeMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTime a, DateTimeMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTimeMinimumFunctionExpression a, DateTime? b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeMinimumFunctionExpression a, DateTime? b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeMinimumFunctionExpression a, DateTime? b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeMinimumFunctionExpression a, DateTime? b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeMinimumFunctionExpression a, DateTime? b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeMinimumFunctionExpression a, DateTime? b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTime? a, DateTimeMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTime? a, DateTimeMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTime? a, DateTimeMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTime? a, DateTimeMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTime? a, DateTimeMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTime? a, DateTimeMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(DateTimeMinimumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeMinimumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeMinimumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeMinimumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeMinimumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeMinimumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DateTimeMinimumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DateTimeMinimumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DateTimeMinimumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DateTimeMinimumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DateTimeMinimumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DateTimeMinimumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
