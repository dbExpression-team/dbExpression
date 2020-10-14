using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetMinimumFunctionExpression
    {
        #region implicit operators
        public static implicit operator DateTimeOffsetExpressionMediator(DateTimeOffsetMinimumFunctionExpression a) => new DateTimeOffsetExpressionMediator(a);
        public static implicit operator OrderByExpression(DateTimeOffsetMinimumFunctionExpression a) => new OrderByExpression(new DateTimeOffsetExpressionMediator(a), OrderExpressionDirection.ASC);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new DateTimeOffsetExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new DateTimeOffsetExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, byte b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, byte b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(byte a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(byte a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(byte? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(byte? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, decimal b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, decimal b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(decimal a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(decimal a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(decimal? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(decimal? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, double b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, double b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(double a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(double a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(double? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(double? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, float b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, float b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(float a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(float a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(float? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(float? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, short b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, short b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(short a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(short a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(short? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(short? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, int b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, int b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(int a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(int a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(int? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(int? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, long b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, long b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(long a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(long a, DateTimeOffsetMinimumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(long? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(long? a, DateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion

        #region mediator
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, ByteExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, ByteExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, DecimalExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, DecimalExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, Int16ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, Int16ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, Int32ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, Int32ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMinimumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMinimumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTimeOffset
        public static FilterExpression<bool> operator ==(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTimeOffset a, DateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeOffset a, DateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeOffset a, DateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeOffset a, DateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeOffset a, DateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeOffset a, DateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTimeOffset? a, DateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeOffset? a, DateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeOffset? a, DateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeOffset? a, DateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeOffset? a, DateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeOffset? a, DateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
