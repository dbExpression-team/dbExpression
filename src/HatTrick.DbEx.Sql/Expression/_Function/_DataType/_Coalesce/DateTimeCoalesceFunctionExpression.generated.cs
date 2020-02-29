
using System;


namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeCoalesceFunctionExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTime>(DateTimeCoalesceFunctionExpression a) => new SelectExpression<DateTime>(new ExpressionContainer(a));
        public static implicit operator DateTimeExpressionMediator(DateTimeCoalesceFunctionExpression a) => new DateTimeExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(DateTimeCoalesceFunctionExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(DateTimeCoalesceFunctionExpression a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #region bool



        #endregion

        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, byte b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, byte b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(byte a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(byte a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, byte? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, byte? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(byte? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(byte? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, decimal b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, decimal b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(decimal a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(decimal a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, decimal? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, decimal? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(decimal? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(decimal? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, DateTime b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, DateTime b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTime a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTime a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, DateTime? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, DateTime? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTime? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTime? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, DateTimeCoalesceFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, DateTimeCoalesceFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, DateTimeOffset? b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, DateTimeCoalesceFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, DateTimeCoalesceFunctionExpression b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, double b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, double b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(double a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(double a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, double? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, double? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(double? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(double? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, float b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, float b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(float a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(float a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, float? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, float? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(float? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(float? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region Guid



        #endregion

        #region short
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, short b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, short b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(short a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(short a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, short? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, short? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(short? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(short? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, int b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, int b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(int a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(int a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, int? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, int? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(int? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(int? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, long b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, long b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(long a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(long a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, long? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, long? b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(long? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(long? a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region string
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, string b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, string b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Subtract)));

        public static DateTimeExpressionMediator operator +(string a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(string a, DateTimeCoalesceFunctionExpression b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<string>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));


        #endregion

        #endregion

        #region mediator
        #region bool

        #endregion

        #region byte
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, ByteExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, ByteExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, NullableByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, DecimalExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, DecimalExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, DateTimeExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, DoubleExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, SingleExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region Guid

        #endregion

        #region short
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, Int16ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, Int16ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, Int32ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, Int32ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, Int64ExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region string
        public static DateTimeExpressionMediator operator +(DateTimeCoalesceFunctionExpression a, StringExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Add)));
        public static DateTimeExpressionMediator operator -(DateTimeCoalesceFunctionExpression a, StringExpressionMediator b) => new DateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), b.Expression, ArithmeticExpressionOperator.Subtract)));

        #endregion

        #endregion
        #endregion

        #region filter operators
        #region TValue
        #region DateTime
        public static FilterExpression<DateTime> operator ==(DateTimeCoalesceFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTimeCoalesceFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTimeCoalesceFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTimeCoalesceFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTimeCoalesceFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTimeCoalesceFunctionExpression a, DateTime b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTime a, DateTimeCoalesceFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTime a, DateTimeCoalesceFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTime a, DateTimeCoalesceFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTime a, DateTimeCoalesceFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTime a, DateTimeCoalesceFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTime a, DateTimeCoalesceFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTimeCoalesceFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTimeCoalesceFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTimeCoalesceFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTimeCoalesceFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTimeCoalesceFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTimeCoalesceFunctionExpression a, DateTime? b) => new FilterExpression<DateTime>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime> operator ==(DateTime? a, DateTimeCoalesceFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTime? a, DateTimeCoalesceFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTime? a, DateTimeCoalesceFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTime? a, DateTimeCoalesceFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTime? a, DateTimeCoalesceFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTime? a, DateTimeCoalesceFunctionExpression b) => new FilterExpression<DateTime>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion

        #region mediator
        public static FilterExpression<DateTime> operator ==(DateTimeCoalesceFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime> operator !=(DateTimeCoalesceFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime> operator <(DateTimeCoalesceFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime> operator <=(DateTimeCoalesceFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime> operator >(DateTimeCoalesceFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime> operator >=(DateTimeCoalesceFunctionExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(DateTimeCoalesceFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime?> operator !=(DateTimeCoalesceFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime?> operator <(DateTimeCoalesceFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime?> operator <=(DateTimeCoalesceFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime?> operator >(DateTimeCoalesceFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime?> operator >=(DateTimeCoalesceFunctionExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
