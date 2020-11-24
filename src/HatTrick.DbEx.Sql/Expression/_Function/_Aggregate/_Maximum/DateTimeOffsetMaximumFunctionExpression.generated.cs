using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetMaximumFunctionExpression
    {
        #region implicit operators
        public static implicit operator DateTimeOffsetExpressionMediator(DateTimeOffsetMaximumFunctionExpression a) => new DateTimeOffsetExpressionMediator(a);
        public static implicit operator OrderByExpression(DateTimeOffsetMaximumFunctionExpression a) => new OrderByExpression(new DateTimeOffsetExpressionMediator(a), OrderExpressionDirection.ASC);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new DateTimeOffsetExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new DateTimeOffsetExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, byte b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, byte b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(byte a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(byte a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(byte? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(byte? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, decimal b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, decimal b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(decimal a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(decimal a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(decimal? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(decimal? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, double b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, double b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(double a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(double a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(double? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(double? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, float b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, float b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(float a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(float a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(float? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(float? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, short b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, short b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(short a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(short a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(short? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(short? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, int b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, int b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(int a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(int a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(int? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(int? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, long b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, long b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(long a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(long a, DateTimeOffsetMaximumFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(long? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(long? a, DateTimeOffsetMaximumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion

        #region mediator
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, ByteExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, ByteExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, DecimalExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, DecimalExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, Int16ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, Int16ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, Int32ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, Int32ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetMaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetMaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTimeOffset
        public static FilterExpressionSet operator ==(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset a, DateTimeOffsetMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset a, DateTimeOffsetMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset a, DateTimeOffsetMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTimeOffset a, DateTimeOffsetMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTimeOffset a, DateTimeOffsetMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTimeOffset a, DateTimeOffsetMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset? a, DateTimeOffsetMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset? a, DateTimeOffsetMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset? a, DateTimeOffsetMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTimeOffset? a, DateTimeOffsetMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTimeOffset? a, DateTimeOffsetMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTimeOffset? a, DateTimeOffsetMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTimeOffsetMaximumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffsetMaximumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetMaximumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetMaximumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetMaximumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(DateTimeOffsetMaximumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(DateTimeOffsetMaximumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
