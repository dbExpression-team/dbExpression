using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt64ExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<long?>(NullableInt64ExpressionMediator a) => new SelectExpression<long?>(a);
        public static implicit operator OrderByExpression(NullableInt64ExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableInt64ExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators 
        #region data type 
        #region byte
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, byte b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, byte b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, byte b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, byte b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, byte b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(byte a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(byte a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(byte a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(byte a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(byte a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(byte? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(byte? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(byte? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(byte? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(byte? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt64ExpressionMediator a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt64ExpressionMediator a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt64ExpressionMediator a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt64ExpressionMediator a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt64ExpressionMediator a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal a, NullableInt64ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableInt64ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableInt64ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableInt64ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableInt64ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt64ExpressionMediator a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt64ExpressionMediator a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt64ExpressionMediator a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt64ExpressionMediator a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt64ExpressionMediator a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableInt64ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableInt64ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableInt64ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableInt64ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableInt64ExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt64ExpressionMediator a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt64ExpressionMediator a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt64ExpressionMediator a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt64ExpressionMediator a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt64ExpressionMediator a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt64ExpressionMediator a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt64ExpressionMediator a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt64ExpressionMediator a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt64ExpressionMediator a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt64ExpressionMediator a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, NullableInt64ExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt64ExpressionMediator a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt64ExpressionMediator a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt64ExpressionMediator a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt64ExpressionMediator a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt64ExpressionMediator a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt64ExpressionMediator a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt64ExpressionMediator a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt64ExpressionMediator a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt64ExpressionMediator a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt64ExpressionMediator a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, short b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, short b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, short b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, short b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, short b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(short a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(short a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(short a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(short a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(short a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(short? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(short? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(short? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(short? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(short? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, int b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, int b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, int b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, int b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, int b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(int a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(int a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(int a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(int a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(int a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(int? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(int? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(int? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(int? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(int? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion


        #region TimeSpan



        #endregion

        #endregion

        #region fields
        #region byte
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, ByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, ByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, ByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, ByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, ByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt64ExpressionMediator a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt64ExpressionMediator a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt64ExpressionMediator a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt64ExpressionMediator a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt64ExpressionMediator a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt64ExpressionMediator a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt64ExpressionMediator a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt64ExpressionMediator a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt64ExpressionMediator a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt64ExpressionMediator a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt64ExpressionMediator a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt64ExpressionMediator a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt64ExpressionMediator a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt64ExpressionMediator a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt64ExpressionMediator a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, Int16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, Int16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, Int16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, Int16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, Int16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, Int32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, Int32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, Int32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, Int32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, Int32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string

        #endregion

        #region TimeSpan

        #endregion

        #endregion

        #region mediator
        #region byte
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, ByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, ByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, ByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, ByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, ByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt64ExpressionMediator a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt64ExpressionMediator a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt64ExpressionMediator a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt64ExpressionMediator a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt64ExpressionMediator a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64ExpressionMediator a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64ExpressionMediator a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt64ExpressionMediator a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt64ExpressionMediator a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt64ExpressionMediator a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt64ExpressionMediator a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt64ExpressionMediator a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt64ExpressionMediator a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt64ExpressionMediator a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt64ExpressionMediator a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt64ExpressionMediator a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt64ExpressionMediator a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, Int16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, Int16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, Int16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, Int16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, Int16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, Int32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, Int32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, Int32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, Int32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, Int32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion


        #region TimeSpan

        #endregion

        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(NullableInt64ExpressionMediator a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(NullableInt64ExpressionMediator a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(NullableInt64ExpressionMediator a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(NullableInt64ExpressionMediator a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(NullableInt64ExpressionMediator a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableInt64ExpressionMediator a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64ExpressionMediator a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data type
        #region long
        public static FilterExpressionSet operator ==(NullableInt64ExpressionMediator a, long b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64ExpressionMediator a, long b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64ExpressionMediator a, long b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64ExpressionMediator a, long b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64ExpressionMediator a, long b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64ExpressionMediator a, long b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(long a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(long a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(long a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(long a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(long a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(long a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt64ExpressionMediator a, long? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64ExpressionMediator a, long? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64ExpressionMediator a, long? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64ExpressionMediator a, long? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64ExpressionMediator a, long? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64ExpressionMediator a, long? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<long?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(long? a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(long? a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(long? a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(long? a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(long? a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(long? a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<long?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64ExpressionMediator a, Int64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        
        #region mediator
        public static FilterExpressionSet operator ==(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableInt64ExpressionMediator a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt64ExpressionMediator a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt64ExpressionMediator a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt64ExpressionMediator a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt64ExpressionMediator a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt64ExpressionMediator a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
