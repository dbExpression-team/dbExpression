using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Builder
{
    public class CastFunctionExpressionBuilder : ICastFunctionExpressionBuilder
    {
        #region internals
        public ExpressionMediator Expression { get; private set; }
        #endregion

        #region constructors
        public CastFunctionExpressionBuilder(ExpressionMediator expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        BooleanCastFunctionExpression ICastFunctionExpressionBuilder.AsBit()
            => new BooleanCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Boolean));

        ByteCastFunctionExpression ICastFunctionExpressionBuilder.AsTinyInt()
            => new ByteCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Byte));

        DateTimeCastFunctionExpression ICastFunctionExpressionBuilder.AsDateTime()
            => new DateTimeCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.DateTime));

        DateTimeOffsetCastFunctionExpression ICastFunctionExpressionBuilder.AsDateTimeOffset()
            => new DateTimeOffsetCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.DateTimeOffset));

        DecimalCastFunctionExpression ICastFunctionExpressionBuilder.AsDecimal(int precision, int scale)
            => new DecimalCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Decimal));

        SingleCastFunctionExpression ICastFunctionExpressionBuilder.AsFloat()
            => new SingleCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Single));

        GuidCastFunctionExpression ICastFunctionExpressionBuilder.AsUniqueIdentifier()
            => new GuidCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Guid));

        Int16CastFunctionExpression ICastFunctionExpressionBuilder.AsSmallInt()
            => new Int16CastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Int16));

        Int32CastFunctionExpression ICastFunctionExpressionBuilder.AsInt()
            => new Int32CastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Int32));

        Int64CastFunctionExpression ICastFunctionExpressionBuilder.AsBigInt()
            => new Int64CastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Int64));

        StringCastFunctionExpression ICastFunctionExpressionBuilder.AsVarChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.String))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression ICastFunctionExpressionBuilder.AsChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.String))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression ICastFunctionExpressionBuilder.AsNVarChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.AnsiString))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression ICastFunctionExpressionBuilder.AsNChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.AnsiString))
            {
                Size = size
            };
            return exp;
        }

        TimeSpanCastFunctionExpression ICastFunctionExpressionBuilder.AsTime()
            => new TimeSpanCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Time));
        #endregion
    }
}
