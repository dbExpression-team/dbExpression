using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<string>(StringExpressionMediator a) => new SelectExpression<string>(a.Expression);
        public static implicit operator OrderByExpression(StringExpressionMediator a) => new OrderByExpression(a.Expression, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(StringExpressionMediator a) => new GroupByExpression(a.Expression);
        #endregion

        #region arithmetic operators
        #region TValue
        #region bool



        #endregion

        #region byte
        public static StringExpressionMediator operator +(StringExpressionMediator a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, byte b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(byte a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(byte a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(byte a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(byte a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(byte a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringExpressionMediator a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, byte? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(byte? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(byte? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(byte? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(byte? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(byte? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region decimal
        public static StringExpressionMediator operator +(StringExpressionMediator a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, decimal b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(decimal a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(decimal a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(decimal a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(decimal a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(decimal a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringExpressionMediator a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, decimal? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(decimal? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(decimal? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(decimal? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(decimal? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(decimal? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTime
        public static StringExpressionMediator operator +(StringExpressionMediator a, DateTime b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, DateTime b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, DateTime b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, DateTime b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, DateTime b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(DateTime a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTime a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(DateTime a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(DateTime a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(DateTime a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringExpressionMediator a, DateTime? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, DateTime? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, DateTime? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, DateTime? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, DateTime? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(DateTime? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTime? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(DateTime? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(DateTime? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(DateTime? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region DateTimeOffset
        public static StringExpressionMediator operator +(StringExpressionMediator a, DateTimeOffset b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, DateTimeOffset b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, DateTimeOffset b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, DateTimeOffset b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, DateTimeOffset b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(DateTimeOffset a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTimeOffset a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(DateTimeOffset a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(DateTimeOffset a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(DateTimeOffset a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringExpressionMediator a, DateTimeOffset? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, DateTimeOffset? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, DateTimeOffset? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, DateTimeOffset? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, DateTimeOffset? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(DateTimeOffset? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTimeOffset? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(DateTimeOffset? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(DateTimeOffset? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(DateTimeOffset? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region double
        public static StringExpressionMediator operator +(StringExpressionMediator a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, double b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(double a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(double a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(double a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(double a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(double a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringExpressionMediator a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, double? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(double? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(double? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(double? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(double? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(double? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region float
        public static StringExpressionMediator operator +(StringExpressionMediator a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, float b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(float a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(float a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(float a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(float a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(float a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringExpressionMediator a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, float? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(float? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(float? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(float? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(float? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(float? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region Guid



        #endregion

        #region short
        public static StringExpressionMediator operator +(StringExpressionMediator a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, short b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(short a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(short a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(short a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(short a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(short a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringExpressionMediator a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, short? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(short? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(short? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(short? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(short? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(short? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region int
        public static StringExpressionMediator operator +(StringExpressionMediator a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, int b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(int a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(int a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(int a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(int a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(int a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringExpressionMediator a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, int? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(int? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(int? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(int? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(int? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(int? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region long
        public static StringExpressionMediator operator +(StringExpressionMediator a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, long b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(long a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(long a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(long a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(long a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(long a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(StringExpressionMediator a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(StringExpressionMediator a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(StringExpressionMediator a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(StringExpressionMediator a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(StringExpressionMediator a, long? b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo)));

        public static StringExpressionMediator operator +(long? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(long? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        public static StringExpressionMediator operator *(long? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), b.Expression, ArithmeticExpressionOperator.Multiply)));
        public static StringExpressionMediator operator /(long? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), b.Expression, ArithmeticExpressionOperator.Divide)));
        public static StringExpressionMediator operator %(long? a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), b.Expression, ArithmeticExpressionOperator.Modulo)));
        #endregion

        #region string
        public static StringExpressionMediator operator +(StringExpressionMediator a, string b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add)));

        public static StringExpressionMediator operator +(string a, StringExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<string>(a)), b.Expression, ArithmeticExpressionOperator.Add)));

        #endregion

        #endregion

        #region mediator
        #endregion
        #endregion
    }
}
