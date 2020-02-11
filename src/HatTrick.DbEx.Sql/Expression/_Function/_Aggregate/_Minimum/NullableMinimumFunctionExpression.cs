using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableMinimumFunctionExpression : MinimumFunctionExpression
    {
        #region constructors
        protected NullableMinimumFunctionExpression()
        {
        }

        protected NullableMinimumFunctionExpression((Type, object) expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
