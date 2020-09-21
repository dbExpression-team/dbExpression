using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DoubleExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<double>(DoubleExpressionMediator a) => new SelectExpression<double>(a);
        public static implicit operator OrderByExpression(DoubleExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(DoubleExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, byte b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, byte b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, byte b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, byte b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, byte b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(byte a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(byte a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(byte a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(byte a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(byte a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, byte? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, byte? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, byte? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, byte? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, byte? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(byte? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(byte? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(byte? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(byte? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(byte? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(DoubleExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DoubleExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DoubleExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DoubleExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DoubleExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal a, DoubleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal a, DoubleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal a, DoubleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal a, DoubleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal a, DoubleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(DoubleExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DoubleExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DoubleExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DoubleExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DoubleExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal? a, DoubleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal? a, DoubleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal? a, DoubleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal? a, DoubleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal? a, DoubleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(DoubleExpressionMediator a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DoubleExpressionMediator a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(DateTime a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(DoubleExpressionMediator a, DateTime? b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DoubleExpressionMediator a, DateTime? b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(DateTime? a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime? a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DoubleExpressionMediator a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DoubleExpressionMediator a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DoubleExpressionMediator a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DoubleExpressionMediator a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, float b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, float b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, float b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, float b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, float b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(float a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(float a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(float a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(float a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(float a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, float? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, float? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, float? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, float? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, float? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(float? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(float? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(float? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(float? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(float? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, short b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, short b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, short b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, short b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, short b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(short a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(short a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(short a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(short a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(short a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, short? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, short? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, short? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, short? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, short? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(short? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(short? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(short? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(short? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(short? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, int b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, int b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, int b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, int b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, int b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(int a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(int a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(int a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(int a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(int a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, int? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, int? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, int? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, int? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, int? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(int? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(int? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(int? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(int? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(int? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, long b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, long b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, long b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, long b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, long b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(long a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(long a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(long a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(long a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(long a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, long? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, long? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, long? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, long? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, long? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(long? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(long? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(long? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(long? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(long? a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string


        #endregion

        #endregion

        #region mediator
        #region byte
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, ByteExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, ByteExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, ByteExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, ByteExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, ByteExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableByteExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableByteExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableByteExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableByteExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableByteExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(DoubleExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(DoubleExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(DoubleExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(DoubleExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(DoubleExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(DoubleExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(DoubleExpressionMediator a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DoubleExpressionMediator a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DoubleExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DoubleExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DoubleExpressionMediator a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DoubleExpressionMediator a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DoubleExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DoubleExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableSingleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableSingleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableSingleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableSingleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableSingleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, Int16ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, Int16ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, Int16ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, Int16ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, Int16ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, Int32ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, Int32ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, Int32ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, Int32ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, Int32ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static DoubleExpressionMediator operator +(DoubleExpressionMediator a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(DoubleExpressionMediator a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(DoubleExpressionMediator a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(DoubleExpressionMediator a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(DoubleExpressionMediator a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(DoubleExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #endregion
        #endregion

        #region filter operators
        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, double b) => new FilterExpression<bool>(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, double b) => new FilterExpression<bool>(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, double b) => new FilterExpression<bool>(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, double b) => new FilterExpression<bool>(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, double b) => new FilterExpression<bool>(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, double b) => new FilterExpression<bool>(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(double a, DoubleExpressionMediator b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(double a, DoubleExpressionMediator b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(double a, DoubleExpressionMediator b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(double a, DoubleExpressionMediator b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(double a, DoubleExpressionMediator b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(double a, DoubleExpressionMediator b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, double? b) => new FilterExpression<bool>(a, new DoubleExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, double? b) => new FilterExpression<bool>(a, new DoubleExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, double? b) => new FilterExpression<bool>(a, new DoubleExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, double? b) => new FilterExpression<bool>(a, new DoubleExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, double? b) => new FilterExpression<bool>(a, new DoubleExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, double? b) => new FilterExpression<bool>(a, new DoubleExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(double? a, DoubleExpressionMediator b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double?>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(double? a, DoubleExpressionMediator b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double?>(a)), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(double? a, DoubleExpressionMediator b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double?>(a)), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(double? a, DoubleExpressionMediator b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double?>(a)), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(double? a, DoubleExpressionMediator b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double?>(a)), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(double? a, DoubleExpressionMediator b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double?>(a)), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DoubleExpressionMediator a, DoubleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DoubleExpressionMediator a, DoubleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DoubleExpressionMediator a, DoubleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DoubleExpressionMediator a, DoubleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DoubleExpressionMediator a, DoubleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DoubleExpressionMediator a, DoubleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DoubleExpressionMediator a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
