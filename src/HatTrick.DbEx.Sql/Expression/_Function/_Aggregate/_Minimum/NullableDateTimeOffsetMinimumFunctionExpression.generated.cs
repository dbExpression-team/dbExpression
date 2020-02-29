using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetMinimumFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTimeOffset?>(NullableDateTimeOffsetMinimumFunctionExpression a) => new SelectExpression<DateTimeOffset?>(new ExpressionContainer(a));
        public static implicit operator NullableDateTimeOffsetExpressionMediator(NullableDateTimeOffsetMinimumFunctionExpression a) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(NullableDateTimeOffsetMinimumFunctionExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, byte b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, byte b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(byte a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(byte a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(byte? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(byte? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        
        #endregion

        #region decimal
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, decimal b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, decimal b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(decimal a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(decimal a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(decimal? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(decimal? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        
        #endregion

        #region double
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, double b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, double b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(double a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(double a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(double? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(double? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        
        #endregion

        #region float
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, float b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, float b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(float a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(float a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(float? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(float? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        
        #endregion

        #region short
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, short b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, short b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(short a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(short a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(short? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(short? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        
        #endregion

        #region int
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, int b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, int b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(int a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(int a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(int? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(int? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        
        #endregion

        #region long
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, long b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, long b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(long a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(long a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(long? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(long? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        
        #endregion

        #endregion

        #region mediator
        #region byte
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, ByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, ByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, DecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, DecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, DoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, DoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, SingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, SingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, Int16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, Int16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, Int32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, Int32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, Int64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, Int64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTimeOffset
        public static FilterExpression<DateTimeOffset> operator ==(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffset a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffset a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffset a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffset a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffset a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffset a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffset? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffset? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffset? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffset? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffset? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffset? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<DateTimeOffset> operator ==(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset?> operator !=(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset?> operator <(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset?> operator <=(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset?> operator >(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset?> operator >=(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
