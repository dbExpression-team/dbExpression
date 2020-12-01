using System;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class DateTimeOffsetFieldExpression
    {
        #region in value set
        public override FilterExpressionSet In(params DateTimeOffset[] value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<DateTimeOffset>(value), FilterExpressionOperator.None)) : null;
        public override FilterExpressionSet In(IEnumerable<DateTimeOffset> value) => value is object ? new FilterExpressionSet(new FilterExpression<bool>(this, new InExpression<DateTimeOffset>(value), FilterExpressionOperator.None)) : null;
        #endregion

        #region set
        public override AssignmentExpression Set(DateTimeOffset value) => new AssignmentExpression(this, new LiteralExpression<DateTimeOffset>(value));
        public virtual AssignmentExpression Set(DateTimeOffsetElement value) => new AssignmentExpression(this, value);
        #endregion

        #region order
        public override OrderByExpression Asc => new OrderByExpression(new DateTimeOffsetExpressionMediator(this), OrderExpressionDirection.ASC);
        public override OrderByExpression Desc => new OrderByExpression(new DateTimeOffsetExpressionMediator(this), OrderExpressionDirection.DESC);
        #endregion

        #region implicit operators
        public static implicit operator SelectExpression<DateTimeOffset>(DateTimeOffsetFieldExpression a) => new SelectExpression<DateTimeOffset>(a);
        public static implicit operator DateTimeOffsetExpressionMediator(DateTimeOffsetFieldExpression a) => new DateTimeOffsetExpressionMediator(a);
        public static implicit operator OrderByExpression(DateTimeOffsetFieldExpression a) => new OrderByExpression(a, OrderExpressionDirection.ASC);
        public static implicit operator GroupByExpression(DateTimeOffsetFieldExpression a) => new GroupByExpression(a);
        #endregion

        #region arithmetic operators
        #region data types
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, byte b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, byte b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(byte a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(byte a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, byte? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<byte?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(byte? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(byte? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<byte?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, decimal b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, decimal b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(decimal a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(decimal a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, decimal? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<decimal?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(decimal? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(decimal? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<decimal?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTime
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTime b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTime b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTime a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTime a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTime? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTime? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTime?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTime? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTime? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTime?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTimeOffset>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<DateTimeOffset?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<DateTimeOffset?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, double b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, double b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(double a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(double a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<double>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, double? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<double?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(double? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(double? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<double?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, float b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, float b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(float a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(float a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<float>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, float? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<float?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(float? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(float? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<float?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, short b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, short b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(short a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(short a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<short>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, short? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<short?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(short? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(short? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<short?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, int b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, int b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(int a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(int a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<int>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, int? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<int?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(int? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(int? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<int?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, long b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, long b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long>(b), ArithmeticExpressionOperator.Subtract));

        public static DateTimeOffsetExpressionMediator operator +(long a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(long a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<long>(a), b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, long? b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, new LiteralExpression<long?>(b), ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(long? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(long? a, DateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(new LiteralExpression<long?>(a), b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region string


        #endregion
        
        #region TimeSpan



        #endregion
        
        #endregion

        #region fields
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, ByteFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, ByteFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableByteFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableByteFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DecimalFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DecimalFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableDecimalFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableDecimalFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTime
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTimeFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTimeFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableDateTimeFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DoubleFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DoubleFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableDoubleFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableDoubleFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, SingleFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, SingleFieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableSingleFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableSingleFieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, Int16FieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, Int16FieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableInt16FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableInt16FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, Int32FieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, Int32FieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableInt32FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableInt32FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, Int64FieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, Int64FieldExpression b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableInt64FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableInt64FieldExpression b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region string

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion

        #region mediators
        #region byte
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, ByteExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, ByteExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableByteExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region decimal
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DecimalExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DecimalExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableDecimalExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTime
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTimeExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTimeExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableDateTimeExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region DateTimeOffset
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region double
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, DoubleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableDoubleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region float
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, SingleExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableSingleExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region short
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, Int16ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, Int16ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableInt16ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region int
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, Int32ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, Int32ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableInt32ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region long
        public static DateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static DateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, Int64ExpressionMediator b) => new DateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));

        public static NullableDateTimeOffsetExpressionMediator operator +(DateTimeOffsetFieldExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static NullableDateTimeOffsetExpressionMediator operator -(DateTimeOffsetFieldExpression a, NullableInt64ExpressionMediator b) => new NullableDateTimeOffsetExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        
        #region string

        #endregion
        
        #region TimeSpan

        #endregion
        
        #endregion

        #region alias
        public static ObjectExpressionMediator operator +(DateTimeOffsetFieldExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Add));
        public static ObjectExpressionMediator operator -(DateTimeOffsetFieldExpression a, AliasExpression b) => new ObjectExpressionMediator(new ArithmeticExpression(a, b, ArithmeticExpressionOperator.Subtract));
        #endregion
        #endregion

        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(DateTimeOffsetFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetFieldExpression a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region data types
        #region DateTimeOffset
        public static FilterExpressionSet operator ==(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetFieldExpression a, DateTimeOffset b) => new FilterExpressionSet(new FilterExpression<bool>(a, new LiteralExpression<DateTimeOffset>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffset a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(new LiteralExpression<DateTimeOffset>(a), b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetFieldExpression a, DateTimeOffset? b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<DateTimeOffset?>(b), FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffset? a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<DateTimeOffset?>(a), b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion

        #region fields
        public static FilterExpressionSet operator ==(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetFieldExpression a, DateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetFieldExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        
        #region mediators
        public static FilterExpressionSet operator ==(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetFieldExpression a, DateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool>(a, b, FilterExpressionOperator.GreaterThanOrEqual));

        public static FilterExpressionSet operator ==(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetFieldExpression a, NullableDateTimeOffsetExpressionMediator b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion

        #region alias
        public static FilterExpressionSet operator ==(DateTimeOffsetFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DateTimeOffsetFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator <(DateTimeOffsetFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThan));
        public static FilterExpressionSet operator >(DateTimeOffsetFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThan));
        public static FilterExpressionSet operator <=(DateTimeOffsetFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.LessThanOrEqual));
        public static FilterExpressionSet operator >=(DateTimeOffsetFieldExpression a, AliasExpression b) => new FilterExpressionSet(new FilterExpression<bool?>(a, b, FilterExpressionOperator.GreaterThanOrEqual));
        #endregion
        #endregion
    }
}
