using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Builder
{
    public class MsSqlNullableCastFunctionExpressionBuilder : INullableCastFunctionExpressionBuilder
    {
        #region internals
        public ExpressionMediator Expression { get; private set; }
        #endregion

        #region constructors
        public MsSqlNullableCastFunctionExpressionBuilder(ExpressionMediator expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        NullableBooleanCastFunctionExpression INullableCastFunctionExpressionBuilder.AsBit()
            => new NullableBooleanCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.Bit));

        NullableByteCastFunctionExpression INullableCastFunctionExpressionBuilder.AsTinyInt()
            => new NullableByteCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.Bit));

        NullableDateTimeCastFunctionExpression INullableCastFunctionExpressionBuilder.AsDateTime()
            => new NullableDateTimeCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.DateTime));

        NullableDateTimeOffsetCastFunctionExpression INullableCastFunctionExpressionBuilder.AsDateTimeOffset()
            => new NullableDateTimeOffsetCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.DateTimeOffset));

        NullableDecimalCastFunctionExpression INullableCastFunctionExpressionBuilder.AsDecimal(int precision, int scale)
            => new NullableDecimalCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.Decimal));

        NullableSingleCastFunctionExpression INullableCastFunctionExpressionBuilder.AsFloat()
            => new NullableSingleCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.Float));

        NullableGuidCastFunctionExpression INullableCastFunctionExpressionBuilder.AsUniqueIdentifier()
            => new NullableGuidCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.UniqueIdentifier));

        NullableInt16CastFunctionExpression INullableCastFunctionExpressionBuilder.AsSmallInt()
            => new NullableInt16CastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.SmallInt));

        NullableInt32CastFunctionExpression INullableCastFunctionExpressionBuilder.AsInt()
            => new NullableInt32CastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.Int));

        NullableInt64CastFunctionExpression INullableCastFunctionExpressionBuilder.AsBigInt()
            => new NullableInt64CastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.BigInt));

        StringCastFunctionExpression INullableCastFunctionExpressionBuilder.AsVarChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.VarChar))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression INullableCastFunctionExpressionBuilder.AsChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.Char))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression INullableCastFunctionExpressionBuilder.AsNVarChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.NVarChar))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression INullableCastFunctionExpressionBuilder.AsNChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.NChar))
            {
                Size = size
            };
            return exp;
        }
        #endregion
    }
}
