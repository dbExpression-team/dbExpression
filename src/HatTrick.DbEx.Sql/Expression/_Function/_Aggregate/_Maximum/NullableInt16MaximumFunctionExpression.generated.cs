using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16MaximumFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableInt16ExpressionMediator(NullableInt16MaximumFunctionExpression a) => new NullableInt16ExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableInt16MaximumFunctionExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static NullableInt16ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, byte b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, byte b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, byte b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, byte b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, byte b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(byte a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(byte a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(byte a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(byte a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(byte a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, byte? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, byte? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, byte? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, byte? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, byte? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(byte? a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(byte? a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(byte? a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(byte? a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(byte? a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal a, NullableInt16MaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableInt16MaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableInt16MaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableInt16MaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableInt16MaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableInt16MaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableInt16MaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableInt16MaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableInt16MaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableInt16MaximumFunctionExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double a, NullableInt16MaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double a, NullableInt16MaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double a, NullableInt16MaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double a, NullableInt16MaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double a, NullableInt16MaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, NullableInt16MaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, NullableInt16MaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, NullableInt16MaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, NullableInt16MaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, NullableInt16MaximumFunctionExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float a, NullableInt16MaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float a, NullableInt16MaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float a, NullableInt16MaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float a, NullableInt16MaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float a, NullableInt16MaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, NullableInt16MaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, NullableInt16MaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, NullableInt16MaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, NullableInt16MaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, NullableInt16MaximumFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region short
        public static NullableInt16ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(short a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(short a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(short a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(short a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(short a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(short? a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(short? a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(short? a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(short? a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(short? a, NullableInt16MaximumFunctionExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int a, NullableInt16MaximumFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int a, NullableInt16MaximumFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int a, NullableInt16MaximumFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int a, NullableInt16MaximumFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int a, NullableInt16MaximumFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int? a, NullableInt16MaximumFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int? a, NullableInt16MaximumFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int? a, NullableInt16MaximumFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int? a, NullableInt16MaximumFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int? a, NullableInt16MaximumFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long a, NullableInt16MaximumFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long a, NullableInt16MaximumFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long a, NullableInt16MaximumFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long a, NullableInt16MaximumFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long a, NullableInt16MaximumFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, NullableInt16MaximumFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, NullableInt16MaximumFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, NullableInt16MaximumFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, NullableInt16MaximumFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, NullableInt16MaximumFunctionExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #endregion

        #region fields
        #region byte
        public static NullableInt16ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, ByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, ByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, ByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, ByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, ByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region short
        public static NullableInt16ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #endregion

        #region mediator
        #region byte
        public static NullableInt16ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, ByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, ByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, ByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, ByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, ByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, DecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region double
        public static NullableDoubleExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, DoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static NullableSingleExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static NullableInt16ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, Int16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static NullableInt64ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, Int64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(NullableInt16MaximumFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(NullableInt16MaximumFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(NullableInt16MaximumFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(NullableInt16MaximumFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(NullableInt16MaximumFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableInt16MaximumFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16MaximumFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data type
        #region short
        public static FilterExpressionSet operator ==(NullableInt16MaximumFunctionExpression a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16MaximumFunctionExpression a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16MaximumFunctionExpression a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16MaximumFunctionExpression a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16MaximumFunctionExpression a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16MaximumFunctionExpression a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(short a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(short a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(short a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(short a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(short a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(short a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt16MaximumFunctionExpression a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16MaximumFunctionExpression a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16MaximumFunctionExpression a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16MaximumFunctionExpression a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16MaximumFunctionExpression a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16MaximumFunctionExpression a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(short? a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(short? a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(short? a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(short? a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(short? a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(short? a, NullableInt16MaximumFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableInt16MaximumFunctionExpression a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16MaximumFunctionExpression a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16MaximumFunctionExpression a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16MaximumFunctionExpression a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16MaximumFunctionExpression a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16MaximumFunctionExpression a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        
        public static FilterExpressionSet operator ==(NullableInt16MaximumFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16MaximumFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16MaximumFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16MaximumFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16MaximumFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16MaximumFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(NullableInt16MaximumFunctionExpression a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16MaximumFunctionExpression a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16MaximumFunctionExpression a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16MaximumFunctionExpression a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16MaximumFunctionExpression a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16MaximumFunctionExpression a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt16MaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16MaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16MaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16MaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16MaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16MaximumFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableInt16MaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16MaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16MaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16MaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16MaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16MaximumFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #endregion
    }
}
