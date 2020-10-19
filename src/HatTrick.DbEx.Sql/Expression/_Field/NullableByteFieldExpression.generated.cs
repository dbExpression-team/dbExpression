using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableByteFieldExpression
    {
        #region in value set
        public override FilterExpression<bool> In(params byte[] value) => value is object ? new FilterExpression<bool>(new ByteExpressionMediator(this), new NullableByteExpressionMediator(new InExpression<byte>(value)), FilterExpressionOperator.None) : null;
        public override FilterExpression<bool> In(IEnumerable<byte> value) => value is object ? new FilterExpression<bool>(new ByteExpressionMediator(this), new NullableByteExpressionMediator(new InExpression<byte>(value)), FilterExpressionOperator.None) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(byte value) => new AssignmentExpression(this, new ByteExpressionMediator(new LiteralExpression<byte>(value)));
        public override AssignmentExpression Set(ExpressionMediator<byte> value) => new AssignmentExpression(this, value);
        public override AssignmentExpression Set(byte? value) => new AssignmentExpression(this, new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(value)));
        public override AssignmentExpression Set(NullableExpressionMediator<byte> value) => new AssignmentExpression(this, value);
        public override AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new NullableByteExpressionMediator(new LiteralExpression<byte?>(null)));

        #endregion

        #region insert
        public override InsertExpression Insert(byte value) => new InsertExpression(this, new ByteExpressionMediator(new LiteralExpression<byte>(value)));
        public override InsertExpression Insert(byte? value) => new InsertExpression(this, new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(value)));

        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new NullableByteExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new NullableByteExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<byte?>(NullableByteFieldExpression a) => new SelectExpression<byte?>(new NullableByteExpressionMediator(a));
        public static implicit operator NullableByteExpressionMediator(NullableByteFieldExpression a) => new NullableByteExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableByteFieldExpression a) => new OrderByExpression(new NullableByteExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableByteFieldExpression a) => new GroupByExpression(new NullableByteExpressionMediator(a));
        #endregion

        #region arithmetic operators
        #region data type
        #region byte
        public static NullableByteExpressionMediator operator +(NullableByteFieldExpression a, byte b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(NullableByteFieldExpression a, byte b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(NullableByteFieldExpression a, byte b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(NullableByteFieldExpression a, byte b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(NullableByteFieldExpression a, byte b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(byte a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(byte a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(byte a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(byte a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(byte a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(NullableByteFieldExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(NullableByteFieldExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(NullableByteFieldExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(NullableByteFieldExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(NullableByteFieldExpression a, byte? b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(byte? a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(byte? a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(byte? a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(byte? a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(byte? a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableByteFieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableByteFieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableByteFieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableByteFieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableByteFieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal a, NullableByteFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableByteFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableByteFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableByteFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableByteFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableByteFieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableByteFieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableByteFieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableByteFieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableByteFieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableByteFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableByteFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableByteFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableByteFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableByteFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableByteFieldExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableByteFieldExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableByteFieldExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableByteFieldExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableByteFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableByteFieldExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableByteFieldExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableByteFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableByteFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableByteFieldExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableByteFieldExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableByteFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableByteFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static NullableDoubleExpressionMediator operator +(NullableByteFieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableByteFieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableByteFieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableByteFieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableByteFieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double a, NullableByteFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double a, NullableByteFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double a, NullableByteFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double a, NullableByteFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double a, NullableByteFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableByteFieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableByteFieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableByteFieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableByteFieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableByteFieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, NullableByteFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, NullableByteFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, NullableByteFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, NullableByteFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, NullableByteFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static NullableSingleExpressionMediator operator +(NullableByteFieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableByteFieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableByteFieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableByteFieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableByteFieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableByteFieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableByteFieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableByteFieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableByteFieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableByteFieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static NullableInt16ExpressionMediator operator +(NullableByteFieldExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableByteFieldExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableByteFieldExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableByteFieldExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableByteFieldExpression a, short b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(short a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(short a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(short a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(short a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(short a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableByteFieldExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableByteFieldExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableByteFieldExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableByteFieldExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableByteFieldExpression a, short? b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(short? a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(short? a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(short? a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(short? a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(short? a, NullableByteFieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static NullableInt32ExpressionMediator operator +(NullableByteFieldExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableByteFieldExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableByteFieldExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableByteFieldExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableByteFieldExpression a, int b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableByteFieldExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableByteFieldExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableByteFieldExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableByteFieldExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableByteFieldExpression a, int? b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(int? a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(int? a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(int? a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(int? a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(int? a, NullableByteFieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static NullableInt64ExpressionMediator operator +(NullableByteFieldExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableByteFieldExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableByteFieldExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableByteFieldExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableByteFieldExpression a, long b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableByteFieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableByteFieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableByteFieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableByteFieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableByteFieldExpression a, long? b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(long? a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(long? a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(long? a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(long? a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(long? a, NullableByteFieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region TimeSpan



        #endregion
        
        #endregion

        #region fields

        #region byte
        public static NullableByteExpressionMediator operator +(NullableByteFieldExpression a, ByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(NullableByteFieldExpression a, ByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(NullableByteFieldExpression a, ByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(NullableByteFieldExpression a, ByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(NullableByteFieldExpression a, ByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableByteExpressionMediator operator +(NullableByteFieldExpression a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableByteExpressionMediator operator -(NullableByteFieldExpression a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableByteExpressionMediator operator *(NullableByteFieldExpression a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableByteExpressionMediator operator /(NullableByteFieldExpression a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableByteExpressionMediator operator %(NullableByteFieldExpression a, NullableByteFieldExpression b) => new NullableByteExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableByteFieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableByteFieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableByteFieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableByteFieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableByteFieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableByteFieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableByteFieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableByteFieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableByteFieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableByteFieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableByteFieldExpression a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableByteFieldExpression a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableByteFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableByteFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableByteFieldExpression a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableByteFieldExpression a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableByteFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableByteFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableByteFieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableByteFieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableByteFieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableByteFieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableByteFieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableByteFieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableByteFieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableByteFieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableByteFieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableByteFieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        #region float
        public static NullableSingleExpressionMediator operator +(NullableByteFieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableByteFieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableByteFieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableByteFieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableByteFieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableByteFieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableByteFieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableByteFieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableByteFieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableByteFieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        #region short
        public static NullableInt16ExpressionMediator operator +(NullableByteFieldExpression a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableByteFieldExpression a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableByteFieldExpression a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableByteFieldExpression a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableByteFieldExpression a, Int16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt16ExpressionMediator operator +(NullableByteFieldExpression a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt16ExpressionMediator operator -(NullableByteFieldExpression a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt16ExpressionMediator operator *(NullableByteFieldExpression a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt16ExpressionMediator operator /(NullableByteFieldExpression a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt16ExpressionMediator operator %(NullableByteFieldExpression a, NullableInt16FieldExpression b) => new NullableInt16ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        #region int
        public static NullableInt32ExpressionMediator operator +(NullableByteFieldExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableByteFieldExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableByteFieldExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableByteFieldExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableByteFieldExpression a, Int32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt32ExpressionMediator operator +(NullableByteFieldExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt32ExpressionMediator operator -(NullableByteFieldExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt32ExpressionMediator operator *(NullableByteFieldExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt32ExpressionMediator operator /(NullableByteFieldExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt32ExpressionMediator operator %(NullableByteFieldExpression a, NullableInt32FieldExpression b) => new NullableInt32ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        #region long
        public static NullableInt64ExpressionMediator operator +(NullableByteFieldExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableByteFieldExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableByteFieldExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableByteFieldExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableByteFieldExpression a, Int64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableInt64ExpressionMediator operator +(NullableByteFieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableInt64ExpressionMediator operator -(NullableByteFieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableInt64ExpressionMediator operator *(NullableByteFieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableInt64ExpressionMediator operator /(NullableByteFieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableInt64ExpressionMediator operator %(NullableByteFieldExpression a, NullableInt64FieldExpression b) => new NullableInt64ExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<bool?> operator ==(NullableByteFieldExpression a, DBNull b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>()), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteFieldExpression a, DBNull b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>()), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator ==(DBNull a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>()), new NullableByteExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DBNull a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>()), new NullableByteExpressionMediator(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region byte
        public static FilterExpression<bool?> operator ==(NullableByteFieldExpression a, byte b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteFieldExpression a, byte b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableByteFieldExpression a, byte b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableByteFieldExpression a, byte b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableByteFieldExpression a, byte b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableByteFieldExpression a, byte b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(byte a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new ByteExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(byte a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new ByteExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(byte a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new ByteExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(byte a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new ByteExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(byte a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new ByteExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(byte a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new ByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new ByteExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableByteFieldExpression a, byte? b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteFieldExpression a, byte? b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableByteFieldExpression a, byte? b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableByteFieldExpression a, byte? b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableByteFieldExpression a, byte? b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableByteFieldExpression a, byte? b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(byte? a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(byte? a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(byte? a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(byte? a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(byte? a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(byte? a, NullableByteFieldExpression b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<bool?> operator ==(NullableByteFieldExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteFieldExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableByteFieldExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableByteFieldExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableByteFieldExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableByteFieldExpression a, ByteExpressionMediator b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableByteFieldExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableByteFieldExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableByteFieldExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableByteFieldExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableByteFieldExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableByteFieldExpression a, NullableByteExpressionMediator b) => new FilterExpression<bool?>(new NullableByteExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
