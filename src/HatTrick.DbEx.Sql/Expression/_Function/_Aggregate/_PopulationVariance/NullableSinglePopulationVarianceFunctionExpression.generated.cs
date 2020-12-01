using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSinglePopulationVarianceFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableSingleExpressionMediator(NullableSinglePopulationVarianceFunctionExpression a) => new NullableSingleExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableSinglePopulationVarianceFunctionExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(this, OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(this, OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(byte a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(byte a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(byte a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(byte a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(byte a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(byte? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(byte? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(byte? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(byte? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(byte? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region decimal
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, decimal b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, decimal b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, decimal b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, decimal b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, decimal b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(decimal a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(decimal a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(decimal a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(decimal a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(decimal a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, decimal? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, decimal? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, decimal? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, decimal? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, decimal? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(decimal? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(decimal? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(decimal? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(decimal? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(decimal? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region double
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, double b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, double b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, double b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, double b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, double b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(double a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(double a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(double a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(double a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(double a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, double? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, double? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, double? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, double? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, double? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(double? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(double? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(double? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(double? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(double? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region float
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region short
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(short a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(short a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(short a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(short a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(short a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(short? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(short? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(short? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(short? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(short? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region int
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(int a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(int a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(int a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(int a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(int a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(int? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(int? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(int? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(int? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(int? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #region long
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(long a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(long a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(long a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(long a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(long a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(long? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(long? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(long? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(long? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(long? a, NullableSinglePopulationVarianceFunctionExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Modulo));
        
        #endregion
        
        #endregion

        #region fields
        #region byte
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, ByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, ByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, ByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, ByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, ByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region decimal
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, DecimalFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, DecimalFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, DecimalFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, DecimalFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, DecimalFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableDecimalFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableDecimalFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableDecimalFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableDecimalFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableDecimalFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region double
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, DoubleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, DoubleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, DoubleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, DoubleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, DoubleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableDoubleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableDoubleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableDoubleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableDoubleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableDoubleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region float
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region short
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, Int16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, Int16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, Int16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, Int16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, Int16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region int
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, Int32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, Int32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, Int32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, Int32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, Int32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #region long
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion        
        #endregion

        #region mediator
        #region byte
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, ByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, ByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, ByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, ByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, ByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableByteExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, DecimalExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, DecimalExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, DecimalExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, DecimalExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, DecimalExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region double
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, DoubleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, DoubleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, DoubleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, DoubleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, DoubleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, SingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, Int16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, Int16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, Int16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, Int16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, Int16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, Int32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, Int32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, Int32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, Int32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, Int32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, Int64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, Int64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, Int64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, Int64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, Int64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableSingleExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(NullableSinglePopulationVarianceFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(NullableSinglePopulationVarianceFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        public static ObjectExpressionMediator operator *(NullableSinglePopulationVarianceFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Multiply));
        public static ObjectExpressionMediator operator /(NullableSinglePopulationVarianceFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Divide));
        public static ObjectExpressionMediator operator %(NullableSinglePopulationVarianceFunctionExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Modulo));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableSinglePopulationVarianceFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableSinglePopulationVarianceFunctionExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data type
        #region float
        public static FilterExpressionSet operator ==(NullableSinglePopulationVarianceFunctionExpression a, float b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableSinglePopulationVarianceFunctionExpression a, float b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableSinglePopulationVarianceFunctionExpression a, float b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableSinglePopulationVarianceFunctionExpression a, float b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableSinglePopulationVarianceFunctionExpression a, float b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableSinglePopulationVarianceFunctionExpression a, float b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(float a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(float a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(float a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(float a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(float a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(float a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableSinglePopulationVarianceFunctionExpression a, float? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableSinglePopulationVarianceFunctionExpression a, float? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableSinglePopulationVarianceFunctionExpression a, float? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableSinglePopulationVarianceFunctionExpression a, float? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableSinglePopulationVarianceFunctionExpression a, float? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableSinglePopulationVarianceFunctionExpression a, float? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<float?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(float? a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(float? a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(float? a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(float? a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(float? a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(float? a, NullableSinglePopulationVarianceFunctionExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<float?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(NullableSinglePopulationVarianceFunctionExpression a, SingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableSinglePopulationVarianceFunctionExpression a, SingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableSinglePopulationVarianceFunctionExpression a, SingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableSinglePopulationVarianceFunctionExpression a, SingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableSinglePopulationVarianceFunctionExpression a, SingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableSinglePopulationVarianceFunctionExpression a, SingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        
        public static FilterExpressionSet operator ==(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        #endregion

        #region mediators
        public static FilterExpressionSet operator ==(NullableSinglePopulationVarianceFunctionExpression a, SingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableSinglePopulationVarianceFunctionExpression a, SingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableSinglePopulationVarianceFunctionExpression a, SingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableSinglePopulationVarianceFunctionExpression a, SingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableSinglePopulationVarianceFunctionExpression a, SingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableSinglePopulationVarianceFunctionExpression a, SingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableSinglePopulationVarianceFunctionExpression a, NullableSingleExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(NullableSinglePopulationVarianceFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableSinglePopulationVarianceFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(NullableSinglePopulationVarianceFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(NullableSinglePopulationVarianceFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(NullableSinglePopulationVarianceFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(NullableSinglePopulationVarianceFunctionExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #endregion
    }
}
