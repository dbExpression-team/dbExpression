using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableMaximumFunctionExpression : MaximumFunctionExpression
    {
        #region constructors
        protected NullableMaximumFunctionExpression()
        {
        }

        protected NullableMaximumFunctionExpression((Type, object) expression, bool isDistinct) : base(expression, isDistinct)
        {
        }
        #endregion    
    }
}
