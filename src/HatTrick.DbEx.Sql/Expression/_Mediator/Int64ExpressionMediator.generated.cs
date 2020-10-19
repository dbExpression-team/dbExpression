using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64ExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<long>(Int64ExpressionMediator a) => new SelectExpression<long>(a);
        public static implicit operator OrderByExpression(Int64ExpressionMediator a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(Int64ExpressionMediator a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators
        #region data type
        #region byte
        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(byte a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(byte a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(byte a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(byte a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(byte a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, byte? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, byte? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, byte? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, byte? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, byte? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(byte? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(byte? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(byte? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(byte? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(byte? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(Int64ExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int64ExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int64ExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int64ExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int64ExpressionMediator a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal a, Int64ExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal a, Int64ExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal a, Int64ExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal a, Int64ExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal a, Int64ExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(Int64ExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int64ExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int64ExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int64ExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int64ExpressionMediator a, decimal? b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal? a, Int64ExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal? a, Int64ExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal? a, Int64ExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal? a, Int64ExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal? a, Int64ExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(Int64ExpressionMediator a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(Int64ExpressionMediator a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(DateTime a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(Int64ExpressionMediator a, DateTime? b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(Int64ExpressionMediator a, DateTime? b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(DateTime? a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime? a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(Int64ExpressionMediator a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(Int64ExpressionMediator a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), b, ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(Int64ExpressionMediator a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(Int64ExpressionMediator a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DoubleExpressionMediator operator +(Int64ExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int64ExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int64ExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int64ExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int64ExpressionMediator a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(Int64ExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int64ExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int64ExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int64ExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int64ExpressionMediator a, double? b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double? a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double? a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double? a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double? a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double? a, Int64ExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static SingleExpressionMediator operator +(Int64ExpressionMediator a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int64ExpressionMediator a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int64ExpressionMediator a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int64ExpressionMediator a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int64ExpressionMediator a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(Int64ExpressionMediator a, float? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int64ExpressionMediator a, float? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int64ExpressionMediator a, float? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int64ExpressionMediator a, float? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int64ExpressionMediator a, float? b) => new SingleExpressionMediator(new ArithmeticExpression(a, new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float? a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float? a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float? a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float? a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float? a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(short a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(short a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(short a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(short a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(short a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, short? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, short? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, short? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, short? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, short? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(short? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(short? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(short? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(short? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(short? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(int a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(int a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(int a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(int a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(int a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, int? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, int? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, int? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, int? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, int? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(int? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(int? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(int? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(int? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(int? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(long a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(long a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(long a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(long a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(long a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, long? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, long? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, long? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, long? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, long? b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(long? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(long? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(long? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(long? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(long? a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string


        #endregion
        
        #region TimeSpan



        #endregion
        
        #endregion

        #region fields
        #region byte
        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, ByteFieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, ByteFieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, ByteFieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, ByteFieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, ByteFieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new ByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(Int64ExpressionMediator a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int64ExpressionMediator a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int64ExpressionMediator a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int64ExpressionMediator a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int64ExpressionMediator a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(Int64ExpressionMediator a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(Int64ExpressionMediator a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(Int64ExpressionMediator a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(Int64ExpressionMediator a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(Int64ExpressionMediator a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int64ExpressionMediator a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int64ExpressionMediator a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int64ExpressionMediator a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int64ExpressionMediator a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static SingleExpressionMediator operator +(Int64ExpressionMediator a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int64ExpressionMediator a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int64ExpressionMediator a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int64ExpressionMediator a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int64ExpressionMediator a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, Int16FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, Int16FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, Int16FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, Int16FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, Int16FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, Int32FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, Int32FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, Int32FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, Int32FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, Int32FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(a, new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region TimeSpan
        #endregion

        #endregion

        #region mediators
        #region byte
        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, ByteExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, ByteExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, ByteExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, ByteExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, ByteExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64ExpressionMediator a, NullableByteExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(Int64ExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int64ExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int64ExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int64ExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int64ExpressionMediator a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(Int64ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(Int64ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(Int64ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(Int64ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(Int64ExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(Int64ExpressionMediator a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(Int64ExpressionMediator a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(Int64ExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(Int64ExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(Int64ExpressionMediator a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(Int64ExpressionMediator a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(Int64ExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(Int64ExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DoubleExpressionMediator operator +(Int64ExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int64ExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int64ExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int64ExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int64ExpressionMediator a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(Int64ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(Int64ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(Int64ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(Int64ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(Int64ExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static SingleExpressionMediator operator +(Int64ExpressionMediator a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int64ExpressionMediator a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int64ExpressionMediator a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int64ExpressionMediator a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int64ExpressionMediator a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(Int64ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(Int64ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(Int64ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(Int64ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(Int64ExpressionMediator a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, Int16ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, Int16ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, Int16ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, Int16ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, Int16ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64ExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, Int32ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, Int32ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, Int32ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, Int32ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, Int32ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64ExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static Int64ExpressionMediator operator +(Int64ExpressionMediator a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64ExpressionMediator a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64ExpressionMediator a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64ExpressionMediator a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64ExpressionMediator a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64ExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region long
        public static FilterExpression<bool> operator ==(Int64ExpressionMediator a, long b) => new FilterExpression<bool>(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Int64ExpressionMediator a, long b) => new FilterExpression<bool>(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(Int64ExpressionMediator a, long b) => new FilterExpression<bool>(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(Int64ExpressionMediator a, long b) => new FilterExpression<bool>(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(Int64ExpressionMediator a, long b) => new FilterExpression<bool>(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(Int64ExpressionMediator a, long b) => new FilterExpression<bool>(a, new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(long a, Int64ExpressionMediator b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(long a, Int64ExpressionMediator b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(long a, Int64ExpressionMediator b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(long a, Int64ExpressionMediator b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(long a, Int64ExpressionMediator b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(long a, Int64ExpressionMediator b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region fields
        public static FilterExpression<bool> operator ==(Int64ExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool>(a, new Int64ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Int64ExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool>(a, new Int64ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(Int64ExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool>(a, new Int64ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(Int64ExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool>(a, new Int64ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(Int64ExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool>(a, new Int64ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(Int64ExpressionMediator a, Int64FieldExpression b) => new FilterExpression<bool>(a, new Int64ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(Int64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, new NullableInt64ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(Int64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, new NullableInt64ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(Int64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, new NullableInt64ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(Int64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, new NullableInt64ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(Int64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, new NullableInt64ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(Int64ExpressionMediator a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(a, new NullableInt64ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region mediators
        public static FilterExpression<bool> operator ==(Int64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Int64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(Int64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(Int64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(Int64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(Int64ExpressionMediator a, Int64ExpressionMediator b) => new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(Int64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(Int64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(Int64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(Int64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(Int64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(Int64ExpressionMediator a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
