using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableInt16FloorFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableInt16ExpressionMediator(NullableInt16FloorFunctionExpression a) => new NullableInt16ExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableInt16FloorFunctionExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableInt16FloorFunctionExpression a) => new GroupByExpression(a);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, byte b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(byte a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(byte a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(byte a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(byte a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(byte a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, byte? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(byte? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(byte? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(byte? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(byte? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(byte? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region decimal
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, decimal b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, decimal b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, decimal b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, decimal b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, decimal b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(decimal a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(decimal a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(decimal a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(decimal a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(decimal a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, decimal? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, decimal? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, decimal? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, decimal? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, decimal? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(decimal? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(decimal? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(decimal? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(decimal? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(decimal? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region double
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, double b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, double b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, double b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, double b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, double b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(double a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(double a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(double a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(double a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(double a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, double? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, double? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, double? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, double? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, double? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(double? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(double? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(double? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(double? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(double? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region float
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, float b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, float b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, float b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, float b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, float b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(float a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(float a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(float a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(float a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(float a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, float? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, float? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, float? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, float? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, float? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(float? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(float? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(float? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(float? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(float? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region short
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, short b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(short a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(short a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(short a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(short a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(short a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, short? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(short? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(short? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(short? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(short? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(short? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region long
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, long b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, long b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, long b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, long b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, long b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(long a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(long a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(long a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(long a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(long a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, long? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, long? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, long? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, long? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, long? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(long? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(long? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(long? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(long? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(long? a, NullableInt16FloorFunctionExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #endregion

        #region fields
        #region byte
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, ByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, ByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, ByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, ByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, ByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region decimal
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, DecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, DecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, DecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, DecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, DecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableDecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableDecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableDecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableDecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableDecimalFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region double
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, DoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, DoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, DoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, DoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, DoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableDoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableDoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableDoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableDoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableDoubleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region float
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, SingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, SingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, SingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, SingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, SingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableSingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableSingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableSingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableSingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableSingleFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region short
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, Int16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, Int16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, Int16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, Int16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, Int16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableInt16FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region long
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, Int64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, Int64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, Int64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, Int64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, Int64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableInt64FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #endregion

        #region mediator
        #region byte
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, ByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableByteExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, DecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, DecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, DecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, DecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, DecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region double
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, DoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, DoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, DoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, DoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, DoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, SingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, SingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, SingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, SingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, SingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableSingleExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, Int16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, Int32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, Int64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, Int64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, Int64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, Int64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, Int64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableInt16FloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableInt16FloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableInt16FloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableInt16FloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableInt16FloorFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(NullableInt16FloorFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(NullableInt16FloorFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(NullableInt16FloorFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(NullableInt16FloorFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(NullableInt16FloorFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableInt16FloorFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16FloorFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data type
        #region short
        public static FilterExpressionSet operator ==(NullableInt16FloorFunctionExpression a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16FloorFunctionExpression a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16FloorFunctionExpression a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16FloorFunctionExpression a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16FloorFunctionExpression a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16FloorFunctionExpression a, short b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(short a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(short a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(short a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(short a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(short a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(short a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt16FloorFunctionExpression a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16FloorFunctionExpression a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16FloorFunctionExpression a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16FloorFunctionExpression a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16FloorFunctionExpression a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16FloorFunctionExpression a, short? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<short?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(short? a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(short? a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(short? a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(short? a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(short? a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(short? a, NullableInt16FloorFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<short?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableInt16FloorFunctionExpression a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16FloorFunctionExpression a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16FloorFunctionExpression a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16FloorFunctionExpression a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16FloorFunctionExpression a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16FloorFunctionExpression a, Int16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        
        public static FilterExpressionSet operator ==(NullableInt16FloorFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16FloorFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16FloorFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16FloorFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16FloorFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16FloorFunctionExpression a, NullableInt16FieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(NullableInt16FloorFunctionExpression a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16FloorFunctionExpression a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16FloorFunctionExpression a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16FloorFunctionExpression a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16FloorFunctionExpression a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16FloorFunctionExpression a, Int16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableInt16FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16FloorFunctionExpression a, NullableInt16ExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableInt16FloorFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableInt16FloorFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableInt16FloorFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableInt16FloorFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableInt16FloorFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableInt16FloorFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #endregion
    }
}
