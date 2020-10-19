using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableSingleFieldExpression
    {
        #region in value set
        public override FilterExpression<bool> In(params float[] value) => value is object ? new FilterExpression<bool>(new SingleExpressionMediator(this), new NullableSingleExpressionMediator(new InExpression<float>(value)), FilterExpressionOperator.None) : null;
        public override FilterExpression<bool> In(IEnumerable<float> value) => value is object ? new FilterExpression<bool>(new SingleExpressionMediator(this), new NullableSingleExpressionMediator(new InExpression<float>(value)), FilterExpressionOperator.None) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(float value) => new AssignmentExpression(this, new SingleExpressionMediator(new LiteralExpression<float>(value)));
        public override AssignmentExpression Set(ExpressionMediator<float> value) => new AssignmentExpression(this, value);
        public override AssignmentExpression Set(float? value) => new AssignmentExpression(this, new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(value)));
        public override AssignmentExpression Set(NullableExpressionMediator<float> value) => new AssignmentExpression(this, value);
        public override AssignmentExpression Set(DBNull value) => new AssignmentExpression(this, new NullableSingleExpressionMediator(new LiteralExpression<float?>(null)));

        #endregion

        #region insert
        public override InsertExpression Insert(float value) => new InsertExpression(this, new SingleExpressionMediator(new LiteralExpression<float>(value)));
        public override InsertExpression Insert(float? value) => new InsertExpression(this, new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(value)));

        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new NullableSingleExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new NullableSingleExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<float?>(NullableSingleFieldExpression a) => new SelectExpression<float?>(new NullableSingleExpressionMediator(a));
        public static implicit operator NullableSingleExpressionMediator(NullableSingleFieldExpression a) => new NullableSingleExpressionMediator(a);
        public static implicit operator OrderByExpression(NullableSingleFieldExpression a) => new OrderByExpression(new NullableSingleExpressionMediator(a), OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(NullableSingleFieldExpression a) => new GroupByExpression(new NullableSingleExpressionMediator(a));
        #endregion

        #region arithmetic operators
        #region data type
        #region byte
        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, byte b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new ByteExpressionMediator(new LiteralExpression<byte>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(byte a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(byte a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(byte a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(byte a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(byte a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new ByteExpressionMediator(new LiteralExpression<byte>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, byte? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(a), new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(byte? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(byte? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(byte? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(byte? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(byte? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableByteExpressionMediator(new NullableLiteralExpression<byte?>(a)), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableSingleFieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableSingleFieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableSingleFieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableSingleFieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableSingleFieldExpression a, decimal b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new DecimalExpressionMediator(new LiteralExpression<decimal>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal a, NullableSingleFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal a, NullableSingleFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal a, NullableSingleFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal a, NullableSingleFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal a, NullableSingleFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new DecimalExpressionMediator(new LiteralExpression<decimal>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableSingleFieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableSingleFieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableSingleFieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableSingleFieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableSingleFieldExpression a, decimal? b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(a), new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(decimal? a, NullableSingleFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(decimal? a, NullableSingleFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(decimal? a, NullableSingleFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(decimal? a, NullableSingleFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(decimal? a, NullableSingleFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableDecimalExpressionMediator(new NullableLiteralExpression<decimal?>(a)), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableSingleFieldExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableSingleFieldExpression a, DateTime b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime a, NullableSingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime a, NullableSingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new DateTimeExpressionMediator(new LiteralExpression<DateTime>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableSingleFieldExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableSingleFieldExpression a, DateTime? b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(a), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(DateTime? a, NullableSingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(DateTime? a, NullableSingleFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(a)), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableSingleFieldExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableSingleFieldExpression a, DateTimeOffset b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset a, NullableSingleFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset a, NullableSingleFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableSingleFieldExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableSingleFieldExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(b)), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, NullableSingleFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, NullableSingleFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(a)), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static NullableDoubleExpressionMediator operator +(NullableSingleFieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableSingleFieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableSingleFieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableSingleFieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableSingleFieldExpression a, double b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new DoubleExpressionMediator(new LiteralExpression<double>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double a, NullableSingleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double a, NullableSingleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double a, NullableSingleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double a, NullableSingleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double a, NullableSingleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new DoubleExpressionMediator(new LiteralExpression<double>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableSingleFieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableSingleFieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableSingleFieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableSingleFieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableSingleFieldExpression a, double? b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(a), new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(double? a, NullableSingleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(double? a, NullableSingleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(double? a, NullableSingleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(double? a, NullableSingleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(double? a, NullableSingleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableDoubleExpressionMediator(new NullableLiteralExpression<double?>(a)), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region float
        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, float b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new SingleExpressionMediator(new LiteralExpression<float>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, float? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(float? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(float? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(float? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(float? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(float? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region short
        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, short b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new Int16ExpressionMediator(new LiteralExpression<short>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(short a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(short a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(short a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(short a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(short a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int16ExpressionMediator(new LiteralExpression<short>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, short? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(a), new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(short? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(short? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(short? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(short? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(short? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt16ExpressionMediator(new NullableLiteralExpression<short?>(a)), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region int
        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, int b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new Int32ExpressionMediator(new LiteralExpression<int>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(int a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(int a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(int a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(int a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(int a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int32ExpressionMediator(new LiteralExpression<int>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, int? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(a), new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(int? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(int? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(int? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(int? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(int? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt32ExpressionMediator(new NullableLiteralExpression<int?>(a)), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region long
        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, long b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new Int64ExpressionMediator(new LiteralExpression<long>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(long a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(long a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(long a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(long a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(long a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new Int64ExpressionMediator(new LiteralExpression<long>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(b)), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(b)), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(b)), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(b)), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, long? b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(a), new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(b)), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(long? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(long? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(long? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(long? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(long? a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableInt64ExpressionMediator(new NullableLiteralExpression<long?>(a)), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion
        
        #region TimeSpan



        #endregion
        
        #endregion

        #region fields

        #region byte
        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, ByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, ByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, ByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, ByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, ByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new ByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, NullableByteFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableByteExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        #region decimal
        public static NullableDecimalExpressionMediator operator +(NullableSingleFieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableSingleFieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableSingleFieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableSingleFieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableSingleFieldExpression a, DecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDecimalExpressionMediator operator +(NullableSingleFieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDecimalExpressionMediator operator -(NullableSingleFieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDecimalExpressionMediator operator *(NullableSingleFieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDecimalExpressionMediator operator /(NullableSingleFieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDecimalExpressionMediator operator %(NullableSingleFieldExpression a, NullableDecimalFieldExpression b) => new NullableDecimalExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDecimalExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        #region DateTime
        public static NullableDateTimeExpressionMediator operator +(NullableSingleFieldExpression a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableSingleFieldExpression a, DateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeExpressionMediator operator +(NullableSingleFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeExpressionMediator operator -(NullableSingleFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDateTimeExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        

        #region DateTimeOffset
        public static NullableDateTimeOffsetExpressionMediator operator +(NullableSingleFieldExpression a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableSingleFieldExpression a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(NullableSingleFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(NullableSingleFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDateTimeOffsetExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        #endregion

        

        #region double
        public static NullableDoubleExpressionMediator operator +(NullableSingleFieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableSingleFieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableSingleFieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableSingleFieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableSingleFieldExpression a, DoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new DoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableDoubleExpressionMediator operator +(NullableSingleFieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableDoubleExpressionMediator operator -(NullableSingleFieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableDoubleExpressionMediator operator *(NullableSingleFieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableDoubleExpressionMediator operator /(NullableSingleFieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableDoubleExpressionMediator operator %(NullableSingleFieldExpression a, NullableDoubleFieldExpression b) => new NullableDoubleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableDoubleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        #region float
        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, SingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, NullableSingleFieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        #region short
        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, Int16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, Int16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, Int16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, Int16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, Int16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, NullableInt16FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt16ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        #region int
        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, Int32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, Int32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, Int32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, Int32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, Int32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, NullableInt32FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt32ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        #region long
        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, Int64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new Int64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));

        public static NullableSingleExpressionMediator operator +(NullableSingleFieldExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Add));
        public static NullableSingleExpressionMediator operator -(NullableSingleFieldExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Subtract));
        public static NullableSingleExpressionMediator operator *(NullableSingleFieldExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Multiply));
        public static NullableSingleExpressionMediator operator /(NullableSingleFieldExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Divide));
        public static NullableSingleExpressionMediator operator %(NullableSingleFieldExpression a, NullableInt64FieldExpression b) => new NullableSingleExpressionMediator(new ArithmeticExpression(new NullableSingleExpressionMediator(a), new NullableInt64ExpressionMediator(b), ArithmeticExpressionOperator.Modulo));
        #endregion

        

        
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpression<bool?> operator ==(NullableSingleFieldExpression a, DBNull b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>()), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableSingleFieldExpression a, DBNull b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>()), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator ==(DBNull a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>()), new NullableSingleExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(DBNull a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>()), new NullableSingleExpressionMediator(b), FilterExpressionOperator.NotEqual);
        #endregion

        #region float
        public static FilterExpression<bool?> operator ==(NullableSingleFieldExpression a, float b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableSingleFieldExpression a, float b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableSingleFieldExpression a, float b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableSingleFieldExpression a, float b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableSingleFieldExpression a, float b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableSingleFieldExpression a, float b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new SingleExpressionMediator(new LiteralExpression<float>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(float a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new SingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(float a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new SingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(float a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new SingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(float a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new SingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(float a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new SingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(float a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new SingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new SingleExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableSingleFieldExpression a, float? b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableSingleFieldExpression a, float? b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableSingleFieldExpression a, float? b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableSingleFieldExpression a, float? b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableSingleFieldExpression a, float? b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableSingleFieldExpression a, float? b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(b)), FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(float? a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(float? a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(float? a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(float? a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(float? a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(float? a, NullableSingleFieldExpression b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(new NullableLiteralExpression<float?>(a)), new NullableSingleExpressionMediator(b), FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        
        #region mediator
        public static FilterExpression<bool?> operator ==(NullableSingleFieldExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableSingleFieldExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableSingleFieldExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableSingleFieldExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableSingleFieldExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableSingleFieldExpression a, SingleExpressionMediator b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);

        public static FilterExpression<bool?> operator ==(NullableSingleFieldExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), b, FilterExpressionOperator.Equal);
        public static FilterExpression<bool?> operator !=(NullableSingleFieldExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), b, FilterExpressionOperator.NotEqual);
        public static FilterExpression<bool?> operator <(NullableSingleFieldExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), b, FilterExpressionOperator.LessThan);
        public static FilterExpression<bool?> operator <=(NullableSingleFieldExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), b, FilterExpressionOperator.LessThanOrEqual);
        public static FilterExpression<bool?> operator >(NullableSingleFieldExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), b, FilterExpressionOperator.GreaterThan);
        public static FilterExpression<bool?> operator >=(NullableSingleFieldExpression a, NullableSingleExpressionMediator b) => new FilterExpression<bool?>(new NullableSingleExpressionMediator(a), b, FilterExpressionOperator.GreaterThanOrEqual);
        #endregion
        #endregion
    }
}
