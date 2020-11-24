using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64IsNullFunctionExpression
    {
        #region implicit operators
        public static implicit operator Int64ExpressionMediator(Int64IsNullFunctionExpression a) => new Int64ExpressionMediator(a);
        public static implicit operator OrderByExpression(Int64IsNullFunctionExpression a) => new OrderByExpression(new Int64ExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(Int64IsNullFunctionExpression a) => new GroupByExpression(new Int64ExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new Int64ExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new Int64ExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region bool



        #endregion
        
        #region byte
        public static Int64ExpressionMediator operator +(Int64IsNullFunctionExpression a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64IsNullFunctionExpression a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64IsNullFunctionExpression a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64IsNullFunctionExpression a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64IsNullFunctionExpression a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(byte a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(byte a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(byte a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(byte a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(byte a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64IsNullFunctionExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64IsNullFunctionExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64IsNullFunctionExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64IsNullFunctionExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64IsNullFunctionExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(byte? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(byte? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(byte? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(byte? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(byte? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(Int64IsNullFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int64IsNullFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int64IsNullFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int64IsNullFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int64IsNullFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal a, Int64IsNullFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal a, Int64IsNullFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal a, Int64IsNullFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal a, Int64IsNullFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal a, Int64IsNullFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(Int64IsNullFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(Int64IsNullFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(Int64IsNullFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(Int64IsNullFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(Int64IsNullFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, Int64IsNullFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, Int64IsNullFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, Int64IsNullFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, Int64IsNullFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, Int64IsNullFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(Int64IsNullFunctionExpression a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(Int64IsNullFunctionExpression a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(DateTime a, Int64IsNullFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime a, Int64IsNullFunctionExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(Int64IsNullFunctionExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(Int64IsNullFunctionExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, Int64IsNullFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, Int64IsNullFunctionExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(Int64IsNullFunctionExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(Int64IsNullFunctionExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, Int64IsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, Int64IsNullFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(Int64IsNullFunctionExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(Int64IsNullFunctionExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, Int64IsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, Int64IsNullFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DoubleExpressionMediator operator +(Int64IsNullFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int64IsNullFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int64IsNullFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int64IsNullFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int64IsNullFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double a, Int64IsNullFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double a, Int64IsNullFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double a, Int64IsNullFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double a, Int64IsNullFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double a, Int64IsNullFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(Int64IsNullFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(Int64IsNullFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(Int64IsNullFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(Int64IsNullFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(Int64IsNullFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, Int64IsNullFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, Int64IsNullFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, Int64IsNullFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, Int64IsNullFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, Int64IsNullFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static SingleExpressionMediator operator +(Int64IsNullFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int64IsNullFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int64IsNullFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int64IsNullFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int64IsNullFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float a, Int64IsNullFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float a, Int64IsNullFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float a, Int64IsNullFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float a, Int64IsNullFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float a, Int64IsNullFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(Int64IsNullFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(Int64IsNullFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(Int64IsNullFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(Int64IsNullFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(Int64IsNullFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, Int64IsNullFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, Int64IsNullFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, Int64IsNullFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, Int64IsNullFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, Int64IsNullFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region Guid



        #endregion
        
        #region short
        public static Int64ExpressionMediator operator +(Int64IsNullFunctionExpression a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64IsNullFunctionExpression a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64IsNullFunctionExpression a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64IsNullFunctionExpression a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64IsNullFunctionExpression a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(short a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(short a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(short a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(short a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(short a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64IsNullFunctionExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64IsNullFunctionExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64IsNullFunctionExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64IsNullFunctionExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64IsNullFunctionExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(short? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(short? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(short? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(short? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(short? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static Int64ExpressionMediator operator +(Int64IsNullFunctionExpression a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64IsNullFunctionExpression a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64IsNullFunctionExpression a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64IsNullFunctionExpression a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64IsNullFunctionExpression a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(int a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(int a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(int a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(int a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(int a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64IsNullFunctionExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64IsNullFunctionExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64IsNullFunctionExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64IsNullFunctionExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64IsNullFunctionExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(int? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(int? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(int? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(int? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(int? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static Int64ExpressionMediator operator +(Int64IsNullFunctionExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64IsNullFunctionExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64IsNullFunctionExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64IsNullFunctionExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64IsNullFunctionExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(long a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(long a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(long a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(long a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(long a, Int64IsNullFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64IsNullFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64IsNullFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64IsNullFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64IsNullFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64IsNullFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, Int64IsNullFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
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
        public static Int64ExpressionMediator operator +(Int64IsNullFunctionExpression a, ByteExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64IsNullFunctionExpression a, ByteExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64IsNullFunctionExpression a, ByteExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64IsNullFunctionExpression a, ByteExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64IsNullFunctionExpression a, ByteExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64IsNullFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64IsNullFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64IsNullFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64IsNullFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64IsNullFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(Int64IsNullFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int64IsNullFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int64IsNullFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int64IsNullFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int64IsNullFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(Int64IsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(Int64IsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(Int64IsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(Int64IsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(Int64IsNullFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(Int64IsNullFunctionExpression a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(Int64IsNullFunctionExpression a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(Int64IsNullFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(Int64IsNullFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(Int64IsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(Int64IsNullFunctionExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(Int64IsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(Int64IsNullFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DoubleExpressionMediator operator +(Int64IsNullFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int64IsNullFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int64IsNullFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int64IsNullFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int64IsNullFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(Int64IsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(Int64IsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(Int64IsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(Int64IsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(Int64IsNullFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static SingleExpressionMediator operator +(Int64IsNullFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int64IsNullFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int64IsNullFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int64IsNullFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int64IsNullFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(Int64IsNullFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(Int64IsNullFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(Int64IsNullFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(Int64IsNullFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(Int64IsNullFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region Guid

        #endregion
        
        #region short
        public static Int64ExpressionMediator operator +(Int64IsNullFunctionExpression a, Int16ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64IsNullFunctionExpression a, Int16ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64IsNullFunctionExpression a, Int16ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64IsNullFunctionExpression a, Int16ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64IsNullFunctionExpression a, Int16ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64IsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64IsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64IsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64IsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64IsNullFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static Int64ExpressionMediator operator +(Int64IsNullFunctionExpression a, Int32ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64IsNullFunctionExpression a, Int32ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64IsNullFunctionExpression a, Int32ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64IsNullFunctionExpression a, Int32ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64IsNullFunctionExpression a, Int32ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64IsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64IsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64IsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64IsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64IsNullFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static Int64ExpressionMediator operator +(Int64IsNullFunctionExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64IsNullFunctionExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64IsNullFunctionExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64IsNullFunctionExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64IsNullFunctionExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64IsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64IsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64IsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64IsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64IsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region long
        public static FilterExpressionSet operator ==(Int64IsNullFunctionExpression a, long b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Int64IsNullFunctionExpression a, long b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Int64IsNullFunctionExpression a, long b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(Int64IsNullFunctionExpression a, long b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(Int64IsNullFunctionExpression a, long b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(Int64IsNullFunctionExpression a, long b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(long a, Int64IsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(long a, Int64IsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(long a, Int64IsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(long a, Int64IsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(long a, Int64IsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(long a, Int64IsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(Int64IsNullFunctionExpression a, long? b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Int64IsNullFunctionExpression a, long? b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Int64IsNullFunctionExpression a, long? b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(Int64IsNullFunctionExpression a, long? b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(Int64IsNullFunctionExpression a, long? b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(Int64IsNullFunctionExpression a, long? b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(long? a, Int64IsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(long? a, Int64IsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(long? a, Int64IsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(long? a, Int64IsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(long? a, Int64IsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(long? a, Int64IsNullFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region mediator
        public static FilterExpressionSet operator ==(Int64IsNullFunctionExpression a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Int64IsNullFunctionExpression a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Int64IsNullFunctionExpression a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(Int64IsNullFunctionExpression a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(Int64IsNullFunctionExpression a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(Int64IsNullFunctionExpression a, Int64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(Int64IsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(Int64IsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(Int64IsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator <=(Int64IsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >(Int64IsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator >=(Int64IsNullFunctionExpression a, NullableInt64ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
