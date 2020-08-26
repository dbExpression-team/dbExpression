using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<float>(SingleExpressionMediator a) => new SelectExpression<float>(a);
        public static implicit operator OrderByExpression(SingleExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(SingleExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static SingleExpressionMediator operator +(SingleExpressionMediator a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(byte a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(byte a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(byte a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(byte a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(byte a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(SingleExpressionMediator a, byte? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, byte? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, byte? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, byte? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, byte? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(byte? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(byte? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(byte? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(byte? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(byte? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(SingleExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(SingleExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(SingleExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(SingleExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(SingleExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal a, SingleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal a, SingleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal a, SingleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal a, SingleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal a, SingleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(SingleExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(SingleExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(SingleExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(SingleExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(SingleExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal? a, SingleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal? a, SingleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal? a, SingleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal? a, SingleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal? a, SingleExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(SingleExpressionMediator a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(SingleExpressionMediator a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));
        public static DateTimeExpressionMediator operator *(SingleExpressionMediator a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Multiply));
        public static DateTimeExpressionMediator operator /(SingleExpressionMediator a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Divide));
        public static DateTimeExpressionMediator operator %(SingleExpressionMediator a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Modulo));

        public static DateTimeExpressionMediator operator +(DateTime a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DateTimeExpressionMediator operator *(DateTime a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DateTimeExpressionMediator operator /(DateTime a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DateTimeExpressionMediator operator %(DateTime a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static DateTimeExpressionMediator operator +(SingleExpressionMediator a, DateTime? b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(SingleExpressionMediator a, DateTime? b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));
        public static DateTimeExpressionMediator operator *(SingleExpressionMediator a, DateTime? b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Multiply));
        public static DateTimeExpressionMediator operator /(SingleExpressionMediator a, DateTime? b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Divide));
        public static DateTimeExpressionMediator operator %(SingleExpressionMediator a, DateTime? b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Modulo));

        public static DateTimeExpressionMediator operator +(DateTime? a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime? a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DateTimeExpressionMediator operator *(DateTime? a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DateTimeExpressionMediator operator /(DateTime? a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DateTimeExpressionMediator operator %(DateTime? a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(SingleExpressionMediator a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(SingleExpressionMediator a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));
        public static DateTimeOffsetExpressionMediator operator *(SingleExpressionMediator a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Multiply));
        public static DateTimeOffsetExpressionMediator operator /(SingleExpressionMediator a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Divide));
        public static DateTimeOffsetExpressionMediator operator %(SingleExpressionMediator a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Modulo));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DateTimeOffsetExpressionMediator operator *(DateTimeOffset a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DateTimeOffsetExpressionMediator operator /(DateTimeOffset a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DateTimeOffsetExpressionMediator operator %(DateTimeOffset a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static DateTimeOffsetExpressionMediator operator +(SingleExpressionMediator a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(SingleExpressionMediator a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));
        public static DateTimeOffsetExpressionMediator operator *(SingleExpressionMediator a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Multiply));
        public static DateTimeOffsetExpressionMediator operator /(SingleExpressionMediator a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Divide));
        public static DateTimeOffsetExpressionMediator operator %(SingleExpressionMediator a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Modulo));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DateTimeOffsetExpressionMediator operator *(DateTimeOffset? a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DateTimeOffsetExpressionMediator operator /(DateTimeOffset? a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DateTimeOffsetExpressionMediator operator %(DateTimeOffset? a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(SingleExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(SingleExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(SingleExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(SingleExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(SingleExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(SingleExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(SingleExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(SingleExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(SingleExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(SingleExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double? a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double? a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double? a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double? a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double? a, SingleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static SingleExpressionMediator operator +(SingleExpressionMediator a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(SingleExpressionMediator a, float? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, float? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, float? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, float? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, float? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static SingleExpressionMediator operator +(SingleExpressionMediator a, short b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, short b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, short b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, short b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, short b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(short a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(short a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(short a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(short a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(short a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(SingleExpressionMediator a, short? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, short? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, short? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, short? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, short? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(short? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(short? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(short? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(short? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(short? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static SingleExpressionMediator operator +(SingleExpressionMediator a, int b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, int b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, int b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, int b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, int b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(int a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(int a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(int a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(int a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(int a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(SingleExpressionMediator a, int? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, int? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, int? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, int? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, int? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(int? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(int? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(int? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(int? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(int? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static SingleExpressionMediator operator +(SingleExpressionMediator a, long b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, long b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, long b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, long b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, long b) => new SingleExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(long a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(long a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(long a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(long a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(long a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(SingleExpressionMediator a, long? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, long? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, long? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, long? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, long? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(long? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(long? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(long? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(long? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(long? a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string
        public static StringExpressionMediator operator +(SingleExpressionMediator a, string b) => new StringExpressionMediator(new ArithmeticExpression(a, new StringExpressionMediator(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add));

        public static StringExpressionMediator operator +(string a, SingleExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(new LiteralExpression<string>(a)), b, ArithmeticExpressionOperator.Add));

        #endregion

        #endregion

        #region mediator
        #region byte
        public static SingleExpressionMediator operator +(SingleExpressionMediator a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleExpressionMediator a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleExpressionMediator a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleExpressionMediator a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleExpressionMediator a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleExpressionMediator a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(SingleExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(SingleExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(SingleExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(SingleExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(SingleExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(SingleExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(SingleExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(SingleExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(SingleExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(SingleExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(SingleExpressionMediator a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(SingleExpressionMediator a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DateTimeExpressionMediator operator *(SingleExpressionMediator a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DateTimeExpressionMediator operator /(SingleExpressionMediator a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DateTimeExpressionMediator operator %(SingleExpressionMediator a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDateTimeExpressionMediator operator +(SingleExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(SingleExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDateTimeExpressionMediator operator *(SingleExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDateTimeExpressionMediator operator /(SingleExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDateTimeExpressionMediator operator %(SingleExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(SingleExpressionMediator a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(SingleExpressionMediator a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DateTimeOffsetExpressionMediator operator *(SingleExpressionMediator a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DateTimeOffsetExpressionMediator operator /(SingleExpressionMediator a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DateTimeOffsetExpressionMediator operator %(SingleExpressionMediator a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDateTimeOffsetExpressionMediator operator +(SingleExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(SingleExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDateTimeOffsetExpressionMediator operator *(SingleExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDateTimeOffsetExpressionMediator operator /(SingleExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDateTimeOffsetExpressionMediator operator %(SingleExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(SingleExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(SingleExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(SingleExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(SingleExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(SingleExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(SingleExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(SingleExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(SingleExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(SingleExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(SingleExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static SingleExpressionMediator operator +(SingleExpressionMediator a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static SingleExpressionMediator operator +(SingleExpressionMediator a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static SingleExpressionMediator operator +(SingleExpressionMediator a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static SingleExpressionMediator operator +(SingleExpressionMediator a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleExpressionMediator a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleExpressionMediator a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleExpressionMediator a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleExpressionMediator a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #endregion
        #endregion

        #region filter operators
        public static FilterExpression<bool> operator ==(SingleExpressionMediator a, float b) => new FilterExpression<bool>(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(SingleExpressionMediator a, float b) => new FilterExpression<bool>(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(SingleExpressionMediator a, float b) => new FilterExpression<bool>(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(SingleExpressionMediator a, float b) => new FilterExpression<bool>(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(SingleExpressionMediator a, float b) => new FilterExpression<bool>(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(SingleExpressionMediator a, float b) => new FilterExpression<bool>(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(float a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(float a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(float a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(float a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(float a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(float a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(SingleExpressionMediator a, float? b) => new FilterExpression<bool>(a, new SingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(SingleExpressionMediator a, float? b) => new FilterExpression<bool>(a, new SingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(SingleExpressionMediator a, float? b) => new FilterExpression<bool>(a, new SingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(SingleExpressionMediator a, float? b) => new FilterExpression<bool>(a, new SingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(SingleExpressionMediator a, float? b) => new FilterExpression<bool>(a, new SingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(SingleExpressionMediator a, float? b) => new FilterExpression<bool>(a, new SingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(float? a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float?>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(float? a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float?>(a)), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(float? a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float?>(a)), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(float? a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float?>(a)), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(float? a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float?>(a)), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(float? a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float?>(a)), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(SingleExpressionMediator a, SingleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(SingleExpressionMediator a, SingleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(SingleExpressionMediator a, SingleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(SingleExpressionMediator a, SingleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(SingleExpressionMediator a, SingleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(SingleExpressionMediator a, SingleExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(SingleExpressionMediator a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(SingleExpressionMediator a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(SingleExpressionMediator a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(SingleExpressionMediator a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(SingleExpressionMediator a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(SingleExpressionMediator a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
    }
}
