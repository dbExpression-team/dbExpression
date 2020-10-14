using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetIsNullFunctionExpression
    {
        #region implicit operators
        public static implicit operator DateTimeOffsetExpressionMediator(DateTimeOffsetIsNullFunctionExpression a) => new DateTimeOffsetExpressionMediator(a);
        public static implicit operator OrderByExpression(DateTimeOffsetIsNullFunctionExpression a) => new OrderByExpression(new DateTimeOffsetExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(DateTimeOffsetIsNullFunctionExpression a) => new GroupByExpression(new DateTimeOffsetExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new DateTimeOffsetExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new DateTimeOffsetExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region bool



        #endregion
        
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, byte b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, byte b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(byte a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(byte a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(byte? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(byte? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, decimal b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, decimal b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(decimal a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(decimal a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(decimal? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(decimal? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTime
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTime b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTime b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTime a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTime a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTime? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTime? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTime? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTime? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, double b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, double b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(double a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(double a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(double? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(double? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, float b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, float b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(float a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(float a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(float? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(float? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region Guid



        #endregion
        
        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, short b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, short b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(short a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(short a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(short? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(short? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, int b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, int b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(int a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(int a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(int? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(int? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, long b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, long b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(long a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(long a, DateTimeOffsetIsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(long? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(long? a, DateTimeOffsetIsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region string



        #endregion
        
        #endregion

        #region mediator
        #region bool

        #endregion
        
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, ByteExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, ByteExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DecimalExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DecimalExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTime
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTimeExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTimeExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region Guid

        #endregion
        
        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, Int16ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, Int16ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, Int32ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, Int32ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetIsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetIsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region string

        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTimeOffset
        public static FilterExpression<bool> operator ==(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeOffset a, DateTimeOffsetIsNullFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeOffset? a, DateTimeOffsetIsNullFunctionExpression b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeOffsetIsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DateTimeOffsetIsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
