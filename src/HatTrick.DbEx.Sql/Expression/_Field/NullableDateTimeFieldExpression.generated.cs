using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeFieldExpression
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTime?>(NullableDateTimeFieldExpression a) => new SelectExpression<DateTime?>(new ExpressionContainer(a));
        public static implicit operator NullableDateTimeExpressionMediator(NullableDateTimeFieldExpression a) => new NullableDateTimeExpressionMediator(new ExpressionContainer(a));
        public static implicit operator OrderByExpression(NullableDateTimeFieldExpression a) => new OrderByExpression(new ExpressionContainer(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableDateTimeFieldExpression a) => new GroupByExpression(new ExpressionContainer(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, byte b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, byte b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(byte a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(byte a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, byte? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, byte? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(byte? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(byte? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, decimal b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, decimal b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(decimal a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(decimal a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, decimal? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, decimal? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(decimal? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(decimal? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeOffset b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeOffset b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeOffset a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeOffset a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeOffset? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeOffset? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeOffset? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeOffset? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, double b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, double b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(double a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(double a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, double? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, double? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(double? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(double? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, float b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, float b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(float a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(float a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, float? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, float? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(float? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(float? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, short b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, short b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(short a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(short a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, short? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, short? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(short? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(short? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, int b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, int b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(int a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(int a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, int? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, int? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(int? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(int? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, long b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, long b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(long a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(long a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, long? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, long? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(long? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(long? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #endregion

        #region mediator
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, ByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, ByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DecimalFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DecimalFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDecimalFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDecimalFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DoubleFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DoubleFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDoubleFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDoubleFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, SingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, SingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableSingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableSingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, Int16FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, Int16FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableInt16FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableInt16FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, Int32FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, Int32FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableInt32FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableInt32FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, Int64FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, Int64FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableInt64FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableInt64FieldExpression b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(a), new ExpressionContainer(b), ArithmeticExpressionOperator.Subtract)));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<DateTime?> operator ==(NullableDateTimeFieldExpression a, DBNull b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(b, typeof(DBNull)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime?> operator !=(NullableDateTimeFieldExpression a, DBNull b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(b, typeof(DBNull)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime?> operator ==(DBNull a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(a, typeof(DBNull)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime?> operator !=(DBNull a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(a, typeof(DBNull)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region DateTime
        public static FilterExpression<DateTime?> operator ==(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime?> operator !=(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime?> operator <(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime?> operator <=(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime?> operator >(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime?> operator >=(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime?> operator !=(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime?> operator <(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime?> operator <=(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime?> operator >(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime?> operator >=(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime?> operator !=(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime?> operator <(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime?> operator <=(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime?> operator >(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime?> operator >=(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), new ExpressionContainer(new LiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime?> operator !=(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime?> operator <(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime?> operator <=(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime?> operator >(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime?> operator >=(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<DateTime?>(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), new ExpressionContainer(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<DateTime?> operator ==(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime?> operator !=(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime?> operator <(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime?> operator <=(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime?> operator >(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime?> operator >=(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<DateTime?> operator ==(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.Equal);
        public static FilterExpression<DateTime?> operator !=(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.NotEqual);
        public static FilterExpression<DateTime?> operator <(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThan);
        public static FilterExpression<DateTime?> operator <=(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<DateTime?> operator >(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<DateTime?> operator >=(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<DateTime?>(new ExpressionContainer(a), b.Expression, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
