using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTimeOffset?>(NullableDateTimeOffsetExpressionMediator a) => new SelectExpression<DateTimeOffset?>(a);
        public static implicit operator OrderByExpression(NullableDateTimeOffsetExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableDateTimeOffsetExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators 
        #region TValue
        #region byte
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, byte b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, byte b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(byte a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(byte a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(byte? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(byte? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region decimal
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, decimal b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, decimal b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(decimal a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(decimal a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(decimal? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(decimal? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTime
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, DateTime b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, DateTime b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTime a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTime a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, DateTime? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, DateTime? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTime? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTime? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, double b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, double b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(double a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(double a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(double? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(double? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region float
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, float b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, float b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(float a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(float a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(float? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(float? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region short
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, short b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, short b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(short a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(short a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(short? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(short? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region int
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, int b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, int b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(int a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(int a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(int? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(int? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region long
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, long b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, long b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(long a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(long a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(long? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(long? a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion


        #endregion

        #region mediator
        #region byte
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, ByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, ByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region decimal
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, DecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, DecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTime
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, DateTimeExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, DateTimeExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, DoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, DoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region float
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, SingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, SingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region short
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, Int16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, Int16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region int
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, Int32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, Int32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region long
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, Int64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, Int64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion


        #endregion
        #endregion

        #region filter operators
        #region DateTimeOffset
        public static FilterExpression<bool?> operator ==(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset b) => new FilterExpression<bool?>(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset b) => new FilterExpression<bool?>(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset b) => new FilterExpression<bool?>(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset b) => new FilterExpression<bool?>(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset b) => new FilterExpression<bool?>(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset b) => new FilterExpression<bool?>(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DateTimeOffset a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DateTimeOffset a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DateTimeOffset a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DateTimeOffset a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DateTimeOffset a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DateTimeOffset a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableDateTimeOffsetExpressionMediator a, DateTimeOffset? b) => new FilterExpression<bool?>(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DateTimeOffset? a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DateTimeOffset? a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DateTimeOffset? a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DateTimeOffset? a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DateTimeOffset? a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DateTimeOffset? a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<bool?> operator ==(NullableDateTimeOffsetExpressionMediator a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableDateTimeOffsetExpressionMediator a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableDateTimeOffsetExpressionMediator a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableDateTimeOffsetExpressionMediator a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableDateTimeOffsetExpressionMediator a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableDateTimeOffsetExpressionMediator a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableDateTimeOffsetExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableDateTimeOffsetExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableDateTimeOffsetExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableDateTimeOffsetExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableDateTimeOffsetExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableDateTimeOffsetExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
