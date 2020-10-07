using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleCastFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableSingleExpressionMediator(NullableSingleCastFunctionExpression a) => new NullableSingleExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableSingleCastFunctionExpression a) => new OrderByExpression(new SingleExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableSingleCastFunctionExpression a) => new GroupByExpression(new SingleExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new SingleExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new SingleExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region bool



        
        #endregion

        #region byte
        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(byte a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(byte a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(byte a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(byte a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(byte a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(byte? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(byte? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(byte? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(byte? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(byte? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableSingleCastFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableSingleCastFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableSingleCastFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableSingleCastFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableSingleCastFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal a, NullableSingleCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableSingleCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableSingleCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableSingleCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableSingleCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableSingleCastFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableSingleCastFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableSingleCastFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableSingleCastFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableSingleCastFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableSingleCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableSingleCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableSingleCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableSingleCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableSingleCastFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableSingleCastFunctionExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableSingleCastFunctionExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableSingleCastFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableSingleCastFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableSingleCastFunctionExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableSingleCastFunctionExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableSingleCastFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableSingleCastFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableSingleCastFunctionExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableSingleCastFunctionExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableSingleCastFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableSingleCastFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableSingleCastFunctionExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableSingleCastFunctionExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableSingleCastFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableSingleCastFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableSingleCastFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableSingleCastFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableSingleCastFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableSingleCastFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableSingleCastFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double a, NullableSingleCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double a, NullableSingleCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double a, NullableSingleCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double a, NullableSingleCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double a, NullableSingleCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableSingleCastFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableSingleCastFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableSingleCastFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableSingleCastFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableSingleCastFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, NullableSingleCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, NullableSingleCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, NullableSingleCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, NullableSingleCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, NullableSingleCastFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region Guid



        
        #endregion

        #region short
        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(short a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(short a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(short a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(short a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(short a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(short? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(short? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(short? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(short? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(short? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region int
        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(int a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(int a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(int a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(int a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(int a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(int? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(int? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(int? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(int? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(int? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region long
        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(long a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(long a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(long a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(long a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(long a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(long? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(long? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(long? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(long? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(long? a, NullableSingleCastFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region string


        
        #endregion

        #endregion

        #region mediator
        #region bool

        #endregion

        #region byte
        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, ByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, ByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, ByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, ByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, ByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableSingleCastFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableSingleCastFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableSingleCastFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableSingleCastFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableSingleCastFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableSingleCastFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableSingleCastFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableSingleCastFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableSingleCastFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableSingleCastFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableSingleCastFunctionExpression a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableSingleCastFunctionExpression a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableSingleCastFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableSingleCastFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableSingleCastFunctionExpression a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableSingleCastFunctionExpression a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableSingleCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableSingleCastFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableSingleCastFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableSingleCastFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableSingleCastFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableSingleCastFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableSingleCastFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableSingleCastFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableSingleCastFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableSingleCastFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableSingleCastFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableSingleCastFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region Guid

        #endregion

        #region short
        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, Int16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, Int16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, Int16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, Int16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, Int16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, Int32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, Int32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, Int32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, Int32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, Int32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, Int64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, Int64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, Int64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, Int64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, Int64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleCastFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleCastFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleCastFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleCastFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleCastFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string

        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region float
        public static FilterExpression<bool?> operator ==(NullableSingleCastFunctionExpression a, float b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableSingleCastFunctionExpression a, float b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableSingleCastFunctionExpression a, float b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableSingleCastFunctionExpression a, float b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableSingleCastFunctionExpression a, float b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableSingleCastFunctionExpression a, float b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(float a, NullableSingleCastFunctionExpression b) => new FilterExpression<bool?>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(float a, NullableSingleCastFunctionExpression b) => new FilterExpression<bool?>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(float a, NullableSingleCastFunctionExpression b) => new FilterExpression<bool?>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(float a, NullableSingleCastFunctionExpression b) => new FilterExpression<bool?>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(float a, NullableSingleCastFunctionExpression b) => new FilterExpression<bool?>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(float a, NullableSingleCastFunctionExpression b) => new FilterExpression<bool?>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableSingleCastFunctionExpression a, float? b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableSingleCastFunctionExpression a, float? b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableSingleCastFunctionExpression a, float? b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableSingleCastFunctionExpression a, float? b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableSingleCastFunctionExpression a, float? b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableSingleCastFunctionExpression a, float? b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(float? a, NullableSingleCastFunctionExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(float? a, NullableSingleCastFunctionExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(float? a, NullableSingleCastFunctionExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(float? a, NullableSingleCastFunctionExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(float? a, NullableSingleCastFunctionExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(float? a, NullableSingleCastFunctionExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool?> operator ==(NullableSingleCastFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableSingleCastFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableSingleCastFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableSingleCastFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableSingleCastFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableSingleCastFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableSingleCastFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableSingleCastFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableSingleCastFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableSingleCastFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableSingleCastFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableSingleCastFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
