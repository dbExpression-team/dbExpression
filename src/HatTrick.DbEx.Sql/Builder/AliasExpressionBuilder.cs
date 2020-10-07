using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class AliasExpressionBuilder : IAliasExpressionContinuationBuilder
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
        BooleanExpressionMediator IAliasExpressionContinuationBuilder.ToBool() => new BooleanExpressionMediator(expression);

        ByteExpressionMediator IAliasExpressionContinuationBuilder.ToByte() => new ByteExpressionMediator(expression);

        DateTimeExpressionMediator IAliasExpressionContinuationBuilder.ToDateTime() => new DateTimeExpressionMediator(expression);

        DateTimeOffsetExpressionMediator IAliasExpressionContinuationBuilder.ToDateTimeOffset() => new DateTimeOffsetExpressionMediator(expression);

        DecimalExpressionMediator IAliasExpressionContinuationBuilder.ToDecimal() => new DecimalExpressionMediator(expression);

        DoubleExpressionMediator IAliasExpressionContinuationBuilder.ToDouble() => new DoubleExpressionMediator(expression);

        SingleExpressionMediator IAliasExpressionContinuationBuilder.ToFloat() => new SingleExpressionMediator(expression);

        GuidExpressionMediator IAliasExpressionContinuationBuilder.ToGuid() => new GuidExpressionMediator(expression);

        Int32ExpressionMediator IAliasExpressionContinuationBuilder.ToInt() => new Int32ExpressionMediator(expression);

        Int64ExpressionMediator IAliasExpressionContinuationBuilder.ToLong() => new Int64ExpressionMediator(expression);

        NullableBooleanExpressionMediator IAliasExpressionContinuationBuilder.ToNullableBool() => new NullableBooleanExpressionMediator(expression);

        NullableByteExpressionMediator IAliasExpressionContinuationBuilder.ToNullableByte() => new NullableByteExpressionMediator(expression);

        NullableDateTimeExpressionMediator IAliasExpressionContinuationBuilder.ToNullableDateTime() => new NullableDateTimeExpressionMediator(expression);

        NullableDateTimeOffsetExpressionMediator IAliasExpressionContinuationBuilder.ToNullableDateTimeOffset() => new NullableDateTimeOffsetExpressionMediator(expression);

        NullableDecimalExpressionMediator IAliasExpressionContinuationBuilder.ToNullableDecimal() => new NullableDecimalExpressionMediator(expression);

        NullableDoubleExpressionMediator IAliasExpressionContinuationBuilder.ToNullableDouble() => new NullableDoubleExpressionMediator(expression);

        NullableSingleExpressionMediator IAliasExpressionContinuationBuilder.ToNullableFloat() => new NullableSingleExpressionMediator(expression);

        NullableGuidExpressionMediator IAliasExpressionContinuationBuilder.ToNullableGuid() => new NullableGuidExpressionMediator(expression);

        NullableInt32ExpressionMediator IAliasExpressionContinuationBuilder.ToNullableInt() => new NullableInt32ExpressionMediator(expression);

        NullableInt64ExpressionMediator IAliasExpressionContinuationBuilder.ToNullableLong() => new NullableInt64ExpressionMediator(expression);

        NullableInt16ExpressionMediator IAliasExpressionContinuationBuilder.ToNullableShort() => new NullableInt16ExpressionMediator(expression);

        Int16ExpressionMediator IAliasExpressionContinuationBuilder.ToShort() => new Int16ExpressionMediator(expression);

        StringExpressionMediator IAliasExpressionContinuationBuilder.ToString() => new StringExpressionMediator(expression);

        EnumExpressionMediator<TEnum> IAliasExpressionContinuationBuilder.ToEnum<TEnum>() => new EnumExpressionMediator<TEnum>(expression);

        NullableEnumExpressionMediator<TEnum> IAliasExpressionContinuationBuilder.ToNullableEnum<TEnum>() => new NullableEnumExpressionMediator<TEnum>(expression);
        #endregion
    }
}
