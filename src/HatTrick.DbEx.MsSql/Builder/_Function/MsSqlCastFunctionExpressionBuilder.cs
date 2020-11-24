using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using System.Data;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlCastFunctionExpressionBuilder : MsSqlCast
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
        BooleanCastFunctionExpression Cast.AsBit()
            => new BooleanCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Bit));

        ByteCastFunctionExpression Cast.AsTinyInt()
            => new ByteCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Bit));

        DateTimeCastFunctionExpression Cast.AsDateTime()
            => new DateTimeCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.DateTime));

        DateTimeOffsetCastFunctionExpression Cast.AsDateTimeOffset()
            => new DateTimeOffsetCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.DateTimeOffset));

        DecimalCastFunctionExpression Cast.AsDecimal(int precision, int scale)
            => new DecimalCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Decimal), precision, scale);

        DoubleCastFunctionExpression MsSqlCast.AsMoney()
            => new DoubleCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Money));

        DoubleCastFunctionExpression MsSqlCast.AsSmallMoney()
            => new DoubleCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.SmallMoney));

        SingleCastFunctionExpression Cast.AsFloat()
            => new SingleCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Float));

        GuidCastFunctionExpression Cast.AsUniqueIdentifier()
            => new GuidCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.UniqueIdentifier));

        Int16CastFunctionExpression Cast.AsSmallInt()
            => new Int16CastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.SmallInt));

        Int32CastFunctionExpression Cast.AsInt()
            => new Int32CastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Int));

        Int64CastFunctionExpression Cast.AsBigInt()
            => new Int64CastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.BigInt));

        StringCastFunctionExpression Cast.AsVarChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.VarChar), size);

        StringCastFunctionExpression Cast.AsChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Char), size);

        StringCastFunctionExpression Cast.AsNVarChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.NVarChar), size);

        StringCastFunctionExpression Cast.AsNChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.NChar), size);

        TimeSpanCastFunctionExpression Cast.AsTime()
            => new TimeSpanCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Time));

        #endregion
    }
}
