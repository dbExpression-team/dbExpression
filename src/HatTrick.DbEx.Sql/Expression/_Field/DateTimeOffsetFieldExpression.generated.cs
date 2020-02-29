using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetFieldExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTimeOffset>(DateTimeOffsetFieldExpression a) => new SelectExpression<DateTimeOffset>(new ExpressionContainer(a));
        public static implicit operator DateTimeOffsetExpressionMediator(DateTimeOffsetFieldExpression a) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(DateTimeOffsetFieldExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(DateTimeOffsetFieldExpression a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, byte b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, byte b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(byte a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(byte a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, byte? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, byte? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(byte? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(byte? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, decimal b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, decimal b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(decimal a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(decimal a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, decimal? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, decimal? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(decimal? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(decimal? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTime b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTime b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTime a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTime a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTime? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTime? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTime? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTime? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, double b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, double b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(double a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(double a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, double? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, double? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(double? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(double? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, float b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, float b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(float a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(float a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, float? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, float? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(float? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(float? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, short b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, short b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(short a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(short a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, short? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, short? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(short? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(short? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, int b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, int b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(int a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(int a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, int? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, int? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(int? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(int? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, long b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, long b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(long a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(long a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, long? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, long? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(long? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(long? a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region string
        public static StringExpressionMediator operator +(DateTimeOffsetFieldExpression a, string b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTimeOffsetFieldExpression a, string b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Subtract)));

        public static StringExpressionMediator operator +(string a, DateTimeOffsetFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(string a, DateTimeOffsetFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        #endregion

        #endregion

        #region mediator
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, ByteFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, ByteFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableByteFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableByteFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DecimalFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DecimalFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableDecimalFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableDecimalFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTimeFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTimeFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DoubleFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DoubleFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableDoubleFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableDoubleFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, SingleFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, SingleFieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableSingleFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableSingleFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, Int16FieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, Int16FieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableInt16FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableInt16FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, Int32FieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, Int32FieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableInt32FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableInt32FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, Int64FieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, Int64FieldExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableInt64FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableInt64FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region string
        public static StringExpressionMediator operator +(DateTimeOffsetFieldExpression a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static StringExpressionMediator operator -(DateTimeOffsetFieldExpression a, StringFieldExpression b) => new StringExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        #endregion

        #endregion
        #endregion

        #region filter operators
        #region DateTimeOffset
        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<DateTimeOffset> operator ==(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset> operator !=(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset> operator <(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset> operator <=(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset> operator >(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset> operator >=(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTimeOffset?> operator ==(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTimeOffset?> operator !=(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTimeOffset?> operator <(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTimeOffset?> operator <=(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTimeOffset?> operator >(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTimeOffset?> operator >=(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpression<DateTimeOffset?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
