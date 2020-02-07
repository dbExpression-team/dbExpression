using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableAverageFunctionExpression : AverageFunctionExpression
    {
        #region constructors
        protected NullableAverageFunctionExpression()
        {
        }

        protected NullableAverageFunctionExpression((Type, object) expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
