using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeExpressionMediator
    {
        #region implicit operators
        public static implicit operator SelectExpression<DateTime?>(NullableDateTimeExpressionMediator a) => new SelectExpression<DateTime?>(a.Expression);
        public static implicit operator OrderByExpression(NullableDateTimeExpressionMediator a) => new OrderByExpression(a.Expression, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableDateTimeExpressionMediator a) => new GroupByExpression(a.Expression);
        #endregion

        #region arithmetic operators 
        #region TValue
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, byte b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, byte b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(byte a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(byte a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, byte? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, byte? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(byte? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(byte? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<byte?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, decimal b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, decimal b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(decimal a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(decimal a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, decimal? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, decimal? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(decimal? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(decimal? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<decimal?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTime b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTime b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTime? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTime? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTime?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTimeOffset b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTimeOffset b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeOffset a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeOffset a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTimeOffset? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTimeOffset? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(DateTimeOffset? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(DateTimeOffset? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<DateTimeOffset?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, double b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, double b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(double a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(double a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, double? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, double? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(double? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(double? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<double?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, float b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, float b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(float a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(float a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, float? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, float? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(float? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(float? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<float?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, short b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, short b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(short a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(short a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, short? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, short? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(short? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(short? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<short?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, int b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, int b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(int a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(int a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, int? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, int? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(int? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(int? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<int?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, long b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, long b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(long a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(long a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, long? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, long? b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, new ExpressionContainer(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(long? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(long? a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(new ExpressionContainer(new LiteralExpression<long?>(a)), b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion


        #endregion

        #region mediator
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, ByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, ByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableByteExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableDecimalExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableDateTimeExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DateTimeOffsetExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region double
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, DoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, DoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableDoubleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, SingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, SingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableSingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableSingleExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, Int16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, Int16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableInt16ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, Int32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, Int32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableInt32ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion

        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, Int64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, Int64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Add)));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeExpressionMediator a, NullableInt64ExpressionMediator b) => new NullableDateTimeExpressionMediator(new ExpressionContainer(new ArithmeticExpression(a.Expression, b.Expression, ArithmeticExpressionOperator.Subtract)));
        #endregion


        #endregion
        #endregion
    }
}
