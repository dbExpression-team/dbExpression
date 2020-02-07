using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Builder
{
    public class CastFunctionExpressionBuilder : ICastFunctionExpressionBuilder
    {
        #region internals
        public (Type, object) Expression { get; private set; }
        #endregion

        #region constructors
        public CastFunctionExpressionBuilder((Type, object) expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        CastFunctionExpression<bool> ICastFunctionExpressionBuilder.AsBit()
        {
            var exp = new CastFunctionExpression<bool>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.Bit
            };
            return exp;
        }

        CastFunctionExpression<byte> ICastFunctionExpressionBuilder.AsTinyInt()
        {
            var exp = new CastFunctionExpression<byte>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.TinyInt
            };
            return exp;
        }

        CastFunctionExpression<DateTime> ICastFunctionExpressionBuilder.AsDateTime()
        {
            var exp = new CastFunctionExpression<DateTime>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.DateTime
            };
            return exp;
        }

        CastFunctionExpression<DateTimeOffset> ICastFunctionExpressionBuilder.AsDateTimeOffset()
        {
            var exp = new CastFunctionExpression<DateTimeOffset>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.DateTimeOffset
            };
            return exp;
        }

        CastFunctionExpression<decimal> ICastFunctionExpressionBuilder.AsDecimal(int precision, int scale)
        {
            var exp = new CastFunctionExpression<decimal>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.Decimal,
                Precision = precision,
                Scale = scale
            };
            return exp;
        }

        CastFunctionExpression<float> ICastFunctionExpressionBuilder.AsFloat()
        {
            var exp = new CastFunctionExpression<float>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.Float
            };
            return exp;
        }

        CastFunctionExpression<Guid> ICastFunctionExpressionBuilder.AsUniqueIdentifier()
        {
            var exp = new CastFunctionExpression<Guid>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.UniqueIdentifier
            };
            return exp;
        }

        CastFunctionExpression<short> ICastFunctionExpressionBuilder.AsSmallInt()
        {
            var exp = new CastFunctionExpression<short>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.SmallInt
            };
            return exp;
        }

        CastFunctionExpression<int> ICastFunctionExpressionBuilder.AsInt()
        {
            var exp = new CastFunctionExpression<int>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.Int
            };
            return exp;
        }

        CastFunctionExpression<long> ICastFunctionExpressionBuilder.AsBigInt()
        {
            var exp = new CastFunctionExpression<long>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.BigInt
            };
            return exp;
        }

        CastFunctionExpression<string> ICastFunctionExpressionBuilder.AsVarChar(int size)
        {
            var exp = new CastFunctionExpression<string>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.VarChar,
                Size = size
            };
            return exp;
        }

        CastFunctionExpression<string> ICastFunctionExpressionBuilder.AsChar(int size)
        {
            var exp = new CastFunctionExpression<string>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.Char,
                Size = size
            };
            return exp;
        }

        CastFunctionExpression<string> ICastFunctionExpressionBuilder.AsNVarChar(int size)
        {
            var exp = new CastFunctionExpression<string>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.NVarChar,
                Size = size
            };
            return exp;
        }

        CastFunctionExpression<string> ICastFunctionExpressionBuilder.AsNChar(int size)
        {
            var exp = new CastFunctionExpression<string>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.NChar,
                Size = size
            };
            return exp;
        }
        #endregion
    }
}
