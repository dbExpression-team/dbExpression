using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class SingleMaximumFunctionExpression
    {
        #region implicit operators
        public static implicit operator SingleExpressionMediator(SingleMaximumFunctionExpression a) => new SingleExpressionMediator(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, byte b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(byte a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(byte a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(byte a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(byte a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(byte a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(byte? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(byte? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(byte? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(byte? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(byte? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(SingleMaximumFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(SingleMaximumFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(SingleMaximumFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(SingleMaximumFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(SingleMaximumFunctionExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal a, SingleMaximumFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal a, SingleMaximumFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal a, SingleMaximumFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal a, SingleMaximumFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal a, SingleMaximumFunctionExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(SingleMaximumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(SingleMaximumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(SingleMaximumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(SingleMaximumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(SingleMaximumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, SingleMaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, SingleMaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, SingleMaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, SingleMaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, SingleMaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region double
        public static DoubleExpressionMediator operator +(SingleMaximumFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(SingleMaximumFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(SingleMaximumFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(SingleMaximumFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(SingleMaximumFunctionExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double a, SingleMaximumFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double a, SingleMaximumFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double a, SingleMaximumFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double a, SingleMaximumFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double a, SingleMaximumFunctionExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(SingleMaximumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(SingleMaximumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(SingleMaximumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(SingleMaximumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(SingleMaximumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, SingleMaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, SingleMaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, SingleMaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, SingleMaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, SingleMaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, short b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, short b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, short b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, short b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, short b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(short a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(short a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(short a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(short a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(short a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(short? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(short? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(short? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(short? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(short? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, int b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, int b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, int b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, int b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, int b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(int a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(int a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(int a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(int a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(int a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(int? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(int? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(int? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(int? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(int? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, long b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, long b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, long b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, long b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, long b) => new SingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(long a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(long a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(long a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(long a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(long a, SingleMaximumFunctionExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(long? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(long? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(long? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(long? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(long? a, SingleMaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #endregion

        #region fields
        #region byte
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, ByteFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, ByteFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, ByteFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, ByteFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, ByteFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region decimal
        public static DecimalExpressionMediator operator +(SingleMaximumFunctionExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(SingleMaximumFunctionExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(SingleMaximumFunctionExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(SingleMaximumFunctionExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(SingleMaximumFunctionExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region double
        public static DoubleExpressionMediator operator +(SingleMaximumFunctionExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(SingleMaximumFunctionExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(SingleMaximumFunctionExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(SingleMaximumFunctionExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(SingleMaximumFunctionExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region float
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region short
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, Int16FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, Int16FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, Int16FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, Int16FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, Int16FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region int
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, Int32FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, Int32FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, Int32FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, Int32FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, Int32FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region long
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, Int64FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, Int64FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, Int64FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, Int64FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, Int64FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #endregion

        #region mediators
        #region byte
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, ByteExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region decimal
        public static DecimalExpressionMediator operator +(SingleMaximumFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(SingleMaximumFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(SingleMaximumFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(SingleMaximumFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(SingleMaximumFunctionExpression a, DecimalExpressionMediator b) => new DecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region double
        public static DoubleExpressionMediator operator +(SingleMaximumFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(SingleMaximumFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(SingleMaximumFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(SingleMaximumFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(SingleMaximumFunctionExpression a, DoubleExpressionMediator b) => new DoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region float
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, SingleExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region short
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, Int16ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region int
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, Int32ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region long
        public static SingleExpressionMediator operator +(SingleMaximumFunctionExpression a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(SingleMaximumFunctionExpression a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(SingleMaximumFunctionExpression a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(SingleMaximumFunctionExpression a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(SingleMaximumFunctionExpression a, Int64ExpressionMediator b) => new SingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(SingleMaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(SingleMaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(SingleMaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(SingleMaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(SingleMaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(SingleMaximumFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(SingleMaximumFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(SingleMaximumFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(SingleMaximumFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(SingleMaximumFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region data types
        #region float
        public static FilterExpressionSet operator ==(SingleMaximumFunctionExpression a, float b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SingleMaximumFunctionExpression a, float b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SingleMaximumFunctionExpression a, float b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SingleMaximumFunctionExpression a, float b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SingleMaximumFunctionExpression a, float b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SingleMaximumFunctionExpression a, float b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(float a, SingleMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(float a, SingleMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(float a, SingleMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(float a, SingleMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(float a, SingleMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(float a, SingleMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(SingleMaximumFunctionExpression a, float? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SingleMaximumFunctionExpression a, float? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SingleMaximumFunctionExpression a, float? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SingleMaximumFunctionExpression a, float? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SingleMaximumFunctionExpression a, float? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SingleMaximumFunctionExpression a, float? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(float? a, SingleMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(float? a, SingleMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(float? a, SingleMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(float? a, SingleMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(float? a, SingleMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(float? a, SingleMaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(SingleMaximumFunctionExpression a, SingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SingleMaximumFunctionExpression a, SingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SingleMaximumFunctionExpression a, SingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SingleMaximumFunctionExpression a, SingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SingleMaximumFunctionExpression a, SingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SingleMaximumFunctionExpression a, SingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        
        public static FilterExpressionSet operator ==(SingleMaximumFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SingleMaximumFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SingleMaximumFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SingleMaximumFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SingleMaximumFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SingleMaximumFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(SingleMaximumFunctionExpression a, SingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SingleMaximumFunctionExpression a, SingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SingleMaximumFunctionExpression a, SingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SingleMaximumFunctionExpression a, SingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SingleMaximumFunctionExpression a, SingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SingleMaximumFunctionExpression a, SingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(SingleMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SingleMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SingleMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SingleMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SingleMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SingleMaximumFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(SingleMaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(SingleMaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(SingleMaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(SingleMaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(SingleMaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(SingleMaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
