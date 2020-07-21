
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int32FloorFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<int>(Int32FloorFunctionExpression a) => new SelectExpression<int>(new Int32ExpressionMediator(a));
        public static implicit operator Int32ExpressionMediator(Int32FloorFunctionExpression a) => new Int32ExpressionMediator(a);
        public static implicit operator OrderByExpression(Int32FloorFunctionExpression a) => new OrderByExpression(new Int32ExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(Int32FloorFunctionExpression a) => new GroupByExpression(new Int32ExpressionMediator(a));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new Int32ExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new Int32ExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static ByteExpressionMediator operator +(Int32FloorFunctionExpression a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static ByteExpressionMediator operator -(Int32FloorFunctionExpression a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static ByteExpressionMediator operator *(Int32FloorFunctionExpression a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static ByteExpressionMediator operator /(Int32FloorFunctionExpression a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static ByteExpressionMediator operator %(Int32FloorFunctionExpression a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static ByteExpressionMediator operator +(byte a, Int32FloorFunctionExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static ByteExpressionMediator operator -(byte a, Int32FloorFunctionExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static ByteExpressionMediator operator *(byte a, Int32FloorFunctionExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static ByteExpressionMediator operator /(byte a, Int32FloorFunctionExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static ByteExpressionMediator operator %(byte a, Int32FloorFunctionExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(Int32FloorFunctionExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(Int32FloorFunctionExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(Int32FloorFunctionExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(Int32FloorFunctionExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(Int32FloorFunctionExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(byte? a, Int32FloorFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(byte? a, Int32FloorFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(byte? a, Int32FloorFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(byte? a, Int32FloorFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(byte? a, Int32FloorFunctionExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(Int32FloorFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int32FloorFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int32FloorFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int32FloorFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int32FloorFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal a, Int32FloorFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal a, Int32FloorFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal a, Int32FloorFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal a, Int32FloorFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal a, Int32FloorFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(Int32FloorFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(Int32FloorFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(Int32FloorFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(Int32FloorFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(Int32FloorFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, Int32FloorFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, Int32FloorFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, Int32FloorFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, Int32FloorFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, Int32FloorFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(Int32FloorFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int32FloorFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int32FloorFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int32FloorFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int32FloorFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double a, Int32FloorFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double a, Int32FloorFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double a, Int32FloorFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double a, Int32FloorFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double a, Int32FloorFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(Int32FloorFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(Int32FloorFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(Int32FloorFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(Int32FloorFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(Int32FloorFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, Int32FloorFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, Int32FloorFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, Int32FloorFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, Int32FloorFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, Int32FloorFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static SingleExpressionMediator operator +(Int32FloorFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int32FloorFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int32FloorFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int32FloorFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int32FloorFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float a, Int32FloorFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float a, Int32FloorFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float a, Int32FloorFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float a, Int32FloorFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float a, Int32FloorFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(Int32FloorFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(Int32FloorFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(Int32FloorFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(Int32FloorFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(Int32FloorFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, Int32FloorFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, Int32FloorFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, Int32FloorFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, Int32FloorFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, Int32FloorFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static Int16ExpressionMediator operator +(Int32FloorFunctionExpression a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static Int16ExpressionMediator operator -(Int32FloorFunctionExpression a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int16ExpressionMediator operator *(Int32FloorFunctionExpression a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int16ExpressionMediator operator /(Int32FloorFunctionExpression a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static Int16ExpressionMediator operator %(Int32FloorFunctionExpression a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int16ExpressionMediator operator +(short a, Int32FloorFunctionExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int16ExpressionMediator operator -(short a, Int32FloorFunctionExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int16ExpressionMediator operator *(short a, Int32FloorFunctionExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int16ExpressionMediator operator /(short a, Int32FloorFunctionExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int16ExpressionMediator operator %(short a, Int32FloorFunctionExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(Int32FloorFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(Int32FloorFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(Int32FloorFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(Int32FloorFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(Int32FloorFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(short? a, Int32FloorFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(short? a, Int32FloorFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(short? a, Int32FloorFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(short? a, Int32FloorFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(short? a, Int32FloorFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static Int32ExpressionMediator operator +(Int32FloorFunctionExpression a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FloorFunctionExpression a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FloorFunctionExpression a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FloorFunctionExpression a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FloorFunctionExpression a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int32ExpressionMediator operator +(int a, Int32FloorFunctionExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(int a, Int32FloorFunctionExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(int a, Int32FloorFunctionExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(int a, Int32FloorFunctionExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(int a, Int32FloorFunctionExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32FloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32FloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32FloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32FloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32FloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int? a, Int32FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int? a, Int32FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int? a, Int32FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int? a, Int32FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int? a, Int32FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static Int64ExpressionMediator operator +(Int32FloorFunctionExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int32FloorFunctionExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int32FloorFunctionExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int32FloorFunctionExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int32FloorFunctionExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(long a, Int32FloorFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(long a, Int32FloorFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(long a, Int32FloorFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(long a, Int32FloorFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(long a, Int32FloorFunctionExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int32FloorFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int32FloorFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int32FloorFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int32FloorFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int32FloorFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, Int32FloorFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, Int32FloorFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, Int32FloorFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, Int32FloorFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, Int32FloorFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #endregion

        #region mediator
        #region byte
        public static ByteExpressionMediator operator +(Int32FloorFunctionExpression a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static ByteExpressionMediator operator -(Int32FloorFunctionExpression a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static ByteExpressionMediator operator *(Int32FloorFunctionExpression a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static ByteExpressionMediator operator /(Int32FloorFunctionExpression a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static ByteExpressionMediator operator %(Int32FloorFunctionExpression a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(Int32FloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(Int32FloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(Int32FloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(Int32FloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(Int32FloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableByteExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(Int32FloorFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int32FloorFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int32FloorFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int32FloorFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int32FloorFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(Int32FloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(Int32FloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(Int32FloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(Int32FloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(Int32FloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(Int32FloorFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int32FloorFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int32FloorFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int32FloorFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int32FloorFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(Int32FloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(Int32FloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(Int32FloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(Int32FloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(Int32FloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static SingleExpressionMediator operator +(Int32FloorFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int32FloorFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int32FloorFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int32FloorFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int32FloorFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(Int32FloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(Int32FloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(Int32FloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(Int32FloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(Int32FloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static Int16ExpressionMediator operator +(Int32FloorFunctionExpression a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static Int16ExpressionMediator operator -(Int32FloorFunctionExpression a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int16ExpressionMediator operator *(Int32FloorFunctionExpression a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int16ExpressionMediator operator /(Int32FloorFunctionExpression a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static Int16ExpressionMediator operator %(Int32FloorFunctionExpression a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(Int32FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(Int32FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(Int32FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(Int32FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(Int32FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static Int32ExpressionMediator operator +(Int32FloorFunctionExpression a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(Int32FloorFunctionExpression a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(Int32FloorFunctionExpression a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(Int32FloorFunctionExpression a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(Int32FloorFunctionExpression a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(Int32FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(Int32FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(Int32FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(Int32FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(Int32FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static Int64ExpressionMediator operator +(Int32FloorFunctionExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int32FloorFunctionExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int32FloorFunctionExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int32FloorFunctionExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int32FloorFunctionExpression a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int32FloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int32FloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int32FloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int32FloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int32FloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region int
        public static FilterExpression<bool> operator ==(Int32FloorFunctionExpression a, int b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Int32FloorFunctionExpression a, int b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(Int32FloorFunctionExpression a, int b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(Int32FloorFunctionExpression a, int b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(Int32FloorFunctionExpression a, int b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(Int32FloorFunctionExpression a, int b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(int a, Int32FloorFunctionExpression b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int32ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(int a, Int32FloorFunctionExpression b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int32ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(int a, Int32FloorFunctionExpression b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int32ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(int a, Int32FloorFunctionExpression b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int32ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(int a, Int32FloorFunctionExpression b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int32ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(int a, Int32FloorFunctionExpression b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int32ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(Int32FloorFunctionExpression a, int? b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Int32FloorFunctionExpression a, int? b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(Int32FloorFunctionExpression a, int? b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(Int32FloorFunctionExpression a, int? b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(Int32FloorFunctionExpression a, int? b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(Int32FloorFunctionExpression a, int? b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(int? a, Int32FloorFunctionExpression b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int?>(a)), new Int32ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(int? a, Int32FloorFunctionExpression b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int?>(a)), new Int32ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(int? a, Int32FloorFunctionExpression b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int?>(a)), new Int32ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(int? a, Int32FloorFunctionExpression b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int?>(a)), new Int32ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(int? a, Int32FloorFunctionExpression b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int?>(a)), new Int32ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(int? a, Int32FloorFunctionExpression b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int?>(a)), new Int32ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool> operator ==(Int32FloorFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Int32FloorFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(Int32FloorFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(Int32FloorFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(Int32FloorFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(Int32FloorFunctionExpression a, Int32ExpressionMediator b) => new FilterExpression<bool>(new Int32ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(Int32FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new Int32ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(Int32FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new Int32ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(Int32FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new Int32ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(Int32FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new Int32ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(Int32FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new Int32ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(Int32FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new Int32ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
