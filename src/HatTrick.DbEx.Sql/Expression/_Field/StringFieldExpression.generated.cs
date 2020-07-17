using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class StringFieldExpression
    {
        #region in value set
        public override FilterExpression In(params string[] value) => value is object ? new FilterExpression<string>(new StringExpressionMediator(this), new StringExpressionMediator(new LiteralExpression<string[]>(value)), FilterExpressionOperator.In) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(string value) => new AssignmentExpression(new StringExpressionMediator(this), new StringExpressionMediator(new LiteralExpression<string>(value)));
        public override AssignmentExpression Set(ExpressionMediator<string> value) => new AssignmentExpression(new StringExpressionMediator(this), value);
        #endregion

        #region insert
        public override InsertExpression Insert(string value) => new InsertExpression(this, new StringExpressionMediator(new LiteralExpression<string>(value)));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new StringExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new StringExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<string>(StringFieldExpression a) => new SelectExpression<string>(new StringExpressionMediator(a));
        public static implicit operator StringExpressionMediator(StringFieldExpression a) => new StringExpressionMediator(a);
        public static implicit operator OrderByExpression(StringFieldExpression a) => new OrderByExpression(new StringExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(StringFieldExpression a) => new GroupByExpression(new StringExpressionMediator(a));
        #endregion

        #region arithmetic operators
        #region TValue
        #region bool



        #endregion

        #region byte
        public static StringExpressionMediator operator +(StringFieldExpression a, byte b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, byte b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, byte b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, byte b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, byte b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(byte a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(byte a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(byte a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(byte a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(byte a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringFieldExpression a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, byte? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(byte? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(byte? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(byte? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(byte? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(byte? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region decimal
        public static StringExpressionMediator operator +(StringFieldExpression a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, decimal b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(decimal a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(decimal a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(decimal a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(decimal a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(decimal a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringFieldExpression a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, decimal? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(decimal? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(decimal? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(decimal? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(decimal? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(decimal? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTime
        public static StringExpressionMediator operator +(StringFieldExpression a, DateTime b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, DateTime b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, DateTime b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, DateTime b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, DateTime b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(DateTime a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(DateTime a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(DateTime a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(DateTime a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(DateTime a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringFieldExpression a, DateTime? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, DateTime? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, DateTime? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, DateTime? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, DateTime? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(DateTime? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(DateTime? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(DateTime? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(DateTime? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(DateTime? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region DateTimeOffset
        public static StringExpressionMediator operator +(StringFieldExpression a, DateTimeOffset b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, DateTimeOffset b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, DateTimeOffset b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, DateTimeOffset b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, DateTimeOffset b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(DateTimeOffset a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(DateTimeOffset a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(DateTimeOffset a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(DateTimeOffset a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(DateTimeOffset a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringFieldExpression a, DateTimeOffset? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, DateTimeOffset? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, DateTimeOffset? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, DateTimeOffset? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, DateTimeOffset? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(DateTimeOffset? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(DateTimeOffset? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(DateTimeOffset? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(DateTimeOffset? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(DateTimeOffset? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region double
        public static StringExpressionMediator operator +(StringFieldExpression a, double b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, double b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, double b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, double b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, double b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(double a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(double a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(double a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(double a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(double a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringFieldExpression a, double? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, double? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, double? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, double? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, double? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(double? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(double? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(double? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(double? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(double? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region float
        public static StringExpressionMediator operator +(StringFieldExpression a, float b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, float b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, float b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, float b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, float b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(float a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(float a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(float a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(float a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(float a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringFieldExpression a, float? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, float? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, float? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, float? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, float? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(float? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(float? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(float? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(float? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(float? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region Guid



        #endregion

        #region short
        public static StringExpressionMediator operator +(StringFieldExpression a, short b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, short b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, short b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, short b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, short b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(short a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(short a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(short a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(short a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(short a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringFieldExpression a, short? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, short? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, short? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, short? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, short? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(short? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(short? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(short? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(short? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(short? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region int
        public static StringExpressionMediator operator +(StringFieldExpression a, int b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, int b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, int b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, int b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, int b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(int a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(int a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(int a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(int a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(int a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringFieldExpression a, int? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, int? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, int? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, int? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, int? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(int? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(int? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(int? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(int? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(int? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region long
        public static StringExpressionMediator operator +(StringFieldExpression a, long b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, long b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, long b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, long b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, long b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(long a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(long a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(long a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(long a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(long a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(StringFieldExpression a, long? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, long? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, long? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, long? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, long? b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static StringExpressionMediator operator +(long? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(long? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(long? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(long? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(long? a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        #region string
        public static StringExpressionMediator operator +(StringFieldExpression a, string b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), ArithmeticExpressionOperator.Add));

        public static StringExpressionMediator operator +(string a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));

        #endregion

        #endregion

        #region mediator
        #region bool

        #endregion

        #region byte
        public static StringExpressionMediator operator +(StringFieldExpression a, ByteFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, ByteFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, ByteFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, ByteFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, ByteFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        #endregion

        #region decimal
        public static StringExpressionMediator operator +(StringFieldExpression a, DecimalFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, DecimalFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, DecimalFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, DecimalFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, DecimalFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        #endregion

        #region DateTime
        public static StringExpressionMediator operator +(StringFieldExpression a, DateTimeFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, DateTimeFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, DateTimeFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, DateTimeFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, DateTimeFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        #endregion

        #region DateTimeOffset
        public static StringExpressionMediator operator +(StringFieldExpression a, DateTimeOffsetFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, DateTimeOffsetFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, DateTimeOffsetFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, DateTimeOffsetFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, DateTimeOffsetFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        #endregion

        #region double
        public static StringExpressionMediator operator +(StringFieldExpression a, DoubleFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, DoubleFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, DoubleFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, DoubleFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, DoubleFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        #endregion

        #region float
        public static StringExpressionMediator operator +(StringFieldExpression a, SingleFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, SingleFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, SingleFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, SingleFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, SingleFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        #endregion

        #region Guid

        #endregion

        #region short
        public static StringExpressionMediator operator +(StringFieldExpression a, Int16FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, Int16FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, Int16FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, Int16FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, Int16FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        #endregion

        #region int
        public static StringExpressionMediator operator +(StringFieldExpression a, Int32FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, Int32FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, Int32FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, Int32FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, Int32FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        #endregion

        #region long
        public static StringExpressionMediator operator +(StringFieldExpression a, Int64FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static StringExpressionMediator operator -(StringFieldExpression a, Int64FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static StringExpressionMediator operator *(StringFieldExpression a, Int64FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static StringExpressionMediator operator /(StringFieldExpression a, Int64FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static StringExpressionMediator operator %(StringFieldExpression a, Int64FieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        #endregion

        #region string
        public static StringExpressionMediator operator +(StringFieldExpression a, StringFieldExpression b) => new StringExpressionMediator(new ArithmeticExpression(new StringExpressionMediator(a), new StringExpressionMediator(b), ArithmeticExpressionOperator.Add));

        #endregion

        #endregion
        #endregion

        #region filter operators
        #region string
        public static FilterExpression<bool> operator ==(StringFieldExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(StringFieldExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(StringFieldExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(StringFieldExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(StringFieldExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(StringFieldExpression a, string b) => new FilterExpression<bool>(new StringExpressionMediator(a), new StringExpressionMediator(new LiteralExpression<string>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(string a, StringFieldExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(string a, StringFieldExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(string a, StringFieldExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(string a, StringFieldExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(string a, StringFieldExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(string a, StringFieldExpression b) => new FilterExpression<bool>(new StringExpressionMediator(new LiteralExpression<string>(a)), new StringExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        
        #region mediator
        public static FilterExpression<bool> operator ==(StringFieldExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(StringFieldExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(StringFieldExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(StringFieldExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(StringFieldExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(StringFieldExpression a, StringExpressionMediator b) => new FilterExpression<bool>(new StringExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        #endregion
        #endregion
    }
}
