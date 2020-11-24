using HatTrick.DbEx.Sql.Expression;
using System.Data;

namespace HatTrick.DbEx.Sql.Builder
{
    public class CastFunctionExpressionBuilder : Cast
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
        BooleanCastFunctionExpression Cast.AsBit()
            => new BooleanCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Boolean));

        ByteCastFunctionExpression Cast.AsTinyInt()
            => new ByteCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Byte));

        DateTimeCastFunctionExpression Cast.AsDateTime()
            => new DateTimeCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.DateTime));

        DateTimeOffsetCastFunctionExpression Cast.AsDateTimeOffset()
            => new DateTimeOffsetCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.DateTimeOffset));

        DecimalCastFunctionExpression Cast.AsDecimal(int precision, int scale)
            => new DecimalCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Decimal), precision, scale);

        SingleCastFunctionExpression Cast.AsFloat()
            => new SingleCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Single));

        GuidCastFunctionExpression Cast.AsUniqueIdentifier()
            => new GuidCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Guid));

        Int16CastFunctionExpression Cast.AsSmallInt()
            => new Int16CastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Int16));

        Int32CastFunctionExpression Cast.AsInt()
            => new Int32CastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Int32));

        Int64CastFunctionExpression Cast.AsBigInt()
            => new Int64CastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Int64));

        StringCastFunctionExpression Cast.AsVarChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.String), size);

        StringCastFunctionExpression Cast.AsChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.String), size);

        StringCastFunctionExpression Cast.AsNVarChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.AnsiString), size);

        StringCastFunctionExpression Cast.AsNChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.AnsiString), size);

        TimeSpanCastFunctionExpression Cast.AsTime()
            => new TimeSpanCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Time));
        #endregion
    }
}
