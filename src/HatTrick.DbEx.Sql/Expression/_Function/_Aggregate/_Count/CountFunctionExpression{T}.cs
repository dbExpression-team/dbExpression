using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class CountFunctionExpression<TValue> : CountFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected CountFunctionExpression() : this(false)
        {
        }

        protected CountFunctionExpression(bool isDistinct) : base(new ExpressionContainer(new LiteralExpression<string>("*")), isDistinct)
        {
        }

        protected CountFunctionExpression(ExpressionContainer expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion
    }
}
