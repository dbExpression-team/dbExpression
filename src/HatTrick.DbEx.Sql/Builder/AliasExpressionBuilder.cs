using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class AliasExpressionBuilder : Alias
    {
        #region internals
        private readonly AliasExpression expression;
        #endregion

        #region constructors
        public AliasExpressionBuilder(AliasExpression expression)
        {
            this.expression = expression ?? throw new ArgumentNullException($"{nameof(expression)} is required.");
        }
        #endregion

        #region methods
        BooleanExpressionMediator Alias.AsBoolean() => new BooleanExpressionMediator(expression);

        ByteExpressionMediator Alias.AsByte() => new ByteExpressionMediator(expression);

        DateTimeExpressionMediator Alias.AsDateTime() => new DateTimeExpressionMediator(expression);

        DateTimeOffsetExpressionMediator Alias.AsDateTimeOffset() => new DateTimeOffsetExpressionMediator(expression);

        DecimalExpressionMediator Alias.AsDecimal() => new DecimalExpressionMediator(expression);

        DoubleExpressionMediator Alias.AsDouble() => new DoubleExpressionMediator(expression);

        SingleExpressionMediator Alias.AsSingle() => new SingleExpressionMediator(expression);

        GuidExpressionMediator Alias.AsGuid() => new GuidExpressionMediator(expression);

        Int32ExpressionMediator Alias.AsInt32() => new Int32ExpressionMediator(expression);

        Int64ExpressionMediator Alias.AsInt64() => new Int64ExpressionMediator(expression);

        NullableBooleanExpressionMediator Alias.AsNullableBoolean() => new NullableBooleanExpressionMediator(expression);

        NullableByteExpressionMediator Alias.AsNullableByte() => new NullableByteExpressionMediator(expression);

        NullableDateTimeExpressionMediator Alias.AsNullableDateTime() => new NullableDateTimeExpressionMediator(expression);

        NullableDateTimeOffsetExpressionMediator Alias.AsNullableDateTimeOffset() => new NullableDateTimeOffsetExpressionMediator(expression);

        NullableDecimalExpressionMediator Alias.AsNullableDecimal() => new NullableDecimalExpressionMediator(expression);

        NullableDoubleExpressionMediator Alias.AsNullableDouble() => new NullableDoubleExpressionMediator(expression);

        NullableSingleExpressionMediator Alias.AsNullableSingle() => new NullableSingleExpressionMediator(expression);

        NullableGuidExpressionMediator Alias.AsNullableGuid() => new NullableGuidExpressionMediator(expression);

        NullableInt32ExpressionMediator Alias.AsNullableInt32() => new NullableInt32ExpressionMediator(expression);

        NullableInt64ExpressionMediator Alias.AsNullableInt64() => new NullableInt64ExpressionMediator(expression);

        NullableInt16ExpressionMediator Alias.AsNullable16() => new NullableInt16ExpressionMediator(expression);

        Int16ExpressionMediator Alias.AsInt16() => new Int16ExpressionMediator(expression);

        StringExpressionMediator Alias.AsString() => new StringExpressionMediator(expression);

        EnumExpressionMediator<TEnum> Alias.AsEnum<TEnum>() => new EnumExpressionMediator<TEnum>(expression);

        NullableEnumExpressionMediator<TEnum> Alias.AsNullableEnum<TEnum>() => new NullableEnumExpressionMediator<TEnum>(expression);
        #endregion
    }
}
