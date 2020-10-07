using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeOffsetMinimumFunctionExpression
    {
        #region implicit operators
        public static implicit operator NullableDateTimeOffsetExpressionMediator(NullableDateTimeOffsetMinimumFunctionExpression a) => new NullableDateTimeOffsetExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableDateTimeOffsetMinimumFunctionExpression a) => new OrderByExpression(new DateTimeOffsetExpressionMediator(a), OrderExpressionDirection.ASC);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new DateTimeOffsetExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new DateTimeOffsetExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, byte b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, byte b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(byte a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(byte a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(byte? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(byte? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region decimal
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, decimal b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, decimal b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(decimal a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(decimal a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(decimal? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(decimal? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region double
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, double b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, double b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(double a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(double a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(double? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(double? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region float
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, float b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, float b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(float a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(float a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(float? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(float? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region short
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, short b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, short b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(short a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(short a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(short? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(short? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region int
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, int b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, int b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(int a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(int a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(int? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(int? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #region long
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, long b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, long b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(long a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(long a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(long? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(long? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        
        #endregion

        #endregion

        #region mediator
        #region byte
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, ByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, ByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region decimal
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, DecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, DecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, DoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, DoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region float
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, SingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, SingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region short
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, Int16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, Int16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region int
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, Int32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, Int32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #region long
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, Int64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, Int64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableDateTimeOffsetMinimumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableDateTimeOffsetMinimumFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTimeOffset
        public static FilterExpression<bool?> operator ==(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DateTimeOffset a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeOffsetExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DateTimeOffset a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeOffsetExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DateTimeOffset a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DateTimeOffset a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DateTimeOffset a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DateTimeOffset a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool?>(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffset? b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DateTimeOffset? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeOffsetExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DateTimeOffset? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeOffsetExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DateTimeOffset? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DateTimeOffset? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeOffsetExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DateTimeOffset? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DateTimeOffset? a, NullableDateTimeOffsetMinimumFunctionExpression b) => new FilterExpression<bool?>(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeOffsetExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<bool?> operator ==(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableDateTimeOffsetMinimumFunctionExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableDateTimeOffsetMinimumFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
