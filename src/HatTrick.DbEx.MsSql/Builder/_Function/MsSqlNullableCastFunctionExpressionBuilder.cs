using HatTrick.DbEx.MsSql.Builder.Syntax;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlNullableCastFunctionExpressionBuilder : IMsSqlNullableCastFunctionExpressionBuilder
    {
        #region internals
        public IExpressionElement Expression { get; private set; }
        #endregion

        #region constructors
        public MsSqlNullableCastFunctionExpressionBuilder(IExpressionElement expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        NullableBooleanCastFunctionExpression INullableCastFunctionExpressionBuilder.AsBit()
            => new NullableBooleanCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Bit));

        NullableByteCastFunctionExpression INullableCastFunctionExpressionBuilder.AsTinyInt()
            => new NullableByteCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Bit));

        NullableDateTimeCastFunctionExpression INullableCastFunctionExpressionBuilder.AsDateTime()
            => new NullableDateTimeCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.DateTime));

        NullableDateTimeOffsetCastFunctionExpression INullableCastFunctionExpressionBuilder.AsDateTimeOffset()
            => new NullableDateTimeOffsetCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.DateTimeOffset));

        NullableDecimalCastFunctionExpression INullableCastFunctionExpressionBuilder.AsDecimal(int precision, int scale)
            => new NullableDecimalCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Decimal));

        NullableDoubleCastFunctionExpression IMsSqlNullableCastFunctionExpressionBuilder.AsMoney()
            => new NullableDoubleCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Money));

        NullableDoubleCastFunctionExpression IMsSqlNullableCastFunctionExpressionBuilder.AsSmallMoney()
            => new NullableDoubleCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.SmallMoney));

        NullableSingleCastFunctionExpression INullableCastFunctionExpressionBuilder.AsFloat()
            => new NullableSingleCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Float));

        NullableGuidCastFunctionExpression INullableCastFunctionExpressionBuilder.AsUniqueIdentifier()
            => new NullableGuidCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.UniqueIdentifier));

        NullableInt16CastFunctionExpression INullableCastFunctionExpressionBuilder.AsSmallInt()
            => new NullableInt16CastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.SmallInt));

        NullableInt32CastFunctionExpression INullableCastFunctionExpressionBuilder.AsInt()
            => new NullableInt32CastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Int));

        NullableInt64CastFunctionExpression INullableCastFunctionExpressionBuilder.AsBigInt()
            => new NullableInt64CastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.BigInt));

        StringCastFunctionExpression INullableCastFunctionExpressionBuilder.AsVarChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.VarChar))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression INullableCastFunctionExpressionBuilder.AsChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Char))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression INullableCastFunctionExpressionBuilder.AsNVarChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.NVarChar))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression INullableCastFunctionExpressionBuilder.AsNChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.NChar))
            {
                Size = size
            };
            return exp;
        }

        NullableTimeSpanCastFunctionExpression INullableCastFunctionExpressionBuilder.AsTime()
            => new NullableTimeSpanCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Time));
        #endregion
    }
}
