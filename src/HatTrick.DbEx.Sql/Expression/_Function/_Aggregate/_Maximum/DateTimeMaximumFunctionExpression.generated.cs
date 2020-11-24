using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeMaximumFunctionExpression
    {
        #region implicit operators
        public static implicit operator DateTimeExpressionMediator(DateTimeMaximumFunctionExpression a) => new DateTimeExpressionMediator(a);
        public static implicit operator OrderByExpression(DateTimeMaximumFunctionExpression a) => new OrderByExpression(new DateTimeExpressionMediator(a), OrderExpressionDirection.ASC);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new DateTimeExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new DateTimeExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, byte b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, byte b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(byte a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(byte a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, byte? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, byte? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(byte? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(byte? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, decimal b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, decimal b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(decimal a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(decimal a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, decimal? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, decimal? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(decimal? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(decimal? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, double b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, double b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(double a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(double a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, double? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, double? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(double? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(double? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, float b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, float b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(float a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(float a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, float? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, float? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(float? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(float? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region short
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, short b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, short b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(short a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(short a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, short? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, short? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(short? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(short? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, int b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, int b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(int a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(int a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, int? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, int? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(int? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(int? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, long b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, long b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(long a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(long a, DateTimeMaximumFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, long? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, long? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(long? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(long? a, DateTimeMaximumFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion

        #region mediator
        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, ByteExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, ByteExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, DecimalExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, DecimalExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region short
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, Int16ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, Int16ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, Int32ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, Int32ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static DateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeMaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeMaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTime
        public static FilterExpressionSet operator ==(DateTimeMaximumFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeMaximumFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeMaximumFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTimeMaximumFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTimeMaximumFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTimeMaximumFunctionExpression a, DateTime b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTime a, DateTimeMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTime a, DateTimeMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTime a, DateTimeMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTime a, DateTimeMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTime a, DateTimeMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTime a, DateTimeMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeMaximumFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeMaximumFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeMaximumFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTimeMaximumFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTimeMaximumFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTimeMaximumFunctionExpression a, DateTime? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTime? a, DateTimeMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTime? a, DateTimeMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTime? a, DateTimeMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTime? a, DateTimeMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTime? a, DateTimeMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTime? a, DateTimeMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(DateTimeMaximumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeMaximumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeMaximumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTimeMaximumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTimeMaximumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTimeMaximumFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeMaximumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeMaximumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeMaximumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTimeMaximumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTimeMaximumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTimeMaximumFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
