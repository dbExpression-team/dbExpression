
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringMaximumFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<string>(StringMaximumFunctionExpression a) => new SelectExpression<string>(new ExpressionContainer(a));
        public static implicit operator StringExpressionMediator(StringMaximumFunctionExpression a) => new StringExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(StringMaximumFunctionExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(byte a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(byte a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(byte a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(byte a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(byte a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(byte? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(byte? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(byte? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(byte? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(byte? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region decimal
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(decimal a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(decimal a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(decimal a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(decimal a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(decimal a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(decimal? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(decimal? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(decimal? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(decimal? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(decimal? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region double
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(double a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(double a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(double a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(double a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(double a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(double? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(double? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(double? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(double? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(double? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region float
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(float a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(float a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(float a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(float a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(float a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(float? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(float? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(float? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(float? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(float? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region short
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(short a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(short a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(short a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(short a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(short a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(short? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(short? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(short? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(short? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(short? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region int
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(int a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(int a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(int a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(int a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(int a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(int? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(int? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(int? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(int? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(int? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region long
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(long a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(long a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(long a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(long a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(long a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(long? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(long? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(long? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(long? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(long? a, StringMaximumFunctionExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #endregion

        #region mediator
        #region byte
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, ByteExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, ByteExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, ByteExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, ByteExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, ByteExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region decimal
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, DecimalExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, DecimalExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, DecimalExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, DecimalExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, DecimalExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region double
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, DoubleExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, DoubleExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, DoubleExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, DoubleExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, DoubleExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region float
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, SingleExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, SingleExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, SingleExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, SingleExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, SingleExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region short
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, Int16ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, Int16ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, Int16ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, Int16ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, Int16ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region int
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, Int32ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, Int32ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, Int32ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, Int32ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, Int32ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region long
        public static StringExpressionMediator operator +(StringMaximumFunctionExpression a, Int64ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringMaximumFunctionExpression a, Int64ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringMaximumFunctionExpression a, Int64ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringMaximumFunctionExpression a, Int64ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringMaximumFunctionExpression a, Int64ExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Modulo)));

        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region string
        public static FilterExpression<string> operator ==(StringMaximumFunctionExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<string> operator !=(StringMaximumFunctionExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<string> operator <(StringMaximumFunctionExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<string> operator <=(StringMaximumFunctionExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<string> operator >(StringMaximumFunctionExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<string> operator >=(StringMaximumFunctionExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<string> operator ==(string a, StringMaximumFunctionExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<string> operator !=(string a, StringMaximumFunctionExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<string> operator <(string a, StringMaximumFunctionExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<string> operator <=(string a, StringMaximumFunctionExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<string> operator >(string a, StringMaximumFunctionExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<string> operator >=(string a, StringMaximumFunctionExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion

        #region mediator
        public static FilterExpression<string> operator ==(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<string> operator !=(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<string> operator <(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<string> operator <=(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<string> operator >(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<string> operator >=(StringMaximumFunctionExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
