using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTimeOffset>(DateTimeOffsetExpressionMediator a) => new SelectExpression<DateTimeOffset>(a.Expression);
        public static implicit operator OrderByExpression(DateTimeOffsetExpressionMediator a) => new OrderByExpression(a.Expression, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(DateTimeOffsetExpressionMediator a) => new GroupByExpression(a.Expression);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, byte b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, byte b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(byte a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(byte a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, byte? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, byte? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(byte? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(byte? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, decimal b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, decimal b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(decimal a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(decimal a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, decimal? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, decimal? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(decimal? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(decimal? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, DateTime b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, DateTime b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTime a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTime a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, DateTime? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, DateTime? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTime? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTime? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, double b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, double b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(double a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(double a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, double? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, double? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(double? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(double? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, float b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, float b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(float a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(float a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, float? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, float? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(float? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(float? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, short b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, short b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(short a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(short a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, short? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, short? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(short? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(short? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, int b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, int b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(int a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(int a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, int? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, int? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(int? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(int? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, long b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, long b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(long a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(long a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, long? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, long? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(long? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(long? a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region string
        public static StringExpressionMediator operator +(DateTimeOffsetExpressionMediator a, string b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTimeOffsetExpressionMediator a, string b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Subtract)));

        public static StringExpressionMediator operator +(string a, DateTimeOffsetExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<string>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(string a, DateTimeOffsetExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<string>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        #endregion

        #endregion

        #region mediator
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, ByteExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, ByteExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, DecimalExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, DecimalExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, DateTimeExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, DateTimeExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, Int16ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, Int16ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, Int32ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, Int32ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #endregion
        #endregion
    }
}
