using HatTrick.DbEx.Sql.Assembler;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class MaximumFunctionExpression<TValue> : MaximumFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected MaximumFunctionExpression(ExpressionMediator<TValue> expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}


