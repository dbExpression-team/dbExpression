using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16ExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<short?>(NullableInt16ExpressionMediator a) => new SelectExpression<short?>(a);
        public static implicit operator OrderByExpression(NullableInt16ExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableInt16ExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators 
        #region data type 
        #region byte
        public static NullableInt16ExpressionMediator operator +(NullableInt16ExpressionMediator a, byte b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16ExpressionMediator a, byte b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16ExpressionMediator a, byte b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16ExpressionMediator a, byte b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16ExpressionMediator a, byte b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(byte a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(byte a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(byte a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(byte a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(byte a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableInt16ExpressionMediator a, byte? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16ExpressionMediator a, byte? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16ExpressionMediator a, byte? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16ExpressionMediator a, byte? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16ExpressionMediator a, byte? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(byte? a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(byte? a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(byte? a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(byte? a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(byte? a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt16ExpressionMediator a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt16ExpressionMediator a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt16ExpressionMediator a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt16ExpressionMediator a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt16ExpressionMediator a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal a, NullableInt16ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableInt16ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableInt16ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableInt16ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableInt16ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt16ExpressionMediator a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt16ExpressionMediator a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt16ExpressionMediator a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt16ExpressionMediator a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt16ExpressionMediator a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableInt16ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableInt16ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableInt16ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableInt16ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableInt16ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt16ExpressionMediator a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt16ExpressionMediator a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt16ExpressionMediator a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt16ExpressionMediator a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt16ExpressionMediator a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt16ExpressionMediator a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt16ExpressionMediator a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt16ExpressionMediator a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt16ExpressionMediator a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt16ExpressionMediator a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt16ExpressionMediator a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt16ExpressionMediator a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt16ExpressionMediator a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt16ExpressionMediator a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt16ExpressionMediator a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt16ExpressionMediator a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt16ExpressionMediator a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt16ExpressionMediator a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, NullableInt16ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt16ExpressionMediator a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt16ExpressionMediator a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt16ExpressionMediator a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt16ExpressionMediator a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt16ExpressionMediator a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt16ExpressionMediator a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt16ExpressionMediator a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt16ExpressionMediator a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt16ExpressionMediator a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt16ExpressionMediator a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static NullableInt16ExpressionMediator operator +(NullableInt16ExpressionMediator a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16ExpressionMediator a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16ExpressionMediator a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16ExpressionMediator a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16ExpressionMediator a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(short a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(short a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(short a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(short a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(short a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableInt16ExpressionMediator a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16ExpressionMediator a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16ExpressionMediator a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16ExpressionMediator a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16ExpressionMediator a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(short? a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(short? a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(short? a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(short? a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(short? a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt16ExpressionMediator a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16ExpressionMediator a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16ExpressionMediator a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16ExpressionMediator a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16ExpressionMediator a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16ExpressionMediator a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16ExpressionMediator a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16ExpressionMediator a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16ExpressionMediator a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16ExpressionMediator a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int? a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int? a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int? a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int? a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int? a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt16ExpressionMediator a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt16ExpressionMediator a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt16ExpressionMediator a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt16ExpressionMediator a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt16ExpressionMediator a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt16ExpressionMediator a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt16ExpressionMediator a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt16ExpressionMediator a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt16ExpressionMediator a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt16ExpressionMediator a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion


        #region TimeSpan



        #endregion

        #endregion

        #region fields
        #region byte
        public static NullableInt16ExpressionMediator operator +(NullableInt16ExpressionMediator a, ByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16ExpressionMediator a, ByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16ExpressionMediator a, ByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16ExpressionMediator a, ByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16ExpressionMediator a, ByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt16ExpressionMediator a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt16ExpressionMediator a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt16ExpressionMediator a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt16ExpressionMediator a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt16ExpressionMediator a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt16ExpressionMediator a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt16ExpressionMediator a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt16ExpressionMediator a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt16ExpressionMediator a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt16ExpressionMediator a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt16ExpressionMediator a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt16ExpressionMediator a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt16ExpressionMediator a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt16ExpressionMediator a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt16ExpressionMediator a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt16ExpressionMediator a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt16ExpressionMediator a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt16ExpressionMediator a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt16ExpressionMediator a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static NullableInt16ExpressionMediator operator +(NullableInt16ExpressionMediator a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16ExpressionMediator a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16ExpressionMediator a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16ExpressionMediator a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16ExpressionMediator a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt16ExpressionMediator a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16ExpressionMediator a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16ExpressionMediator a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16ExpressionMediator a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16ExpressionMediator a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt16ExpressionMediator a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt16ExpressionMediator a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt16ExpressionMediator a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt16ExpressionMediator a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt16ExpressionMediator a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string

        #endregion

        #region TimeSpan

        #endregion

        #endregion

        #region mediators
        #region byte
        public static NullableInt16ExpressionMediator operator +(NullableInt16ExpressionMediator a, ByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16ExpressionMediator a, ByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16ExpressionMediator a, ByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16ExpressionMediator a, ByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16ExpressionMediator a, ByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt16ExpressionMediator a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt16ExpressionMediator a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt16ExpressionMediator a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt16ExpressionMediator a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt16ExpressionMediator a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt16ExpressionMediator a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt16ExpressionMediator a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt16ExpressionMediator a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt16ExpressionMediator a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt16ExpressionMediator a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt16ExpressionMediator a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt16ExpressionMediator a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt16ExpressionMediator a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt16ExpressionMediator a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt16ExpressionMediator a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt16ExpressionMediator a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt16ExpressionMediator a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt16ExpressionMediator a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt16ExpressionMediator a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static NullableInt16ExpressionMediator operator +(NullableInt16ExpressionMediator a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16ExpressionMediator a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16ExpressionMediator a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16ExpressionMediator a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16ExpressionMediator a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt16ExpressionMediator a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16ExpressionMediator a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16ExpressionMediator a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16ExpressionMediator a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16ExpressionMediator a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt16ExpressionMediator a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt16ExpressionMediator a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt16ExpressionMediator a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt16ExpressionMediator a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt16ExpressionMediator a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt16ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt16ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt16ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt16ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt16ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion


        #region TimeSpan

        #endregion

        #endregion
        #endregion

        #region filter operators
        #region short
        public static FilterExpressionSet operator ==(NullableInt16ExpressionMediator a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16ExpressionMediator a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16ExpressionMediator a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableInt16ExpressionMediator a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableInt16ExpressionMediator a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableInt16ExpressionMediator a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(short a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(short a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(short a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(short a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(short a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(short a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt16ExpressionMediator a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16ExpressionMediator a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16ExpressionMediator a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableInt16ExpressionMediator a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableInt16ExpressionMediator a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableInt16ExpressionMediator a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(short? a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(short? a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(short? a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(short? a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(short? a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(short? a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableInt16ExpressionMediator a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16ExpressionMediator a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16ExpressionMediator a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableInt16ExpressionMediator a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableInt16ExpressionMediator a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableInt16ExpressionMediator a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt16ExpressionMediator a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16ExpressionMediator a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16ExpressionMediator a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableInt16ExpressionMediator a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableInt16ExpressionMediator a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableInt16ExpressionMediator a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new NullableInt16ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        
        #region mediator
        public static FilterExpressionSet operator ==(NullableInt16ExpressionMediator a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16ExpressionMediator a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16ExpressionMediator a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableInt16ExpressionMediator a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableInt16ExpressionMediator a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableInt16ExpressionMediator a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt16ExpressionMediator a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int16ExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16ExpressionMediator a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int16ExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16ExpressionMediator a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int16ExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(NullableInt16ExpressionMediator a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int16ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(NullableInt16ExpressionMediator a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int16ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(NullableInt16ExpressionMediator a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int16ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
