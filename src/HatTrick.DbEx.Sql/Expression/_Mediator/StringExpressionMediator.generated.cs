using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<string>(StringExpressionMediator a) => new SelectExpression<string>(a);
        public static implicit operator OrderByExpression(StringExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(StringExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators
        #region TValue
        #region bool



        #endregion

        #region byte
        public static StringExpressionMediator operator +(StringExpressionMediator a, byte b) => new StringExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, byte b) => new StringExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, byte b) => new StringExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, byte b) => new StringExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, byte b) => new StringExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(byte a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(byte a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(byte a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(byte a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(byte a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringExpressionMediator a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(byte? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(byte? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(byte? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(byte? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(byte? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static StringExpressionMediator operator +(StringExpressionMediator a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(decimal a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(decimal a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(decimal a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(decimal a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(decimal a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringExpressionMediator a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(decimal? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(decimal? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(decimal? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(decimal? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(decimal? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static StringExpressionMediator operator +(StringExpressionMediator a, DateTime b) => new StringExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, DateTime b) => new StringExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, DateTime b) => new StringExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, DateTime b) => new StringExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, DateTime b) => new StringExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(DateTime a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(DateTime a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(DateTime a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(DateTime a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(DateTime a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringExpressionMediator a, DateTime? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, DateTime? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, DateTime? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, DateTime? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, DateTime? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(DateTime? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(DateTime? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(DateTime? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(DateTime? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(DateTime? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTimeOffset
        public static StringExpressionMediator operator +(StringExpressionMediator a, DateTimeOffset b) => new StringExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, DateTimeOffset b) => new StringExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, DateTimeOffset b) => new StringExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, DateTimeOffset b) => new StringExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, DateTimeOffset b) => new StringExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(DateTimeOffset a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(DateTimeOffset a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(DateTimeOffset a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(DateTimeOffset a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(DateTimeOffset a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringExpressionMediator a, DateTimeOffset? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, DateTimeOffset? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, DateTimeOffset? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, DateTimeOffset? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, DateTimeOffset? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(DateTimeOffset? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(DateTimeOffset? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(DateTimeOffset? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(DateTimeOffset? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(DateTimeOffset? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static StringExpressionMediator operator +(StringExpressionMediator a, double b) => new StringExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, double b) => new StringExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, double b) => new StringExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, double b) => new StringExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, double b) => new StringExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(double a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(double a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(double a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(double a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(double a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringExpressionMediator a, double? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, double? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, double? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, double? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, double? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(double? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(double? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(double? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(double? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(double? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static StringExpressionMediator operator +(StringExpressionMediator a, float b) => new StringExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, float b) => new StringExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, float b) => new StringExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, float b) => new StringExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, float b) => new StringExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(float a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(float a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(float a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(float a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(float a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringExpressionMediator a, float? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, float? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, float? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, float? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, float? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(float? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(float? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(float? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(float? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(float? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region Guid



        #endregion

        #region short
        public static StringExpressionMediator operator +(StringExpressionMediator a, short b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, short b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, short b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, short b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, short b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(short a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(short a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(short a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(short a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(short a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringExpressionMediator a, short? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, short? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, short? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, short? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, short? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(short? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(short? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(short? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(short? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(short? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static StringExpressionMediator operator +(StringExpressionMediator a, int b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, int b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, int b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, int b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, int b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(int a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(int a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(int a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(int a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(int a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringExpressionMediator a, int? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, int? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, int? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, int? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, int? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(int? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(int? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(int? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(int? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(int? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static StringExpressionMediator operator +(StringExpressionMediator a, long b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, long b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, long b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, long b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, long b) => new StringExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(long a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(long a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(long a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(long a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(long a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringExpressionMediator a, long? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringExpressionMediator a, long? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringExpressionMediator a, long? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringExpressionMediator a, long? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringExpressionMediator a, long? b) => new StringExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(long? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(long? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(long? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(long? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(long? a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string
        public static StringExpressionMediator operator +(StringExpressionMediator a, string b) => new StringExpressionMediator(new ArithmeticExpression(a, new StringExpressionMediator(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add));

        public static StringExpressionMediator operator +(string a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(new LiteralExpression<string>(a)), b, ArithmeticExpressionOperator.Add));

        #endregion

        #endregion

        #region mediator
        #endregion
        #endregion

        #region filter operators
        public static FilterExpression<bool> operator ==(StringExpressionMediator a, string b) => new FilterExpression<bool>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(StringExpressionMediator a, string b) => new FilterExpression<bool>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(StringExpressionMediator a, string b) => new FilterExpression<bool>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(StringExpressionMediator a, string b) => new FilterExpression<bool>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(StringExpressionMediator a, string b) => new FilterExpression<bool>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(StringExpressionMediator a, string b) => new FilterExpression<bool>(a, new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(string a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(string a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(string a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(string a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(string a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(string a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), b, FilterExpressionOperator.GreaterThanOrEqual);


        public static FilterExpression<bool> operator ==(StringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(StringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(StringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(StringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(StringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(StringExpressionMediator a, StringExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
    }
}
