using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class ExpressionMediator<TValue> : ExpressionMediator,
        IExpressionElement<TValue>
    {
        #region constructors
        protected ExpressionMediator()
        {
        }

        public ExpressionMediator(IExpressionElement expression) : base(expression, expression is IExpressionTypeProvider p ? p.DeclaredType : typeof(TValue))
        {
        }

        protected ExpressionMediator(IExpressionElement expression, string alias) : base(expression, expression is IExpressionTypeProvider p ? p.DeclaredType : typeof(TValue), alias)
        {
        }

        protected ExpressionMediator(IExpressionElement expression, Type declaredType, string alias) : base(expression, declaredType, alias)
        {
        }
        #endregion

        #region equals
        public bool Equals(ExpressionMediator<TValue> obj)
            => obj is ExpressionMediator<TValue> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is ExpressionMediator<TValue> exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<TValue>(ExpressionMediator<TValue> a) => new SelectExpression<TValue>(a);
        #endregion

        #region arithmetic operators
        #region alias
        public static ExpressionMediator operator +(ExpressionMediator<TValue> a, ExpressionMediator<TValue> b) => new ExpressionMediator<TValue>(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static ExpressionMediator operator -(ExpressionMediator<TValue> a, ExpressionMediator<TValue> b) => new ExpressionMediator<TValue>(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static ExpressionMediator operator *(ExpressionMediator<TValue> a, ExpressionMediator<TValue> b) => new ExpressionMediator<TValue>(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static ExpressionMediator operator /(ExpressionMediator<TValue> a, ExpressionMediator<TValue> b) => new ExpressionMediator<TValue>(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static ExpressionMediator operator %(ExpressionMediator<TValue> a, ExpressionMediator<TValue> b) => new ExpressionMediator<TValue>(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region data type
        #region byte
        public static ByteExpressionMediator operator +(ExpressionMediator<TValue> a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static ByteExpressionMediator operator -(ExpressionMediator<TValue> a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static ByteExpressionMediator operator *(ExpressionMediator<TValue> a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static ByteExpressionMediator operator /(ExpressionMediator<TValue> a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static ByteExpressionMediator operator %(ExpressionMediator<TValue> a, byte b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static ByteExpressionMediator operator +(byte a, ExpressionMediator<TValue> b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static ByteExpressionMediator operator -(byte a, ExpressionMediator<TValue> b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static ByteExpressionMediator operator *(byte a, ExpressionMediator<TValue> b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static ByteExpressionMediator operator /(byte a, ExpressionMediator<TValue> b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static ByteExpressionMediator operator %(byte a, ExpressionMediator<TValue> b) => new ByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(ExpressionMediator<TValue> a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(ExpressionMediator<TValue> a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(ExpressionMediator<TValue> a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(ExpressionMediator<TValue> a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(ExpressionMediator<TValue> a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(byte? a, ExpressionMediator<TValue> b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(byte? a, ExpressionMediator<TValue> b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(byte? a, ExpressionMediator<TValue> b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(byte? a, ExpressionMediator<TValue> b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(byte? a, ExpressionMediator<TValue> b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(ExpressionMediator<TValue> a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(ExpressionMediator<TValue> a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(ExpressionMediator<TValue> a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(ExpressionMediator<TValue> a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(ExpressionMediator<TValue> a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal a, ExpressionMediator<TValue> b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal a, ExpressionMediator<TValue> b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal a, ExpressionMediator<TValue> b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal a, ExpressionMediator<TValue> b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal a, ExpressionMediator<TValue> b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(ExpressionMediator<TValue> a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(ExpressionMediator<TValue> a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(ExpressionMediator<TValue> a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(ExpressionMediator<TValue> a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(ExpressionMediator<TValue> a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, ExpressionMediator<TValue> b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, ExpressionMediator<TValue> b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, ExpressionMediator<TValue> b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, ExpressionMediator<TValue> b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, ExpressionMediator<TValue> b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(ExpressionMediator<TValue> a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(ExpressionMediator<TValue> a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(ExpressionMediator<TValue> a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(ExpressionMediator<TValue> a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(ExpressionMediator<TValue> a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double a, ExpressionMediator<TValue> b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double a, ExpressionMediator<TValue> b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double a, ExpressionMediator<TValue> b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double a, ExpressionMediator<TValue> b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double a, ExpressionMediator<TValue> b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(ExpressionMediator<TValue> a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(ExpressionMediator<TValue> a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(ExpressionMediator<TValue> a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(ExpressionMediator<TValue> a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(ExpressionMediator<TValue> a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, ExpressionMediator<TValue> b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, ExpressionMediator<TValue> b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, ExpressionMediator<TValue> b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, ExpressionMediator<TValue> b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, ExpressionMediator<TValue> b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static SingleExpressionMediator operator +(ExpressionMediator<TValue> a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(ExpressionMediator<TValue> a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(ExpressionMediator<TValue> a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(ExpressionMediator<TValue> a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(ExpressionMediator<TValue> a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float a, ExpressionMediator<TValue> b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float a, ExpressionMediator<TValue> b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float a, ExpressionMediator<TValue> b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float a, ExpressionMediator<TValue> b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float a, ExpressionMediator<TValue> b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(ExpressionMediator<TValue> a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(ExpressionMediator<TValue> a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(ExpressionMediator<TValue> a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(ExpressionMediator<TValue> a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(ExpressionMediator<TValue> a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, ExpressionMediator<TValue> b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, ExpressionMediator<TValue> b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, ExpressionMediator<TValue> b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, ExpressionMediator<TValue> b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, ExpressionMediator<TValue> b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static Int16ExpressionMediator operator +(ExpressionMediator<TValue> a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static Int16ExpressionMediator operator -(ExpressionMediator<TValue> a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int16ExpressionMediator operator *(ExpressionMediator<TValue> a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int16ExpressionMediator operator /(ExpressionMediator<TValue> a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static Int16ExpressionMediator operator %(ExpressionMediator<TValue> a, short b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int16ExpressionMediator operator +(short a, ExpressionMediator<TValue> b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static Int16ExpressionMediator operator -(short a, ExpressionMediator<TValue> b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static Int16ExpressionMediator operator *(short a, ExpressionMediator<TValue> b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static Int16ExpressionMediator operator /(short a, ExpressionMediator<TValue> b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static Int16ExpressionMediator operator %(short a, ExpressionMediator<TValue> b) => new Int16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(ExpressionMediator<TValue> a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(ExpressionMediator<TValue> a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(ExpressionMediator<TValue> a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(ExpressionMediator<TValue> a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(ExpressionMediator<TValue> a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(short? a, ExpressionMediator<TValue> b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(short? a, ExpressionMediator<TValue> b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(short? a, ExpressionMediator<TValue> b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(short? a, ExpressionMediator<TValue> b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(short? a, ExpressionMediator<TValue> b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static Int32ExpressionMediator operator +(ExpressionMediator<TValue> a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(ExpressionMediator<TValue> a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(ExpressionMediator<TValue> a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(ExpressionMediator<TValue> a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(ExpressionMediator<TValue> a, int b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int32ExpressionMediator operator +(int a, ExpressionMediator<TValue> b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(int a, ExpressionMediator<TValue> b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(int a, ExpressionMediator<TValue> b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(int a, ExpressionMediator<TValue> b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(int a, ExpressionMediator<TValue> b) => new Int32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(ExpressionMediator<TValue> a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(ExpressionMediator<TValue> a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(ExpressionMediator<TValue> a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(ExpressionMediator<TValue> a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(ExpressionMediator<TValue> a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int? a, ExpressionMediator<TValue> b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int? a, ExpressionMediator<TValue> b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int? a, ExpressionMediator<TValue> b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int? a, ExpressionMediator<TValue> b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int? a, ExpressionMediator<TValue> b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static Int64ExpressionMediator operator +(ExpressionMediator<TValue> a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(ExpressionMediator<TValue> a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(ExpressionMediator<TValue> a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(ExpressionMediator<TValue> a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(ExpressionMediator<TValue> a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(long a, ExpressionMediator<TValue> b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(long a, ExpressionMediator<TValue> b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(long a, ExpressionMediator<TValue> b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(long a, ExpressionMediator<TValue> b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(long a, ExpressionMediator<TValue> b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(ExpressionMediator<TValue> a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(ExpressionMediator<TValue> a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(ExpressionMediator<TValue> a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(ExpressionMediator<TValue> a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(ExpressionMediator<TValue> a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, ExpressionMediator<TValue> b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, ExpressionMediator<TValue> b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, ExpressionMediator<TValue> b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, ExpressionMediator<TValue> b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, ExpressionMediator<TValue> b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string
        public static StringExpressionMediator operator +(ExpressionMediator<TValue> a, string b) => new StringExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new StringExpressionMediator(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add));

        public static StringExpressionMediator operator +(string a, ExpressionMediator<TValue> b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        #endregion
        #endregion

        #region fields
        #region byte
        public static ByteExpressionMediator operator +(ExpressionMediator<TValue> a, ByteFieldExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static ByteExpressionMediator operator -(ExpressionMediator<TValue> a, ByteFieldExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static ByteExpressionMediator operator *(ExpressionMediator<TValue> a, ByteFieldExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static ByteExpressionMediator operator /(ExpressionMediator<TValue> a, ByteFieldExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static ByteExpressionMediator operator %(ExpressionMediator<TValue> a, ByteFieldExpression b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(ExpressionMediator<TValue> a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(ExpressionMediator<TValue> a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(ExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(ExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static SingleExpressionMediator operator +(ExpressionMediator<TValue> a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(ExpressionMediator<TValue> a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(ExpressionMediator<TValue> a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(ExpressionMediator<TValue> a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(ExpressionMediator<TValue> a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static Int16ExpressionMediator operator +(ExpressionMediator<TValue> a, Int16FieldExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int16ExpressionMediator operator -(ExpressionMediator<TValue> a, Int16FieldExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int16ExpressionMediator operator *(ExpressionMediator<TValue> a, Int16FieldExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int16ExpressionMediator operator /(ExpressionMediator<TValue> a, Int16FieldExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int16ExpressionMediator operator %(ExpressionMediator<TValue> a, Int16FieldExpression b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static Int32ExpressionMediator operator +(ExpressionMediator<TValue> a, Int32FieldExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(ExpressionMediator<TValue> a, Int32FieldExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(ExpressionMediator<TValue> a, Int32FieldExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(ExpressionMediator<TValue> a, Int32FieldExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(ExpressionMediator<TValue> a, Int32FieldExpression b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static Int64ExpressionMediator operator +(ExpressionMediator<TValue> a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(ExpressionMediator<TValue> a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(ExpressionMediator<TValue> a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(ExpressionMediator<TValue> a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(ExpressionMediator<TValue> a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string
        public static Int64ExpressionMediator operator +(ExpressionMediator<TValue> a, StringFieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        #endregion
        #endregion

        #region mediator
        #region byte
        public static ByteExpressionMediator operator +(ExpressionMediator<TValue> a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static ByteExpressionMediator operator -(ExpressionMediator<TValue> a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static ByteExpressionMediator operator *(ExpressionMediator<TValue> a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Multiply));
        public static ByteExpressionMediator operator /(ExpressionMediator<TValue> a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Divide));
        public static ByteExpressionMediator operator %(ExpressionMediator<TValue> a, ByteExpressionMediator b) => new ByteExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(ByteExpressionMediator a, ExpressionMediator<TValue> b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(ByteExpressionMediator a, ExpressionMediator<TValue> b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(ByteExpressionMediator a, ExpressionMediator<TValue> b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(ByteExpressionMediator a, ExpressionMediator<TValue> b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(ByteExpressionMediator a, ExpressionMediator<TValue> b) => new NullableByteExpressionMediator(new ArithmeticExpression(a, new ExpressionMediator<TValue>(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(ExpressionMediator<TValue> a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(ExpressionMediator<TValue> a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDateTimeExpressionMediator operator +(ExpressionMediator<TValue> a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(ExpressionMediator<TValue> a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(ExpressionMediator<TValue> a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(ExpressionMediator<TValue> a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDateTimeOffsetExpressionMediator operator +(ExpressionMediator<TValue> a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(ExpressionMediator<TValue> a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region decimal
        public static DecimalExpressionMediator operator +(ExpressionMediator<TValue> a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(ExpressionMediator<TValue> a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(ExpressionMediator<TValue> a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(ExpressionMediator<TValue> a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(ExpressionMediator<TValue> a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Modulo));
        public static NullableDecimalExpressionMediator operator +(ExpressionMediator<TValue> a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(ExpressionMediator<TValue> a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(ExpressionMediator<TValue> a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(ExpressionMediator<TValue> a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(ExpressionMediator<TValue> a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static DoubleExpressionMediator operator +(ExpressionMediator<TValue> a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(ExpressionMediator<TValue> a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(ExpressionMediator<TValue> a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(ExpressionMediator<TValue> a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(ExpressionMediator<TValue> a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Modulo));
        public static NullableDoubleExpressionMediator operator +(ExpressionMediator<TValue> a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(ExpressionMediator<TValue> a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(ExpressionMediator<TValue> a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(ExpressionMediator<TValue> a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(ExpressionMediator<TValue> a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static SingleExpressionMediator operator +(ExpressionMediator<TValue> a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(ExpressionMediator<TValue> a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(ExpressionMediator<TValue> a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(ExpressionMediator<TValue> a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(ExpressionMediator<TValue> a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Modulo));
        public static NullableSingleExpressionMediator operator +(ExpressionMediator<TValue> a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(ExpressionMediator<TValue> a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(ExpressionMediator<TValue> a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(ExpressionMediator<TValue> a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(ExpressionMediator<TValue> a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region short
        public static Int16ExpressionMediator operator +(ExpressionMediator<TValue> a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static Int16ExpressionMediator operator -(ExpressionMediator<TValue> a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int16ExpressionMediator operator *(ExpressionMediator<TValue> a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int16ExpressionMediator operator /(ExpressionMediator<TValue> a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Divide));
        public static Int16ExpressionMediator operator %(ExpressionMediator<TValue> a, Int16ExpressionMediator b) => new Int16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Modulo));
        public static NullableInt16ExpressionMediator operator +(ExpressionMediator<TValue> a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(ExpressionMediator<TValue> a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(ExpressionMediator<TValue> a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(ExpressionMediator<TValue> a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(ExpressionMediator<TValue> a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static Int32ExpressionMediator operator +(ExpressionMediator<TValue> a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static Int32ExpressionMediator operator -(ExpressionMediator<TValue> a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int32ExpressionMediator operator *(ExpressionMediator<TValue> a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int32ExpressionMediator operator /(ExpressionMediator<TValue> a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Divide));
        public static Int32ExpressionMediator operator %(ExpressionMediator<TValue> a, Int32ExpressionMediator b) => new Int32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Modulo));
        public static NullableInt32ExpressionMediator operator +(ExpressionMediator<TValue> a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(ExpressionMediator<TValue> a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(ExpressionMediator<TValue> a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(ExpressionMediator<TValue> a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(ExpressionMediator<TValue> a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static Int64ExpressionMediator operator +(ExpressionMediator<TValue> a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(ExpressionMediator<TValue> a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(ExpressionMediator<TValue> a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(ExpressionMediator<TValue> a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(ExpressionMediator<TValue> a, Int64ExpressionMediator b) => new Int64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Modulo));
        public static NullableInt64ExpressionMediator operator +(ExpressionMediator<TValue> a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(ExpressionMediator<TValue> a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(ExpressionMediator<TValue> a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(ExpressionMediator<TValue> a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(ExpressionMediator<TValue> a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string
        public static StringExpressionMediator operator +(ExpressionMediator<TValue> a, StringExpressionMediator b) => new StringExpressionMediator(new ArithmeticExpression(new ExpressionMediator<TValue>(a), b, ArithmeticExpressionOperator.Add));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region data type
        #region bool
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, bool b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, bool b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, bool b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, bool b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, bool b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, bool b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new BooleanExpressionMediator(new LiteralExpression<bool>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(bool a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(bool a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(bool a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(bool a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(bool a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(bool a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new BooleanExpressionMediator(new LiteralExpression<bool>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, bool? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, bool? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, bool? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, bool? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, bool? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, bool? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(bool? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(bool? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(bool? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(bool? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(bool? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(bool? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableBooleanExpressionMediator(new LiteralExpression<bool?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region byte
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, byte b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, byte b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, byte b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, byte b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, byte b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, byte b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(byte a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(byte a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(byte a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(byte a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(byte a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(byte a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, byte? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, byte? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, byte? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, byte? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, byte? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, byte? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(byte? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(byte? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(byte? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(byte? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(byte? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(byte? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region decimal
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, decimal b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, decimal b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, decimal b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, decimal b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, decimal b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, decimal b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(decimal a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(decimal a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(decimal a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(decimal a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(decimal a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(decimal a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, decimal? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, decimal? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, decimal? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, decimal? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, decimal? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, decimal? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(decimal? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(decimal? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(decimal? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(decimal? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(decimal? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(decimal? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region double
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, double b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, double b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, double b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, double b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, double b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, double b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(double a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(double a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(double a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(double a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(double a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(double a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, double? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, double? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, double? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, double? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, double? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, double? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(double? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(double? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(double? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(double? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(double? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(double? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTime
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, DateTime b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, DateTime b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, DateTime b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, DateTime b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, DateTime b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, DateTime b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTime a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTime a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTime a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTime a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTime a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTime a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, DateTime? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, DateTime? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, DateTime? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, DateTime? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, DateTime? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, DateTime? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DateTime? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DateTime? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DateTime? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DateTime? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DateTime? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DateTime? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, DateTimeOffset b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, DateTimeOffset b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, DateTimeOffset b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, DateTimeOffset b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, DateTimeOffset b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, DateTimeOffset b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(DateTimeOffset a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(DateTimeOffset a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(DateTimeOffset a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(DateTimeOffset a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(DateTimeOffset a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(DateTimeOffset a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, DateTimeOffset? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, DateTimeOffset? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, DateTimeOffset? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, DateTimeOffset? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, DateTimeOffset? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, DateTimeOffset? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DateTimeOffset? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DateTimeOffset? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DateTimeOffset? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DateTimeOffset? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DateTimeOffset? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DateTimeOffset? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region float
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, float b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, float b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, float b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, float b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, float b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, float b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(float a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(float a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(float a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(float a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(float a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(float a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new SingleExpressionMediator(new LiteralExpression<float>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, float? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, float? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, float? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, float? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, float? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, float? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(float? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(float? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(float? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(float? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(float? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(float? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region Guid
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, Guid b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, Guid b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, Guid b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, Guid b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, Guid b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, Guid b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new GuidExpressionMediator(new LiteralExpression<Guid>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(Guid a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Guid a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(Guid a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(Guid a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(Guid a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(Guid a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new GuidExpressionMediator(new LiteralExpression<Guid>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, Guid? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, Guid? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, Guid? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, Guid? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, Guid? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, Guid? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(Guid? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(Guid? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(Guid? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(Guid? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(Guid? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(Guid? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableGuidExpressionMediator(new LiteralExpression<Guid?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region short
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, short b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, short b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, short b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, short b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, short b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, short b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(short a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(short a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(short a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(short a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(short a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(short a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, short? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, short? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, short? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, short? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, short? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, short? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(short? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(short? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(short? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(short? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(short? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(short? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region int
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, int b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, int b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, int b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, int b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, int b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, int b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(int a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(int a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(int a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(int a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(int a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(int a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, int? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, int? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, int? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, int? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, int? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, int? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(int? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(int? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(int? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(int? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(int? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(int? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region long
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, long b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, long b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, long b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, long b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, long b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, long b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(long a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(long a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(long a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(long a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(long a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(long a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, long? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, long? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, long? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, long? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, long? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, long? b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(long? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(long? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(long? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(long? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(long? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(long? a, ExpressionMediator<TValue> b) => new FilterExpression<bool?>(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region string
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, string b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, string b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, string b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, string b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, string b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, string b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(string a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(string a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(string a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(string a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(string a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(string a, ExpressionMediator<TValue> b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region fields
        #region bool
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, BooleanFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableBooleanFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region byte
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, ByteFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, ByteFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, ByteFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, ByteFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, ByteFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, ByteFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region decimal
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, DecimalFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableDecimalFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region double
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, DoubleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableDoubleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTime
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, DateTimeFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, DateTimeFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, DateTimeFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, DateTimeFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, DateTimeFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, DateTimeFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, DateTimeOffsetFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableDateTimeOffsetFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region float
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, SingleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, SingleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, SingleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, SingleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, SingleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, SingleFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region Guid
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, GuidFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, GuidFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, GuidFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, GuidFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, GuidFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, GuidFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableGuidFieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region short
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, Int16FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, Int16FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, Int16FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, Int16FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, Int16FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, Int16FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableInt16FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region int
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, Int32FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, Int32FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, Int32FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, Int32FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, Int32FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, Int32FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableInt32FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region long
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, Int64FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, Int64FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, Int64FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, Int64FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, Int64FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, Int64FieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableInt64FieldExpression b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region string
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, StringFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, StringFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, StringFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, StringFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, StringFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, StringFieldExpression b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), new ExpressionMediator<TValue>(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        #region bool
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, BooleanExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableBooleanExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region byte
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, ByteExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, ByteExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, ByteExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, ByteExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, ByteExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, ByteExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region decimal
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, DecimalExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, DecimalExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, DecimalExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, DecimalExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, DecimalExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, DecimalExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableDecimalExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region double
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, DoubleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, DoubleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, DoubleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, DoubleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, DoubleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, DoubleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableDoubleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTime
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, DateTimeExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region DateTimeOffset
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region float
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, SingleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, SingleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, SingleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, SingleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, SingleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, SingleExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region Guid
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, GuidExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, GuidExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, GuidExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, GuidExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, GuidExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, GuidExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableGuidExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region short
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, Int16ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, Int16ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, Int16ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, Int16ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, Int16ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, Int16ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableInt16ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region int
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, Int32ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, Int32ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, Int32ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, Int32ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, Int32ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, Int32ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableInt32ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region long
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, Int64ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, Int64ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, Int64ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, Int64ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, Int64ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, Int64ExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(ExpressionMediator<TValue> a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(ExpressionMediator<TValue> a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(ExpressionMediator<TValue> a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(ExpressionMediator<TValue> a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(ExpressionMediator<TValue> a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(ExpressionMediator<TValue> a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion

        #region string
        public static FilterExpression<bool> operator ==(ExpressionMediator<TValue> a, StringExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(ExpressionMediator<TValue> a, StringExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(ExpressionMediator<TValue> a, StringExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(ExpressionMediator<TValue> a, StringExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(ExpressionMediator<TValue> a, StringExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(ExpressionMediator<TValue> a, StringExpressionMediator b) => new FilterExpression<bool>(new ExpressionMediator<TValue>(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
        #endregion
    }
}
