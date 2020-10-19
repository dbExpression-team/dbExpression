using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteCastFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableByteExpressionMediator(NullableByteCastFunctionExpression a) => new NullableByteExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableByteCastFunctionExpression a) => new OrderByExpression(new ByteExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableByteCastFunctionExpression a) => new GroupByExpression(new ByteExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new ByteExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new ByteExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region bool



        
        #endregion
        
        #region byte
        public static NullableByteExpressionMediator operator +(NullableByteCastFunctionExpression a, byte b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(NullableByteCastFunctionExpression a, byte b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(NullableByteCastFunctionExpression a, byte b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(NullableByteCastFunctionExpression a, byte b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(NullableByteCastFunctionExpression a, byte b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(byte a, NullableByteCastFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(byte a, NullableByteCastFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(byte a, NullableByteCastFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(byte a, NullableByteCastFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(byte a, NullableByteCastFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(NullableByteCastFunctionExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(NullableByteCastFunctionExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(NullableByteCastFunctionExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(NullableByteCastFunctionExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(NullableByteCastFunctionExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(byte? a, NullableByteCastFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(byte? a, NullableByteCastFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(byte? a, NullableByteCastFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(byte? a, NullableByteCastFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(byte? a, NullableByteCastFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableByteCastFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableByteCastFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableByteCastFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableByteCastFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableByteCastFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal a, NullableByteCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableByteCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableByteCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableByteCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableByteCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableByteCastFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableByteCastFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableByteCastFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableByteCastFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableByteCastFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableByteCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableByteCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableByteCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableByteCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableByteCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableByteCastFunctionExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableByteCastFunctionExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableByteCastFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableByteCastFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableByteCastFunctionExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableByteCastFunctionExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableByteCastFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableByteCastFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableByteCastFunctionExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableByteCastFunctionExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableByteCastFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableByteCastFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableByteCastFunctionExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableByteCastFunctionExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableByteCastFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableByteCastFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion
        
        #region double
        public static NullableDoubleExpressionMediator operator +(NullableByteCastFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableByteCastFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableByteCastFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableByteCastFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableByteCastFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double a, NullableByteCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double a, NullableByteCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double a, NullableByteCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double a, NullableByteCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double a, NullableByteCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableByteCastFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableByteCastFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableByteCastFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableByteCastFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableByteCastFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, NullableByteCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, NullableByteCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, NullableByteCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, NullableByteCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, NullableByteCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region float
        public static NullableSingleExpressionMediator operator +(NullableByteCastFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableByteCastFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableByteCastFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableByteCastFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableByteCastFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float a, NullableByteCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float a, NullableByteCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float a, NullableByteCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float a, NullableByteCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float a, NullableByteCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableByteCastFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableByteCastFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableByteCastFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableByteCastFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableByteCastFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, NullableByteCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, NullableByteCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, NullableByteCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, NullableByteCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, NullableByteCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region Guid



        
        #endregion
        
        #region short
        public static NullableInt16ExpressionMediator operator +(NullableByteCastFunctionExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableByteCastFunctionExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableByteCastFunctionExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableByteCastFunctionExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableByteCastFunctionExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(short a, NullableByteCastFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(short a, NullableByteCastFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(short a, NullableByteCastFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(short a, NullableByteCastFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(short a, NullableByteCastFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableByteCastFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableByteCastFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableByteCastFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableByteCastFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableByteCastFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(short? a, NullableByteCastFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(short? a, NullableByteCastFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(short? a, NullableByteCastFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(short? a, NullableByteCastFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(short? a, NullableByteCastFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region int
        public static NullableInt32ExpressionMediator operator +(NullableByteCastFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableByteCastFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableByteCastFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableByteCastFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableByteCastFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int a, NullableByteCastFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int a, NullableByteCastFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int a, NullableByteCastFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int a, NullableByteCastFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int a, NullableByteCastFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableByteCastFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableByteCastFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableByteCastFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableByteCastFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableByteCastFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int? a, NullableByteCastFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int? a, NullableByteCastFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int? a, NullableByteCastFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int? a, NullableByteCastFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int? a, NullableByteCastFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region long
        public static NullableInt64ExpressionMediator operator +(NullableByteCastFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableByteCastFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableByteCastFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableByteCastFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableByteCastFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long a, NullableByteCastFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long a, NullableByteCastFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long a, NullableByteCastFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long a, NullableByteCastFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long a, NullableByteCastFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableByteCastFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableByteCastFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableByteCastFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableByteCastFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableByteCastFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, NullableByteCastFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, NullableByteCastFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, NullableByteCastFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, NullableByteCastFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, NullableByteCastFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region string
        
        #endregion
        
        #region TimeSpan



        
        #endregion
        
        #endregion

        #region mediator
        #region bool

        #endregion
        
        #region byte
        public static NullableByteExpressionMediator operator +(NullableByteCastFunctionExpression a, ByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(NullableByteCastFunctionExpression a, ByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(NullableByteCastFunctionExpression a, ByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(NullableByteCastFunctionExpression a, ByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(NullableByteCastFunctionExpression a, ByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(NullableByteCastFunctionExpression a, NullableByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(NullableByteCastFunctionExpression a, NullableByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(NullableByteCastFunctionExpression a, NullableByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(NullableByteCastFunctionExpression a, NullableByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(NullableByteCastFunctionExpression a, NullableByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableByteCastFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableByteCastFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableByteCastFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableByteCastFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableByteCastFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableByteCastFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableByteCastFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableByteCastFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableByteCastFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableByteCastFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableByteCastFunctionExpression a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableByteCastFunctionExpression a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableByteCastFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableByteCastFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableByteCastFunctionExpression a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableByteCastFunctionExpression a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableByteCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableByteCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static NullableDoubleExpressionMediator operator +(NullableByteCastFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableByteCastFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableByteCastFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableByteCastFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableByteCastFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableByteCastFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableByteCastFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableByteCastFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableByteCastFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableByteCastFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static NullableSingleExpressionMediator operator +(NullableByteCastFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableByteCastFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableByteCastFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableByteCastFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableByteCastFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableByteCastFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableByteCastFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableByteCastFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableByteCastFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableByteCastFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region Guid

        #endregion
        
        #region short
        public static NullableInt16ExpressionMediator operator +(NullableByteCastFunctionExpression a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableByteCastFunctionExpression a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableByteCastFunctionExpression a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableByteCastFunctionExpression a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableByteCastFunctionExpression a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableByteCastFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableByteCastFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableByteCastFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableByteCastFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableByteCastFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static NullableInt32ExpressionMediator operator +(NullableByteCastFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableByteCastFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableByteCastFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableByteCastFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableByteCastFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableByteCastFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableByteCastFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableByteCastFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableByteCastFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableByteCastFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static NullableInt64ExpressionMediator operator +(NullableByteCastFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableByteCastFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableByteCastFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableByteCastFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableByteCastFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableByteCastFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableByteCastFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableByteCastFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableByteCastFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableByteCastFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region byte
        public static FilterExpression<bool?> operator ==(NullableByteCastFunctionExpression a, byte b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteCastFunctionExpression a, byte b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableByteCastFunctionExpression a, byte b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableByteCastFunctionExpression a, byte b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableByteCastFunctionExpression a, byte b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableByteCastFunctionExpression a, byte b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(byte a, NullableByteCastFunctionExpression b) => new FilterExpression<bool?>(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(byte a, NullableByteCastFunctionExpression b) => new FilterExpression<bool?>(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(byte a, NullableByteCastFunctionExpression b) => new FilterExpression<bool?>(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(byte a, NullableByteCastFunctionExpression b) => new FilterExpression<bool?>(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(byte a, NullableByteCastFunctionExpression b) => new FilterExpression<bool?>(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(byte a, NullableByteCastFunctionExpression b) => new FilterExpression<bool?>(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableByteCastFunctionExpression a, byte? b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteCastFunctionExpression a, byte? b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableByteCastFunctionExpression a, byte? b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableByteCastFunctionExpression a, byte? b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableByteCastFunctionExpression a, byte? b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableByteCastFunctionExpression a, byte? b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(byte? a, NullableByteCastFunctionExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(byte? a, NullableByteCastFunctionExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(byte? a, NullableByteCastFunctionExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(byte? a, NullableByteCastFunctionExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(byte? a, NullableByteCastFunctionExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(byte? a, NullableByteCastFunctionExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool?> operator ==(NullableByteCastFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteCastFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableByteCastFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableByteCastFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableByteCastFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableByteCastFunctionExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableByteCastFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteCastFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableByteCastFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableByteCastFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableByteCastFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableByteCastFunctionExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
