using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeFieldExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTime>(DateTimeFieldExpression a) => new SelectExpression<DateTime>(new ExpressionContainer(a));
        public static implicit operator DateTimeExpressionMediator(DateTimeFieldExpression a) => new DateTimeExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(DateTimeFieldExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(DateTimeFieldExpression a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, byte b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, byte b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(byte a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(byte a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, byte? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, byte? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(byte? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(byte? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, decimal b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, decimal b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(decimal a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(decimal a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, decimal? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, decimal? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(decimal? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(decimal? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, DateTime b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, DateTime b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTime a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTime a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, DateTime? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, DateTime? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTime? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTime? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, DateTimeOffset b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, DateTimeOffset b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeOffset a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeOffset a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, DateTimeOffset? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, DateTimeOffset? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeOffset? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeOffset? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, double b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, double b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(double a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(double a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, double? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, double? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(double? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(double? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, float b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, float b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(float a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(float a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, float? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, float? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(float? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(float? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, short b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, short b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(short a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(short a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, short? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, short? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(short? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(short? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, int b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, int b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(int a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(int a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, int? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, int? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(int? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(int? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, long b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, long b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(long a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(long a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, long? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, long? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(long? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(long? a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region string
        public static StringExpressionMediator operator +(DateTimeFieldExpression a, string b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTimeFieldExpression a, string b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Subtract)));

        public static StringExpressionMediator operator +(string a, DateTimeFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(string a, DateTimeFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        #endregion

        #endregion

        #region mediator
        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, ByteFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, ByteFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeFieldExpression a, NullableByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeFieldExpression a, NullableByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, DecimalFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, DecimalFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeFieldExpression a, NullableDecimalFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeFieldExpression a, NullableDecimalFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, DoubleFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, DoubleFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeFieldExpression a, NullableDoubleFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeFieldExpression a, NullableDoubleFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, SingleFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, SingleFieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeFieldExpression a, NullableSingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeFieldExpression a, NullableSingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, Int16FieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, Int16FieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeFieldExpression a, NullableInt16FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeFieldExpression a, NullableInt16FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, Int32FieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, Int32FieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeFieldExpression a, NullableInt32FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeFieldExpression a, NullableInt32FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static DateTimeExpressionMediator operator +(DateTimeFieldExpression a, Int64FieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeFieldExpression a, Int64FieldExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeFieldExpression a, NullableInt64FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeFieldExpression a, NullableInt64FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region string
        public static StringExpressionMediator operator +(DateTimeFieldExpression a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTimeFieldExpression a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        #endregion

        #endregion
        #endregion

        #region filter operators
        #region DateTime
        public static FilterExpression<DateTime> operator ==(DateTimeFieldExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTimeFieldExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTimeFieldExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTimeFieldExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTimeFieldExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTimeFieldExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTime a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTime a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTime a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTime a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTime a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTime a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTimeFieldExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTimeFieldExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTimeFieldExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTimeFieldExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTimeFieldExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTimeFieldExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTime? a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTime? a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTime? a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTime? a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTime? a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTime? a, DateTimeFieldExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<DateTime> operator ==(DateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(DateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime?> operator !=(DateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime?> operator <(DateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime?> operator <=(DateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime?> operator >(DateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime?> operator >=(DateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
