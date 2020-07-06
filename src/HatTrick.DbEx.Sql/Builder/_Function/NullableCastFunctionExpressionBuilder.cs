using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Builder
{
    public class NullableCastFunctionExpressionBuilder : INullableCastFunctionExpressionBuilder
    {
        #region internals
        public ExpressionMediator Expression { get; private set; }
        #endregion

        #region constructors
        public NullableCastFunctionExpressionBuilder(ExpressionMediator expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        NullableBooleanCastFunctionExpression INullableCastFunctionExpressionBuilder.AsBit()
           => new NullableBooleanCastFunctionExpression(Expression, new ExpressionContainer(DbType.Boolean));

        NullableByteCastFunctionExpression INullableCastFunctionExpressionBuilder.AsTinyInt()
            => new NullableByteCastFunctionExpression(Expression, new ExpressionContainer(DbType.Byte));

        NullableDateTimeCastFunctionExpression INullableCastFunctionExpressionBuilder.AsDateTime()
            => new NullableDateTimeCastFunctionExpression(Expression, new ExpressionContainer(DbType.DateTime));

        NullableDateTimeOffsetCastFunctionExpression INullableCastFunctionExpressionBuilder.AsDateTimeOffset()
            => new NullableDateTimeOffsetCastFunctionExpression(Expression, new ExpressionContainer(DbType.DateTimeOffset));

        NullableDecimalCastFunctionExpression INullableCastFunctionExpressionBuilder.AsDecimal(int precision, int scale)
            => new NullableDecimalCastFunctionExpression(Expression, new ExpressionContainer(DbType.Decimal));

        NullableSingleCastFunctionExpression INullableCastFunctionExpressionBuilder.AsFloat()
            => new NullableSingleCastFunctionExpression(Expression, new ExpressionContainer(DbType.Single));

        NullableGuidCastFunctionExpression INullableCastFunctionExpressionBuilder.AsUniqueIdentifier()
            => new NullableGuidCastFunctionExpression(Expression, new ExpressionContainer(DbType.Guid));

        NullableInt16CastFunctionExpression INullableCastFunctionExpressionBuilder.AsSmallInt()
            => new NullableInt16CastFunctionExpression(Expression, new ExpressionContainer(DbType.Int16));

        NullableInt32CastFunctionExpression INullableCastFunctionExpressionBuilder.AsInt()
            => new NullableInt32CastFunctionExpression(Expression, new ExpressionContainer(DbType.Int32));

        NullableInt64CastFunctionExpression INullableCastFunctionExpressionBuilder.AsBigInt()
            => new NullableInt64CastFunctionExpression(Expression, new ExpressionContainer(DbType.Int64));

        StringCastFunctionExpression INullableCastFunctionExpressionBuilder.AsVarChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new ExpressionContainer(DbType.String))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression INullableCastFunctionExpressionBuilder.AsChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new ExpressionContainer(DbType.String))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression INullableCastFunctionExpressionBuilder.AsNVarChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new ExpressionContainer(DbType.AnsiString))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression INullableCastFunctionExpressionBuilder.AsNChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new ExpressionContainer(DbType.AnsiString))
            {
                Size = size
            };
            return exp;
        }
        #endregion
    }
}
