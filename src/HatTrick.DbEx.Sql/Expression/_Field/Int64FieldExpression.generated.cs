using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class Int64FieldExpression
    {
        #region in value set
        public override FilterExpression<bool> In(params long[] value) => value is object ? new FilterExpression<bool>(new Int64ExpressionMediator(this), new Int64ExpressionMediator(new InExpression<long>(value)), FilterExpressionOperator.None) : null;
        public override FilterExpression<bool> In(IEnumerable<long> value) => value is object ? new FilterExpression<bool>(new Int64ExpressionMediator(this), new Int64ExpressionMediator(new InExpression<long>(value)), FilterExpressionOperator.None) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(long value) => new AssignmentExpression(this, new Int64ExpressionMediator(new LiteralExpression<long>(value)));
        public override AssignmentExpression Set(ExpressionMediator<long> value) => new AssignmentExpression(this, value);
        #endregion

        #region insert
        public override InsertExpression Insert(long value) => new InsertExpression(this, new Int64ExpressionMediator(new LiteralExpression<long>(value)));
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new Int64ExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new Int64ExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<long>(Int64FieldExpression a) => new SelectExpression<long>(new Int64ExpressionMediator(a));
        public static implicit operator Int64ExpressionMediator(Int64FieldExpression a) => new Int64ExpressionMediator(a);
        public static implicit operator OrderByExpression(Int64FieldExpression a) => new OrderByExpression(new Int64ExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(Int64FieldExpression a) => new GroupByExpression(new Int64ExpressionMediator(a));
        #endregion

        #region arithmetic operators
        #region data type
        #region byte
        public static Int64ExpressionMediator operator +(Int64FieldExpression a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64FieldExpression a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64FieldExpression a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64FieldExpression a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64FieldExpression a, byte b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(byte a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(byte a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(byte a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(byte a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(byte a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64FieldExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64FieldExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64FieldExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64FieldExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64FieldExpression a, byte? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(new LiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(byte? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(byte? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(byte? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(byte? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(byte? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new LiteralExpression<byte?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(Int64FieldExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int64FieldExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int64FieldExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int64FieldExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int64FieldExpression a, decimal b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static DecimalExpressionMediator operator +(decimal a, Int64FieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(decimal a, Int64FieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(decimal a, Int64FieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(decimal a, Int64FieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(decimal a, Int64FieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(Int64FieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(Int64FieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(Int64FieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(Int64FieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(Int64FieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, Int64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, Int64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, Int64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, Int64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, Int64FieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new LiteralExpression<decimal?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(Int64FieldExpression a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(Int64FieldExpression a, DateTime b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeExpressionMediator operator +(DateTime a, Int64FieldExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(DateTime a, Int64FieldExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(Int64FieldExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(Int64FieldExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, Int64FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, Int64FieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(Int64FieldExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(Int64FieldExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, Int64FieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, Int64FieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(Int64FieldExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(Int64FieldExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, Int64FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, Int64FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DoubleExpressionMediator operator +(Int64FieldExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int64FieldExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int64FieldExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int64FieldExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int64FieldExpression a, double b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static DoubleExpressionMediator operator +(double a, Int64FieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(double a, Int64FieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(double a, Int64FieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(double a, Int64FieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(double a, Int64FieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(Int64FieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(Int64FieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(Int64FieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(Int64FieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(Int64FieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDoubleExpressionMediator(new LiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, Int64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, Int64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, Int64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, Int64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, Int64FieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new LiteralExpression<double?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static SingleExpressionMediator operator +(Int64FieldExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int64FieldExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int64FieldExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int64FieldExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int64FieldExpression a, float b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static SingleExpressionMediator operator +(float a, Int64FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(float a, Int64FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(float a, Int64FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(float a, Int64FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(float a, Int64FieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(Int64FieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(Int64FieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(Int64FieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(Int64FieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(Int64FieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableSingleExpressionMediator(new LiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new LiteralExpression<float?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static Int64ExpressionMediator operator +(Int64FieldExpression a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64FieldExpression a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64FieldExpression a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64FieldExpression a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64FieldExpression a, short b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(short a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(short a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(short a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(short a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(short a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64FieldExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64FieldExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64FieldExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64FieldExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64FieldExpression a, short? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(new LiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(short? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(short? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(short? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(short? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(short? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new LiteralExpression<short?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static Int64ExpressionMediator operator +(Int64FieldExpression a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64FieldExpression a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64FieldExpression a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64FieldExpression a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64FieldExpression a, int b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(int a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(int a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(int a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(int a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(int a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64FieldExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64FieldExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64FieldExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64FieldExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64FieldExpression a, int? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(int? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(int? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(int? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(int? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(int? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new LiteralExpression<int?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static Int64ExpressionMediator operator +(Int64FieldExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64FieldExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64FieldExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64FieldExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64FieldExpression a, long b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static Int64ExpressionMediator operator +(long a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(long a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(long a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(long a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(long a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64FieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64FieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64FieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64FieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64FieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string


        #endregion
        
        #endregion

        #region fields
        #region byte
        public static Int64ExpressionMediator operator +(Int64FieldExpression a, ByteFieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64FieldExpression a, ByteFieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64FieldExpression a, ByteFieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64FieldExpression a, ByteFieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64FieldExpression a, ByteFieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64FieldExpression a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64FieldExpression a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64FieldExpression a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64FieldExpression a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64FieldExpression a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static DecimalExpressionMediator operator +(Int64FieldExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DecimalExpressionMediator operator -(Int64FieldExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DecimalExpressionMediator operator *(Int64FieldExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DecimalExpressionMediator operator /(Int64FieldExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DecimalExpressionMediator operator %(Int64FieldExpression a, DecimalFieldExpression b) => new DecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(Int64FieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(Int64FieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(Int64FieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(Int64FieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(Int64FieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static DateTimeExpressionMediator operator +(Int64FieldExpression a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeExpressionMediator operator -(Int64FieldExpression a, DateTimeFieldExpression b) => new DateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(Int64FieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(Int64FieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(Int64FieldExpression a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(Int64FieldExpression a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(Int64FieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(Int64FieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DoubleExpressionMediator operator +(Int64FieldExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static DoubleExpressionMediator operator -(Int64FieldExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static DoubleExpressionMediator operator *(Int64FieldExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static DoubleExpressionMediator operator /(Int64FieldExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static DoubleExpressionMediator operator %(Int64FieldExpression a, DoubleFieldExpression b) => new DoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(Int64FieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(Int64FieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(Int64FieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(Int64FieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(Int64FieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static SingleExpressionMediator operator +(Int64FieldExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static SingleExpressionMediator operator -(Int64FieldExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static SingleExpressionMediator operator *(Int64FieldExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static SingleExpressionMediator operator /(Int64FieldExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static SingleExpressionMediator operator %(Int64FieldExpression a, SingleFieldExpression b) => new SingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(Int64FieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(Int64FieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(Int64FieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(Int64FieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(Int64FieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static Int64ExpressionMediator operator +(Int64FieldExpression a, Int16FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64FieldExpression a, Int16FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64FieldExpression a, Int16FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64FieldExpression a, Int16FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64FieldExpression a, Int16FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64FieldExpression a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64FieldExpression a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64FieldExpression a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64FieldExpression a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64FieldExpression a, NullableInt16FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static Int64ExpressionMediator operator +(Int64FieldExpression a, Int32FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64FieldExpression a, Int32FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64FieldExpression a, Int32FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64FieldExpression a, Int32FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64FieldExpression a, Int32FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64FieldExpression a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64FieldExpression a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64FieldExpression a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64FieldExpression a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64FieldExpression a, NullableInt32FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static Int64ExpressionMediator operator +(Int64FieldExpression a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static Int64ExpressionMediator operator -(Int64FieldExpression a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static Int64ExpressionMediator operator *(Int64FieldExpression a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static Int64ExpressionMediator operator /(Int64FieldExpression a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static Int64ExpressionMediator operator %(Int64FieldExpression a, Int64FieldExpression b) => new Int64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(Int64FieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(Int64FieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(Int64FieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(Int64FieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(Int64FieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region string

        #endregion
        
        #endregion
        #endregion

        #region filter operators
        #region long
        public static FilterExpression<bool> operator ==(Int64FieldExpression a, long b) => new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Int64FieldExpression a, long b) => new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(Int64FieldExpression a, long b) => new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(Int64FieldExpression a, long b) => new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(Int64FieldExpression a, long b) => new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(Int64FieldExpression a, long b) => new FilterExpression<bool>(new Int64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool> operator ==(long a, Int64FieldExpression b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(long a, Int64FieldExpression b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(long a, Int64FieldExpression b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(long a, Int64FieldExpression b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(long a, Int64FieldExpression b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(long a, Int64FieldExpression b) => new FilterExpression<bool>(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(Int64FieldExpression a, long? b) => new FilterExpression<bool?>(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(Int64FieldExpression a, long? b) => new FilterExpression<bool?>(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(Int64FieldExpression a, long? b) => new FilterExpression<bool?>(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(Int64FieldExpression a, long? b) => new FilterExpression<bool?>(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(Int64FieldExpression a, long? b) => new FilterExpression<bool?>(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(Int64FieldExpression a, long? b) => new FilterExpression<bool?>(new Int64ExpressionMediator(a), new NullableInt64ExpressionMediator(new LiteralExpression<long?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(long? a, Int64FieldExpression b) => new FilterExpression<bool?>(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(long? a, Int64FieldExpression b) => new FilterExpression<bool?>(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(long? a, Int64FieldExpression b) => new FilterExpression<bool?>(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(long? a, Int64FieldExpression b) => new FilterExpression<bool?>(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(long? a, Int64FieldExpression b) => new FilterExpression<bool?>(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(long? a, Int64FieldExpression b) => new FilterExpression<bool?>(new NullableInt64ExpressionMediator(new LiteralExpression<long?>(a)), new Int64ExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<bool> operator ==(Int64FieldExpression a, Int64ExpressionMediator b) => new FilterExpression<bool>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool> operator !=(Int64FieldExpression a, Int64ExpressionMediator b) => new FilterExpression<bool>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool> operator <(Int64FieldExpression a, Int64ExpressionMediator b) => new FilterExpression<bool>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool> operator <=(Int64FieldExpression a, Int64ExpressionMediator b) => new FilterExpression<bool>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool> operator >(Int64FieldExpression a, Int64ExpressionMediator b) => new FilterExpression<bool>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool> operator >=(Int64FieldExpression a, Int64ExpressionMediator b) => new FilterExpression<bool>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(Int64FieldExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(Int64FieldExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(Int64FieldExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(Int64FieldExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(Int64FieldExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(Int64FieldExpression a, NullableInt64ExpressionMediator b) => new FilterExpression<bool?>(new Int64ExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
