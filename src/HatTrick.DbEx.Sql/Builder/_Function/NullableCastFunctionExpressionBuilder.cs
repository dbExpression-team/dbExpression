using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Builder
{
    public class NullableCastFunctionExpressionBuilder : INullableCastFunctionExpressionBuilder
    {
        #region internals
        public (Type, object) Expression { get; private set; }
        #endregion

        #region constructors
        public NullableCastFunctionExpressionBuilder((Type, object) expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        NullableCastFunctionExpression<bool?> INullableCastFunctionExpressionBuilder.AsBit()
        {
            var exp = new NullableCastFunctionExpression<bool?>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.Bit
            };
            return exp;
        }

        NullableCastFunctionExpression<byte?> INullableCastFunctionExpressionBuilder.AsTinyInt()
        {
            var exp = new NullableCastFunctionExpression<byte?>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.TinyInt
            };
            return exp;
        }

        NullableCastFunctionExpression<DateTime?> INullableCastFunctionExpressionBuilder.AsDateTime()
        {
            var exp = new NullableCastFunctionExpression<DateTime?>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.DateTime
            };
            return exp;
        }

        NullableCastFunctionExpression<DateTimeOffset?> INullableCastFunctionExpressionBuilder.AsDateTimeOffset()
        {
            var exp = new NullableCastFunctionExpression<DateTimeOffset?>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.DateTimeOffset
            };
            return exp;
        }

        NullableCastFunctionExpression<decimal?> INullableCastFunctionExpressionBuilder.AsDecimal(int precision, int scale)
        {
            var exp = new NullableCastFunctionExpression<decimal?>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.Decimal,
                Precision = precision,
                Scale = scale
            };
            return exp;
        }

        NullableCastFunctionExpression<float?> INullableCastFunctionExpressionBuilder.AsFloat()
        {
            var exp = new NullableCastFunctionExpression<float?>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.Float
            };
            return exp;
        }

        NullableCastFunctionExpression<Guid?> INullableCastFunctionExpressionBuilder.AsUniqueIdentifier()
        {
            var exp = new NullableCastFunctionExpression<Guid?>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.UniqueIdentifier
            };
            return exp;
        }

        NullableCastFunctionExpression<short?> INullableCastFunctionExpressionBuilder.AsSmallInt()
        {
            var exp = new NullableCastFunctionExpression<short?>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.SmallInt
            };
            return exp;
        }

        NullableCastFunctionExpression<int?> INullableCastFunctionExpressionBuilder.AsInt()
        {
            var exp = new NullableCastFunctionExpression<int?>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.Int
            };
            return exp;
        }

        NullableCastFunctionExpression<long?> INullableCastFunctionExpressionBuilder.AsBigInt()
        {
            var exp = new NullableCastFunctionExpression<long?>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.BigInt
            };
            return exp;
        }

        NullableCastFunctionExpression<string> INullableCastFunctionExpressionBuilder.AsVarChar(int size)
        {
            var exp = new NullableCastFunctionExpression<string>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.VarChar,
                Size = size
            };
            return exp;
        }

        NullableCastFunctionExpression<string> INullableCastFunctionExpressionBuilder.AsChar(int size)
        {
            var exp = new NullableCastFunctionExpression<string>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.Char,
                Size = size
            };
            return exp;
        }

        NullableCastFunctionExpression<string> INullableCastFunctionExpressionBuilder.AsNVarChar(int size)
        {
            var exp = new NullableCastFunctionExpression<string>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.NVarChar,
                Size = size
            };
            return exp;
        }

        NullableCastFunctionExpression<string> INullableCastFunctionExpressionBuilder.AsNChar(int size)
        {
            var exp = new NullableCastFunctionExpression<string>(Expression)
            {
                ConvertToSqlDbType = SqlDbType.NChar,
                Size = size
            };
            return exp;
        }
        #endregion
    }
}
