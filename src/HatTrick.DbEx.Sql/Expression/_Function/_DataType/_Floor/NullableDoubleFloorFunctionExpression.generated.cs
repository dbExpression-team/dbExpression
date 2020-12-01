using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDoubleFloorFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableDoubleExpressionMediator(NullableDoubleFloorFunctionExpression a) => new NullableDoubleExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableDoubleFloorFunctionExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableDoubleFloorFunctionExpression a) => new GroupByExpression(a);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(byte a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(byte a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(byte a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(byte a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(byte a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(byte? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(byte? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(byte? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(byte? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(byte? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region decimal
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, decimal b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, decimal b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, decimal b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, decimal b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, decimal b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(decimal a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(decimal a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(decimal a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(decimal a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(decimal a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, decimal? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, decimal? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, decimal? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, decimal? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, decimal? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(decimal? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(decimal? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(decimal? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(decimal? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(decimal? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region double
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, double b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, double b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, double b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, double b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, double b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(double a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(double a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(double a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(double a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(double a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, double? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, double? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, double? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, double? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, double? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(double? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(double? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(double? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(double? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(double? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region float
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, float b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, float b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, float b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, float b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, float b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(float a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(float a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(float a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(float a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(float a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, float? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, float? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, float? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, float? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, float? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(float? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(float? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(float? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(float? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(float? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region short
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(short a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(short a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(short a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(short a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(short a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(short? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(short? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(short? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(short? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(short? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region int
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region long
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, long b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, long b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, long b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, long b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, long b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(long a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(long a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(long a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(long a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(long a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, long? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, long? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, long? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, long? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, long? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(long? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(long? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(long? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(long? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(long? a, NullableDoubleFloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #endregion

        #region fields
        #region byte
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, ByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, ByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, ByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, ByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, ByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region decimal
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, DecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, DecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, DecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, DecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, DecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableDecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableDecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableDecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableDecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableDecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region double
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, DoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, DoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, DoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, DoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, DoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableDoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableDoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableDoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableDoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableDoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region float
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, SingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, SingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, SingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, SingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, SingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableSingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableSingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableSingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableSingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableSingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region short
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, Int16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, Int16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, Int16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, Int16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, Int16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region int
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region long
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, Int64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, Int64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, Int64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, Int64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, Int64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #endregion

        #region mediator
        #region byte
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, DecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, DecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, DecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, DecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, DecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region double
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, DoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, DoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, DoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, DoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, DoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, SingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, SingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, SingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, SingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, SingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, Int64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, Int64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, Int64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, Int64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, Int64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(NullableDoubleFloorFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(NullableDoubleFloorFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(NullableDoubleFloorFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(NullableDoubleFloorFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(NullableDoubleFloorFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableDoubleFloorFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double?>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleFloorFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double?>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double?>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double?>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data type
        #region double
        public static FilterExpressionSet operator ==(NullableDoubleFloorFunctionExpression a, double b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleFloorFunctionExpression a, double b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDoubleFloorFunctionExpression a, double b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDoubleFloorFunctionExpression a, double b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDoubleFloorFunctionExpression a, double b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDoubleFloorFunctionExpression a, double b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(double a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(double a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(double a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(double a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(double a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(double a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableDoubleFloorFunctionExpression a, double? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleFloorFunctionExpression a, double? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDoubleFloorFunctionExpression a, double? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDoubleFloorFunctionExpression a, double? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDoubleFloorFunctionExpression a, double? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDoubleFloorFunctionExpression a, double? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<double?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(double? a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(double? a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(double? a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(double? a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(double? a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(double? a, NullableDoubleFloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<double?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableDoubleFloorFunctionExpression a, DoubleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleFloorFunctionExpression a, DoubleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDoubleFloorFunctionExpression a, DoubleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDoubleFloorFunctionExpression a, DoubleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDoubleFloorFunctionExpression a, DoubleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDoubleFloorFunctionExpression a, DoubleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        
        public static FilterExpressionSet operator ==(NullableDoubleFloorFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleFloorFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDoubleFloorFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDoubleFloorFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDoubleFloorFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDoubleFloorFunctionExpression a, NullableDoubleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(NullableDoubleFloorFunctionExpression a, DoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleFloorFunctionExpression a, DoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDoubleFloorFunctionExpression a, DoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDoubleFloorFunctionExpression a, DoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDoubleFloorFunctionExpression a, DoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDoubleFloorFunctionExpression a, DoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableDoubleFloorFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleFloorFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDoubleFloorFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDoubleFloorFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDoubleFloorFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDoubleFloorFunctionExpression a, NullableDoubleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableDoubleFloorFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableDoubleFloorFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableDoubleFloorFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableDoubleFloorFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableDoubleFloorFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableDoubleFloorFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #endregion
    }
}
