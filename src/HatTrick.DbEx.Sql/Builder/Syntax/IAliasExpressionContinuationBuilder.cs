using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IAliasExpressionContinuationBuilder
    {
        //Change "As" to "To"
        BooleanExpressionMediator ToBool();
        NullableBooleanExpressionMediator ToNullableBool();
        ByteExpressionMediator ToByte();
        NullableByteExpressionMediator ToNullableByte();
        DateTimeExpressionMediator ToDateTime();
        NullableDateTimeExpressionMediator ToNullableDateTime();
        DateTimeOffsetExpressionMediator ToDateTimeOffset();
        NullableDateTimeOffsetExpressionMediator ToNullableDateTimeOffset();
        DecimalExpressionMediator ToDecimal();
        NullableDecimalExpressionMediator ToNullableDecimal();
        DoubleExpressionMediator ToDouble();
        NullableDoubleExpressionMediator ToNullableDouble();
        EnumExpressionMediator<TEnum> ToEnum<TEnum>()
            where TEnum : struct, Enum, IComparable;
        NullableEnumExpressionMediator<TEnum> ToNullableEnum<TEnum>()
            where TEnum : struct, Enum, IComparable;
        GuidExpressionMediator ToGuid();
        NullableGuidExpressionMediator ToNullableGuid();
        Int16ExpressionMediator ToShort();
        NullableInt16ExpressionMediator ToNullableShort();
        Int32ExpressionMediator ToInt();
        NullableInt32ExpressionMediator ToNullableInt();
        Int64ExpressionMediator ToLong();
        NullableInt64ExpressionMediator ToNullableLong();
        SingleExpressionMediator ToFloat();
        NullableSingleExpressionMediator ToNullableFloat();
        StringExpressionMediator ToString();
    }
}
