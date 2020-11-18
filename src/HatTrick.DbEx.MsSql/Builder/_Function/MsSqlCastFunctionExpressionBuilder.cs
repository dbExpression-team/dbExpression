using HatTrick.DbEx.MsSql.Builder.Syntax;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlCastFunctionExpressionBuilder : IMsSqlCastFunctionExpressionBuilder
    {
        #region internals
        public IExpressionElement Expression { get; private set; }
        #endregion

        #region constructors
        public MsSqlCastFunctionExpressionBuilder(IExpressionElement expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        BooleanCastFunctionExpression ICastFunctionExpressionBuilder.AsBit()
            => new BooleanCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Bit));

        ByteCastFunctionExpression ICastFunctionExpressionBuilder.AsTinyInt()
            => new ByteCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Bit));

        DateTimeCastFunctionExpression ICastFunctionExpressionBuilder.AsDateTime()
            => new DateTimeCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.DateTime));

        DateTimeOffsetCastFunctionExpression ICastFunctionExpressionBuilder.AsDateTimeOffset()
            => new DateTimeOffsetCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.DateTimeOffset));

        DecimalCastFunctionExpression ICastFunctionExpressionBuilder.AsDecimal(int precision, int scale)
            => new DecimalCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Decimal));

        DoubleCastFunctionExpression IMsSqlCastFunctionExpressionBuilder.AsMoney()
            => new DoubleCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Money));

        DoubleCastFunctionExpression IMsSqlCastFunctionExpressionBuilder.AsSmallMoney()
            => new DoubleCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.SmallMoney));

        SingleCastFunctionExpression ICastFunctionExpressionBuilder.AsFloat()
            => new SingleCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Float));

        GuidCastFunctionExpression ICastFunctionExpressionBuilder.AsUniqueIdentifier()
            => new GuidCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.UniqueIdentifier));

        Int16CastFunctionExpression ICastFunctionExpressionBuilder.AsSmallInt()
            => new Int16CastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.SmallInt));

        Int32CastFunctionExpression ICastFunctionExpressionBuilder.AsInt()
            => new Int32CastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Int));

        Int64CastFunctionExpression ICastFunctionExpressionBuilder.AsBigInt()
            => new Int64CastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.BigInt));

        StringCastFunctionExpression ICastFunctionExpressionBuilder.AsVarChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.VarChar))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression ICastFunctionExpressionBuilder.AsChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Char))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression ICastFunctionExpressionBuilder.AsNVarChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.NVarChar))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression ICastFunctionExpressionBuilder.AsNChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.NChar))
            {
                Size = size
            };
            return exp;
        }

        TimeSpanCastFunctionExpression ICastFunctionExpressionBuilder.AsTime()
            => new TimeSpanCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Time));

        #endregion
    }
}
