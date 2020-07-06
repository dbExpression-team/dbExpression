
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleSumFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<float>(SingleSumFunctionExpression a) => new SelectExpression<float>(new SingleExpressionMediator(a));
        public static implicit operator SingleExpressionMediator(SingleSumFunctionExpression a) => new SingleExpressionMediator(a);
        public static implicit operator OrderByExpression(SingleSumFunctionExpression a) => new OrderByExpression(new SingleExpressionMediator(a), OrderExpressionDirection.ASC);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new SingleExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new SingleExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static SingleExpressionMediator operator +(SingleSumFunctionExpression a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleSumFunctionExpression a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleSumFunctionExpression a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleSumFunctionExpression a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleSumFunctionExpression a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(byte a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(byte a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(byte a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(byte a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(byte a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleSumFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleSumFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleSumFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleSumFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleSumFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(byte? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(byte? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(byte? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(byte? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(byte? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(SingleSumFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(SingleSumFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(SingleSumFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(SingleSumFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(SingleSumFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal a, SingleSumFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal a, SingleSumFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal a, SingleSumFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal a, SingleSumFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal a, SingleSumFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(SingleSumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(SingleSumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(SingleSumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(SingleSumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(SingleSumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, SingleSumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, SingleSumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, SingleSumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, SingleSumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, SingleSumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(SingleSumFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(SingleSumFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(SingleSumFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(SingleSumFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(SingleSumFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double a, SingleSumFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double a, SingleSumFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double a, SingleSumFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double a, SingleSumFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double a, SingleSumFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(SingleSumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(SingleSumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(SingleSumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(SingleSumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(SingleSumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, SingleSumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, SingleSumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, SingleSumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, SingleSumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, SingleSumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static SingleExpressionMediator operator +(SingleSumFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleSumFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleSumFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleSumFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleSumFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleSumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleSumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleSumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleSumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleSumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static SingleExpressionMediator operator +(SingleSumFunctionExpression a, short b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleSumFunctionExpression a, short b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleSumFunctionExpression a, short b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleSumFunctionExpression a, short b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleSumFunctionExpression a, short b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(short a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(short a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(short a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(short a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(short a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleSumFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleSumFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleSumFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleSumFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleSumFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(short? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(short? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(short? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(short? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(short? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static SingleExpressionMediator operator +(SingleSumFunctionExpression a, int b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleSumFunctionExpression a, int b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleSumFunctionExpression a, int b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleSumFunctionExpression a, int b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleSumFunctionExpression a, int b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(int a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(int a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(int a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(int a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(int a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleSumFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleSumFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleSumFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleSumFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleSumFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(int? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(int? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(int? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(int? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(int? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static SingleExpressionMediator operator +(SingleSumFunctionExpression a, long b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleSumFunctionExpression a, long b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleSumFunctionExpression a, long b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleSumFunctionExpression a, long b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleSumFunctionExpression a, long b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(long a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(long a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(long a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(long a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(long a, SingleSumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleSumFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleSumFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleSumFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleSumFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleSumFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(long? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(long? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(long? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(long? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(long? a, SingleSumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #endregion

        #region mediator
        #region byte
        public static SingleExpressionMediator operator +(SingleSumFunctionExpression a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleSumFunctionExpression a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleSumFunctionExpression a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleSumFunctionExpression a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleSumFunctionExpression a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleSumFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleSumFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleSumFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleSumFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleSumFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(SingleSumFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(SingleSumFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(SingleSumFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(SingleSumFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(SingleSumFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(SingleSumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(SingleSumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(SingleSumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(SingleSumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(SingleSumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(SingleSumFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(SingleSumFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(SingleSumFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(SingleSumFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(SingleSumFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(SingleSumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(SingleSumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(SingleSumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(SingleSumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(SingleSumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static SingleExpressionMediator operator +(SingleSumFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleSumFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleSumFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleSumFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleSumFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleSumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleSumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleSumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleSumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleSumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static SingleExpressionMediator operator +(SingleSumFunctionExpression a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleSumFunctionExpression a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleSumFunctionExpression a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleSumFunctionExpression a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleSumFunctionExpression a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleSumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleSumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleSumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleSumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleSumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static SingleExpressionMediator operator +(SingleSumFunctionExpression a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleSumFunctionExpression a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleSumFunctionExpression a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleSumFunctionExpression a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleSumFunctionExpression a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleSumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleSumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleSumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleSumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleSumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static SingleExpressionMediator operator +(SingleSumFunctionExpression a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleSumFunctionExpression a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleSumFunctionExpression a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleSumFunctionExpression a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleSumFunctionExpression a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleSumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleSumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleSumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleSumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleSumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region float
        public static FilterExpression<bool> operator ==(SingleSumFunctionExpression a, float b) => new FilterExpression<bool>(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(SingleSumFunctionExpression a, float b) => new FilterExpression<bool>(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(SingleSumFunctionExpression a, float b) => new FilterExpression<bool>(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(SingleSumFunctionExpression a, float b) => new FilterExpression<bool>(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(SingleSumFunctionExpression a, float b) => new FilterExpression<bool>(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(SingleSumFunctionExpression a, float b) => new FilterExpression<bool>(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(float a, SingleSumFunctionExpression b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(float a, SingleSumFunctionExpression b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(float a, SingleSumFunctionExpression b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(float a, SingleSumFunctionExpression b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(float a, SingleSumFunctionExpression b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(float a, SingleSumFunctionExpression b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(SingleSumFunctionExpression a, float? b) => new FilterExpression<bool>(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(SingleSumFunctionExpression a, float? b) => new FilterExpression<bool>(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(SingleSumFunctionExpression a, float? b) => new FilterExpression<bool>(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(SingleSumFunctionExpression a, float? b) => new FilterExpression<bool>(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(SingleSumFunctionExpression a, float? b) => new FilterExpression<bool>(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(SingleSumFunctionExpression a, float? b) => new FilterExpression<bool>(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(float? a, SingleSumFunctionExpression b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(float? a, SingleSumFunctionExpression b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(float? a, SingleSumFunctionExpression b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(float? a, SingleSumFunctionExpression b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(float? a, SingleSumFunctionExpression b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(float? a, SingleSumFunctionExpression b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(SingleSumFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(SingleSumFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(SingleSumFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(SingleSumFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(SingleSumFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(SingleSumFunctionExpression a, SingleExpressionMediator b) => new FilterExpression<bool>(new SingleExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(SingleSumFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new SingleExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(SingleSumFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new SingleExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(SingleSumFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new SingleExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(SingleSumFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new SingleExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(SingleSumFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new SingleExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(SingleSumFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new SingleExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
