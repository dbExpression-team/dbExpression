using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface Alias
#pragma warning restore IDE1006 // Naming Styles
    {
        BooleanExpressionMediator AsBoolean();
        NullableBooleanExpressionMediator AsNullableBoolean();
        ByteExpressionMediator AsByte();
        NullableByteExpressionMediator AsNullableByte();
        DateTimeExpressionMediator AsDateTime();
        NullableDateTimeExpressionMediator AsNullableDateTime();
        DateTimeOffsetExpressionMediator AsDateTimeOffset();
        NullableDateTimeOffsetExpressionMediator AsNullableDateTimeOffset();
        DecimalExpressionMediator AsDecimal();
        NullableDecimalExpressionMediator AsNullableDecimal();
        DoubleExpressionMediator AsDouble();
        NullableDoubleExpressionMediator AsNullableDouble();
        EnumExpressionMediator<TEnum> AsEnum<TEnum>()
            where TEnum : struct, Enum, IComparable;
        NullableEnumExpressionMediator<TEnum> AsNullableEnum<TEnum>()
            where TEnum : struct, Enum, IComparable;
        GuidExpressionMediator AsGuid();
        NullableGuidExpressionMediator AsNullableGuid();
        Int16ExpressionMediator AsInt16();
        NullableInt16ExpressionMediator AsNullable16();
        Int32ExpressionMediator AsInt32();
        NullableInt32ExpressionMediator AsNullableInt32();
        Int64ExpressionMediator AsInt64();
        NullableInt64ExpressionMediator AsNullableInt64();
        SingleExpressionMediator AsSingle();
        NullableSingleExpressionMediator AsNullableSingle();
        StringExpressionMediator AsString();
    }
}
