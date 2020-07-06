
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringMaximumFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<string>(StringMaximumFunctionExpression a) => new SelectExpression<string>(new StringExpressionMediator(a));
        public static implicit operator StringExpressionMediator(StringMaximumFunctionExpression a) => new StringExpressionMediator(a);
        public static implicit operator OrderByExpression(StringMaximumFunctionExpression a) => new OrderByExpression(new StringExpressionMediator(a), OrderExpressionDirection.ASC);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new StringExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new StringExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, byte b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, byte b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, byte b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, byte b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, byte b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(byte a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(byte a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(byte a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(byte a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(byte a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(byte? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(byte? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(byte? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(byte? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(byte? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(decimal a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(decimal a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(decimal a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(decimal a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(decimal a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(decimal? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(decimal? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(decimal? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(decimal? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(decimal? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, double b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, double b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, double b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, double b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, double b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(double a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(double a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(double a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(double a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(double a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, double? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, double? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, double? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, double? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, double? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(double? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(double? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(double? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(double? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(double? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, float b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, float b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, float b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, float b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, float b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(float a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(float a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(float a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(float a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(float a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, float? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, float? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, float? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, float? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, float? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(float? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(float? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(float? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(float? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(float? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, short b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, short b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, short b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, short b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, short b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(short a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(short a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(short a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(short a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(short a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, short? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, short? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, short? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, short? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, short? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(short? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(short? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(short? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(short? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(short? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, int b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, int b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, int b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, int b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, int b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(int a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(int a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(int a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(int a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(int a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, int? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, int? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, int? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, int? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, int? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(int? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(int? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(int? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(int? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(int? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, long b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, long b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, long b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, long b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, long b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(long a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(long a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(long a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(long a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(long a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, long? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, long? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, long? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, long? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, long? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(long? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(long? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(long? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(long? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(long? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #endregion

        #region mediator
        #region byte
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, ByteExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, ByteExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, ByteExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, ByteExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, ByteExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        #endregion

        #region decimal
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, DecimalExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, DecimalExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, DecimalExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, DecimalExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, DecimalExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        #endregion

        #region double
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, DoubleExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, DoubleExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, DoubleExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, DoubleExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, DoubleExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        #endregion

        #region float
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, SingleExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, SingleExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, SingleExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, SingleExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, SingleExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        #endregion

        #region short
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, Int16ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, Int16ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, Int16ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, Int16ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, Int16ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        #endregion

        #region int
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, Int32ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, Int32ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, Int32ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, Int32ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, Int32ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        #endregion

        #region long
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, Int64ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, Int64ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, Int64ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, Int64ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, Int64ExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region string
        public static FilterExpression<bool> operator ==(StringMaximumFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(StringMaximumFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(StringMaximumFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(StringMaximumFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(StringMaximumFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(StringMaximumFunctionExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(string a, StringMaximumFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(string a, StringMaximumFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(string a, StringMaximumFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(string a, StringMaximumFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(string a, StringMaximumFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(string a, StringMaximumFunctionExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
