using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Builder
{
    public class MsSqlCastFunctionExpressionBuilder : ICastFunctionExpressionBuilder
    {
        #region internals
        public ExpressionMediator Expression { get; private set; }
        #endregion

        #region constructors
        public MsSqlCastFunctionExpressionBuilder(ExpressionMediator expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        BooleanCastFunctionExpression ICastFunctionExpressionBuilder.AsBit()
            => new BooleanCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.Bit));

        ByteCastFunctionExpression ICastFunctionExpressionBuilder.AsTinyInt()
            => new ByteCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.Bit));

        DateTimeCastFunctionExpression ICastFunctionExpressionBuilder.AsDateTime()
            => new DateTimeCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.DateTime));

        DateTimeOffsetCastFunctionExpression ICastFunctionExpressionBuilder.AsDateTimeOffset()
            => new DateTimeOffsetCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.DateTimeOffset));

        DecimalCastFunctionExpression ICastFunctionExpressionBuilder.AsDecimal(int precision, int scale)
            => new DecimalCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.Decimal));

        SingleCastFunctionExpression ICastFunctionExpressionBuilder.AsFloat()
            => new SingleCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.Float));

        GuidCastFunctionExpression ICastFunctionExpressionBuilder.AsUniqueIdentifier()
            => new GuidCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.UniqueIdentifier));

        Int16CastFunctionExpression ICastFunctionExpressionBuilder.AsSmallInt()
            => new Int16CastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.SmallInt));

        Int32CastFunctionExpression ICastFunctionExpressionBuilder.AsInt()
            => new Int32CastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.Int));

        Int64CastFunctionExpression ICastFunctionExpressionBuilder.AsBigInt()
            => new Int64CastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.BigInt));

        StringCastFunctionExpression ICastFunctionExpressionBuilder.AsVarChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.VarChar))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression ICastFunctionExpressionBuilder.AsChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.Char))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression ICastFunctionExpressionBuilder.AsNVarChar(int size)
        {
            var exp = new StringCastFunctionExpression(Expression, new ExpressionContainer(SqlDbType.NVarChar))
            {
                Size = size
            };
            return exp;
        }

        StringCastFunctionExpression ICastFunctionExpressionBuilder.AsNChar(int size)
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
