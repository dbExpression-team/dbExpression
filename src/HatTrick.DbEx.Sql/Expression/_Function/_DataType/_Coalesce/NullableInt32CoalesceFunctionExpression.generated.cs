using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt32CoalesceFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<int?>(NullableInt32CoalesceFunctionExpression a) => new SelectExpression<int?>(new NullableInt32ExpressionMediator(a));
        public static implicit operator NullableInt32ExpressionMediator(NullableInt32CoalesceFunctionExpression a) => new NullableInt32ExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableInt32CoalesceFunctionExpression a) => new OrderByExpression(new Int32ExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableInt32CoalesceFunctionExpression a) => new GroupByExpression(new Int32ExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new Int32ExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new Int32ExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region bool



        
        #endregion

        #region byte
        public static NullableInt32ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(byte a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(byte a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(byte a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(byte a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(byte a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(byte? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(byte? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(byte? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(byte? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(byte? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal a, NullableInt32CoalesceFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableInt32CoalesceFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableInt32CoalesceFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableInt32CoalesceFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableInt32CoalesceFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableInt32CoalesceFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableInt32CoalesceFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableInt32CoalesceFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableInt32CoalesceFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableInt32CoalesceFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableInt32CoalesceFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableInt32CoalesceFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableInt32CoalesceFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableInt32CoalesceFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableInt32CoalesceFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableInt32CoalesceFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableInt32CoalesceFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableInt32CoalesceFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double a, NullableInt32CoalesceFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double a, NullableInt32CoalesceFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double a, NullableInt32CoalesceFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double a, NullableInt32CoalesceFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double a, NullableInt32CoalesceFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, NullableInt32CoalesceFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, NullableInt32CoalesceFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, NullableInt32CoalesceFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, NullableInt32CoalesceFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, NullableInt32CoalesceFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float a, NullableInt32CoalesceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float a, NullableInt32CoalesceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float a, NullableInt32CoalesceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float a, NullableInt32CoalesceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float a, NullableInt32CoalesceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, NullableInt32CoalesceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, NullableInt32CoalesceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, NullableInt32CoalesceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, NullableInt32CoalesceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, NullableInt32CoalesceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region Guid



        
        #endregion

        #region short
        public static NullableInt32ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(short a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(short a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(short a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(short a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(short a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(short? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(short? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(short? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(short? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(short? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long a, NullableInt32CoalesceFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long a, NullableInt32CoalesceFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long a, NullableInt32CoalesceFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long a, NullableInt32CoalesceFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long a, NullableInt32CoalesceFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, NullableInt32CoalesceFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        
        #endregion

        #region string


        
        #endregion

        #endregion

        #region mediator
        #region bool

        #endregion

        #region byte
        public static NullableInt32ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region Guid

        #endregion

        #region short
        public static NullableInt32ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt32CoalesceFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt32CoalesceFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt32CoalesceFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt32CoalesceFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt32CoalesceFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string

        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region int
        public static FilterExpression<bool?> operator ==(NullableInt32CoalesceFunctionExpression a, int b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableInt32CoalesceFunctionExpression a, int b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableInt32CoalesceFunctionExpression a, int b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableInt32CoalesceFunctionExpression a, int b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableInt32CoalesceFunctionExpression a, int b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableInt32CoalesceFunctionExpression a, int b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(int a, NullableInt32CoalesceFunctionExpression b) => new FilterExpression<bool?>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(int a, NullableInt32CoalesceFunctionExpression b) => new FilterExpression<bool?>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(int a, NullableInt32CoalesceFunctionExpression b) => new FilterExpression<bool?>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(int a, NullableInt32CoalesceFunctionExpression b) => new FilterExpression<bool?>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(int a, NullableInt32CoalesceFunctionExpression b) => new FilterExpression<bool?>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(int a, NullableInt32CoalesceFunctionExpression b) => new FilterExpression<bool?>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableInt32CoalesceFunctionExpression a, int? b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableInt32CoalesceFunctionExpression a, int? b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableInt32CoalesceFunctionExpression a, int? b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableInt32CoalesceFunctionExpression a, int? b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableInt32CoalesceFunctionExpression a, int? b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableInt32CoalesceFunctionExpression a, int? b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(int? a, NullableInt32CoalesceFunctionExpression b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(int? a, NullableInt32CoalesceFunctionExpression b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(int? a, NullableInt32CoalesceFunctionExpression b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(int? a, NullableInt32CoalesceFunctionExpression b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(int? a, NullableInt32CoalesceFunctionExpression b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(int? a, NullableInt32CoalesceFunctionExpression b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool?> operator ==(NullableInt32CoalesceFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableInt32CoalesceFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableInt32CoalesceFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableInt32CoalesceFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableInt32CoalesceFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableInt32CoalesceFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableInt32CoalesceFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableInt32CoalesceFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableInt32CoalesceFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableInt32CoalesceFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableInt32CoalesceFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableInt32CoalesceFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
