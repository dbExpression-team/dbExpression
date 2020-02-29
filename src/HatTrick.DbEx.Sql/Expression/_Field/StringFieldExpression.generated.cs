using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringFieldExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<string>(StringFieldExpression a) => new SelectExpression<string>(new ExpressionContainer(a));
        public static implicit operator StringExpressionMediator(StringFieldExpression a) => new StringExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(StringFieldExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(StringFieldExpression a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #region bool



        #endregion

        #region byte
        public static StringExpressionMediator operator +(StringFieldExpression a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(byte a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(byte a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(byte a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(byte a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(byte a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringFieldExpression a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(byte? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(byte? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(byte? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(byte? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(byte? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region decimal
        public static StringExpressionMediator operator +(StringFieldExpression a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(decimal a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(decimal a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(decimal a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(decimal a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(decimal a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringFieldExpression a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(decimal? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(decimal? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(decimal? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(decimal? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(decimal? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTime
        public static StringExpressionMediator operator +(StringFieldExpression a, DateTime b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, DateTime b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, DateTime b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, DateTime b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, DateTime b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(DateTime a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTime a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(DateTime a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(DateTime a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(DateTime a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringFieldExpression a, DateTime? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, DateTime? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, DateTime? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, DateTime? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, DateTime? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(DateTime? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTime? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(DateTime? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(DateTime? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(DateTime? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTimeOffset
        public static StringExpressionMediator operator +(StringFieldExpression a, DateTimeOffset b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, DateTimeOffset b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, DateTimeOffset b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, DateTimeOffset b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, DateTimeOffset b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(DateTimeOffset a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTimeOffset a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(DateTimeOffset a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(DateTimeOffset a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(DateTimeOffset a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringFieldExpression a, DateTimeOffset? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, DateTimeOffset? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, DateTimeOffset? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, DateTimeOffset? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, DateTimeOffset? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(DateTimeOffset? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTimeOffset? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(DateTimeOffset? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(DateTimeOffset? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(DateTimeOffset? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region double
        public static StringExpressionMediator operator +(StringFieldExpression a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(double a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(double a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(double a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(double a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(double a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringFieldExpression a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(double? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(double? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(double? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(double? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(double? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region float
        public static StringExpressionMediator operator +(StringFieldExpression a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(float a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(float a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(float a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(float a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(float a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringFieldExpression a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(float? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(float? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(float? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(float? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(float? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region Guid



        #endregion

        #region short
        public static StringExpressionMediator operator +(StringFieldExpression a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(short a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(short a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(short a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(short a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(short a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringFieldExpression a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(short? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(short? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(short? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(short? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(short? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region int
        public static StringExpressionMediator operator +(StringFieldExpression a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(int a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(int a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(int a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(int a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(int a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringFieldExpression a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(int? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(int? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(int? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(int? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(int? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region long
        public static StringExpressionMediator operator +(StringFieldExpression a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(long a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(long a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(long a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(long a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(long a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringFieldExpression a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(long? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(long? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(long? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(long? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(long? a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region string
        public static StringExpressionMediator operator +(StringFieldExpression a, string b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add)));

        public static StringExpressionMediator operator +(string a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));

        #endregion

        #endregion

        #region mediator
        #region bool

        #endregion

        #region byte
        public static StringExpressionMediator operator +(StringFieldExpression a, ByteFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, ByteFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, ByteFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, ByteFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, ByteFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region decimal
        public static StringExpressionMediator operator +(StringFieldExpression a, DecimalFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, DecimalFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, DecimalFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, DecimalFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, DecimalFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region DateTime
        public static StringExpressionMediator operator +(StringFieldExpression a, DateTimeFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, DateTimeFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, DateTimeFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, DateTimeFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, DateTimeFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region DateTimeOffset
        public static StringExpressionMediator operator +(StringFieldExpression a, DateTimeOffsetFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, DateTimeOffsetFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, DateTimeOffsetFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, DateTimeOffsetFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, DateTimeOffsetFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region double
        public static StringExpressionMediator operator +(StringFieldExpression a, DoubleFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, DoubleFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, DoubleFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, DoubleFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, DoubleFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region float
        public static StringExpressionMediator operator +(StringFieldExpression a, SingleFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, SingleFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, SingleFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, SingleFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, SingleFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region Guid

        #endregion

        #region short
        public static StringExpressionMediator operator +(StringFieldExpression a, Int16FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, Int16FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, Int16FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, Int16FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, Int16FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region int
        public static StringExpressionMediator operator +(StringFieldExpression a, Int32FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, Int32FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, Int32FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, Int32FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, Int32FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region long
        public static StringExpressionMediator operator +(StringFieldExpression a, Int64FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringFieldExpression a, Int64FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringFieldExpression a, Int64FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringFieldExpression a, Int64FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringFieldExpression a, Int64FieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Modulo)));

        #endregion

        #region string
        public static StringExpressionMediator operator +(StringFieldExpression a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));

        #endregion

        #endregion
        #endregion

        #region filter operators
        #region string
        public static FilterExpression<string> operator ==(StringFieldExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<string> operator !=(StringFieldExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<string> operator <(StringFieldExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<string> operator <=(StringFieldExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<string> operator >(StringFieldExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<string> operator >=(StringFieldExpression a, string b) => new FilterExpression<string>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<string> operator ==(string a, StringFieldExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<string> operator !=(string a, StringFieldExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<string> operator <(string a, StringFieldExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<string> operator <=(string a, StringFieldExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<string> operator >(string a, StringFieldExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<string> operator >=(string a, StringFieldExpression b) => new FilterExpression<string>(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        
        #region mediator
        public static FilterExpression<string> operator ==(StringFieldExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<string> operator !=(StringFieldExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<string> operator <(StringFieldExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<string> operator <=(StringFieldExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<string> operator >(StringFieldExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<string> operator >=(StringFieldExpression a, StringExpressionMediator b) => new FilterExpression<string>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
