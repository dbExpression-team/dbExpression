using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public class LiteralExpression<TValue> : LiteralExpression,
        ISupportedForFunctionExpression<CastFunctionExpression, TValue>,
        ISupportedForFunctionExpression<CoalesceFunctionExpression, TValue>,
        ISupportedForFunctionExpression<ConcatFunctionExpression, TValue>,
        ISupportedForFunctionExpression<IsNullFunctionExpression, TValue>,
        ISupportedForExpression<SelectExpression>
        where TValue : IComparable
    {
        public LiteralExpression(TValue value) : base(value)
        {

        }
    }
}
