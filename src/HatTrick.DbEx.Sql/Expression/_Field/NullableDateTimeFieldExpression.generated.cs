using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableDateTimeFieldExpression
    {
        #region in value set
        public override FilterExpression In(params DateTime[] value) => value is object ? new FilterExpression<DateTime>(new NullableDateTimeExpressionMediator(this), new DateTimeExpressionMediator(new LiteralExpression<DateTime[]>(value)), FilterExpressionOperator.In) : null;
        #endregion

        #region isnull
        public override FilterExpression<bool> IsNull() => new FilterExpression<bool>(new NullableDateTimeExpressionMediator(this), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>()), FilterExpressionOperator.Equal);
        public override FilterExpression<bool> IsNotNull() => new FilterExpression<bool>(new NullableDateTimeExpressionMediator(this), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>()), FilterExpressionOperator.NotEqual);
        #endregion

        #region set
        public override AssignmentExpression Set(DateTime value) => new AssignmentExpression(this, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)));
        public override AssignmentExpression Set(ExpressionMediator<DateTime> value) => new AssignmentExpression(this, value);
        public override AssignmentExpression Set(DateTime? value) => new AssignmentExpression(this, new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(value)));
        public override AssignmentExpression Set(NullableExpressionMediator<DateTime> value) => new AssignmentExpression(this, value);
        #endregion

        #region insert
        public override InsertExpression Insert(DateTime value) => new InsertExpression(this, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(value)));
        public override InsertExpression Insert(DateTime? value) => new InsertExpression(this, new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(value)));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new NullableDateTimeExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new NullableDateTimeExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<DateTime?>(NullableDateTimeFieldExpression a) => new SelectExpression<DateTime?>(new NullableDateTimeExpressionMediator(a));
        public static implicit operator NullableDateTimeExpressionMediator(NullableDateTimeFieldExpression a) => new NullableDateTimeExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableDateTimeFieldExpression a) => new OrderByExpression(new NullableDateTimeExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableDateTimeFieldExpression a) => new GroupByExpression(new NullableDateTimeExpressionMediator(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, byte b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, byte b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(byte a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(byte a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, byte? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, byte? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(byte? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(byte? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, decimal b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, decimal b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(decimal a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(decimal a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, decimal? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, decimal? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(decimal? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(decimal? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeOffset b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeOffset b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeOffset a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeOffset a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeOffset? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeOffset? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTimeOffset? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTimeOffset? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, double b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, double b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(double a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(double a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, double? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, double? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(double? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(double? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, float b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, float b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(float a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(float a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, float? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, float? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(float? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(float? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, short b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, short b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(short a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(short a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, short? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, short? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(short? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(short? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, int b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, int b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(int a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(int a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, int? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, int? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(int? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(int? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, long b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, long b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(long a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(long a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, long? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, long? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(long? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(long? a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #endregion

        #region mediator
        #region byte
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, ByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, ByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region decimal
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DecimalFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DecimalFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDecimalFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDecimalFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region DateTimeOffset
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DateTimeOffsetFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region double
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, DoubleFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, DoubleFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableDoubleFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableDoubleFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region float
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, SingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, SingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableSingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableSingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region short
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, Int16FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, Int16FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableInt16FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableInt16FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region int
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, Int32FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, Int32FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableInt32FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableInt32FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #region long
        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, Int64FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, Int64FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableDateTimeFieldExpression a, NullableInt64FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableDateTimeFieldExpression a, NullableInt64FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, DBNull b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>()), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, DBNull b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>()), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator ==(DBNull a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>()), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DBNull a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>()), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region DateTime
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, DateTime b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DateTime a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new DateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new DateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, DateTime? b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(DateTime? a, NullableDateTimeFieldExpression b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, DateTimeExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableDateTimeFieldExpression a, NullableDateTimeExpressionMediator b) => new FilterExpression<bool?>(new NullableDateTimeExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
