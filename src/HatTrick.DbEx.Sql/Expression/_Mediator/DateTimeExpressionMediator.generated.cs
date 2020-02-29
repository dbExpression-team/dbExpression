using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTime>(DateTimeExpressionMediator a) => new SelectExpression<DateTime>(a.Expression);
        public static implicit operator OrderByExpression(DateTimeExpressionMediator a) => new OrderByExpression(a.Expression, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(DateTimeExpressionMediator a) => new GroupByExpression(a.Expression);
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, byte b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, byte b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(byte a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(byte a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, byte? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, byte? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(byte? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(byte? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, decimal b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, decimal b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(decimal a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(decimal a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, decimal? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, decimal? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(decimal? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(decimal? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTime b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTime b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTime a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTime a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTime? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTime? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTime? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTime? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTimeOffset b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTimeOffset b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeOffset a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeOffset a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTimeOffset? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTimeOffset? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeOffset? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeOffset? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, double b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, double b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(double a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(double a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, double? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, double? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(double? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(double? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, float b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, float b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(float a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(float a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, float? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, float? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(float? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(float? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, short b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, short b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(short a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(short a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, short? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, short? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(short? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(short? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, int b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, int b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(int a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(int a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, int? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, int? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(int? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(int? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, long b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, long b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(long a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(long a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, long? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, long? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(long? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(long? a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region string
        public static StringExpressionMediator operator +(DateTimeExpressionMediator a, string b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTimeExpressionMediator a, string b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Subtract)));

        public static StringExpressionMediator operator +(string a, DateTimeExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<string>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(string a, DateTimeExpressionMediator b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<string>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        #endregion

        #endregion

        #region mediator
        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, ByteExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, ByteExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DecimalExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DecimalExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableSingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableSingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, Int16ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, Int16ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, Int32ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, Int32ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static DateTimeExpressionMediator operator +(DateTimeExpressionMediator a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeExpressionMediator a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #endregion
        #endregion
    }
}
